using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using BE.Ref;

namespace SL.Mapeos.Ref
{
    public class MapPolizaCabecera : ClassMapping<BE.PolizaCabecera>
    {
        public MapPolizaCabecera()
        {
            Id(x => x.Interno);
            Property(p => p.PolizaNumero);
            Property(p => p.EmpleadorCUIT);
            Property(p => p.FechaInicio);
            Property(p => p.FechaFinal);
        }
    }
}
