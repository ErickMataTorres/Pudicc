using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pudicc.Controllers
{
    public class TipoController : Controller
    {
        // GET: Tipo
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ListaTipos()
        {
            var a = Models.Tipo.ListaTipos();
            return Json(a, JsonRequestBehavior.AllowGet);
        }

    }
}