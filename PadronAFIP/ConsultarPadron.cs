using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Configuration;

namespace PadronAFIP
{
    public class ConsultarPadron
    {
        //#region Singleton
        //public static PadronAFIP.ConsultarPadron instancia = new ConsultarPadron();

        //private ConsultarPadron()
        //{
        //}

        //#endregion 

        public ConsultarPadron()
        {

        }

        /// <summary>
        /// Metodo que se encarga de verificar/pedir Ticket y luego consultar al padron
        /// </summary>
        /// <param name="pCUIT"></param>
        /// <param name="pPersona"></param>
        /// <returns></returns>
        public bool ConsultaPadron(double pCUIT, BE.Persona pPersona)
        {
            bool ret = false;

            try
            {
                if (ClsLogin.instancia.Login() == true)
                {
                    ClsLog.instancia.EscribirLog("Login exitoso");
                    //Conecto con la AFIP
                    ret = PadronAFIP.ClsGetPersona.instancia.Consultar(pCUIT, pPersona);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return ret;
        }
    }
}
