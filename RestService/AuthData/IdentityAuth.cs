using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;
using RestService.Model;

namespace RestService.AuthData
{
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class IdentityAuth : IdentityDbContext<IdentityUser>
    {
        public IdentityAuth() : base("AuthDb") { }

        public static IdentityAuth Create()
        {
            return new IdentityAuth();
        }
    }
}