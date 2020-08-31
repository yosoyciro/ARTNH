using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace SL
{

    class MapRefReclamoConsulta : ClassMapping<BE.ReclamoConsulta>
    {
        public MapRefReclamoConsulta()
        {
            Id(x => x.Interno, mapper =>
            {
                mapper.UnsavedValue(0);
                mapper.Generator(Generators.Native);
            });
            Property(p => p.Operador);
            Property(p => p.Origen);
            Property(p => p.Tramite);
            Property(p => p.Tema);
            Property(p => p.Categoria);
            Property(p => p.Contacto);
            Property(p => p.Apertura);
            Property(p => p.Cierre);
            Property(p => p.Siniestro);
            Property(p => p.ContactoDomicilioInterno);
        }
    }
}
