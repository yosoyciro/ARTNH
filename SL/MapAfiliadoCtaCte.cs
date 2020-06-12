using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace SL
{
    public class MapAfiliadoCtaCte : ClassMapping<BE.AfiliadoCuentaCorriente>
    {
        public MapAfiliadoCtaCte()
        {
            Id(x => x.Interno, mapper =>
            {
                mapper.UnsavedValue(0);
                mapper.Generator(Generators.Native);
            });
            Property(p => p.CuitAportante);
            Property(p => p.CuitContribuyente);
            Property(p => p.Periodo);
            Property(p => p.ObligacionNumero);
            Property(p => p.ObligacionSecuencia);
            Property(p => p.Banco);
            Property(p => p.Rectificativa);
        }
    }
}
