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
    public class MercadoController : Controller
    {
        private AppContext db = new AppContext();

        // GET: Mercado
        public ActionResult Index()
        {
            return RedirectToAction("Mercados", "Admin");
        }

        // GET: Mercado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mercado mercado = db.Mercados.Find(id);
            if (mercado == null)
            {
                return HttpNotFound();
            }
            return View(mercado);
        }

        // GET: Mercado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mercado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Create([Bind(Include = "Id,Name,Location")] Mercado mercado)
        {
            if (ModelState.IsValid)
            {
                db.Mercados.Add(mercado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mercado);
        }

        // GET: Mercado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mercado mercado = db.Mercados.Find(id);
            if (mercado == null)
            {
                return HttpNotFound();
            }
            return View(mercado);
        }

        // POST: Mercado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Edit([Bind(Include = "Id,Name,Location")] Mercado mercado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mercado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mercado);
        }

        // GET: Mercado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mercado mercado = db.Mercados.Find(id);
            if (mercado == null)
            {
                return HttpNotFound();
            }

            db.Mercados.Remove(mercado);
            db.SaveChanges();
            return RedirectToAction("Mercados", "Admin", new { area = "" });
        }

        // POST: Mercado/Delete/5
        [HttpPost, ActionName("Delete")]
        
        public ActionResult DeleteConfirmed(int id)
        {
            Mercado mercado = db.Mercados.Find(id);
            db.Mercados.Remove(mercado);
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
