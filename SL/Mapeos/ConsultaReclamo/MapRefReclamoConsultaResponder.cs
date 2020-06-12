using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace SL
{
    
    class MapRefReclamoConsultaResponder : ClassMapping<BE.ReclamoConsultaResponder>
    {
        public MapRefReclamoConsultaResponder()
        {
            Id(x => x.Interno, mapper =>
            {
                mapper.UnsavedValue(0);
                mapper.Generator(Generators.Native);
            });
            Property(p => p.ReclamoConsulta);
            Property(p => p.Medio);

        }
    }
}
