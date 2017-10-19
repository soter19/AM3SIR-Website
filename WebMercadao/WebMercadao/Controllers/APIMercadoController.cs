using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebMercadao.Models;

namespace WebMercadao.Controllers
{
    public class APIMercadoController : ApiController
    {
        private AppContext db = new AppContext();

        // GET: api/Mercadoes
        public IQueryable<Mercado> GetMercados()
        {
            return db.Mercados;
        }

        // GET: api/Mercadoes/5
        [ResponseType(typeof(Mercado))]
        public IHttpActionResult GetMercado(int id)
        {
            Mercado mercado = db.Mercados.Find(id);
            if (mercado == null)
            {
                return NotFound();
            }

            return Ok(mercado);
        }

        // PUT: api/Mercadoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMercado(int id, Mercado mercado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mercado.Id)
            {
                return BadRequest();
            }

            db.Entry(mercado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MercadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Mercadoes
        [ResponseType(typeof(Mercado))]
        public IHttpActionResult PostMercado(Mercado mercado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Mercados.Add(mercado);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mercado.Id }, mercado);
        }

        // DELETE: api/Mercadoes/5
        [ResponseType(typeof(Mercado))]
        public IHttpActionResult DeleteMercado(int id)
        {
            Mercado mercado = db.Mercados.Find(id);
            if (mercado == null)
            {
                return NotFound();
            }

            db.Mercados.Remove(mercado);
            db.SaveChanges();

            return Ok(mercado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MercadoExists(int id)
        {
            return db.Mercados.Count(e => e.Id == id) > 0;
        }
    }
}