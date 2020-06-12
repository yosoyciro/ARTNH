using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuarios
    {
        public Usuarios()
        {
        }

        public virtual string Nombre { get; set; }
        public virtual string Usuario { get; set; }
        public virtual string Email { get; set; }
        public virtual int Status { get; set; }
        public virtual string Token { get; set; }
        
    }
}
