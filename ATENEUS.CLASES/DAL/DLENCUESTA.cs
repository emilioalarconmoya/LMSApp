
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
	public class DLENCUESTA : DLBase
	{
		public DLENCUESTA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_ENCUESTA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_ENCUESTA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_ENCUESTA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_ENCUESTA";
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
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EENCUESTA objENCUESTA = obj as EENCUESTA;

            prms[0] = db.GetParameter();
            prms[0].Value = objENCUESTA.CodUnidad;
            prms[0].ParameterName = "@cod_unidad";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(9);
            EENCUESTA objENCUESTA = obj as EENCUESTA;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objENCUESTA.CodUnidad;
            prms[0].ParameterName = "@cod_unidad";

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
            prms[5].Value = objENCUESTA.Puntaje;
            prms[5].ParameterName = "@puntaje";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objENCUESTA.Comentarios;
            prms[6].ParameterName = "@Comentarios";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objENCUESTA.EstaIncluida;
            prms[7].ParameterName = "@Esta_incluida";

            prms[8] = db.GetParameter();
            prms[8].Value = objENCUESTA.CodEmpresa;
            prms[8].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(8);
            EENCUESTA objENCUESTA = obj as EENCUESTA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objENCUESTA.CodUnidad;
            prms[0].ParameterName = "@cod_unidad";
            	
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
            prms[5].Value = objENCUESTA.Puntaje;
            prms[5].ParameterName = "@puntaje";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objENCUESTA.Comentarios;
            prms[6].ParameterName = "@Comentarios";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objENCUESTA.EstaIncluida;
            prms[7].ParameterName = "@Esta_incluida";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EENCUESTA objRoot = obj as EENCUESTA;

            objRoot.CodUnidad = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EENCUESTA objENCUESTA = obj as EENCUESTA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objENCUESTA.CodUnidad = Utiles.ConvertToInt16(dr["cod_unidad"]);
            
            objENCUESTA.CodPregunta =Utiles.ConvertToInt16( dr["cod_pregunta"]);
            
            objENCUESTA.CodActivUsr = Utiles.ConvertToDecimal(dr["cod_activ_usr"]);

            objENCUESTA.FechaHora = Utiles.ConvertToDateTime(dr["Fecha_hora"]);
            
            objENCUESTA.TextoRespuesta = Utiles.ConvertToString(dr["Texto_respuesta"]);
            
            objENCUESTA.Puntaje = Utiles.ConvertToDouble(dr["puntaje"]);
            
            objENCUESTA.Comentarios = Utiles.ConvertToString(dr["Comentarios"]);
            
            objENCUESTA.EstaIncluida = Utiles.ConvertToBoolean(dr["Esta_incluida"]);
            
        }

        #endregion

	}
}
