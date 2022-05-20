using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaMVCMerino_A.Models;

namespace SistemaMVCMerino_A.Controllers
{
    public class LoginController : Controller
    {
        private USUARIO objUsuario = new USUARIO();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Acceder(string Usuario, string Password)
        {
            var rm = objUsuario.Acceder(Usuario, Password);

            if (rm.response)
            {
                rm.href = Url.Content("~/Home");
            }
            return Json(rm);
        }

        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/");
        }

    }
}