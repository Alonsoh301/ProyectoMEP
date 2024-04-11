using ProyectoMEP.Entidades;
using ProyectoMEP.Services;

namespace ProyectoMEP.Models
{
    public class EstudianteModel(HttpClient _httpClient, IConfiguration _configuration) : IEstudianteModel
    {
        public Respuesta? RegistrarEstudiante(Estudiante entidad)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Estudiante/RegistrarEstudiante";
            JsonContent body = JsonContent.Create(entidad);
            var resp = _httpClient.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<Respuesta>().Result;

            return null;
        }

        public EstudianteRespuesta? IniciarSesion(Estudiante entidad)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Estudiante/IniciarSesion";
            JsonContent body = JsonContent.Create(entidad);
            var resp = _httpClient.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<EstudianteRespuesta>().Result;

            return null;
        }

        public EstudianteRespuesta? RecuperarAcceso(Estudiante entidad)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Estudiante/RecuperarAcceso";
            JsonContent body = JsonContent.Create(entidad);
            var resp = _httpClient.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<EstudianteRespuesta>().Result;

            return null;
        }

        public EstudianteRespuesta? CambiarContrasenna(Estudiante entidad)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Estudiante/CambiarContrasenna";
            JsonContent body = JsonContent.Create(entidad);
            var resp = _httpClient.PutAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<EstudianteRespuesta>().Result;

            return null;
        }
    }
}
