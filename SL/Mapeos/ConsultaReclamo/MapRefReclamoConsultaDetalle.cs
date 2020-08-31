using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace SL
{

    class MapRefReclamoConsultaDetalle : ClassMapping<BE.ReclamoConsultaDetalle>
    {
        public MapRefReclamoConsultaDetalle()
        {
            Id(x => x.Interno, mapper =>
            {
                mapper.UnsavedValue(0);
                mapper.Generator(Generators.Native);
            });

            Property(p => p.ReclamoConsulta);
            Property(p => p.Ingreso);
            Property(p => p.Medio);
            Property(p => p.Asunto);
            Property(p => p.Cuerpo);
            Property(p => p.Movimiento);
            Property(p => p.Operador);
            Property(p => p.Revision);
            Property(p => p.CuerpoHtml);
            Property(p => p.SectorInterno);
            Property(p => p.OperadorReasigna);
        }
    }
}
