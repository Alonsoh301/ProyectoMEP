using ProyectoMEP.Entidades;

namespace ProyectoMEP.Services
{
    public interface IServicioModel
    {
        ServicioRespuesta? ConsultarServicios(bool MostrarTodos);
        ServicioRespuesta? ConsultarServicio(long IdServicio);
        Respuesta? RegistrarServicio(Servicio entidad);
        Respuesta? ActualizarServicio(Servicio entidad);
    }
}
