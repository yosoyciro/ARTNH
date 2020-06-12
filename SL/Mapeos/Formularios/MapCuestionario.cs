using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace SL
{
    public class MapCuestionario : ClassMapping<BE.Formularios.Cuestionarios>
    {
        public MapCuestionario()
        {
            Id(x => x.Interno, id =>
            {
                id.Generator(
                    Generators.Identity
                    );
            });
            Property(p => p.InternoSeccion);
            Property(p => p.Orden);
            Property(p => p.Codigo);
            Property(p => p.Pregunta);
            Property(p => p.Comentario);            
        }
    }
}
