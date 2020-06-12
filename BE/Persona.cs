using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Clase definida para recibir lo que devuelve el método GetPersona de AFIP.
/// </summary>
namespace BE
{
    public class Persona
    {
        public Persona()
        {
        }

        public virtual string Apellido { get; set; }
        public virtual string Nombre { get; set; }
        public virtual Int64 IdPersona { get; set; }
        public virtual Int64 NroDocumento { get; set; }
        public virtual string TipoClave { get; set; }
        public virtual string TipoDocumento { get; set; }
        public virtual string TipoPersona { get; set; }
        public virtual string MensajeError { get; set; }
        public virtual IList<Domicilios> Domicilios { get; set; }
    }
}
