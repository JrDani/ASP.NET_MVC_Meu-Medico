using DiaOito.Models;
using DiaOito.Utils;
using DiaOito.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace DiaOito.Controllers
{
    public class AutenticacaoController : Controller
    {
        private MeuMedicoEntities db = new MeuMedicoEntities();

        // GET: Autenticacao
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string ReturnUrl)
        {
            var viewModel = new LoginViewModel
            {
                UrlRetorno = ReturnUrl
            };

            return View(viewModel);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var usuario = db.Usuarios.FirstOrDefault(u => u.Usuario == viewModel.Usuario);
            if (usuario == null || usuario.Senha != HashSha.GeraHash(viewModel.Senha))
            {
                ModelState.AddModelError("Usuario", "Usuario ou senha incorretos");
                return View(viewModel);
            }

            var identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim("Login", usuario.Usuario)
            }, "ApplicationCookie");

            Request.GetOwinContext().Authentication.SignIn(identity);

            if (!string.IsNullOrWhiteSpace(viewModel.UrlRetorno) || Url.IsLocalUrl(viewModel.UrlRetorno))
                return Redirect(viewModel.UrlRetorno);
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Cadastrar(CadastroUsuarioViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            if (db.Usuarios.Count(u => u.Usuario == viewModel.Usuario) > 0)
            {
                ModelState.AddModelError("Login", "Esse nome de usuario já esta em uso");
                return View(viewModel);
            }

            try
            {
                Usuarios usuario = new Usuarios
                {
                    Nome = viewModel.Nome,
                    Email = viewModel.Email,
                    Usuario = viewModel.Usuario,
                    Senha = HashSha.GeraHash(viewModel.Senha)
                };

                db.Usuarios.Add(usuario);
                db.SaveChanges();
                TempData["Mensagem"] = "Cadastro de usuário efetuado com sucesso";

                return RedirectToAction("Index", "Home");
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }

            return null;
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
            return RedirectToAction("login");
        }

    }
}