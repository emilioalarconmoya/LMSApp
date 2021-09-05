
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
    public class DLENCUESTAList : DLGenericBaseList<EENCUESTA>
	{
		public DLENCUESTAList()
		{
            this._proc_select_all = "proc_select_ENCUESTA_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EENCUESTA> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }


        public List<EENCUESTA> SelectEncuestaRealizada(long CodActivUsr, Int32 CodUnidad)
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

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_encuesta_realizada", prms);


            List<EENCUESTA> lst = new List<EENCUESTA>();

            while (dr.Read())
            {
                EENCUESTA objEnc = new EENCUESTA();

                objEnc.CodActivUsr = Utiles.ConvertToDecimal(dr["COD_ACTIV_USR"]);

                objEnc.CodUnidad = Utiles.ConvertToInt16(dr["COD_UNIDAD"]);

                objEnc.CodPregunta = Utiles.ConvertToInt16(dr["COD_PREGUNTA"]);

                objEnc.FechaHora = Utiles.ConvertToDateTime(dr["FECHA_HORA"]);

                objEnc.TextoRespuesta = Utiles.ConvertToString(dr["TEXTO_RESPUESTA"]);

                objEnc.Puntaje = Utiles.ConvertToDouble(dr["PUNTAJE"]);

                objEnc.Comentarios = Utiles.ConvertToString(dr["COMENTARIOS"]);

                objEnc.EstaIncluida = Utiles.ConvertToBoolean(dr["Esta_incluida"]);

                lst.Add(objEnc);
            }
            dr.Close();
            return lst;
        }



        public EENCUESTA SelectPreguntaEncuestadas(long CodActivUsr, Int32 CodUnidad, Int16 CodPregunta, Int64 CodEmpresa)
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

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_pregunta_encuesta", prms);

            EENCUESTA objEnc = new EENCUESTA();

            while (dr.Read())
            {

                objEnc.CodActivUsr = Utiles.ConvertToDecimal(dr["COD_ACTIV_USR"]);

                objEnc.CodUnidad = Utiles.ConvertToInt16(dr["COD_UNIDAD"]);

                objEnc.CodPregunta = Utiles.ConvertToInt16(dr["COD_PREGUNTA"]);

                objEnc.FechaHora = Utiles.ConvertToDateTime(dr["FECHA_HORA"]);

                objEnc.TextoRespuesta = Utiles.ConvertToString(dr["TEXTO_RESPUESTA"]);

                objEnc.Puntaje = Utiles.ConvertToDouble(dr["PUNTAJE"]);

                objEnc.Comentarios = Utiles.ConvertToString(dr["COMENTARIOS"]);

                objEnc.EstaIncluida = Utiles.ConvertToBoolean(dr["Esta_incluida"]);

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

        public static DataTable GetReporteEncuesta(Int64 RutUsuario, Int32 CodActividad, Int32 CodUnidad, DateTime FechaInicio, DateTime FechaFin,Int64 CodEmpresa)
        {
            try
            {
                DB db = DatabaseFactory.Instance.GetDatabase();
                IDbDataParameter[] prms;
                prms = db.GetArrayParameter(6);

                prms[0] = db.GetParameter();
                prms[0].Value = CodActividad;
                prms[0].ParameterName = "@CODACTIVIDAD";

                prms[1] = db.GetParameter();
                prms[1].Value = CodUnidad;
                prms[1].ParameterName = "@CODUNIDAD";

                prms[2] = db.GetParameter();
                prms[2].Value = RutUsuario;
                prms[2].ParameterName = "@RUTUSUARIO";

                prms[3] = db.GetParameter();
                prms[3].Value = FechaInicio;
                prms[3].ParameterName = "@FECHAINICIO";

                prms[4] = db.GetParameter();
                prms[4].Value = FechaFin;
                prms[4].ParameterName = "@FECHAFIN";

                prms[5] = db.GetParameter();
                prms[5].Value = CodEmpresa;
                prms[5].ParameterName = "@cod_empresa";

                DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_Get_Reporte_Encuesta", prms);

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
