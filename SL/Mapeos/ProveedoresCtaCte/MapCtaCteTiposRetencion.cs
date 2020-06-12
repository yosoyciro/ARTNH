using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using BE.ProveedoresCtaCte;

namespace SL
{
    public class MapCtaCteTiposRetencion : ClassMapping<CtaCteTiposRetencion>
    {
        public MapCtaCteTiposRetencion()
        {
            Id(x => x.Interno, id =>
            {
                id.Generator(
                    Generators.Identity
                    );
            });
            Property(p => p.Descripcion);
        }
    }
}
