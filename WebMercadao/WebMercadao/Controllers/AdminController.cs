using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMercadao.Models;

namespace WebMercadao.Controllers
{
    public class AdminController : Controller
    {
        private AppContext db = new AppContext();

        public ActionResult Index()
        {
            ViewBag.ErroLogin = "";
            return View();
        }

        public ActionResult Atendentes()
        {
            MainViewModel mvm = new MainViewModel();
            mvm.Atendentes = db.Atendentes.ToList();
            return View("Atendentes", mvm);
        }

        public ActionResult Clientes()
        {
            MainViewModel mvm = new MainViewModel();
            mvm.Usuarios = db.Usuarios.ToList();
            return View("Clientes", mvm);
        }

        public ActionResult Mercados()
        {
            MainViewModel mvm = new MainViewModel();
            mvm.Mercados = db.Mercados.ToList();
            return View("Mercados", mvm);
        }

        public ActionResult Produtos()
        {
            MainViewModel mvm = new MainViewModel();
            mvm.Produtos = db.Produtos.ToList();
            return View("Produtos", mvm);
        }

        public ActionResult Noticias()
        {
            MainViewModel mvm = new MainViewModel();
            mvm.Noticias = db.Noticias.ToList();
            return View("Noticias", mvm);
        }

        public ActionResult Contatos()
        {
            MainViewModel mvm = new MainViewModel();
            mvm.Contatos = db.Contatos.ToList();
            return View("Contatos", mvm);
        }
        [HttpPost]
        public ActionResult Entrar(MainViewModel mvm)
        {
            using (var ctx = new AppContext())
            {
               

                if (mvm.Usuario.Email != null && mvm.Usuario.Senha != null && mvm.Usuario.Email != "" && mvm.Usuario.Senha != "")
                {
                    Usuario usuarioAutenticado = null;

                    try
                    {
                        usuarioAutenticado = ctx.Usuarios.Where(usuario =>
                            usuario.Email == mvm.Usuario.Email &&
                            usuario.Senha == mvm.Usuario.Senha).First();

                        return RedirectToAction("Clientes", "Admin");
                    }
                    catch (Exception e)
                    {
                        ViewBag.ErroLogin = "Usuário ou senha inválidos.";
                        return View("Index");
                    }
                }

                ViewBag.ErroLogin = "Preencha os campos obrigatórios.";
                return View("Index");

            }
        }

    }
}
