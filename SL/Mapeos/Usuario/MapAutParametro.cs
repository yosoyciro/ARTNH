using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace SL
{
    public class MapAutParametro : ClassMapping<BE.Usuario.AutParametro>
    {
        public MapAutParametro()
        {
            Schema("Usuario.dbo");
            Id(x => x.Interno);
            Property(p => p.Parametro);
            Property(p => p.CUIT);
        }
    }
}
