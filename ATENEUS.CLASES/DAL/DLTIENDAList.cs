

using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLTIENDAList.
	/// </summary>
    public class DLTIENDAList : DLGenericBaseList<ETIENDA>
	{
		public DLTIENDAList()
		{
            this._proc_select_all = "proc_select_TIENDA_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<ETIENDA> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public ETIENDA GetTiendasByCodigo(String Codigo)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = Codigo;
            prms[0].ParameterName = "@cod_accion"; 

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_TIENDA_BY_CODIGO", prms);

            ETIENDA obj = new ETIENDA();

            while (dr.Read())
            {
                obj.CODTIENDA = Utiles.ConvertToString(dr["COD_TIENDA"]);

                obj.CODATRIBUTO = Utiles.ConvertToInt16(dr["COD_ATRIBUTO"]);

                obj.CODCARACTERISTICA = Utiles.ConvertToInt16(dr["COD_CARACTERISTICA"]);

                obj.NOMBRE = Utiles.ConvertToString(dr["NOMBRE"]);

                obj.INICIO = Utiles.ConvertToDateTime(dr["INICIO"]);

                obj.FIN = Utiles.ConvertToDateTime(dr["FIN"]);
            }
            dr.Close();
            return obj;
        }

        public List<ETIENDA> GetTiendasByNombreAndFechas(String Nombre, DateTime Inicio, DateTime Fin,Int64  CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(4);

            prms[0] = db.GetParameter();
            prms[0].Value = Nombre;
            prms[0].ParameterName = "@NOMBRE";

            prms[1] = db.GetParameter();
            prms[1].Value = Inicio;
            prms[1].ParameterName = "@INICIO";

            prms[2] = db.GetParameter();
            prms[2].Value = Fin;
            prms[2].ParameterName = "@FIN";

            prms[3] = db.GetParameter();
            prms[3].Value = CodEmpresa;
            prms[3].ParameterName = "@cod_empresa";


            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_TIENDA_BY_NOMBRE_AND_FECHAS", prms);

            return GetCollection(dr);
        }

        public List<ETIENDA> GetTiendasActivasByRut(Int64 RutUsuario)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = RutUsuario;
            prms[0].ParameterName = "@RUT"; 

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_TIENDAS_ACTIVAS_BY_USUARIO", prms);

            return GetCollection(dr);
        }

        public DataTable GetTiendasByCodigoTienda(String CodigoTienda)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodigoTienda;
            prms[0].ParameterName = "@COD_TIENDA";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_PRODUCTO_BY_COD_TIENDA", prms);

            return dt;
        }

        public DataTable GetProductosTiendaActiva(String CodigoTienda, Int16 CodCategoria)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = CodigoTienda;
            prms[0].ParameterName = "@COD_TIENDA";

            prms[1] = db.GetParameter();
            prms[1].Value = CodCategoria;
            prms[1].ParameterName = "@COD_CATEGORIA";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_PRODUCTOS_BY_TIENDA_ACTIVA", prms);

            return dt;
        }

        public DataTable GetProductosTiendaActiva(String CodigoTienda, Int16 CodCategoria, Int64 RutUsuario)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = CodigoTienda;
            prms[0].ParameterName = "@COD_TIENDA";

            prms[1] = db.GetParameter();
            prms[1].Value = CodCategoria;
            prms[1].ParameterName = "@COD_CATEGORIA";

            prms[2] = db.GetParameter();
            prms[2].Value = RutUsuario;
            prms[2].ParameterName = "@RUT_USUARIO";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_PRODUCTOS_BY_TIENDA_ACTIVA_POR_USUARIO", prms);

            return dt;
        }

        #endregion
    }
}
