using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoApi_Sabado.Entities;
using ProyectoApi_Sabado.Services;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using Dapper;



namespace ProyectoApi_Sabado.Controllers
{
    [Route("api/error")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorController(IConfiguration _configuration, IUtilitariosModel _utilitariosModel, IHttpContextAccessor _accesor) : ControllerBase
    {
        [Route("error")]
        public IActionResult RegistrarError()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                Respuesta respuesta = new Respuesta();

                long IdUsuario = (User.Identity!.Name != null ? long.Parse(_utilitariosModel.Decrypt(User.Identity!.Name!)) : 0);
                string Mensaje = context!.Error.Message;
                string Origen = context!.Path;
                string DireccionIP = _accesor.HttpContext?.Connection.RemoteIpAddress?.ToString()!;

                var resultado = db.Execute("RegistrarError",
                    new { IdUsuario, Mensaje, Origen, DireccionIP },
                    commandType: CommandType.StoredProcedure);

                return Problem(
                    detail: context!.Error.StackTrace,
                    title: context!.Error.Message
                );
            }
        }
    }
}