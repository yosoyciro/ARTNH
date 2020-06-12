using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class AfiliadoDatos
    {
        public AfiliadoDatos()
        {
        }

        public virtual int Interno { get; set; }
        public virtual double Cuil { get; set; }
        public virtual string DocTipo { get; set; }
        public virtual double DocNumero { get; set; }
        public virtual string Nombre { get; set; }
        public virtual DateTime FechaNacimiento { get; set; }
        public virtual int Nacionalidad { get; set; }
        public virtual string Sexo { get; set; }
        public virtual string DomicilioCalle { get; set; }
        public virtual string CodLocalidadSRT { get; set; }
        public virtual string CodLocalidadPostal { get; set; }
        public virtual string Telefono { get; set; }
        public virtual string EstadoCivil { get; set; }
        public virtual string eMail { get; set; }
    }

    

}
