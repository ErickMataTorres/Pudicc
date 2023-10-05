using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pudicc.Controllers
{
    public class PublicacionController : Controller
    {
        // GET: Publicacion
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult CardsPublicacion(int idTipo)
        {
            var a = Models.Publicacion.CardsPublicacion(idTipo);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string Guardar(Models.Publicacion c)
        {
            string respuesta = string.Empty;
            List<string> listaImagenes = new List<string>();
            foreach (var imagen in c.Files)
            {

                string nombreImagen = Path.GetFileNameWithoutExtension(imagen.FileName);
                string extensionImagen = Path.GetExtension(imagen.FileName);
                string nombreImagenExtension = Path.GetFileName(imagen.FileName);

                string path = Path.Combine(Server.MapPath("~/Imagenes/"), nombreImagenExtension);

                string imagenUrl = "/Imagenes/" + nombreImagenExtension;

                listaImagenes.Add(imagenUrl);
                
                if (!System.IO.File.Exists(path))
                {
                    imagen.SaveAs(path);
                }
            }
            var oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string sJSON = oSerializer.Serialize(listaImagenes);
            c.Imagen = sJSON;
            respuesta = c.Guardar();
            return respuesta;
        }
    }
}