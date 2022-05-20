using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaMVCMerino_A.Models;

namespace SistemaMVCMerino_A.Controllers
{
    public class CATEGORIAController : Controller
    {
        private CATEGORIA objCategoria = new CATEGORIA();

        // GET: CATEGORIA
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objCategoria.Listar());
            }
            else
            {
                return View(objCategoria.Buscar(criterio));
            }
        }

        public ActionResult Visualizar(int id)
        {
            return View(objCategoria.Obtener(id));
        }

        public ActionResult Buscar(string criterio)
        {
            return View(
                criterio == null || criterio == ""
                ? objCategoria.Listar()
                : objCategoria.Buscar(criterio)
                );

        }

        public ActionResult AgregarEditar(int id = 0)
        {
            return View(
                    id == 0
                    ? new CATEGORIA() //Crea una nuevo objeto
                    : objCategoria.Obtener(id)
                );
        }


        public ActionResult Guardar(CATEGORIA objCategoria)
        {
            if (ModelState.IsValid)
            {

                objCategoria.Guardar();
                return Redirect("~/CATEGORIA/");

            }
            else
            {
                return View("~/Views/CATEGORIA/AgregarEditar.cshtml", objCategoria);
            }

        }

        public ActionResult Eliminar(int id)
        {
            objCategoria.IDCATEGORIA = id;
            objCategoria.Eliminar();
            return Redirect("~/CATEGORIA/");
        }
    }
}