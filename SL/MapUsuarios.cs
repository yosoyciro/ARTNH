using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace SL
{
    public class MapUsuarios : ClassMapping<BE.Usuarios>
    {
        public MapUsuarios()
        {
            //Id(x => x.UsuariosId, mapper =>
            //{
            //    mapper.UnsavedValue(0);
            //    mapper.Generator(Generators.Native);
            //});
            Property(p => p.Nombre);
            Property(p => p.Usuario);
            Property(p => p.Password);
            //Property(p => p.Email);
            //Property(p => p.Status);
            //Property(p => p.TotalCnt);
        }
    }
}
