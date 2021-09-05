
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLMALLAACTUSUARIO.
	/// </summary>
	public class DLMALLAACTUSUARIO : DLBase
	{
		public DLMALLAACTUSUARIO()
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
            return "proc_update_MALLA_ACT_USUARIO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_activ_usr";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EMALLAACTUSUARIO objMALLAACTUSUARIO = obj as EMALLAACTUSUARIO;

            //prms[0] = db.GetParameter();
            //prms[0].Value = objMALLAACTUSUARIO.RutUsuario;
            //prms[0].ParameterName = "@cod_activ_usr";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EMALLAACTUSUARIO objMALLAACTUSUARIO = obj as EMALLAACTUSUARIO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objMALLAACTUSUARIO.CodMalla;
            prms[1].ParameterName = "@Cod_Malla";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objMALLAACTUSUARIO.NroAsignacion;
            prms[2].ParameterName = "@nro_asignacion";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            EMALLAACTUSUARIO objMALLAACTUSUARIO = obj as EMALLAACTUSUARIO;

            //Poner las rutinas del Tools que se necesiten
            	
            //prms[0] = db.GetParameter();
            //prms[0].Value = objMALLAACTUSUARIO.CodActivUsr;
            //prms[0].ParameterName = "@cod_activ_usr";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objMALLAACTUSUARIO.CodMalla;
            prms[1].ParameterName = "@Cod_Malla";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objMALLAACTUSUARIO.NroAsignacion;
            prms[2].ParameterName = "@nro_asignacion";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EMALLAACTUSUARIO objRoot = obj as EMALLAACTUSUARIO;

            //objRoot.CodActivUsr = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EMALLAACTUSUARIO objMALLAACTUSUARIO = obj as EMALLAACTUSUARIO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objMALLAACTUSUARIO.CodMalla = Convert.ToInt32(dr["COD_MALLA"]);
            
            objMALLAACTUSUARIO.NombreMalla = Convert.ToString(dr["nombre_malla"]);

            objMALLAACTUSUARIO.RutUsuario = Utiles.ConvertToInt32(dr["rut_usuario"]);

            objMALLAACTUSUARIO.NombreUsuario = Convert.ToString(dr["nombre"]);

            objMALLAACTUSUARIO.NroAsignacion = Utiles.ConvertToInt32(dr["nro_asignacion"]);

            objMALLAACTUSUARIO.Vigente = Convert.ToBoolean(dr["flag_vigente"]);

        }

        #endregion

	}
}
