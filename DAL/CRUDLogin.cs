using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace DAL
{
    public class CRUDLogin
    {
        private static ISession session;
        public static DAL.CRUDLogin instancia = new DAL.CRUDLogin();
        private CRUDLogin()
        {
            session = SL.GenerarSesion.Instance.Session;
        }

        public bool CrearUsuario(BE.Usuarios pUsuarios)
        {
            bool ret = false;

            

            return ret;
        }
        /// <summary>
        /// Devuelvo un estado. -1 no existe el usuario, 0 error de usuario/contraseña, 1 OK
        /// </summary>
        /// <param name="pUsuario"></param>
        /// <returns></returns>
        public BE.Usuarios Login(string pUsuario, string pPassword)
        {
            try
            {
                var usuarios = session.CreateSQLQuery("EXEC Login @pUsuario = N'" + pUsuario + "',@pPassword = N'" + pPassword + "'").UniqueResult();

                BE.Usuarios oUsuario = new BE.Usuarios
                {
                    Nombre = Convert.ToString(((object[])usuarios)[1]),
                    Usuario = Convert.ToString(((object[])usuarios)[2]),
                    Status = Convert.ToInt32(((object[])usuarios)[5]),
                };

                //Si el login está ok, genero el token y devuelvo todo en el objeto oUsuario (sin el pass)
                switch (oUsuario.Status)
                {
                    case 1:
                        var token = TokenGen.GenerateTokenJwt(pUsuario);
                        oUsuario.Token = token;
                        break;

                    default:
                        oUsuario.Token = "";
                        break;
                };
                                        
                return oUsuario;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
