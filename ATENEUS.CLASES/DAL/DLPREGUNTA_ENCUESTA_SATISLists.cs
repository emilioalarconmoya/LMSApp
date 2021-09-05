
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
	/// Summary description for DLPREGUNTAUNIDADList.
	/// </summary>
    public class DLPREGUNTAENCUESTASATISList : DLGenericBaseList<EPREGUNTAENCUESTASATIS>
	{
		public DLPREGUNTAENCUESTASATISList()
		{
            this._proc_select_all = "proc_select_PREGUNTA_UNIDAD_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EPREGUNTAENCUESTASATIS> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public List<EPREGUNTAENCUESTASATIS> PreguntasEncuesta(Int16 CodEncuesta)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodEncuesta;
            prms[0].ParameterName = "@COD_ENCUESTA_SATISFACCION";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_PREGUNTA_ENCUESTA_SATIS", prms);

            List<EPREGUNTAENCUESTASATIS> lst = new List<EPREGUNTAENCUESTASATIS>();

            while (dr.Read())
            {
                EPREGUNTAENCUESTASATIS objPreguntaUnidad = new EPREGUNTAENCUESTASATIS();

                objPreguntaUnidad.CodEncuestaSatisfaccion= Utiles.ConvertToInt16(dr["COD_ENCUESTA_SATISFACCION"]);

                objPreguntaUnidad.CodPregunta = Utiles.ConvertToInt16(dr["cod_pregunta"]);

                objPreguntaUnidad.PuntajeMax = Utiles.ConvertToDouble(dr["PUNTAJE_MAX"]);

                objPreguntaUnidad.Imagen = Utiles.ConvertToString(dr["imagen"]);

                objPreguntaUnidad.Ancho = Utiles.ConvertToString(dr["ancho"]);

                objPreguntaUnidad.Alto = Utiles.ConvertToString(dr["alto"]);

                objPreguntaUnidad.Link = Utiles.ConvertToString(dr["link"]);

                objPreguntaUnidad.UrlVideo = Utiles.ConvertToString(dr["url_video"]);
                /*DLPREGUNTA  objPre = new DLPREGUNTA();

                objPreguntaUnidad.Pregunta = objPre.PreguntaUnidad(Utiles.ConvertToInt16(dr["cod_pregunta"]));*/

                lst.Add(objPreguntaUnidad);
            }

            dr.Close();

            for (int i=0; i <= lst.Count - 1; i++)
            {
                DLPREGUNTA objPre = new DLPREGUNTA();

                lst[i].Pregunta = objPre.PreguntaEncuestaSatisfaccion(lst[i].CodPregunta);
            }

            return lst;
        }


        public List<EPREGUNTAENCUESTASATIS> PreguntasEvaluadas(Int16 Codencuesta, Int64 CodActivUsr,Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = Codencuesta;
            prms[0].ParameterName = "@COD_ENCUESTA_SATISFACCION";

            prms[1] = db.GetParameter();
            prms[1].Value = CodActivUsr;
            prms[1].ParameterName = "@COD_ACTIV_USR";

            prms[2] = db.GetParameter();
            prms[2].Value = CodEmpresa;
            prms[2].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_preguntas_evaluadas_encuesta_satis", prms);

            List<EPREGUNTAENCUESTASATIS> lst = new List<EPREGUNTAENCUESTASATIS>();

            while (dr.Read())
            {
                EPREGUNTAENCUESTASATIS objPreguntaUnidad = new EPREGUNTAENCUESTASATIS();

                objPreguntaUnidad.CodEncuestaSatisfaccion = Utiles.ConvertToInt16(dr["cod_encuesta_satisfaccion"]);

                objPreguntaUnidad.CodPregunta = Utiles.ConvertToInt16(dr["cod_pregunta"]);

                objPreguntaUnidad.PuntajeMax = Utiles.ConvertToDouble(dr["PUNTAJE_MAX"]);

                objPreguntaUnidad.Imagen = Utiles.ConvertToString(dr["imagen"]);

                objPreguntaUnidad.Ancho = Utiles.ConvertToString(dr["ancho"]);

                objPreguntaUnidad.Alto = Utiles.ConvertToString(dr["alto"]);

                objPreguntaUnidad.Link = Utiles.ConvertToString(dr["link"]);

                objPreguntaUnidad.UrlVideo = Utiles.ConvertToString(dr["url_video"]);

                lst.Add(objPreguntaUnidad);
            }

            dr.Close();

            for (int i = 0; i <= lst.Count - 1; i++)
            {
                DLPREGUNTA objPre = new DLPREGUNTA();

                lst[i].Pregunta = objPre.PreguntaUnidad(lst[i].CodPregunta);
            }

            return lst;
        }


        public List<EPREGUNTAENCUESTASATIS> PreguntasEncuestadas(Int16 Codencuesta, Int64 CodActivUsr,Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = Codencuesta;
            prms[0].ParameterName = "@COD_ENCUESTA_SATISFACCION";

            prms[1] = db.GetParameter();
            prms[1].Value = CodActivUsr;
            prms[1].ParameterName = "@COD_ACTIV_USR";

            prms[2] = db.GetParameter();
            prms[2].Value = CodEmpresa;
            prms[2].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_preguntas_evaluadas_encuesta_satis", prms);

            List<EPREGUNTAENCUESTASATIS> lst = new List<EPREGUNTAENCUESTASATIS>();

            while (dr.Read())
            {
                EPREGUNTAENCUESTASATIS objPreguntaUnidad = new EPREGUNTAENCUESTASATIS();

                objPreguntaUnidad.CodEncuestaSatisfaccion = Utiles.ConvertToInt16(dr["cod_encuesta_satisfaccion"]);

                objPreguntaUnidad.CodPregunta = Utiles.ConvertToInt16(dr["cod_pregunta"]);

                objPreguntaUnidad.PuntajeMax = Utiles.ConvertToDouble(dr["PUNTAJE_MAX"]);

                objPreguntaUnidad.Imagen = Utiles.ConvertToString(dr["imagen"]);

                objPreguntaUnidad.Ancho = Utiles.ConvertToString(dr["ancho"]);

                objPreguntaUnidad.Alto = Utiles.ConvertToString(dr["alto"]);

                objPreguntaUnidad.Link = Utiles.ConvertToString(dr["link"]);

                objPreguntaUnidad.UrlVideo = Utiles.ConvertToString(dr["url_video"]);

                lst.Add(objPreguntaUnidad);
            }

            dr.Close();

            for (int i = 0; i <= lst.Count - 1; i++)
            {
                DLPREGUNTA objPre = new DLPREGUNTA();

                lst[i].Pregunta = objPre.PreguntaEncuestaSatisfaccion(lst[i].CodPregunta);
            }

            return lst;
        }

        public List<EPREGUNTAUNIDAD> PreguntasEncuestadasDeSatisfaccion(Int16 CodUnidad, Int64 CodActivUsr, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = CodUnidad;
            prms[0].ParameterName = "@COD_UNIDAD";

            prms[1] = db.GetParameter();
            prms[1].Value = CodActivUsr;
            prms[1].ParameterName = "@COD_ACTIV_USR";

            prms[2] = db.GetParameter();
            prms[2].Value = CodEmpresa;
            prms[2].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "[proc_preguntas_encuestadas_de_satisfaccion]", prms);

            List<EPREGUNTAUNIDAD> lst = new List<EPREGUNTAUNIDAD>();

            while (dr.Read())
            {
                EPREGUNTAUNIDAD objPreguntaUnidad = new EPREGUNTAUNIDAD();

                objPreguntaUnidad.CodUnidad = Utiles.ConvertToInt16(dr["cod_pregunta"]);

                objPreguntaUnidad.CodPregunta = Utiles.ConvertToInt16(dr["cod_pregunta"]);

                objPreguntaUnidad.PuntajeMax = Utiles.ConvertToDouble(dr["PUNTAJE_MAX"]);

                objPreguntaUnidad.Imagen = Utiles.ConvertToString(dr["imagen"]);

                objPreguntaUnidad.Ancho = Utiles.ConvertToString(dr["ancho"]);

                objPreguntaUnidad.Alto = Utiles.ConvertToString(dr["alto"]);

                objPreguntaUnidad.Link = Utiles.ConvertToString(dr["link"]);

                lst.Add(objPreguntaUnidad);
            }

            dr.Close();

            for (int i = 0; i <= lst.Count - 1; i++)
            {
                DLPREGUNTA objPre = new DLPREGUNTA();

                lst[i].Pregunta = objPre.PreguntaUnidad(lst[i].CodPregunta);
            }

            return lst;
        }

        #endregion
    }
}
