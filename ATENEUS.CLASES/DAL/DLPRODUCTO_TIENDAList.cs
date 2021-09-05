

using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLPRODUCTOTIENDAList.
	/// </summary>
    public class DLPRODUCTOTIENDAList : DLGenericBaseList<EPRODUCTOTIENDA>
	{
		public DLPRODUCTOTIENDAList()
		{
            this._proc_select_all = "proc_select_PRODUCTO_TIENDA_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EPRODUCTOTIENDA> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }
        public EPRODUCTOTIENDA GetProductoTienda(string CodTienda, string CodProducto)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = CodTienda;
            prms[0].ParameterName = "@COD_TIENDA";

            prms[1] = db.GetParameter();
            prms[1].Value = CodProducto;
            prms[1].ParameterName = "@COD_PRODUCTO";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_PRODUCTO_TIENDA", prms);

            EPRODUCTOTIENDA obj = new EPRODUCTOTIENDA();

            while (dr.Read())
            {

                obj.CODPRODUCTO = Utiles.ConvertToString(dr["COD_PRODUCTO"]);

                obj.CODTIENDA = Utiles.ConvertToString(dr["COD_TIENDA"]);

                obj.STOCK = Utiles.ConvertToInt32(dr["STOCK"]);

                obj.COSTOPUNTOS = Utiles.ConvertToInt32(dr["COSTO_PUNTOS"]);

                obj.SALDO_INICIAL = Utiles.ConvertToInt32(dr["SALDO_INICIAL"]);

            }
            dr.Close();
            return obj;
        }

        #endregion
    }
}
