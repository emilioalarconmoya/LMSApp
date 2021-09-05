
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
	/// Summary description for DLENCUESTAList.
	/// </summary>
    public class DLENCUESTASATISUSUARIOList : DLGenericBaseList<EENCUESTASATISUSUARIO>
	{
		public DLENCUESTASATISUSUARIOList()
		{
            this._proc_select_all = "proc_select_Encuesta_SATIS_USUARIO_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EENCUESTASATISUSUARIO> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }


        public List<EENCUESTASATISUSUARIO> SelectEncuestaRealizada(long CodActivUsr, Int32 CodEncuesta)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActivUsr;
            prms[0].ParameterName = "@COD_ACTIV_USR";

            prms[1] = db.GetParameter();
            prms[1].Value = CodEncuesta;
            prms[1].ParameterName = "@cod_encuesta_satisfaccion";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_encuesta_realizada", prms);


            List<EENCUESTASATISUSUARIO> lst = new List<EENCUESTASATISUSUARIO>();

            while (dr.Read())
            {
                EENCUESTASATISUSUARIO objEnc = new EENCUESTASATISUSUARIO();

                objEnc.CodActivUsr = Utiles.ConvertToDecimal(dr["COD_ACTIV_USR"]);

                objEnc.CodEncuestaSatisfaccion = Utiles.ConvertToInt16(dr["cod_encuesta_satisfaccion"]);

                objEnc.CodPregunta = Utiles.ConvertToInt16(dr["COD_PREGUNTA"]);

                objEnc.FechaHora = Utiles.ConvertToDateTime(dr["FECHA_HORA"]);

                objEnc.TextoRespuesta = Utiles.ConvertToString(dr["TEXTO_RESPUESTA"]);

                lst.Add(objEnc);
            }
            dr.Close();
            return lst;
        }



        public EENCUESTASATISUSUARIO SelectPreguntaEncuestadas(long CodActivUsr, Int32 Codencuesta, Int16 CodPregunta, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(4);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActivUsr;
            prms[0].ParameterName = "@COD_ACTIV_USR";

            prms[1] = db.GetParameter();
            prms[1].Value = Codencuesta;
            prms[1].ParameterName = "@COD_ENCUESTA_SATISFACCION";

            prms[2] = db.GetParameter();
            prms[2].Value = CodPregunta;
            prms[2].ParameterName = "@COD_PREGUNTA";

            prms[3] = db.GetParameter();
            prms[3].Value = CodEmpresa;
            prms[3].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_pregunta_encuesta_satis_usuario", prms);

            EENCUESTASATISUSUARIO objEnc = new EENCUESTASATISUSUARIO();

            while (dr.Read())
            {

                objEnc.CodActivUsr = Utiles.ConvertToDecimal(dr["COD_ACTIV_USR"]);

                objEnc.CodEncuestaSatisfaccion = Utiles.ConvertToInt16(dr["cod_encuesta_satisfaccion"]);

                objEnc.CodPregunta = Utiles.ConvertToInt16(dr["COD_PREGUNTA"]);

                objEnc.FechaHora = Utiles.ConvertToDateTime(dr["FECHA_HORA"]);

                objEnc.TextoRespuesta = Utiles.ConvertToString(dr["TEXTO_RESPUESTA"]);

            }
            dr.Close();
            return objEnc;
        }
            

        public Boolean SelectSeEncuestoPregunta(Int16 CodPregunta)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodPregunta;
            prms[0].ParameterName = "@CodPregunta";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_se_encuesto_pregunta", prms);

            Boolean blnExiste = false;

            while (dr.Read())
            {

                blnExiste = Utiles.ConvertToBoolean(dr[0]);

            }
            dr.Close();
            return blnExiste;
        }

        public static DataTable GetReporteEncuesta(Int64 RutUsuario, Int32 codencuesta, DateTime FechaInicio, DateTime FechaFin, Int32 codActividad, Int64 CodEmpresa)
        {
            try
            {
                DB db = DatabaseFactory.Instance.GetDatabase();
                IDbDataParameter[] prms;
                prms = db.GetArrayParameter(6);
                
                prms[0] = db.GetParameter();
                prms[0].Value = codencuesta;
                prms[0].ParameterName = "@cod_encuesta_satisfaccion";

                prms[1] = db.GetParameter();
                prms[1].Value = RutUsuario;
                prms[1].ParameterName = "@RUTUSUARIO";

                prms[2] = db.GetParameter();
                prms[2].Value = FechaInicio;
                prms[2].ParameterName = "@FECHAINICIO";

                prms[3] = db.GetParameter();
                prms[3].Value = FechaFin;
                prms[3].ParameterName = "@FECHAFIN";

                prms[4] = db.GetParameter();
                prms[4].Value = codActividad;
                prms[4].ParameterName = "@COD_ACTIVIDAD";

                prms[5] = db.GetParameter();
                prms[5].Value = CodEmpresa;
                prms[5].ParameterName = "@cod_empresa";

                DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "[proc_select_Get_Reporte_Encuesta_satis]", prms);

                return dt;
            }
            catch (Exception)
            { 
                throw;
            }


        }

        public static DataTable GetReporteEncuestaPromedio(Int64 RutUsuario, Int32 codencuesta, DateTime FechaInicio, DateTime FechaFin, Int32 codActividad, Int64 CodEmpresa)
        {
            try
            {
                DB db = DatabaseFactory.Instance.GetDatabase();
                IDbDataParameter[] prms;
                prms = db.GetArrayParameter(6);

                prms[0] = db.GetParameter();
                prms[0].Value = codencuesta;
                prms[0].ParameterName = "@cod_encuesta_satisfaccion";

                prms[1] = db.GetParameter();
                prms[1].Value = RutUsuario;
                prms[1].ParameterName = "@RUTUSUARIO";

                prms[2] = db.GetParameter();
                prms[2].Value = FechaInicio;
                prms[2].ParameterName = "@FECHAINICIO";

                prms[3] = db.GetParameter();
                prms[3].Value = FechaFin;
                prms[3].ParameterName = "@FECHAFIN";

                prms[4] = db.GetParameter();
                prms[4].Value = codActividad;
                prms[4].ParameterName = "@COD_ACTIVIDAD";

                prms[5] = db.GetParameter();
                prms[5].Value = CodEmpresa;
                prms[5].ParameterName = "@cod_empresa";

                DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_Get_Reporte_Encuesta_satis_promedio", prms);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }


        }
        #endregion
    }
}
