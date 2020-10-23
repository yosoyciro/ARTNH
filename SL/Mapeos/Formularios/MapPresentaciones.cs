using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace SL
{
    public class MapPresentaciones : ClassMapping<BE.Formularios.Presentaciones>
    {
        public MapPresentaciones()
        {
            Id(x => x.Interno, id =>
            {
                id.Generator(
                    Generators.Identity
                    );
            });
            Property(p => p.CUIT);
            //Property(p => p.InternoEstablecimiento);
            Property(p => p.Nombre);
            Property(p => p.Estado);
            Property(p => p.Tipo);
            //Property(p => p.FechaHoraGeneracion);            
        }
    }
}
