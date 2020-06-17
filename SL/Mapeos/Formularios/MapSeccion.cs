using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace SL
{
    public class MapSeccion : ClassMapping<BE.Formularios.Secciones>
    {
        public MapSeccion()
        {
            Id(x => x.Interno, id =>
            {
                id.Generator(
                    Generators.Identity
                    );
            });
            Property(p => p.InternoFormulario);
            Property(p => p.Orden);
            Property(p => p.Descripcion);
            Property(p => p.TieneNoAplica);
            Property(p => p.Comentario);
            Property(p => p.Pagina);
            Property(p => p.Baja);
            Property(p => p.Planilla);
        }
    }
}
