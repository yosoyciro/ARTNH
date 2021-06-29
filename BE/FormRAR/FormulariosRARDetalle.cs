using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Ref;

namespace BE.FormRAR
{
    public class FormulariosRARDetalle
    {
        public FormulariosRARDetalle()
        {

        }
        public virtual int Interno { get; set; }
        public virtual int InternoFormulariosRAR { get; set; }
        public virtual double CUIL { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string SectorTarea { get; set; }
        public virtual System.DateTime? FechaIngreso { get; set; }
        public virtual byte HorasExposicion { get; set; }
        public virtual System.DateTime? FechaUltimoExamenMedico { get; set; }
        public virtual int CodigoAgente { get; set; }
        public virtual string DescripcionAgente { get; set; }
        //public virtual SRTSiniestralidadAgenteCausante AgenteCausante { get; set; }
    }
}
