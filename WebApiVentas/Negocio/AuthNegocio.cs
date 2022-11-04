using WebApiVentas.Modelos.RequestResponse;

namespace WebApiVentas.Negocio
{
    public class AuthNegocio
    {
        public bool login(LoginRequest request)
        {
            if (request.UserName == "admin" && request.Password == "admin123")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
