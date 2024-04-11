using ProyectoMEP.Entidades;

namespace ProyectoMEP.Services
{
    public interface IEstudianteModel
    {
        Respuesta? RegistrarEstudiante(Estudiante entidad);

        EstudianteRespuesta? IniciarSesion(Estudiante entidad);

        EstudianteRespuesta? RecuperarAcceso(Estudiante entidad);

        EstudianteRespuesta? CambiarContrasenna(Estudiante entidad);
    }
}
