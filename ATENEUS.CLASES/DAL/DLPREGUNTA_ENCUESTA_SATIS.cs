
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLPREGUNTAUNIDAD.
	/// </summary>
	public class DLPREGUNTAENCUESTASATIS : DLBase
	{
		public DLPREGUNTAENCUESTASATIS()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_PREGUNTA_ENCUESTA_SATIS";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_PREGUNTA_ENCUESTA_SATIS";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_PREGUNTA_ENCUESTA_SATIS";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_PREGUNTA_ENCUESTA_SATIS";
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
            EPREGUNTAENCUESTASATIS objPREGUNTAUNIDAD = obj as EPREGUNTAENCUESTASATIS;

            prms[0] = db.GetParameter();
            prms[0].Value = objPREGUNTAUNIDAD.CodEncuestaSatisfaccion;
            prms[0].ParameterName = "@COD_ENCUESTA_SATISFACCION";

            prms[1] = db.GetParameter();
            prms[1].Value = objPREGUNTAUNIDAD.CodPregunta;
            prms[1].ParameterName = "@cod_pregunta";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(8);
            EPREGUNTAENCUESTASATIS objPREGUNTAUNIDAD = obj as EPREGUNTAENCUESTASATIS;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objPREGUNTAUNIDAD.CodEncuestaSatisfaccion;
            prms[0].ParameterName = "@COD_ENCUESTA_SATISFACCION";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPREGUNTAUNIDAD.CodPregunta;
            prms[1].ParameterName = "@cod_pregunta";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objPREGUNTAUNIDAD.PuntajeMax;
            prms[2].ParameterName = "@puntaje_max";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objPREGUNTAUNIDAD.Imagen;
            prms[3].ParameterName = "@imagen";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objPREGUNTAUNIDAD.Ancho;
            prms[4].ParameterName = "@ancho";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objPREGUNTAUNIDAD.Alto;
            prms[5].ParameterName = "@alto";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objPREGUNTAUNIDAD.Link;
            prms[6].ParameterName = "@link";

            prms[7] = db.GetParameter();
            prms[7].Value = objPREGUNTAUNIDAD.UrlVideo;
            prms[7].ParameterName = "@url_video";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(8);
            EPREGUNTAENCUESTASATIS objPREGUNTAUNIDAD = obj as EPREGUNTAENCUESTASATIS;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPREGUNTAUNIDAD.CodEncuestaSatisfaccion;
            prms[0].ParameterName = "@COD_ENCUESTA_SATISFACCION";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPREGUNTAUNIDAD.CodPregunta;
            prms[1].ParameterName = "@cod_pregunta";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objPREGUNTAUNIDAD.PuntajeMax;
            prms[2].ParameterName = "@puntaje_max";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objPREGUNTAUNIDAD.Imagen;
            prms[3].ParameterName = "@imagen";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objPREGUNTAUNIDAD.Ancho;
            prms[4].ParameterName = "@ancho";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objPREGUNTAUNIDAD.Alto;
            prms[5].ParameterName = "@alto";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objPREGUNTAUNIDAD.Link;
            prms[6].ParameterName = "@link";

            prms[7] = db.GetParameter();
            prms[7].Value = objPREGUNTAUNIDAD.UrlVideo;
            prms[7].ParameterName = "@url_video";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EPREGUNTAENCUESTASATIS objRoot = obj as EPREGUNTAENCUESTASATIS;

            objRoot.CodEncuestaSatisfaccion = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EPREGUNTAENCUESTASATIS objPREGUNTAUNIDAD = obj as EPREGUNTAENCUESTASATIS;
    
            //Poner las rutinas del Tools que se necesiten

            objPREGUNTAUNIDAD.CodEncuestaSatisfaccion = Utiles.ConvertToInt16(dr["COD_ENCUESTA_SATISFACCION"]);
            
            objPREGUNTAUNIDAD.CodPregunta = Utiles.ConvertToInt16(dr["cod_pregunta"]);
            
            objPREGUNTAUNIDAD.PuntajeMax = Utiles.ConvertToDouble(dr["puntaje_max"]);
            
            objPREGUNTAUNIDAD.Imagen = Utiles.ConvertToString(dr["imagen"]);
            
            objPREGUNTAUNIDAD.Ancho = Utiles.ConvertToString(dr["ancho"]);
            
            objPREGUNTAUNIDAD.Alto = Utiles.ConvertToString(dr["alto"]);
            
            objPREGUNTAUNIDAD.Link = Utiles.ConvertToString(dr["link"]);

            objPREGUNTAUNIDAD.UrlVideo = Utiles.ConvertToString(dr["url_video"]);

        }

        #endregion

	}
}
