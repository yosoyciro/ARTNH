using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace SL
{
    public class MapFormulario : ClassMapping<BE.Formularios.Formularios>
    {
        public MapFormulario()
        {
            Id(x => x.Interno, id =>
            {
                id.Generator(
                    Generators.Identity
                    );
            });
            Property(p => p.Descripcion);
            Property(p => p.CantidadGremios);
            Property(p => p.CantidadContratistas);
            Property(p => p.CantidadResponsables);
        }
    }
}
