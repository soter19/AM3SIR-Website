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
    public class InvestimentoController : Controller
    {
        private AppContext db = new AppContext();

        // GET: Investimento
        public ActionResult Index()
        {
			return RedirectToAction("Investimentos", "Admin");
		}

        // GET: Investimento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Investimento investimento = db.Investimentos.Find(id);
            if (investimento == null)
            {
                return HttpNotFound();
            }
            return View(investimento);
        }

        // GET: Investimento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Investimento/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name,Descricao,Valor,Quantidade")] Investimento investimento)
        {
            if (ModelState.IsValid)
            {
                db.Investimentos.Add(investimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(investimento);
        }

        // GET: Investimento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Investimento investimento = db.Investimentos.Find(id);
            if (investimento == null)
            {
                return HttpNotFound();
            }
            return View(investimento);
        }

        // POST: Investimento/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name,Descricao,Valor,Quantidade")] Investimento investimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(investimento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(investimento);
        }

        // GET: Investimento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Investimento investimento = db.Investimentos.Find(id);
            if (investimento == null)
            {
                return HttpNotFound();
            }
			db.Investimentos.Remove(investimento);
			db.SaveChanges();
			return RedirectToAction("Investimentos", "Admin", new { area = "" });
		}

        // POST: Investimento/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Investimento investimento = db.Investimentos.Find(id);
            db.Investimentos.Remove(investimento);
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
