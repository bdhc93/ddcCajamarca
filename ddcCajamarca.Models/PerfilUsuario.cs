using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddcCajamarca.Models
{
    public class PerfilUsuario
    {
        public PerfilUsuario()
        {
            this.webpages_UsersInRoles = new List<webpages_UsersInRol>();
        }

        public Int32 Id { get; set; }
        public String Usuario { get; set; }
        public String Imagen { get; set; }
        public String Email { get; set; }
        public String NombreApellidos { get; set; }
        public String NombreMostrar { get; set; }

        public List<webpages_UsersInRol> webpages_UsersInRoles { get; set; }


        [NotMapped]
        public String ImagenTemp { get; set; }
    }
}
