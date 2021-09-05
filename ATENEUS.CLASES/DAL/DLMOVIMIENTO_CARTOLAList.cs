

using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLMOVIMIENTOCARTOLAList.
	/// </summary>
    public class DLMOVIMIENTOCARTOLAList : DLGenericBaseList<EMOVIMIENTOCARTOLA>
	{
		public DLMOVIMIENTOCARTOLAList()
		{
            this._proc_select_all = "proc_select_MOVIMIENTO_CARTOLA_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EMOVIMIENTOCARTOLA> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }
        public DataTable GetCartolaPuntos(Int64 RutUsuario, Int16 Periodo)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = RutUsuario;
            prms[0].ParameterName = "@RUTUSUARIO";

            prms[1] = db.GetParameter();
            prms[1].Value = Periodo;
            prms[1].ParameterName = "@PERIODO";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_CARTOLA_DE_PUNTOS", prms);

            return dt;
        }

        #endregion
    }
}
