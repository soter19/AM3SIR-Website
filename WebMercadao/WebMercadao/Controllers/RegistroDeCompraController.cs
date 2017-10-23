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
    public class RegistroDeCompraController : Controller
    {
        private AppContext db = new AppContext();

        // GET: RegistroDeCompra
        public ActionResult Index()
        {
            return RedirectToAction("RegistrosDeCompras", "Admin");
        }

        // GET: RegistroDeCompra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroDeCompra registroDeCompra = db.RegistrosDeCompras.Find(id);
            if (registroDeCompra == null)
            {
                return HttpNotFound();
            }
            return View(registroDeCompra);
        }

        // GET: RegistroDeCompra/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistroDeCompra/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(int investimentoId, MainViewModel mvm)
        {
            using (var ctx = new AppContext())
            {
                if (mvm.Usuario.Email != null && mvm.Usuario.Senha != null && mvm.Usuario.Email != "" && mvm.Usuario.Senha != "")
                {
                    Usuario usuarioAutenticado = null;
                    Investimento investimentoEscolhido = null;

                    try
                    {
                        usuarioAutenticado = ctx.Usuarios.Where(usuario =>
                            usuario.Email == mvm.Usuario.Email &&
                            usuario.Senha == mvm.Usuario.Senha).First();

                        investimentoEscolhido = ctx.Investimentos.Where(investimento =>
                        investimento.Id == investimentoId).First();

                        RegistroDeCompra novoRegistro = new RegistroDeCompra()
                        {
                            Investimento = investimentoEscolhido,
                            Usuario = usuarioAutenticado
                        };

                        investimentoEscolhido.Quantidade--;

                        ctx.Entry(investimentoEscolhido).State = EntityState.Modified;

                        ctx.RegistrosDeCompras.Add(novoRegistro);
                        ctx.SaveChanges();
                        
                        TempData["errorInvestimento"] = "";
                        return RedirectToAction("Index", "Home");
                    }
                    catch (Exception e)
                    {
                        TempData["errorInvestimento"] = "Nao foi possivel concluir o seu investimento";
                        return RedirectToAction("Index", "Home");
                    }
                }

                return RedirectToAction("Index", "Home");
            }
        }

        // GET: RegistroDeCompra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroDeCompra registroDeCompra = db.RegistrosDeCompras.Find(id);
            if (registroDeCompra == null)
            {
                return HttpNotFound();
            }
            return View(registroDeCompra);
        }

        // POST: RegistroDeCompra/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id")] RegistroDeCompra registroDeCompra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registroDeCompra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registroDeCompra);
        }

        // GET: RegistroDeCompra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroDeCompra registroDeCompra = db.RegistrosDeCompras.Find(id);
            if (registroDeCompra == null)
            {
                return HttpNotFound();
            }
            db.RegistrosDeCompras.Remove(registroDeCompra);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: RegistroDeCompra/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistroDeCompra registroDeCompra = db.RegistrosDeCompras.Find(id);
            db.RegistrosDeCompras.Remove(registroDeCompra);
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
