using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace SL
{
    public class MapFormulariosRARDetalleAgentes : ClassMapping<BE.FormRAR.FormulariosRARDetalleAgentes>
    {
        public MapFormulariosRARDetalleAgentes()
        {
            Id(x => x.Interno, id =>
            {
                id.Generator(
                    Generators.Identity
                    );
            });
            Property(p => p.InternoFormulariosRARDetalle);
            Property(p => p.CodigoAgente);
        }
    }
}
