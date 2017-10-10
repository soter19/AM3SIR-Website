using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMercadao.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }

        public ActionResult Noticias(){
            return View();
        }
    }
}
