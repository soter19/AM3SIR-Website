using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebMercadao.Controllers
{
    public class APIMercadosController : ApiController
    {
        // GET: api/APIMercados
        public IEnumerable<string> Get()
        {
            return new string[] { "Extra", "Carrefour" };
        }

        // GET: api/APIMercados/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/APIMercados
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/APIMercados/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/APIMercados/5
        public void Delete(int id)
        {
        }
    }
}
