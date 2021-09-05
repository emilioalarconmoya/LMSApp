
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
	/// Summary description for DLATRIBUTOList.
	/// </summary>
    public class DLATRIBUTOList : DLGenericBaseList<EATRIBUTO>
	{
		public DLATRIBUTOList()
		{
            this._proc_select_all = "proc_select_ATRIBUTO_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EATRIBUTO> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public List<EATRIBUTO> AtributosCaracteristicas(Int16 CodCaracteristicas, long CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = CodCaracteristicas;
            prms[0].ParameterName = "@COD_CARACTERISTICA";

            prms[1] = db.GetParameter();
            prms[1].Value = CodEmpresa;
            prms[1].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_atributos_caracteristica", prms);

            return GetCollection(dr);
        }

        public DataTable AtributosPorCaracteristica(Int16 CodCaracteristicas)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodCaracteristicas;
            prms[0].ParameterName = "@CODCARACTERISTICA";

            return db.ExecuteDataTable(CommandType.StoredProcedure, "proc_ATRIBUTOS_POR_CARACTERISTICA", prms);
            
        }

        #endregion
    }
}
