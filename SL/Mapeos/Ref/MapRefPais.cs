using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using BE.Ref;

namespace SL.Mapeos.Ref
{
    public class MapRefPais : ClassMapping<BE.Ref.RefPais>
    {
        public MapRefPais()
        {
            Schema("Referencia.dbo");
            Id(x => x.Codigo);
            Property(p => p.Denominacion);
            Property(p => p.Pais);
        }
    }
}
