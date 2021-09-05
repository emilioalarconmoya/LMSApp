
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
	/// Summary description for DLMALLAACTUSUARIOList.
	/// </summary>
    public class DLMALLAACTUSUARIOList : DLGenericBaseList<EMALLAACTUSUARIO>
	{
		public DLMALLAACTUSUARIOList()
		{
            this._proc_select_all = "proc_select_MALLA_ACT_USUARIO_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EMALLAACTUSUARIO> SelectAll(Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public List<EMALLAACTUSUARIO> GetMallasAsignadas(string listaRuts, string listaActividades,Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = listaRuts;
            prms[0].ParameterName = "@LISTRUTUSUARIOS";

            prms[1] = db.GetParameter();
            prms[1].Value = listaActividades;
            prms[1].ParameterName = "@LISTMALLAS";
			
			prms[2] = db.GetParameter();
            prms[2].Value = CodEmpresa;
            prms[2].ParameterName = "@COD_EMPRESA";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_MALLAS_ASIGNADAS", prms);

            return GetCollection(dr);
        }

        #endregion
    }
}
