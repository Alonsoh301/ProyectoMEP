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
    public class CursoController(IConfiguration _configuration) : ControllerBase
    {
        
        [HttpGet]
        [Route("ConsultarCursos")]
        public IActionResult ConsultarCursos()
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var resultado = db.Query<Curso>("ConsultarCursos",
                    new { },
                    commandType: CommandType.StoredProcedure).ToList();

                if (resultado != null) {
                    return Ok(resultado);
                }

                return NoContent();
                
            }
        }

        [HttpGet]
        [Route("ConsultarCursoID")]
        public IActionResult ConsultarCursoID(int idcurso)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var resultado = db.Query<Curso>("ConsultarCursoID",
                    new { idcurso },
                    commandType: CommandType.StoredProcedure).ToList();

                if (resultado != null)
                {
                    return Ok(resultado);
                }

                return NoContent();

            }
        }

        [HttpPost]
        [Route("RegistrarCurso")]
        public IActionResult RegistrarCurso(Curso entidad)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var resultado = db.Query<Curso>("RegistrarCurso",
                    new { entidad.nombre, entidad.descripcion, entidad.objetivos, entidad.requisitos, entidad.evaluacion },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                if (resultado != null) {
                    return Ok(resultado);
                }

                return NoContent();

            }
        }

        [HttpPut]
        [Route("ActualizarMateria")]
        public IActionResult ActualizarServicio(Curso entidad)
        {
            //using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            //{
            //    Respuesta respuesta = new Respuesta();

            //    var resultado = db.Execute("ActualizarMateria",
            //        new { entidad.IdMateria, entidad.Precio, entidad.Imagen },
            //        commandType: CommandType.StoredProcedure);

            //    return Ok(respuesta);
            //}
            return null;
        }

        [HttpDelete]
        [Route("EliminarMateria")]
        public IActionResult EliminarServicio(long IdMateria)
        {
            //using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            //{
            //    Respuesta respuesta = new Respuesta();

            //    var resultado = db.Execute("EliminarMateria",
            //        new { IdMateria },
            //        commandType: CommandType.StoredProcedure);

            //    return Ok(respuesta);
            //}
            return null;
        }
    }
}
