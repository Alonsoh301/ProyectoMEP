using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoMEP.Entidades;
using ProyectoMEP.Models;
using ProyectoMEP.Services;

namespace ProyectoMEP.Controllers
{
    [ResponseCache(NoStore = true, Duration = 0)]
    public class HomeController(IEstudianteModel _usuarioModel, IUtilitariosModel _utilitariosModel) : Controller
    {
        [HttpGet]
        public IActionResult IniciarSesion()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        public IActionResult IniciarSesion(Estudiante entidad)
        {
            entidad.Contrasenna = _utilitariosModel.Encrypt(entidad.Contrasenna!);
            var resp = _usuarioModel.IniciarSesion(entidad);

            if (resp?.Codigo == "00")
            {
                HttpContext.Session.SetString("Correo", resp?.Dato?.Correo!);
                HttpContext.Session.SetString("Nombre", resp?.Dato?.NombreEstudiante!);
                HttpContext.Session.SetString("Categoria", resp?.Dato?.NombreCategoria!);
                HttpContext.Session.SetString("Token", resp?.Dato?.Token!);

                if ((bool)(resp?.Dato?.EsTemporal!))
                    return RedirectToAction("CambiarContrasenna", "Home");
                else
                {
                    HttpContext.Session.SetString("Login", "true");
                    return RedirectToAction("PantallaInicio", "Home");
                }
            }
            else
            {
                ViewBag.MsjPantalla = resp?.Mensaje;
                return View();
            }
        }


        [HttpGet]
        public IActionResult RegistrarEstudiante()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarEstudiante(Estudiante entidad)
        {
            entidad.Contrasenna = _utilitariosModel.Encrypt(entidad.Contrasenna!);
            var resp = _usuarioModel.RegistrarEstudiante(entidad);

            if (resp?.Codigo == "00")
                return RedirectToAction("IniciarSesion", "Home");
            else
            {
                ViewBag.MsjPantalla = resp?.Mensaje;
                return View();
            }
        }


        [HttpGet]
        public IActionResult RecuperarAcceso()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        public IActionResult RecuperarAcceso(Estudiante entidad)
        {
            var resp = _usuarioModel.RecuperarAcceso(entidad);

            if (resp?.Codigo == "00")
                return RedirectToAction("IniciarSesion", "Home");
            else
            {
                ViewBag.MsjPantalla = resp?.Mensaje;
                return View();
            }
        }


        [HttpGet]
        public IActionResult CambiarContrasenna()
        {
            var usuario = new Estudiante();
            usuario.Correo = HttpContext.Session.GetString("Correo");

            return View(usuario);
        }

        [HttpPost]
        public IActionResult CambiarContrasenna(Estudiante entidad)
        {
            if (entidad.Contrasenna?.Trim() == entidad.ContrasennaTemporal?.Trim())
            {
                ViewBag.MsjPantalla = "Debe utilizar una contraseña distinta";
                return View();
            }

            entidad.Contrasenna = _utilitariosModel.Encrypt(entidad.Contrasenna!);
            entidad.ContrasennaTemporal = _utilitariosModel.Encrypt(entidad.ContrasennaTemporal!);

            var resp = _usuarioModel.CambiarContrasenna(entidad);

            if (resp?.Codigo == "00")
            {
                HttpContext.Session.SetString("Login", "true");
                return RedirectToAction("PantallaInicio", "Home");
            }
            else
            {
                ViewBag.MsjPantalla = resp?.Mensaje;
                return View();
            }
        }


        [Seguridad]
        [HttpGet]
        public IActionResult Salir()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("IniciarSesion", "Home");
        }


        [Seguridad]
        [HttpGet]
        public IActionResult PantallaInicio()
        {
            return View();
        }

    }
}
