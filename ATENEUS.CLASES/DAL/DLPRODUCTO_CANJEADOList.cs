

using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLPRODUCTOCANJEADOList.
	/// </summary>
    public class DLPRODUCTOCANJEADOList : DLGenericBaseList<EPRODUCTOCANJEADO>
	{
		public DLPRODUCTOCANJEADOList()
		{
            this._proc_select_all = "proc_select_PRODUCTO_CANJEADO_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EPRODUCTOCANJEADO> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }
        public DataTable GetCanjesByRut(Int64 Rut)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@RUT_USUARIO";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_CANJEES_BY_USUARIO", prms);

            return dt;
        }
        public DataTable GetCanjesByRutAndTienda(Int64 Rut, string CodTienda, DateTime Inicio, DateTime Fin)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(4);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@RUT_USUARIO";

            prms[1] = db.GetParameter();
            prms[1].Value = CodTienda;
            prms[1].ParameterName = "@COD_TIENDA";

            prms[2] = db.GetParameter();
            prms[2].Value = Inicio;
            prms[2].ParameterName = "@INICIO";

            prms[3] = db.GetParameter();
            prms[3].Value = Fin;
            prms[3].ParameterName = "@FIN";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_CANJEES_BY_USUARIO_AND_TIENDA", prms);

            return dt;
        }
        public DataTable GetProductoCanjeadoByCodMovimiento(Decimal CodMovimiento)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodMovimiento;
            prms[0].ParameterName = "@COD_MOVIMIENTO";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_PRODUCTO_CANJEADO_BY_COD_MOVIMIENTO", prms);

            return dt;
        }


        #endregion
    }
}
