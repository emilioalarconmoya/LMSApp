
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLATRIBUTOUSUARIO.
	/// </summary>
	public class DLATRIBUTOUSUARIO : DLBase
	{
		public DLATRIBUTOUSUARIO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_ATRIBUTO_USUARIO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_ATRIBUTO_USUARIO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_ATRIBUTO_USUARIO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_ATRIBUTO_USUARIO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_atributo";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EATRIBUTOUSUARIO objATRIBUTOUSUARIO = obj as EATRIBUTOUSUARIO;

            prms[0] = db.GetParameter();
            prms[0].Value = objATRIBUTOUSUARIO.CodAtributo;
            prms[0].ParameterName = "@cod_atributo";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EATRIBUTOUSUARIO objATRIBUTOUSUARIO = obj as EATRIBUTOUSUARIO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objATRIBUTOUSUARIO.RutUsuario;
            prms[1].ParameterName = "@rut_usuario";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EATRIBUTOUSUARIO objATRIBUTOUSUARIO = obj as EATRIBUTOUSUARIO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objATRIBUTOUSUARIO.CodAtributo;
            prms[0].ParameterName = "@cod_atributo";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objATRIBUTOUSUARIO.RutUsuario;
            prms[1].ParameterName = "@rut_usuario";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EATRIBUTOUSUARIO objRoot = obj as EATRIBUTOUSUARIO;

            objRoot.CodAtributo = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EATRIBUTOUSUARIO objATRIBUTOUSUARIO = obj as EATRIBUTOUSUARIO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objATRIBUTOUSUARIO.CodAtributo = Utiles.ConvertToInt16(dr["cod_atributo"]);

            objATRIBUTOUSUARIO.RutUsuario = Utiles.ConvertToInt64(dr["rut_usuario"]);
            
        }

        #endregion

	}
}
