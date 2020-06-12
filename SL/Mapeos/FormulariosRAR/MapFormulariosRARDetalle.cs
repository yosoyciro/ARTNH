using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace SL
{
    public class MapFormulariosRARDetalle : ClassMapping<BE.FormRAR.FormulariosRARDetalle>
    {
        public MapFormulariosRARDetalle()
        {
            Id(x => x.Interno, id =>
            {
                id.Generator(
                    Generators.Identity
                    );
            });
            Property(p => p.InternoFormulariosRAR);
            Property(p => p.CUIL);
            Property(p => p.Nombre);
            Property(p => p.SectorTarea);
            Property(p => p.FechaIngreso);
            Property(p => p.HorasExposicion);
            Property(p => p.FechaUltimoExamenMedico);
            Property(p => p.CodigoAgente);
        }
    }
}
