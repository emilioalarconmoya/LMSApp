
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLEVALUACION.
	/// </summary>
	public class DLEVALUACION : DLBase
	{
		public DLEVALUACION()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_EVALUACION";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_EVALUACION";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_EVALUACION";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_EVALUACION";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_unidad";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EEVALUACION objEVALUACION = obj as EEVALUACION;

            prms[0] = db.GetParameter();
            prms[0].Value = objEVALUACION.CodActivUsr;
            prms[0].ParameterName = "@COD_ACTIV_USR";

            prms[1] = db.GetParameter();
            prms[1].Value = objEVALUACION.CodUnidad;
            prms[1].ParameterName = "@cod_unidad";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(11);
            EEVALUACION objEVALUACION = obj as EEVALUACION;

            prms[0] = db.GetParameter();
            prms[0].Value = objEVALUACION.CodActivUsr;
            prms[0].ParameterName = "@cod_activ_usr";

            //Poner las rutinas del Tools que se necesiten

            prms[1] = db.GetParameter();
            prms[1].Value = objEVALUACION.CodUnidad;
            prms[1].ParameterName = "@COD_UNIDAD";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objEVALUACION.CodPregunta;
            prms[2].ParameterName = "@cod_pregunta";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objEVALUACION.FechaHora;
            prms[3].ParameterName = "@fecha_hora";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objEVALUACION.TextoRespuesta;
            prms[4].ParameterName = "@texto_respuesta";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objEVALUACION.Puntaje;
            prms[5].ParameterName = "@puntaje";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objEVALUACION.Comentarios;
            prms[6].ParameterName = "@comentarios";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objEVALUACION.EstaIncluida;
            prms[7].ParameterName = "@Esta_incluida";
            	
            prms[8] = db.GetParameter();
            prms[8].Value = objEVALUACION.NroIntentos;
            prms[8].ParameterName = "@NroIntentos";

            prms[9] = db.GetParameter();
            prms[9].Value = objEVALUACION.CodEmpresa;
            prms[9].ParameterName = "@cod_empresa";

            prms[10] = db.GetParameter();
            prms[10].Value = objEVALUACION.AvisaTremino;
            prms[10].ParameterName = "@avisa_termino";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(9);
            EEVALUACION objEVALUACION = obj as EEVALUACION;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objEVALUACION.CodUnidad;
            prms[0].ParameterName = "@cod_unidad";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objEVALUACION.CodPregunta;
            prms[1].ParameterName = "@cod_pregunta";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objEVALUACION.FechaHora;
            prms[2].ParameterName = "@fecha_hora";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objEVALUACION.CodActivUsr;
            prms[3].ParameterName = "@cod_activ_usr";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objEVALUACION.TextoRespuesta;
            prms[4].ParameterName = "@texto_respuesta";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objEVALUACION.Puntaje;
            prms[5].ParameterName = "@puntaje";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objEVALUACION.Comentarios;
            prms[6].ParameterName = "@comentarios";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objEVALUACION.EstaIncluida;
            prms[7].ParameterName = "@Esta_incluida";
            	
            prms[8] = db.GetParameter();
            prms[8].Value = objEVALUACION.NroIntentos;
            prms[8].ParameterName = "@NroIntentos";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EEVALUACION objRoot = obj as EEVALUACION;

            objRoot.CodUnidad = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EEVALUACION objEVALUACION = obj as EEVALUACION;
    
            //Poner las rutinas del Tools que se necesiten
            
            objEVALUACION.CodUnidad = Utiles.ConvertToInt16(dr["cod_unidad"]);
            
            objEVALUACION.CodPregunta = Utiles.ConvertToInt16(dr["cod_pregunta"]);
            
            objEVALUACION.FechaHora = Utiles.ConvertToDateTime(dr["fecha_hora"]);
            
            objEVALUACION.CodActivUsr = Utiles.ConvertToDecimal(dr["cod_activ_usr"]);
            
            objEVALUACION.TextoRespuesta = Utiles.ConvertToString(dr["texto_respuesta"]);
            
            objEVALUACION.Puntaje = Utiles.ConvertToDouble(dr["puntaje"]);
            
            objEVALUACION.Comentarios = Utiles.ConvertToString(dr["comentarios"]);
            
            objEVALUACION.EstaIncluida = Utiles.ConvertToBoolean(dr["Esta_incluida"]);

            objEVALUACION.NroIntentos = Utiles.ConvertToInt32(dr["NroIntentos"]);
            
        }

        #endregion

	}
}
