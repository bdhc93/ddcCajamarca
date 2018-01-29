using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddcCajamarca.Models
{
    public class webpages_Rol
    {
        public webpages_Rol()
        {
            this.webpages_UsersInRoles = new List<webpages_UsersInRol>();
        }

        public Int32 RoleId { get; set; }
        public String RoleName { get; set; }

        public List<webpages_UsersInRol> webpages_UsersInRoles { get; set; }
    }
}
