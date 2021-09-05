
using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;
using ATENEUS.CLASES.DAO;
//using Moebius.ErrorManagement;
//using ATENEUS.BUSINESS.Collections;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLCARACTERISTICAList.
	/// </summary>
    public class DLCARACTERISTICAList : DLGenericBaseList<ECARACTERISTICA>
	{
		public DLCARACTERISTICAList()
		{
            this._proc_select_all = "proc_select_CARACTERISTICA_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<ECARACTERISTICA> SelectAll(long CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodEmpresa;
            prms[0].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, prms);

            return GetCollection(dr);
        }
        //public List<ECARACTERISTICA> SelectAll(long CodEmpresa)
        //{
        //    DB db = DatabaseFactory.Instance.GetDatabase();
        //    IDbDataParameter[] prms;
        //    prms = db.GetArrayParameter(1);

        //    prms[0] = db.GetParameter();
        //    prms[0].Value = CodEmpresa;
        //    prms[0].ParameterName = "@cod_empresa";

        //    IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_atributos_caracteristica", prms);

        //    return GetCollection(dr);
        //}

        #endregion
    }
}
