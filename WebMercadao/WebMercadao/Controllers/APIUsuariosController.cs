using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebMercadao.Controllers
{
    public class APIUsuariosController : ApiController
    {
        // GET: api/APIUsuarios
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/APIUsuarios/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/APIUsuarios
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/APIUsuarios/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/APIUsuarios/5
        public void Delete(int id)
        {
        }
    }
}
