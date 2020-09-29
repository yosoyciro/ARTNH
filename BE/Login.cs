using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Login
    {
        #region Singleton
        public static Login instancia;

        private Login()
        {
            if (null == instancia)
                instancia = new Login();
        }
        #endregion
        
        /// <summary>
        /// Metodo que verifica usuario y clave.
        /// </summary>
        /// <param name="pUsuario"></param>
        /// <param name="pClave"></param>
        /// <returns></returns>
        public bool Loguearse(string pUsuario, string pClave)
        {
            return VerificarUsuarioClave(pUsuario, pClave);
        }

        private bool VerificarUsuarioClave(string pUsuario, string pClave)
        {
            return true;
        }
    }
}
