namespace ProyectoMEP.Entidades
{
    public class Estudiante
    {
        public long IdEstudiante { get; set; }
        public string? Correo { get; set; }
        public string? Contrasenna { get; set; }
        public string? NombreEstudiante { get; set; }
        public short IdRol { get; set; }
        public string? NombreRol { get; set; }
        public bool Estado { get; set; }
        public string? Token { get; set; }
        public bool EsTemporal { get; set; }
        public string? ContrasennaTemporal { get; set; }
        public short IdCategoria { get; set; }
        public string? NombreCategoria { get; set; }
    }

    public class EstudianteRespuesta
    {
        public string? Codigo { get; set; }
        public string? Mensaje { get; set; }
        public Estudiante? Dato { get; set; }
        public List<Estudiante>? Datos { get; set; }
    }
}
