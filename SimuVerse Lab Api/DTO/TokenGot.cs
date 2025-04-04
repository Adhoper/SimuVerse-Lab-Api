namespace ALQUILER_VIDEOJUEGOS_BACK.DTO
{
    public class TokenGot
    {
        public int IdUsuario { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdRol { get; set; }
        public int IdInstitucion { get; set; }
        public string NombreRol { get; set; }
        public string NombreInstitucion { get; set; }
        public string Token { get; set; }
    }
}
