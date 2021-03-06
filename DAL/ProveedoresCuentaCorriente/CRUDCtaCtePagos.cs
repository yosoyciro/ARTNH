﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using BE.ProveedoresCtaCte;

namespace DAL.ProveedoresCuentaCorriente
{
    public class CRUDCtaCtePagos
    {
        #region Singleton
        private static ISession session;
        public static CRUDCtaCtePagos instancia = new CRUDCtaCtePagos();

        private CRUDCtaCtePagos()
        {
            session = SL.GenerarSesion.Instance.Session;
        }
        #endregion

        public IList<CtaCtePagos> ListarPorCtaCteProvInterno(double pInternoCtaCte)
        {
            return session.Query<CtaCtePagos>().Where(a => a.InternoCtaCteProv == pInternoCtaCte).ToList();
        }

        public bool Guardar(CtaCtePagos pCtaCtePagos)
        {
            bool ret = true;
            ITransaction transaction = session.BeginTransaction();

            try
            {
                CtaCtePagos ctactepagos = session.Get<CtaCtePagos>(pCtaCtePagos.Interno);
                if (ctactepagos != null)
                    session.Merge(pCtaCtePagos);
                else
                    session.Save(pCtaCtePagos);

                transaction.Commit();

                return ret;
            }

            catch(Exception ex)
            {
                ret = false;
                throw ex;
            }
        }

    }
}
