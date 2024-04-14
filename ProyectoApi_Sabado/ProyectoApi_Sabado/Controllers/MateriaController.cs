using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoApi_Sabado.Entities;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoApi_Sabado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController(IConfiguration _configuration) : ControllerBase
    {
        [Authorize]
        [HttpGet]
        [Route("ConsultarMaterias")]
        public IActionResult ConsultarMaterias(bool MostrarTodos)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                ServicioRespuesta respuesta = new ServicioRespuesta();

                var resultado = db.Query<Materia>("ConsultarMaterias",
                    new { MostrarTodos },
                    commandType: CommandType.StoredProcedure).ToList();

                if (resultado == null)
                {
                    respuesta.Codigo = "-1";
                    respuesta.Mensaje = "No hay materias registrados";
                }
                else
                {
                    respuesta.Datos = resultado;
                }

                return Ok(respuesta);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("ConsultarMateria")]
        public IActionResult ConsultarMateria(long IdServicio)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                ServicioRespuesta respuesta = new ServicioRespuesta();

                var resultado = db.Query<Materia>("ConsultarMateria",
                    new { IdServicio },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                if (resultado == null)
                {
                    respuesta.Codigo = "-1";
                    respuesta.Mensaje = "No hay materias registradas";
                }
                else
                {
                    respuesta.Dato = resultado;
                }

                return Ok(respuesta);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("RegistrarMateria")]
        public IActionResult RegistrarServicio(Materia entidad)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                Respuesta respuesta = new Respuesta();

                var resultado = db.Query<Materia>("RegistrarMateria",
                    new { entidad.Nombre, entidad.Precio, entidad.Imagen, entidad.Video },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                if (resultado == null)
                {
                    respuesta.Codigo = "-1";
                    respuesta.Mensaje = "Esta materia  ya se encuentra registrada";
                }
                else
                {
                    respuesta.ConsecutivoGenerado = resultado.IdServicio;
                }

                return Ok(respuesta);

            }
        }

        [Authorize]
        [HttpPut]
        [Route("ActualizarMateria")]
        public IActionResult ActualizarServicio(Materia entidad)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                Respuesta respuesta = new Respuesta();

                var resultado = db.Execute("ActualizarMateria",
                    new { entidad.IdServicio, entidad.Precio, entidad.Video },
                    commandType: CommandType.StoredProcedure);

                if (resultado <= 0)
                {
                    respuesta.Codigo = "-1";
                    respuesta.Mensaje = "No se pudo actualizar esta materia";
                }

                return Ok(respuesta);
            }
        }
    }
}
