
using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;
using ATENEUS.CLASES.DAO;
//using Moebius.ErrorManagement;
//using ATENEUS.BUSINESS.Collections;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLALTERNATIVAList.
	/// </summary>
    public class DLALTERNATIVAList : DLGenericBaseList<EALTERNATIVA>
	{
		public DLALTERNATIVAList()
		{
            this._proc_select_all = "proc_select_ALTERNATIVA_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EALTERNATIVA> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public List<EALTERNATIVA> AlternativasPregunta(Int16 CodPregunta)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodPregunta;
            prms[0].ParameterName = "@CodPregunta";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_alternativas_pregunta", prms);

            List<EALTERNATIVA> lst = new List<EALTERNATIVA>();

            while (dr.Read())
            {
                EALTERNATIVA objAlternativa = new EALTERNATIVA();

                objAlternativa.CodPregunta = Utiles.ConvertToInt16(dr["cod_pregunta"]);

                objAlternativa.CodAlternativa = Utiles.ConvertToInt16(dr["cod_alternativa"]);

                objAlternativa.Texto = Utiles.ConvertToString(dr["texto"]);

                objAlternativa.EsCorrecta = Utiles.ConvertToBoolean(dr["es_correcta"]);

                objAlternativa.TextoComentario = Utiles.ConvertToString(dr["texto_comentario"]);

                lst.Add(objAlternativa);
            }

            dr.Close();

            return lst;
        }

        public List<EALTERNATIVA> AlternativasPreguntaEncuesta(Int16 CodPregunta)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodPregunta;
            prms[0].ParameterName = "@CodPregunta";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_alternativas_pregunta_encuesta_satis", prms);

            List<EALTERNATIVA> lst = new List<EALTERNATIVA>();

            while (dr.Read())
            {
                EALTERNATIVA objAlternativa = new EALTERNATIVA();

                objAlternativa.CodPregunta = Utiles.ConvertToInt16(dr["cod_pregunta"]);

                objAlternativa.CodAlternativa = Utiles.ConvertToInt16(dr["cod_alternativa"]);

                objAlternativa.Texto = Utiles.ConvertToString(dr["texto"]);

                objAlternativa.EsCorrecta = Utiles.ConvertToBoolean(dr["es_correcta"]);

                objAlternativa.TextoComentario = Utiles.ConvertToString(dr["texto_comentario"]);

                lst.Add(objAlternativa);
            }

            dr.Close();

            return lst;
        }
        #endregion
    }
}
