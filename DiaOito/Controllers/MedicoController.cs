using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace DiaOito.Controllers
{
    public class MedicoController : Controller
    {
        private MeuMedicoEntities db = new MeuMedicoEntities();
        // GET: Medico
        public ActionResult Index(string cidade, string especialidade)
        {

            List<Medicos> medico;

            if (especialidade != null)
            {               
                int especialidade_id = int.Parse(especialidade);

                medico = db.MedicoPorEspecialidade
                    .Join(db.Medicos, a => a.MedicoId, b => b.Id, (a, b) => b)
                    .Include(x => x.Cidades)
                    .Distinct()
                    .ToList();

            }
            else if (cidade != null)
            {
                int cidade_id = int.Parse(cidade);

                medico = db.Medicos
                       .Where(t => t.Cidades.Id == cidade_id)
                       //(PayrollNo  == null || x.payrollNo ==PayrollNo)
                       .Include(med => med.Cidades)                       
                       .Join(db.MedicoPorEspecialidade, a => a.Id, b => b.MedicoId, (a, b) => a)
                       .Distinct()
                       .ToList();

            }
            else
            {
                 medico = db.Medicos
                       .Include(med => med.Cidades)
                       .Join(db.MedicoPorEspecialidade, a => a.Id, b => b.MedicoId, (a, b) => a)
                       .Distinct()
                       .ToList();
            }            

            ViewBag.Cidades = db.Cidades.ToList();            
            return View(medico); 
        }

        public ActionResult Create()
        {
            ViewBag.CidadeFK = new SelectList(db.Cidades, "Id", "Cidade");            
            ViewBag.Especialidade = new SelectList(db.Especialidades, "Id", "Especialidade");
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(Medicos medico, string Especialidade)
        {
            if(ModelState.IsValid)
            {                              
                db.Medicos.Add(medico);
                db.SaveChanges();
                int medico_id = medico.Id;

                MedicoPorEspecialidade medicoPorEspecialidade = new MedicoPorEspecialidade();
                medicoPorEspecialidade.EspecialidadeId = int.Parse(Especialidade);
                medicoPorEspecialidade.MedicoId = medico_id;
                db.MedicoPorEspecialidade.Add(medicoPorEspecialidade);
                db.SaveChanges();

                return RedirectToAction("Index");
            } 
            return View(medico);
        }

        public ActionResult Editar(long? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Medicos medico = db.Medicos.Find(id);
            if(medico == null)
            {
                return HttpNotFound();
            }

            ViewBag.CidadeFK = new SelectList(db.Cidades, "Id", "Cidade", medico.Id);

            return View(medico);
        }

        [HttpPost]
        public ActionResult Editar(Medicos medico)
        {
            if(ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.CidadeFK = new SelectList(db.Cidades, "Id", "Cidade");
            return View(medico);
        }

        
        public ActionResult Excluir(long? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicos medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            ViewBag.CidadeFK = new SelectList(db.Cidades, "Id", "Cidade", medico.Id);
            return View(medico);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(string Id)
        {
            try
            {
                int id = int.Parse(Id);
                Medicos medico = db.Medicos.Find(id);
                db.Medicos.Remove(medico);
                db.SaveChanges();

                return RedirectToAction("index");
            }catch
            {
                return HttpNotFound();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}