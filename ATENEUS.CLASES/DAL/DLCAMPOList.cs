
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
	/// Summary description for DLCAMPOList.
	/// </summary>
    public class DLCAMPOList : DLGenericBaseList<ECAMPO>
	{
		public DLCAMPOList()
		{
            this._proc_select_all = "proc_select_CAMPO_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<ECAMPO> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }
        public List<ECAMPO> GetCamposPlantilla(Decimal CodPlantilla)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodPlantilla;
            prms[0].ParameterName = "@CodPlantilla";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_CAMPOS_PLANTILLA", prms);

            return GetCollection(dr);
        }

        #endregion
    }
}
