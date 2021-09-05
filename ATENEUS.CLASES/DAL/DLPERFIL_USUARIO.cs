
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLPERFILUSUARIO.
	/// </summary>
	public class DLPERFILUSUARIO : DLBase
	{
		public DLPERFILUSUARIO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_PERFIL_USUARIO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_PERFIL_USUARIO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_PERFIL_USUARIO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_PERFIL_USUARIO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_perfil";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EPERFILUSUARIO objPERFILUSUARIO = obj as EPERFILUSUARIO;

            prms[0] = db.GetParameter();
            prms[0].Value = objPERFILUSUARIO.CodPerfil;
            prms[0].ParameterName = "@cod_perfil";

            prms[1] = db.GetParameter();
            prms[1].Value = objPERFILUSUARIO.RutUsuario;
            prms[1].ParameterName = "@RUT_USUARIO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EPERFILUSUARIO objPERFILUSUARIO = obj as EPERFILUSUARIO;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objPERFILUSUARIO.CodPerfil;
            prms[0].ParameterName = "@cod_perfil";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPERFILUSUARIO.RutUsuario;
            prms[1].ParameterName = "@rut_usuario";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EPERFILUSUARIO objPERFILUSUARIO = obj as EPERFILUSUARIO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPERFILUSUARIO.CodPerfil;
            prms[0].ParameterName = "@cod_perfil";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPERFILUSUARIO.RutUsuario;
            prms[1].ParameterName = "@rut_usuario";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EPERFILUSUARIO objRoot = obj as EPERFILUSUARIO;

            objRoot.CodPerfil = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EPERFILUSUARIO objPERFILUSUARIO = obj as EPERFILUSUARIO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objPERFILUSUARIO.CodPerfil = Utiles.ConvertToInt16(dr["cod_perfil"]);

            objPERFILUSUARIO.RutUsuario = Utiles.ConvertToInt64(dr["rut_usuario"]);
            
        }

        #endregion

	}
}
