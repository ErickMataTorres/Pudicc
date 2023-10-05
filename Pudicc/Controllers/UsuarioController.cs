using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pudicc.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IniciarSesion()
        {
            return View();
        }
        public ActionResult Perfil()
        {
            return View();
        }
        public ActionResult Proyectos()
        {
            return View();
        }
        public JsonResult Login(string usuario, string contrasena)
        {
            Models.Usuario u = new Models.Usuario();
            var r = u.Login(usuario, contrasena);
            return Json(r,JsonRequestBehavior.AllowGet);
        }
    }
}