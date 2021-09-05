
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLENCUESTA.
	/// </summary>
	public class DLENCUESTASATISUSUARIO : DLBase
	{
		public DLENCUESTASATISUSUARIO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_ENCUESTA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_Encuesta_SATIS_USUARIO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_Encuesta_SATIS_USUARIO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_Encuesta_SATIS_USUARIO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_encuesta_satisfaccion";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EENCUESTA objENCUESTA = obj as EENCUESTA;

            prms[0] = db.GetParameter();
            prms[0].Value = objENCUESTA.CodUnidad;
            prms[0].ParameterName = "@cod_encuesta_satisfaccion";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(6);
            EENCUESTASATISUSUARIO objENCUESTA = obj as EENCUESTASATISUSUARIO;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objENCUESTA.CodEncuestaSatisfaccion;
            prms[0].ParameterName = "@cod_encuesta_satisfaccion";

            prms[1] = db.GetParameter();
            prms[1].Value = objENCUESTA.CodPregunta;
            prms[1].ParameterName = "@cod_pregunta";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objENCUESTA.CodActivUsr;
            prms[2].ParameterName = "@cod_activ_usr";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objENCUESTA.FechaHora;
            prms[3].ParameterName = "@Fecha_hora";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objENCUESTA.TextoRespuesta;
            prms[4].ParameterName = "@Texto_respuesta";

            prms[5] = db.GetParameter();
            prms[5].Value = objENCUESTA.CodEmpresa;
            prms[5].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(6);
            EENCUESTASATISUSUARIO objENCUESTA = obj as EENCUESTASATISUSUARIO;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objENCUESTA.CodEncuestaSatisfaccion;
            prms[0].ParameterName = "@cod_encuesta_satisfaccion";

            prms[1] = db.GetParameter();
            prms[1].Value = objENCUESTA.CodPregunta;
            prms[1].ParameterName = "@cod_pregunta";

            prms[2] = db.GetParameter();
            prms[2].Value = objENCUESTA.CodActivUsr;
            prms[2].ParameterName = "@cod_activ_usr";

            prms[3] = db.GetParameter();
            prms[3].Value = objENCUESTA.FechaHora;
            prms[3].ParameterName = "@Fecha_hora";

            prms[4] = db.GetParameter();
            prms[4].Value = objENCUESTA.TextoRespuesta;
            prms[4].ParameterName = "@Texto_respuesta";

            prms[5] = db.GetParameter();
            prms[5].Value = objENCUESTA.CodEmpresa;
            prms[5].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EENCUESTASATISUSUARIO objRoot = obj as EENCUESTASATISUSUARIO;

            objRoot.CodEncuestaSatisfaccion = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EENCUESTASATISUSUARIO objENCUESTA = obj as EENCUESTASATISUSUARIO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objENCUESTA.CodEncuestaSatisfaccion = Utiles.ConvertToInt16(dr["cod_encuesta_satisfaccion"]);
            
            objENCUESTA.CodPregunta =Utiles.ConvertToInt16( dr["cod_pregunta"]);
            
            objENCUESTA.CodActivUsr = Utiles.ConvertToDecimal(dr["cod_activ_usr"]);

            objENCUESTA.FechaHora = Utiles.ConvertToDateTime(dr["Fecha_hora"]);
            
            objENCUESTA.TextoRespuesta = Utiles.ConvertToString(dr["Texto_respuesta"]);
            
        }

        #endregion

	}
}
