using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace SL
{
    public class MapRespuestasFormulario : ClassMapping<BE.Formularios.RespuestasFormulario>
    {
        public MapRespuestasFormulario()
        {
            Id(x => x.Interno, id =>
            {
                id.Generator(
                    Generators.Identity
                    );
            });
            Property(p => p.InternoFormulario);
            Property(p => p.InternoEstablecimiento);
            Property(p => p.CreacionFechaHora);
            Property(p => p.CompletadoFechaHora);
            Property(p => p.NotificacionFecha);
        }
    }
}
