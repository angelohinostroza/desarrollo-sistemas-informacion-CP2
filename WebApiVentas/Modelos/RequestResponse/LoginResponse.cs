namespace WebApiVentas.Modelos.RequestResponse
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Perfil { get; set; }
        public string RefreshToken { get; set; }
    }
}
