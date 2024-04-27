namespace ProyectoApi_Sabado.Entities
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }
        public bool Estado { get; set; }
        public string rol { get; set; }
    }
}
