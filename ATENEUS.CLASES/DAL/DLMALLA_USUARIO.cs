using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
    public class DLMALLAUSUARIO : DLBase
    {
        public DLMALLAUSUARIO()
        {
        }

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_MALLA_ACT_USUARIO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_MALLA_ACT_USUARIO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_MALLA_ACT_USUARIO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_MALLA_USUARIO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@rut_usuario";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EMALLAUSUARIO objMALLAACTUSUARIO = obj as EMALLAUSUARIO;

            prms[0] = db.GetParameter();
            prms[0].Value = objMALLAACTUSUARIO.RutUsuario;
            prms[0].ParameterName = "@rut_usuario";
			
			prms[1] = db.GetParameter();
            prms[1].Value = objMALLAACTUSUARIO.CodEmpresa; 
            prms[1].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(5);
            EMALLAUSUARIO objMALLAACTUSUARIO = obj as EMALLAUSUARIO;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objMALLAACTUSUARIO.CodMalla;
            prms[0].ParameterName = "@Cod_Malla";

            prms[1] = db.GetParameter();
            prms[1].Value = objMALLAACTUSUARIO.RutUsuario;
            prms[1].ParameterName = "@rut_usuario";

            prms[2] = db.GetParameter();
            prms[2].Value = objMALLAACTUSUARIO.NroAsignacion;
            prms[2].ParameterName = "@nro_asignacion";

            prms[3] = db.GetParameter();
            prms[3].Value = objMALLAACTUSUARIO.Vigente;
            prms[3].ParameterName = "@vigente";
			
			prms[4] = db.GetParameter();
            prms[4].Value = objMALLAACTUSUARIO.CodEmpresa; 
            prms[4].ParameterName = "@cod_empresa";



            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(5);
            EMALLAUSUARIO objMALLAACTUSUARIO = obj as EMALLAUSUARIO;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objMALLAACTUSUARIO.RutUsuario;
            prms[0].ParameterName = "@rut_usuario";

            prms[1] = db.GetParameter();
            prms[1].Value = objMALLAACTUSUARIO.CodMalla;
            prms[1].ParameterName = "@Cod_Malla";

            prms[2] = db.GetParameter();
            prms[2].Value = objMALLAACTUSUARIO.NroAsignacion;
            prms[2].ParameterName = "@nro_asignacion";

            prms[3] = db.GetParameter();
            prms[3].Value = objMALLAACTUSUARIO.Vigente;
            prms[3].ParameterName = "@vigente";
			
			prms[4] = db.GetParameter();
            prms[4].Value = objMALLAACTUSUARIO.CodEmpresa; 
            prms[4].ParameterName = "@cod_empresa";

            return prms;
        }

        public void UpdateMallaUsuario(long RutUsuario, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = RutUsuario;
            prms[0].ParameterName = "@rut_usuario";
			
			prms[1] = db.GetParameter();
            prms[1].Value = CodEmpresa; 
            prms[1].ParameterName = "@cod_empresa";

            db.ExecuteNonQuery(CommandType.StoredProcedure, "proc_update_MALLA_USUARIO_vigencia", prms);

            
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EMALLAUSUARIO objRoot = obj as EMALLAUSUARIO;

            objRoot.RutUsuario = Convert.ToInt32(id);
        }

        #endregion

        #region Public Methods

        public override void Fill(DomainObject obj, IDataReader dr)
        {
            EMALLAUSUARIO objMALLAACTUSUARIO = obj as EMALLAUSUARIO;

            //Poner las rutinas del Tools que se necesiten

            objMALLAACTUSUARIO.RutUsuario = Utiles.ConvertToInt32(dr["rut_usuario"]);

            objMALLAACTUSUARIO.CodMalla = Utiles.ConvertToInt32(dr["Cod_Malla"]);

            objMALLAACTUSUARIO.NroAsignacion = Utiles.ConvertToInt32(dr["nro_asignacion"]);

            objMALLAACTUSUARIO.NombreMalla = Convert.ToString(dr["NOMBRE_MALLA"]);

            objMALLAACTUSUARIO.NombreUsuario = Convert.ToString(dr["NOMBRE"]);

            objMALLAACTUSUARIO.Vigente = Convert.ToBoolean(dr["flag_vigente"]);

			objMALLAACTUSUARIO.CodEmpresa = Convert.ToInt64(dr["COD_EMPRESA"]);


        }

        #endregion
    }
}
