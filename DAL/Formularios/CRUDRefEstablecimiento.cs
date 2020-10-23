using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;

namespace DAL.Formularios
{
    public class CRUDRefEstablecimiento
    {

        #region Singleton
        private static ISession session;
        public static CRUDRefEstablecimiento instancia = new CRUDRefEstablecimiento();

        private CRUDRefEstablecimiento()
        {
            session = SL.GenerarSesion.Instance.Session;
        }
        #endregion

        public List<BE.Formularios.RefEstablecimiento> ListarPorCuit(double pCuit)
        {
            session.Clear();
            try
            {
                var establecimientos = session.Query<BE.Formularios.RefEstablecimiento>()
                    .Where(a => a.CUIT == pCuit && a.BajaMotivo == 0)
                    .ToList();
                foreach (var item in establecimientos)
                {
                    if (item != null && item.CodLocalidadSRT != "" && item.CodLocalidadSRT != null)
                    {
                        var localidadSRT = session.Query<BE.Ref.SRTLocalidad>()
                            .Where(l => l.Codigo == item.CodLocalidadSRT)
                            .SingleOrDefault();
                        item.Localidad = localidadSRT.Nombre;
                        item.Provincia = localidadSRT.NombreProvincia;
                    }
                    else
                    {
                        item.Localidad = "Sin Localidad";
                        item.Provincia = "Sin Provincia";
                    }
                }
                session.Flush();
                return establecimientos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Formularios.RefEstablecimiento ListarPorInterno(int pInternoEstablecimiento)
        {
            session.Clear();
            try
            {
                var establecimiento = session.Get<BE.Formularios.RefEstablecimiento>(pInternoEstablecimiento);
                if (establecimiento != null && (establecimiento.CodLocalidadSRT != "" || establecimiento.CodLocalidadSRT != null))
                { 
                    var SRTLocalidad = session.Query<BE.Ref.SRTLocalidad>().
                        Where(l => l.Codigo == establecimiento.CodLocalidadSRT).
                        SingleOrDefault();
                    establecimiento.Localidad = SRTLocalidad.Nombre;
                    establecimiento.Provincia = SRTLocalidad.NombreProvincia;
                }
                else
                {
                    establecimiento.Localidad = "Sin Localidad";
                    establecimiento.Provincia = "Sin Provincia";
                }

                return establecimiento;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(int pInternoEstablecimiento, BE.Formularios.RefEstablecimientoActualizar pRefEstablecimientoActualizar)
        {
            ITransaction transaction = session.BeginTransaction();
            try
            {
                var establecimiento = session.Get<BE.Formularios.RefEstablecimiento>(pInternoEstablecimiento);
                establecimiento.CantTrabajadores = pRefEstablecimientoActualizar.CantTrabajadores;
                establecimiento.Superficie = pRefEstablecimientoActualizar.Superficie;

                session.Merge(establecimiento);
                session.Flush();
                transaction.Commit();

                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }
    }
}
