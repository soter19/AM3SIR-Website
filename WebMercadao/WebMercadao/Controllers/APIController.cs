using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMercadao.Controllers
{
    public class APIController : Controller
    {
        
        public Object Index()
        {
            return "Error: no request done";
        }

        public Object getAllClients()
        {
            return new JSON();    
        }
    }
}
