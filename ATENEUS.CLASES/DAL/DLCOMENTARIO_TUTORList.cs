using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;
using ATENEUS.CLASES.DAO;


namespace ATENEUS.CLASES.DAL
{
    public class DLCOMENTARIOTUTORList : DLGenericBaseList<ECOMENTARIOTUTOR>
    {
        public DLCOMENTARIOTUTORList()
        {
            this._proc_select_all = "proc_select_COMENTARIO_TUTOR_all";
        }

        #region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<ECOMENTARIOTUTOR> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public List<ECOMENTARIOTUTOR> SelectComentarioTutor(Int64 CodActividad)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActividad;
            prms[0].ParameterName = "@cod_actividad_tutor";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_COMENTARIO_TUTOR", prms);


            List<ECOMENTARIOTUTOR> lst = new List<ECOMENTARIOTUTOR>();

            while (dr.Read())
            {
                ECOMENTARIOTUTOR objComentario = new ECOMENTARIOTUTOR();

                objComentario.CodActividadTutor = Utiles.ConvertToInt32(dr["cod_actividad_tutor"]);

                objComentario.CodComentario = Utiles.ConvertToInt16(dr["COD_COMENTARIO"]);

                objComentario.Comentario = Utiles.ConvertToString(dr["COMENTARIO"]);

                objComentario.FechaIngreso = Utiles.ConvertToDateTime(dr["FECHA"]);
                

                lst.Add(objComentario);
            }
            dr.Close();
            return lst;
        }


        public DataTable SelectComentarioSala(Int64 CodActividad, long codEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActividad;
            prms[0].ParameterName = "@cod_actividad_tutor";

            DataTable dt =  db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_COMENTARIO_TUTOR", prms);
                        
            return dt;
        }

        public DataTable SelectDatosTutor(Int64 codActividadTutor)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = codActividadTutor;
            prms[0].ParameterName = "@cod_actividad_tutor";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_datos_tutor", prms);

            return dt;
        }
        #endregion
    }
}
