
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLPREGUNTAFRECUENTE.
	/// </summary>
	public class DLPREGUNTAFRECUENTE : DLBase
	{
		public DLPREGUNTAFRECUENTE()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_PREGUNTA_FRECUENTE";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_PREGUNTA_FRECUENTE";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_PREGUNTA_FRECUENTE";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_PREGUNTA_FRECUENTE";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_pregunta";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EPREGUNTAFRECUENTE objPREGUNTAFRECUENTE = obj as EPREGUNTAFRECUENTE;

            prms[0] = db.GetParameter();
            prms[0].Value = objPREGUNTAFRECUENTE.CodPregunta;
            prms[0].ParameterName = "@cod_pregunta";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(5);
            EPREGUNTAFRECUENTE objPREGUNTAFRECUENTE = obj as EPREGUNTAFRECUENTE;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPREGUNTAFRECUENTE.CodActividad;
            prms[1].ParameterName = "@cod_actividad";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objPREGUNTAFRECUENTE.TextoPregunta;
            prms[2].ParameterName = "@texto_pregunta";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objPREGUNTAFRECUENTE.TextoRespuesta;
            prms[3].ParameterName = "@texto_respuesta";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objPREGUNTAFRECUENTE.Mostrar;
            prms[4].ParameterName = "@mostrar";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objPREGUNTAFRECUENTE.OrdenRelativo;
            prms[5].ParameterName = "@orden_relativo";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(6);
            EPREGUNTAFRECUENTE objPREGUNTAFRECUENTE = obj as EPREGUNTAFRECUENTE;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPREGUNTAFRECUENTE.CodPregunta;
            prms[0].ParameterName = "@cod_pregunta";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPREGUNTAFRECUENTE.CodActividad;
            prms[1].ParameterName = "@cod_actividad";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objPREGUNTAFRECUENTE.TextoPregunta;
            prms[2].ParameterName = "@texto_pregunta";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objPREGUNTAFRECUENTE.TextoRespuesta;
            prms[3].ParameterName = "@texto_respuesta";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objPREGUNTAFRECUENTE.Mostrar;
            prms[4].ParameterName = "@mostrar";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objPREGUNTAFRECUENTE.OrdenRelativo;
            prms[5].ParameterName = "@orden_relativo";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EPREGUNTAFRECUENTE objRoot = obj as EPREGUNTAFRECUENTE;

            objRoot.CodPregunta = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EPREGUNTAFRECUENTE objPREGUNTAFRECUENTE = obj as EPREGUNTAFRECUENTE;
    
            //Poner las rutinas del Tools que se necesiten
            
            objPREGUNTAFRECUENTE.CodPregunta = Utiles.ConvertToDecimal(dr["cod_pregunta"]);
            
            objPREGUNTAFRECUENTE.CodActividad = Utiles.ConvertToInt16(dr["cod_actividad"]);
            
            objPREGUNTAFRECUENTE.TextoPregunta = Utiles.ConvertToString(dr["texto_pregunta"]);
            
            objPREGUNTAFRECUENTE.TextoRespuesta = Utiles.ConvertToString(dr["texto_respuesta"]);
            
            objPREGUNTAFRECUENTE.Mostrar = Utiles.ConvertToBoolean(dr["mostrar"]);

            objPREGUNTAFRECUENTE.OrdenRelativo = Utiles.ConvertToInt16(dr["orden_relativo"]);
            
        }

        #endregion

	}
}
