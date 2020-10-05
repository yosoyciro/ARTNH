using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace SL.Mapeos.Ref
{
    public class MapRefEmpleador : ClassMapping<BE.Ref.RefEmpleador>
    {
        public MapRefEmpleador()
        {
            Id(x => x.Interno);
            Property(p => p.CUIT);
            Property(p => p.CuilFirmante1);
            Property(p => p.Nombre1);
            Property(p => p.CuilFirmante2);
            Property(p => p.Nombre2);
            Property(p => p.Comentario);
            Property(p => p.ContratoNro);
            Property(p => p.CIIU);
        }
        
    }
}
