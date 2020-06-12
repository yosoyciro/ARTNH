using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using BE.ProveedoresCtaCte;

namespace DAL.ProveedoresCuentaCorriente
{ 
    public class CRUDProveedorCuentaCorriente
    {
        #region Singleton
        private static ISession session;
        public static CRUDProveedorCuentaCorriente instancia = new CRUDProveedorCuentaCorriente();

        private CRUDProveedorCuentaCorriente()
        {
            session = SL.GenerarSesion.Instance.Session;
        }
        #endregion

        public IList<ProveedorCuentaCorriente> ListarPorProveedor(double pCUIT)
        {
            return session.Query<ProveedorCuentaCorriente>().Where(a => a.CUIT == pCUIT).ToList();
        }

        public bool Guardar(ProveedorCuentaCorriente pProveedorCuentaCorriente)
        {
            bool ret = true;
            ITransaction transaction = session.BeginTransaction();

            try
            {
                DateTime fechaMov = Convert.ToDateTime(pProveedorCuentaCorriente.FechaMovimientoNormal);
                DateTime fechaRecibo = Convert.ToDateTime(pProveedorCuentaCorriente.FechaReciboNormal);
                pProveedorCuentaCorriente.FechaMovimiento = ConvertirFecha(fechaMov);
                pProveedorCuentaCorriente.FechaRecibo = ConvertirFecha(fechaRecibo);

                ProveedorCuentaCorriente proveedorCuentaCorriente = session.Get<ProveedorCuentaCorriente>(pProveedorCuentaCorriente.Interno);
                if (proveedorCuentaCorriente != null)
                    session.Merge(pProveedorCuentaCorriente);
                else
                    session.Save(pProveedorCuentaCorriente);

                int interno = pProveedorCuentaCorriente.Interno;

                //Pagos 
                foreach (var item in pProveedorCuentaCorriente.CtaCtePagos)
                {
                    item.InternoCtaCteProv = interno;

                    var pago = session.Get<BE.ProveedoresCtaCte.CtaCtePagos>(item.Interno);
                    if (pago == null)
                        session.Save(item);
                    else
                        session.Merge(item);
                }

                // Retenciones
                foreach (var item in pProveedorCuentaCorriente.CtaCteRetenciones)
                {
                    item.InternoCtaCteProv = interno;

                    var retencion = session.Get<BE.ProveedoresCtaCte.CtaCteRetenciones> (item.Interno);
                    if (retencion == null)
                        session.Save(item);
                    else
                        session.Merge(item);
                }

                transaction.Commit();
                session.Flush();

                return ret;
            }

            catch(Exception ex)
            {
                ret = false;
                throw ex;
            }
        }

        #region Funciones
        private int ConvertirFecha(DateTime pFechaNormal)
        {
            switch (pFechaNormal.Year)
            {
                case 1:
                    return 0;

                default:
                    DateTime FechaBase = new DateTime(1801, 01, 01);
                    int FechaClarion = ((TimeSpan)(pFechaNormal - FechaBase.AddDays(-4))).Days;
                    return FechaClarion;
            }
            
        }
        #endregion
    }
}
