
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
	/// Summary description for DLESCALANOTASList.
	/// </summary>
    public class DLESCALANOTASList : DLGenericBaseList<EESCALANOTAS>
	{
		public DLESCALANOTASList()
		{
            this._proc_select_all = "proc_select_ESCALA_NOTAS_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EESCALANOTAS> SelectAll(Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodEmpresa;
            prms[0].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, prms);

            return GetCollection(dr);
        }

		#endregion
	}
}
