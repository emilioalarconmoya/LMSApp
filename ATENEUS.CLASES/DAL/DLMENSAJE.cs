
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLMENSAJE.
	/// </summary>
	public class DLMENSAJE : DLBase
	{
		public DLMENSAJE()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_MENSAJE";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_MENSAJE";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_MENSAJE";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_MENSAJE";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_mensaje";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EMENSAJE objMENSAJE = obj as EMENSAJE;

            prms[0] = db.GetParameter();
            prms[0].Value = objMENSAJE.CodMensaje;
            prms[0].ParameterName = "@cod_mensaje";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(7);
            EMENSAJE objMENSAJE = obj as EMENSAJE;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objMENSAJE.CodActividad;
            prms[1].ParameterName = "@cod_actividad";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objMENSAJE.RutUsuarioDest;
            prms[2].ParameterName = "@rut_usuario_dest";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objMENSAJE.RutUsuarioOrigen;
            prms[3].ParameterName = "@rut_usuario_origen";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objMENSAJE.FechaHora;
            prms[4].ParameterName = "@fecha_hora";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objMENSAJE.TextoMensaje;
            prms[5].ParameterName = "@texto_mensaje";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objMENSAJE.Estado;
            prms[6].ParameterName = "@estado";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objMENSAJE.Visto;
            prms[7].ParameterName = "@Visto";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(8);
            EMENSAJE objMENSAJE = obj as EMENSAJE;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objMENSAJE.CodMensaje;
            prms[0].ParameterName = "@cod_mensaje";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objMENSAJE.CodActividad;
            prms[1].ParameterName = "@cod_actividad";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objMENSAJE.RutUsuarioDest;
            prms[2].ParameterName = "@rut_usuario_dest";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objMENSAJE.RutUsuarioOrigen;
            prms[3].ParameterName = "@rut_usuario_origen";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objMENSAJE.FechaHora;
            prms[4].ParameterName = "@fecha_hora";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objMENSAJE.TextoMensaje;
            prms[5].ParameterName = "@texto_mensaje";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objMENSAJE.Estado;
            prms[6].ParameterName = "@estado";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objMENSAJE.Visto;
            prms[7].ParameterName = "@Visto";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EMENSAJE objRoot = obj as EMENSAJE;

            objRoot.CodMensaje = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EMENSAJE objMENSAJE = obj as EMENSAJE;
    
            //Poner las rutinas del Tools que se necesiten

            objMENSAJE.CodMensaje = Utiles.ConvertToDecimal(dr["cod_mensaje"]);
            
            objMENSAJE.CodActividad = Utiles.ConvertToInt16(dr["cod_actividad"]);
            
            objMENSAJE.RutUsuarioDest = Utiles.ConvertToInt64(dr["rut_usuario_dest"]);
            
            objMENSAJE.RutUsuarioOrigen = Utiles.ConvertToInt64(dr["rut_usuario_origen"]);
            
            objMENSAJE.FechaHora = Utiles.ConvertToDateTime(dr["fecha_hora"]);
            
            objMENSAJE.TextoMensaje = Utiles.ConvertToString(dr["texto_mensaje"]);
            
            objMENSAJE.Estado = Utiles.ConvertToBoolean(dr["estado"]);
            
            objMENSAJE.Visto = Utiles.ConvertToBoolean(dr["Visto"]);
            
        }

        #endregion

	}
}
