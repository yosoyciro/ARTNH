using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace SL
{
    public class MapRespuestasCuestionario : ClassMapping<BE.Formularios.RespuestasCuestionario>
    {
        public MapRespuestasCuestionario()
        {
            Id(x => x.Interno, id =>
            {
                id.Generator(
                    Generators.Identity
                    );
            });
            Property(p => p.InternoCuestionario);
            Property(p => p.InternoRespuestaFormulario);
            Property(p => p.Respuesta);
            Property(p => p.FechaRegularizacion);
            Property(p => p.Observaciones);
            Property(p => p.FechaRegularizacionNormal, m =>
            {
                m.Formula("dbo.ClarionToDate(FechaRegularizacion)");
            });
            Property(p => p.EstadoAccion);
            Property(p => p.EstadoFecha);
            Property(p => p.EstadoSituacion);
            Property(p => p.BajaMotivo);
        }
    }
}
