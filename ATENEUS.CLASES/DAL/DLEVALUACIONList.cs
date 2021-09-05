
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
	/// Summary description for DLEVALUACIONList.
	/// </summary>
    public class DLEVALUACIONList : DLGenericBaseList<EEVALUACION>
	{
		public DLEVALUACIONList()
		{
            this._proc_select_all = "proc_select_EVALUACION_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EEVALUACION> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public List<EEVALUACION> SelectEvaluacionRealizada(long CodActivUsr, Int32 CodUnidad)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActivUsr;
            prms[0].ParameterName = "@COD_ACTIV_USR";

            prms[1] = db.GetParameter();
            prms[1].Value = CodUnidad;
            prms[1].ParameterName = "@COD_UNIDAD";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_evaluacion_realizada", prms);


            List<EEVALUACION> lst = new List<EEVALUACION>();

            while (dr.Read())
            {
                EEVALUACION objEval = new EEVALUACION();

                objEval.CodActivUsr = Utiles.ConvertToDecimal(dr["COD_ACTIV_USR"]);

                objEval.CodUnidad = Utiles.ConvertToInt16(dr["COD_UNIDAD"]);

                objEval.CodPregunta = Utiles.ConvertToInt16(dr["COD_PREGUNTA"]);

                objEval.FechaHora = Utiles.ConvertToDateTime(dr["FECHA_HORA"]);

                objEval.TextoRespuesta = Utiles.ConvertToString(dr["TEXTO_RESPUESTA"]);

                objEval.Puntaje = Utiles.ConvertToDouble(dr["PUNTAJE"]);

                objEval.Comentarios = Utiles.ConvertToString(dr["COMENTARIOS"]);

                objEval.EstaIncluida = Utiles.ConvertToBoolean(dr["Esta_incluida"]);

                objEval.NroIntentos = Utiles.ConvertToInt32(dr["NroIntentos"]);

                lst.Add(objEval);
            }
            dr.Close();
            return lst;
        }

        public EEVALUACION SelectPreguntaEvaluacion(long CodActivUsr, Int32 CodUnidad, Int16 CodPregunta,Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(4);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActivUsr;
            prms[0].ParameterName = "@COD_ACTIV_USR";

            prms[1] = db.GetParameter();
            prms[1].Value = CodUnidad;
            prms[1].ParameterName = "@COD_UNIDAD";

            prms[2] = db.GetParameter();
            prms[2].Value = CodPregunta;
            prms[2].ParameterName = "@COD_PREGUNTA";

            prms[3] = db.GetParameter();
            prms[3].Value = CodEmpresa;
            prms[3].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_pregunta_evaluacion", prms);

            EEVALUACION objEval = new EEVALUACION();

            while (dr.Read())
            {

                objEval.CodActivUsr = Utiles.ConvertToDecimal(dr["COD_ACTIV_USR"]);

                objEval.CodUnidad = Utiles.ConvertToInt16(dr["COD_UNIDAD"]);

                objEval.CodPregunta = Utiles.ConvertToInt16(dr["COD_PREGUNTA"]);

                objEval.FechaHora = Utiles.ConvertToDateTime(dr["FECHA_HORA"]);

                objEval.TextoRespuesta = Utiles.ConvertToString(dr["TEXTO_RESPUESTA"]);

                objEval.Puntaje = Utiles.ConvertToDouble(dr["PUNTAJE"]);

                objEval.Comentarios = Utiles.ConvertToString(dr["COMENTARIOS"]);

                objEval.EstaIncluida = Utiles.ConvertToBoolean(dr["Esta_incluida"]);

                objEval.NroIntentos = Utiles.ConvertToInt32(dr["NroIntentos"]);

            }
            dr.Close();
            return objEval;
        }

        public Boolean SelectSeEvaluoPregunta(Int16 CodPregunta)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodPregunta;
            prms[0].ParameterName = "@CodPregunta";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_se_evaluo_pregunta", prms);

            Boolean blnExiste = false;

            while (dr.Read())
            {

                blnExiste = Utiles.ConvertToBoolean(dr[0]);

            }
            dr.Close();
            return blnExiste;
        }

		#endregion
	}
}
