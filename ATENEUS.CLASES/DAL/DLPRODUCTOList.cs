

using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLPRODUCTOList.
	/// </summary>
    public class DLPRODUCTOList : DLGenericBaseList<EPRODUCTO>
	{
		public DLPRODUCTOList()
		{
            this._proc_select_all = "proc_select_PRODUCTO_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EPRODUCTO> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }
        public EPRODUCTO GetProductoByCodigo(String Codigo)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = Codigo;
            prms[0].ParameterName = "@COD_PRODUCTO";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_PRODUCTO", prms);

            EPRODUCTO objPRODUCTO = new EPRODUCTO();

            while (dr.Read())
            {
                objPRODUCTO.CODPRODUCTO = Utiles.ConvertToString(dr["COD_PRODUCTO"]);

                objPRODUCTO.CODCATEGORIA = Utiles.ConvertToInt16(dr["COD_CATEGORIA"]);

                objPRODUCTO.NOMBRE = Utiles.ConvertToString(dr["NOMBRE"]);

                objPRODUCTO.DESCRIPCION = Utiles.ConvertToString(dr["DESCRIPCION"]);

                objPRODUCTO.FOTO = Utiles.ConvertToString(dr["FOTO"]);
            }
            dr.Close();
            return objPRODUCTO;
        }
        public DataTable GetProductoByNombreAndCategoria(String Nombre, Int16 CodCategoria,Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = Nombre;
            prms[0].ParameterName = "@NOMBRE";

            prms[1] = db.GetParameter();
            prms[1].Value = CodCategoria;
            prms[1].ParameterName = "@COD_CATEGORIA";

            prms[2] = db.GetParameter();
            prms[2].Value = CodEmpresa;
            prms[2].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_PRODUCTO_BY_NOMBRE_AND_CATEGORIA", prms);
                        
            return dt;
        }

        #endregion
    }
}
