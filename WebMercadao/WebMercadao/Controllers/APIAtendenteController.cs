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
    public class APIAtendenteController : ApiController
    {
        private AppContext db = new AppContext();

        // GET: api/APIAtendente
        public IQueryable<Atendente> GetAtendentes()
        {
            return db.Atendentes;
        }

        // GET: api/APIAtendente/5
        [ResponseType(typeof(Atendente))]
        public IHttpActionResult GetAtendente(int id)
        {
            Atendente atendente = db.Atendentes.Find(id);
            if (atendente == null)
            {
                return NotFound();
            }

            return Ok(atendente);
        }

        // PUT: api/APIAtendente/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAtendente(int id, Atendente atendente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != atendente.Id)
            {
                return BadRequest();
            }

            db.Entry(atendente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtendenteExists(id))
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

        // POST: api/APIAtendente
        [ResponseType(typeof(Atendente))]
        public IHttpActionResult PostAtendente(Atendente atendente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Atendentes.Add(atendente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = atendente.Id }, atendente);
        }

        // DELETE: api/APIAtendente/5
        [ResponseType(typeof(Atendente))]
        public IHttpActionResult DeleteAtendente(int id)
        {
            Atendente atendente = db.Atendentes.Find(id);
            if (atendente == null)
            {
                return NotFound();
            }

            db.Atendentes.Remove(atendente);
            db.SaveChanges();

            return Ok(atendente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AtendenteExists(int id)
        {
            return db.Atendentes.Count(e => e.Id == id) > 0;
        }
    }
}