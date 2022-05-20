using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaMVCMerino_A.Models;

namespace SistemaMVCMerino_A.Controllers
{
    public class USUARIOController : Controller
    {
        private USUARIO objUsuario = new USUARIO();
        private EMPLEADO objEmpleado = new EMPLEADO();

        // GET: CATEGORIA
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objUsuario.Listar());
            }
            else
            {
                return View(objUsuario.Buscar(criterio));
            }
        }

        public ActionResult Visualizar(int id)
        {
            return View(objUsuario.Obtener(id));
        }

        public ActionResult Buscar(string criterio)
        {
            return View(
                criterio == null || criterio == ""
                ? objUsuario.Listar()
                : objUsuario.Buscar(criterio)
                );

        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Empleado = objEmpleado.Listar();

            return View(
                    id == 0
                    ? new USUARIO() //Crea un nuevo objeto
                    : objUsuario.Obtener(id)
                );
        }


        public ActionResult Guardar(USUARIO objUsuario)
        {
            if (ModelState.IsValid)
            {

                objUsuario.Guardar();
                return Redirect("~/USUARIO/");

            }
            else
            {
                return View("~/Views/USUARIO/AgregarEditar.cshtml", objUsuario);
            }

        }

        public ActionResult Eliminar(int id)
        {
            objUsuario.IDUSUARIO = id;
            objUsuario.Eliminar();
            return Redirect("~/USUARIO/");
        }
    }
}