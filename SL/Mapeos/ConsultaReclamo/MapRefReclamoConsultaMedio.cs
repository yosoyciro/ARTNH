using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace SL
{
    
    class MapRefReclamoConsultaMedio : ClassMapping<BE.ReclamoConsultaMedio>
    {
        public MapRefReclamoConsultaMedio()
        {
            Id(x => x.Interno, mapper =>
            {
                mapper.UnsavedValue(0);
                mapper.Generator(Generators.Native);
            });
            Property(p => p.Contacto);
            Property(p => p.Tipo);
            Property(p => p.Direccion);
     }
    }
}
