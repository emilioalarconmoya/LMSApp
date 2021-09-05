

using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLCATEGORIAPRODUCTOList.
	/// </summary>
    public class DLCATEGORIAACTIVIDADList : DLGenericBaseList<ECATAGORIAACTIVIDAD>
	{
		public DLCATEGORIAACTIVIDADList()
		{
            this._proc_select_all = "proc_select_CATEGORIA_ACTIVIDAD_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<ECATAGORIAACTIVIDAD> SelectAll(Int64 codEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = codEmpresa;
            prms[0].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, prms);

            return GetCollection(dr);
        }
        //public List<ECATAGORIAACTIVIDAD> GetCategoriaProductoByTienda(string CodTienda)
        //{
        //    DB db = DatabaseFactory.Instance.GetDatabase();
        //    IDbDataParameter[] prms = db.GetArrayParameter(1);

        //    prms[0] = db.GetParameter();
        //    prms[0].Value = CodTienda;
        //    prms[0].ParameterName = "@COD_TIENDA";

        //    IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_CATEGORIAS_POR_TIENDA", prms);

        //    return GetCollection(dr);
        //}

        #endregion
    }
}
