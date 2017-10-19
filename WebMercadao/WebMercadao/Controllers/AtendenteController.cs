using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebMercadao.Models;

namespace WebMercadao.Controllers
{
    public class AtendenteController : Controller
    {
        private AppContext db = new AppContext();

        // GET: Atendente
        public ActionResult Index()
        {
            return RedirectToAction("Atendentes", "Admin");
        }

        // GET: Atendente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atendente atendente = db.Atendentes.Find(id);
            if (atendente == null)
            {
                return HttpNotFound();
            }
            return View(atendente);
        }

        // GET: Atendente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Atendente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Nome,Email,Senha")] Atendente atendente)
        {
            if (ModelState.IsValid)
            {
                db.Atendentes.Add(atendente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(atendente);
        }

        // GET: Atendente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atendente atendente = db.Atendentes.Find(id);
            if (atendente == null)
            {
                return HttpNotFound();
            }
            return View(atendente);
        }

        // POST: Atendente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Edit([Bind(Include = "Id,Nome,Email,Senha")] Atendente atendente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atendente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(atendente);
        }

        // GET: Atendente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atendente atendente = db.Atendentes.Find(id);
            if (atendente == null)
            {
                return HttpNotFound();
            }
            return View(atendente);
        }

        // POST: Atendente/Delete/5
        [HttpPost, ActionName("Delete")]
        
        public ActionResult DeleteConfirmed(int id)
        {
            Atendente atendente = db.Atendentes.Find(id);
            db.Atendentes.Remove(atendente);
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
