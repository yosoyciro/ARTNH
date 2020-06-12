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
    public class MapCtaCteRetenciones : ClassMapping<CtaCteRetenciones>
    {
        public MapCtaCteRetenciones()
        {
            Id(x => x.Interno, id =>
            {
                id.Generator(
                    Generators.Identity
                    );
            });
            Property(p => p.InternoCtaCteProv);
            Property(p => p.InternoCtaCteTiposRetencion);
            Property(p => p.Concepto);
            Property(p => p.Importe);
        }
    }
}
