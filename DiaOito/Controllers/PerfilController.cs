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
    [Authorize]
    public class PerfilController : Controller
    {
        MeuMedicoEntities db = new MeuMedicoEntities();

        // GET: Perfil
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AlterarSenha()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AlterarSenha(AlterarSenhaViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var identity = User.Identity as ClaimsIdentity;
            var login = identity.Claims.FirstOrDefault(c => c.Type == "Login").Value;
            var usuario = db.Usuarios.FirstOrDefault(u => u.Usuario == login);

            if (HashSha.GeraHash(viewModel.SenhaAtual) != usuario.Senha)
            {
                ModelState.AddModelError("SenhaAtual", "Senha atual incorreta");
                return View(viewModel);
            }

            usuario.Senha = HashSha.GeraHash(viewModel.NovaSenha);
            db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("index", "home");
        }
    }
}