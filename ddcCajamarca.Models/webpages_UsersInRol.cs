using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddcCajamarca.Models
{
    public class webpages_UsersInRol
    {
        public Int32 Id { get; set; }

        public Int32 UserId { get; set; }
        public PerfilUsuario PerfilUsuario { get; set; }

        public Int32 RoleId { get; set; }
        public webpages_Rol webpages_Roles { get; set; }
    }
}
