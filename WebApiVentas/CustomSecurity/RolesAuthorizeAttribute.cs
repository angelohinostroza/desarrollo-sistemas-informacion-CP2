using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace WebApiVentas.CustomSecurity
{
    public class AuthorizeByRoleAttribute : AuthorizeAttribute
    {
        public class RolesAuthorizeAttribute : AuthorizeAttribute
        {
            public RolesAuthorizeAttribute(params string[] roles)
            {
                Roles = String.Join(",", roles);
            }
        }
        public const string administrador = "Administrador";
        
    }

}
