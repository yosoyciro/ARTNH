using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Configuration;

namespace PadronAFIP
{
    public class ClsGetPersona
    {
        public static PadronAFIP.ClsGetPersona instancia = new ClsGetPersona();
        private ClsGetPersona()
        {
        }

        public bool Consultar(double pCUIT, BE.Persona pPersona)
        {
            ClsLog.instancia.EscribirLog("Ingresa a Consultar");
            var appconfig = ConfigurationManager.AppSettings;             

            //Leo xml del ticket con el token y el sign
            XmlDocument XmlTicket = new XmlDocument();
            XmlTicket.Load(appconfig["Ticket"]);

            //Conecto
            string token = XmlTicket.SelectSingleNode("//token").InnerText;
            string sign = XmlTicket.SelectSingleNode("//sign").InnerText;
            Int64 cuitrepresentada = Convert.ToInt64(appconfig["CUIT"]);
            Int64 cuitconsultada = Convert.ToInt64(pCUIT);

            if (appconfig["MetodoPadron"] == "ws_sr_padron_a13")
            {
                AFIP.PadronA13.PersonaServiceA13 padrona13 = new AFIP.PadronA13.PersonaServiceA13();
                AFIP.PadronA13.personaReturn personaReturn = new AFIP.PadronA13.personaReturn();

                padrona13.Url = appconfig["URLPadronProduccion"].ToString();
                personaReturn = padrona13.getPersona(token, sign, cuitrepresentada, cuitconsultada);

                pPersona.Apellido = personaReturn.persona.apellido;
                pPersona.Nombre = personaReturn.persona.nombre;
                pPersona.IdPersona = personaReturn.persona.idPersona;
                pPersona.TipoClave = personaReturn.persona.tipoClave;
                pPersona.TipoDocumento = personaReturn.persona.tipoDocumento;
                pPersona.TipoPersona = personaReturn.persona.tipoPersona;
            }
            

                       

            return true;
        }
    }
}
