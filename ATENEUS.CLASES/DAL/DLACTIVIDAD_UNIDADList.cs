
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
	/// Summary description for DLACTIVIDADUNIDADList.
	/// </summary>
    public class DLACTIVIDADUNIDADList : DLGenericBaseList<EACTIVIDADUNIDAD>
	{
		public DLACTIVIDADUNIDADList()
		{
            this._proc_select_all = "proc_select_ACTIVIDAD_UNIDAD_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EACTIVIDADUNIDAD> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public DataTable SelectUnidadesActividad(long CodActividad)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActividad;
            prms[0].ParameterName = "@COD_ACTIVIDAD";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_unidades_actividad", prms);

            return dt;
        }

        public Boolean GetTerminoUnidad(long CodActivUsr, long CodUnidad,Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActivUsr;   
            prms[0].ParameterName = "@CODACTIVUSR";

            prms[1] = db.GetParameter();
            prms[1].Value = CodUnidad;
            prms[1].ParameterName = "@CODUNIDAD";

            prms[2] = db.GetParameter();
            prms[2].Value = CodEmpresa;
            prms[2].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_TERMINO_UNIDAD", prms);

            if (Utiles.ConvertToInt16(dt.Rows[0][0]) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
