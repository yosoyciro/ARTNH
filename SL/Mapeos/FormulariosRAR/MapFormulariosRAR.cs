using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace SL
{
    public class MapFormulariosRAR : ClassMapping<BE.FormRAR.FormulariosRAR>
    {
        public MapFormulariosRAR()
        {
            Id(x => x.Interno, id =>
            {
                id.Generator(
                    Generators.Identity
                    );
            });
            Property(p => p.InternoEstablecimiento);
            Property(p => p.CantTrabajadoresExpuestos);
            Property(p => p.CantTrabajadoresNoExpuestos);
            Property(p => p.FechaCreacion);
            Property(p => p.FechaPresentacion);
            Property(p => p.InternoPresentacion);
        }
    }
}
