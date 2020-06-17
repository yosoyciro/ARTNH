using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace SL
{
    public class MapRespuestasFormularioRel : ClassMapping<BE.Formularios.RespuestasFormularioRel>
    {
        public MapRespuestasFormularioRel()
        {
            Id(x => x.Interno, id =>
            {
                id.Generator(
                    Generators.Identity
                    );
            });
            Property(p => p.InternoRespuestaFormularioOriginal);
            Property(p => p.InternoRespuestaFormularioNuevo);            
        }
    }
}
