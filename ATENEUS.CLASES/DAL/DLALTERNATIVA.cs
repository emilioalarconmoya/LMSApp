
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLALTERNATIVA.
	/// </summary>
	public class DLALTERNATIVA : DLBase
	{
		public DLALTERNATIVA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_ALTERNATIVA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_ALTERNATIVA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_ALTERNATIVA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_ALTERNATIVA";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_alternativa";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EALTERNATIVA objALTERNATIVA = obj as EALTERNATIVA;

            prms[0] = db.GetParameter();
            prms[0].Value = objALTERNATIVA.CodAlternativa;
            prms[0].ParameterName = "@cod_alternativa";

            prms[1] = db.GetParameter();
            prms[1].Value = objALTERNATIVA.CodPregunta;
            prms[1].ParameterName = "@cod_pregunta";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(5);
            EALTERNATIVA objALTERNATIVA = obj as EALTERNATIVA;

            //Poner las rutinas del Tools que se necesiten
            prms[0] = db.GetParameter();
            prms[0].Value = objALTERNATIVA.CodAlternativa;
            prms[0].ParameterName = "@cod_alternativa";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objALTERNATIVA.CodPregunta;
            prms[1].ParameterName = "@cod_pregunta";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objALTERNATIVA.Texto;
            prms[2].ParameterName = "@texto";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objALTERNATIVA.EsCorrecta;
            prms[3].ParameterName = "@es_correcta";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objALTERNATIVA.TextoComentario;
            prms[4].ParameterName = "@texto_comentario";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(5);
            EALTERNATIVA objALTERNATIVA = obj as EALTERNATIVA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objALTERNATIVA.CodAlternativa;
            prms[0].ParameterName = "@cod_alternativa";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objALTERNATIVA.CodPregunta;
            prms[1].ParameterName = "@cod_pregunta";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objALTERNATIVA.Texto;
            prms[2].ParameterName = "@texto";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objALTERNATIVA.EsCorrecta;
            prms[3].ParameterName = "@es_correcta";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objALTERNATIVA.TextoComentario;
            prms[4].ParameterName = "@texto_comentario";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EALTERNATIVA objRoot = obj as EALTERNATIVA;

            objRoot.CodAlternativa = Utiles.ConvertToInt16(id);
        }



        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EALTERNATIVA objALTERNATIVA = obj as EALTERNATIVA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objALTERNATIVA.CodAlternativa = Utiles.ConvertToInt16(dr["cod_alternativa"]);
            
            objALTERNATIVA.CodPregunta = Utiles.ConvertToInt16(dr["cod_pregunta"]);
            
            objALTERNATIVA.Texto = Utiles.ConvertToString(dr["texto"]);
            
            objALTERNATIVA.EsCorrecta = Utiles.ConvertToBoolean(dr["es_correcta"]);

            objALTERNATIVA.TextoComentario = Utiles.ConvertToString(dr["texto_comentario"]);

            
        }

        #endregion

	}
}
