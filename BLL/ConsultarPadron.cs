using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ConsultarPadron
    {
        public static ConsultarPadron instancia = new ConsultarPadron();

        private ConsultarPadron()
        {
        }

        //public bool ConsultaPadron(Int64 pCUIT, BE.Persona pPersona)
        //{
        //    if (ValidarCUIT(pCUIT) == false)
        //    {
        //        pPersona.MensajeError = "CUIT inválido.";
        //        return false;
        //    }
        //    else
        //    {
        //        return PadronAFIP.ConsultarPadron.instancia.ConsultaPadron(pCUIT, pPersona);
        //    }
        //}

        private bool ValidarCUIT(Int64 pCUIT)
        {            
            string cuit = Convert.ToString(pCUIT);
            int ultimodigito = Convert.ToInt32(cuit.Substring(cuit.Length-1));
            int[] mult = new[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            char[] nums = cuit.ToCharArray();
            int total = 0;
            for (int i = 0; i<mult.Length; i++)
            {
                total += int.Parse(nums[i].ToString()) * mult[i];
            }
            var resto = total % 11;
            int digito = resto == 0 ? 0 : resto == 1 ? 9 : 11 - resto;

            if (digito == ultimodigito)
                return true;
            else
                return false;
        }
    }
}
