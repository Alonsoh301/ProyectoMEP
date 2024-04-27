namespace ProyectoMEP.Entidades
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

    public class UsuarioRespuesta
    {
        public string? Codigo { get; set; }
        public string? Mensaje { get; set; }
        public Usuario? Dato { get; set; }
        public List<Usuario>? Datos { get; set; }
    }
}
