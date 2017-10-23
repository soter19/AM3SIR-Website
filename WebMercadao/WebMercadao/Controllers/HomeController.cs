using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using WebMercadao.Models;

namespace WebMercadao.Controllers
{
    public class HomeController : Controller
    {
        private AppContext db = new AppContext();

        public ActionResult Index()
        {
            MainViewModel mvm = new MainViewModel();
            mvm.Noticias = db.Noticias.ToList();
			mvm.Investimentos = db.Investimentos.ToList();
            return View("Index", mvm);
        }
    }
}
