
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
    public class DLPREGUNTAUNIDADList : DLGenericBaseList<EPREGUNTAUNIDAD>
	{
		public DLPREGUNTAUNIDADList()
		{
            this._proc_select_all = "proc_select_PREGUNTA_UNIDAD_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EPREGUNTAUNIDAD> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public List<EPREGUNTAUNIDAD> PreguntasUnidad(Int16 CodUnidad)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodUnidad;
            prms[0].ParameterName = "@COD_UNIDAD";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_preguntas_unidad", prms);

            List<EPREGUNTAUNIDAD> lst = new List<EPREGUNTAUNIDAD>();

            while (dr.Read())
            {
                EPREGUNTAUNIDAD objPreguntaUnidad = new EPREGUNTAUNIDAD();

                objPreguntaUnidad.CodUnidad= Utiles.ConvertToInt16(dr["cod_unidad"]);

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

                lst[i].Pregunta = objPre.PreguntaUnidad(lst[i].CodPregunta);
            }

           
            
            return lst;
        }

        public DataTable PreguntasUnidadApp(int codUnidad)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = codUnidad;
            prms[0].ParameterName = "@COD_UNIDAD";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_preguntas_unidad_app", prms);

            return dt;
        }
        public List<EPREGUNTAUNIDAD> PreguntasEvaluadas(Int16 CodUnidad, Int64 CodActivUsr,Int64 CodEmpresa)
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

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_preguntas_evaluadas", prms);

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


        public List<EPREGUNTAUNIDAD> PreguntasEncuestadas(Int16 CodUnidad, Int64 CodActivUsr,Int64 CodEmpresa)
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

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_preguntas_encuestadas", prms);

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
