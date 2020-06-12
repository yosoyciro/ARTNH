using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Clase definida para recibir los domicilios de un contribuyente.
/// </summary>
namespace BE
{
    public class Domicilios
    {
        public Domicilios()
        {
        }

        public virtual string Domicilio { get; set; }
        public virtual string TipoDomicilio { get; set; }
    }
}
