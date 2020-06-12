using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace SL
{
    public class MapRefEstablecimiento : ClassMapping<BE.Formularios.RefEstablecimiento>
    {
        public MapRefEstablecimiento()
        {
            Schema("Referencia.dbo");
            Id(x => x.Interno, id =>
            {
                id.Generator(
                    Generators.Identity
                    );
            });
            Property(p => p.CUIT);
            Property(p => p.NroSucursal);
            Property(p => p.Nombre);
            Property(p => p.DomicilioCalle);
            Property(p => p.DomicilioNro);
        }
    }
}
