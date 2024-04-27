using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoApi_Sabado.Entities;
using ProyectoApi_Sabado.Services;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoApi_Sabado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController(IConfiguration _configuration, IUtilitariosModel _utilitariosModel,
                                   IHostEnvironment _hostEnvironment) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        [Route("IniciarSesion")]
        public IActionResult IniciarSesion(Usuario entidad)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var resultado = db.Query<Usuario>("IniciarSesion",
                    new { entidad.correo, entidad.contrasena },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                if (resultado != null) {
                    return Ok(resultado);
                }

                return NotFound(resultado);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("RegistrarUsuario")]
        public IActionResult RegistrarUsuario(Usuario entidad)
        {
            //using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            //{
            //    Respuesta respuesta = new Respuesta();

            //    var resultado = db.Execute("RegistrarUsuario",
            //        new { entidad.Correo, entidad.Contrasenna, entidad.NombreEstudiante },
            //        commandType: CommandType.StoredProcedure);

            //    if (resultado <= 0)
            //    {
            //        respuesta.Codigo = "-1";
            //        respuesta.Mensaje = "Su correo ya se encuentra registrado";
            //    }

            //    return Ok(respuesta);

            //}
            return null;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("RecuperarAcceso")]
        public IActionResult RecuperarAcceso(Usuario entidad)
        {
            //using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            //{
            //    EstudianteRespuesta respuesta = new EstudianteRespuesta();

            //    string NuevaContrasenna = _utilitariosModel.GenerarNuevaContrasenna();
            //    string Contrasenna = _utilitariosModel.Encrypt(NuevaContrasenna);
            //    bool EsTemporal = true;

            //    var resultado = db.Query<Estudiante>("RecuperarAcceso",
            //        new { entidad.Correo, Contrasenna, EsTemporal },
            //        commandType: CommandType.StoredProcedure).FirstOrDefault();

            //    if (resultado == null)
            //    {
            //        respuesta.Codigo = "-1";
            //        respuesta.Mensaje = "Sus datos no son correctos";
            //    }
            //    else
            //    {
            //        string ruta = Path.Combine(_hostEnvironment.ContentRootPath, "Password.html");
            //        string htmlBody = System.IO.File.ReadAllText(ruta);
            //        htmlBody = htmlBody.Replace("@Usuario@", resultado.NombreEstudiante);
            //        htmlBody = htmlBody.Replace("@Contrasenna@", NuevaContrasenna);

            //        _utilitariosModel.EnviarCorreo(resultado.Correo!, "Nueva Contraseña!!", htmlBody);
            //        respuesta.Dato = resultado;
            //    }

            //    return Ok(respuesta);
            //}
            return null;
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("CambiarContrasenna")]
        public IActionResult CambiarContrasenna(Usuario entidad)
        {
            //using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            //{
            //    EstudianteRespuesta respuesta = new EstudianteRespuesta();
            //    bool EsTemporal = false;

            //    var resultado = db.Query<Estudiante>("CambiarContrasenna",
            //        new { entidad.Correo, entidad.Contrasenna, entidad.ContrasennaTemporal, EsTemporal },
            //        commandType: CommandType.StoredProcedure).FirstOrDefault();

            //    if (resultado == null)
            //    {
            //        respuesta.Codigo = "-1";
            //        respuesta.Mensaje = "Sus datos no son correctos";
            //    }
            //    else
            //    {
            //        respuesta.Dato = resultado;
            //    }

            //    return Ok(respuesta);
            //}
            return null;
        }

        [HttpGet]
        [Route("ConsultarEstudiante")]
        public IActionResult ConsultarEstudiante()
        {
            //using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            //{
            //    MateriaRespuesta respuesta = new MateriaRespuesta();

            //    long IdEstudiante = long.Parse(_utilitariosModel.Decrypt(User.Identity!.Name!));

            //    var resultado = db.Query<Curso>("ConsultarEstudiante",
            //        new { IdEstudiante },
            //        commandType: CommandType.StoredProcedure).FirstOrDefault();

            //    if (resultado == null)
            //    {
            //        respuesta.Codigo = "-1";
            //        respuesta.Mensaje = "No se encontró su información";
            //    }
            //    else
            //    {
            //        respuesta.Dato = resultado;
            //    }

            //    return Ok(respuesta);
            //}
            return null;
        }
    }
}
