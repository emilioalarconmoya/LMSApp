

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
    public class DLCATEGORIAPRODUCTOList : DLGenericBaseList<ECATEGORIAPRODUCTO>
	{
		public DLCATEGORIAPRODUCTOList()
		{
            this._proc_select_all = "proc_select_CATEGORIA_PRODUCTO_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<ECATEGORIAPRODUCTO> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }
        public List<ECATEGORIAPRODUCTO> GetCategoriaProductoByTienda(string CodTienda)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodTienda;
            prms[0].ParameterName = "@COD_TIENDA";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_CATEGORIAS_POR_TIENDA", prms);

            return GetCollection(dr);
        }

        #endregion
    }
}
