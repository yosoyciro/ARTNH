using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace SL
{
    
    class MapRefReclamoConsultaContacto : ClassMapping<BE.ReclamoConsultaContacto>
    {
        public MapRefReclamoConsultaContacto()
        {
            Id(x => x.Interno, mapper =>
            {
                mapper.UnsavedValue(0);
                mapper.Generator(Generators.Native);
            });
            Property(p => p.DocTipo);
            Property(p => p.DocNro);
            Property(p => p.TrabajadorEmpleador);
            Property(p => p.Nombre);
    }
    }
}
