using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiaOito;

namespace DiaOito.Controllers
{
    [Authorize]
    public class CidadesController : Controller
    {
        private MeuMedicoEntities db = new MeuMedicoEntities();

        // GET: Cidades
        public ActionResult Index()
        {
            var cidades = db.Cidades;
            return View(cidades.ToList());
        }

        // GET: Cidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidades cidades = db.Cidades.Find(id);
            if (cidades == null)
            {
                return HttpNotFound();
            }
            return View(cidades);
        }

        // GET: Cidades/Create
        public ActionResult Create()
        {
            ViewBag.EstadosId = new SelectList(db.Estados, "Id", "Estado");
            return View();
        }

        // POST: Cidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cidade,EstadosId")] Cidades cidades)
        {
            if (ModelState.IsValid)
            {
                db.Cidades.Add(cidades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstadosId = new SelectList(db.Estados, "Id", "Estado", cidades.EstadosId);
            return View(cidades);
        }

        // GET: Cidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidades cidades = db.Cidades.Find(id);
            if (cidades == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadosId = new SelectList(db.Estados, "Id", "Estado", cidades.EstadosId);
            return View(cidades);
        }

        // POST: Cidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cidade,EstadosId")] Cidades cidades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cidades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstadosId = new SelectList(db.Estados, "Id", "Estado", cidades.EstadosId);
            return View(cidades);
        }

        // GET: Cidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidades cidades = db.Cidades.Find(id);
            if (cidades == null)
            {
                return HttpNotFound();
            }
            return View(cidades);
        }

        // POST: Cidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cidades cidades = db.Cidades.Find(id);
            db.Cidades.Remove(cidades);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
