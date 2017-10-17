using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using WebMercadao.Models;

namespace WebMercadao.Controllers
{
    public class APIProdutosController : ApiController
    {
        // GET: api/APIProdutos
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/APIProdutos/5
        public string Get(string id)
        {
            Produto p = new Produto();

            switch (id)
            {
                case "1":
                    AppContext ac = new AppContext();
                    ac.Produtos.Add(new Produto());
                    ac.SaveChanges();
                    return "fodase";
                    //return JsonConvert.SerializeObject(new Produto(id), Newtonsoft.Json.Formatting.Indented);
                default:
                    return "oi";
            }
        }

        // POST: api/APIProduto
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/APIProduto/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/APIProduto/5
        public void Delete(int id)
        {
        }
    }
}
