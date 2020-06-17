using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;


namespace SL
{
    public class MapRespuestasContratista : ClassMapping<BE.Formularios.RespuestasContratista>
    {
        public MapRespuestasContratista()
        {
            Id(x => x.Interno, id =>
            {
                id.Generator(
                    Generators.Identity
                    );
            });
            Property(p => p.InternoRespuestaFormulario);
            Property(p => p.CUIT);
            Property(p => p.Contratista);
            Property(p => p.EstadoAccion);
            Property(p => p.EstadoFecha);
            Property(p => p.EstadoSituacion);
            Property(p => p.BajaMotivo);
            Property(p => p.Renglon);
        }
    }
}
