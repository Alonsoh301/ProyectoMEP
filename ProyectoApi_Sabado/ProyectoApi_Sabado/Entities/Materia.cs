namespace ProyectoApi_Sabado.Entities
{
    public class Materia
    {
        public long IdMateria { get; set; }
        public string? Nombre { get; set; }
        public decimal Precio { get; set; }
        public string? Descripcion { get; set; }
        public string? Imagen { get; set; }
        public bool Estado { get; set; }
    }

    public class MateriaRespuesta
    {
        public MateriaRespuesta()
        {
            Codigo = "00";
            Mensaje = string.Empty;
        }

        public string? Codigo { get; set; }
        public string? Mensaje { get; set; }
        public Materia? Dato { get; set; }
        public List<Materia>? Datos { get; set; }
    }
}
