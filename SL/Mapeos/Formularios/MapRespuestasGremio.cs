using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace SL
{
    public class MapRespuestasGremio : ClassMapping<BE.Formularios.RespuestasGremio>
    {
        public MapRespuestasGremio()
        {
            Id(x => x.Interno, id =>
            {
                id.Generator(
                    Generators.Identity
                    );
            });
            Property(p => p.InternoRespuestaFormulario);
            Property(p => p.Legajo);
            Property(p => p.Nombre);
            Property(p => p.EstadoAccion);
            Property(p => p.EstadoFecha);
            Property(p => p.EstadoSituacion);
            Property(p => p.BajaMotivo);
            Property(p => p.Renglon);
        }
    }
}
