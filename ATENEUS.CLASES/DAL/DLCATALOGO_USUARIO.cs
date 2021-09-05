
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLTIPOACTIVIDAD.
	/// </summary>
	public class DLCATALOGOUSUARIO : DLBase
	{
		public DLCATALOGOUSUARIO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_CATALOGO_USUARIO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_CATALOGO_USUARIO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_CATALOGO_USUARIO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_CATALOGO_USUARIO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_CATALOGO_usuario";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ECATALOGOUSUARIO objCATALOGOUSUARIO = obj as ECATALOGOUSUARIO;

            prms[0] = db.GetParameter();
            prms[0].Value = objCATALOGOUSUARIO.RutUsuario;
            prms[0].ParameterName = "@rut_usuario";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            ECATALOGOUSUARIO objCATALOGOUSUARIO = obj as ECATALOGOUSUARIO;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objCATALOGOUSUARIO.Codcatalogo;
            prms[0].ParameterName = "@cod_CATALOGO";

            prms[1] = db.GetParameter();
            prms[1].Value = objCATALOGOUSUARIO.RutUsuario;
            prms[1].ParameterName = "@rut_usuario";

            prms[2] = db.GetParameter();
            prms[2].Value = objCATALOGOUSUARIO.CodEmpresa;
            prms[2].ParameterName = "@cod_empresa";



            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            ECATALOGOUSUARIO objCATALOGOUSUARIO = obj as ECATALOGOUSUARIO;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objCATALOGOUSUARIO.Codcatalogo;
            prms[0].ParameterName = "@cod_CATALOGO_usuario";

            prms[1] = db.GetParameter();
            prms[1].Value = objCATALOGOUSUARIO.RutUsuario;
            prms[1].ParameterName = "@rut_usuario";

            prms[2] = db.GetParameter();
            prms[2].Value = objCATALOGOUSUARIO.CodEmpresa;
            prms[2].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ECATALOGOUSUARIO objRoot = obj as ECATALOGOUSUARIO;

            objRoot.Codcatalogo = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ECATALOGOUSUARIO objCATALOGOUSUARIO = obj as ECATALOGOUSUARIO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objCATALOGOUSUARIO.Codcatalogo = Utiles.ConvertToInt16(dr["cod_CATALOGO"]);
            
            objCATALOGOUSUARIO.RutUsuario = Utiles.ConvertToInt16(dr["rut_usuario"]);

            objCATALOGOUSUARIO.CodEmpresa = Utiles.ConvertToInt64(dr["cod_empresa"]);

        }

        #endregion
        public Boolean ExisteEnCATALOGOUsuario(int codActividad, long rutUsuario)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = codActividad;
            prms[0].ParameterName = "@COD_ACTIVIDAD";

            prms[1] = db.GetParameter();
            prms[1].Value = rutUsuario;
            prms[1].ParameterName = "@RUT_USUARIO";
            

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_existe_en_CATALOGO_actividad", prms);

            if (dt.Rows.Count > 0)
            {
                return Convert.ToBoolean(dt.Rows[0][0]);
            }
            else
            {
                return false;
            }
        }

        public DataTable SelectActividadesVigentesPortal(long rutUsuario, Int64 codEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = rutUsuario;
            prms[0].ParameterName = "@rut";

            prms[1] = db.GetParameter();
            prms[1].Value = codEmpresa;
            prms[1].ParameterName = "@cod_empresa";


            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "[proc_select_catalogo_usuario_por_rut]", prms);

            return dt;
        }

       
    }
}
