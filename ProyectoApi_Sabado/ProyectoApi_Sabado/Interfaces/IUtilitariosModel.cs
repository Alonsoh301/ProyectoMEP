namespace ProyectoApi_Sabado.Services
{
    public interface IUtilitariosModel
    {
        string GenerarToken(string correo);
        string GenerarNuevaContrasenna();
        string Encrypt(string texto);
        string Decrypt (string texto);
        void EnviarCorreo(string Destinatario, string Asunto, string Mensaje);
    }
}
