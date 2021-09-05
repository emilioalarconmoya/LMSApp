using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.CLASES.DAL
{
    public class DLACTIVIDADTUTORList : DLGenericBaseList<EACTIVIDADTUTOR>
    {
        public DLACTIVIDADTUTORList()
        {
            this._proc_select_all = "proc_select_ACTIVIDAD_TUTOR_ALL";
        }

        #region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EACTIVIDADTUTOR> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public List<EACTIVIDADTUTOR> SelectAll(long rut)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = rut;
            prms[0].ParameterName = "@rut_usuario";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_ACTIVIDAD_TUTOR_ALL_rut", prms);

            return GetCollection(dr);
        }

        public DataTable SelectActividadTutor(long CodActividad)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActividad;
            prms[0].ParameterName = "@COD_ACTIVIDAD";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_ACTIVIDAD_TUTOR", prms);

            return dt;
        }

        public DataTable SelectActividadTutor2(long CodActividad)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActividad;
            prms[0].ParameterName = "@COD_ACTIVIDAD";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_ACTIVIDAD_TUTOR2", prms);

            return dt;
        }

        public List<EACTIVIDADTUTOR> SelectBuscadorActividadTutorNombre(string Nombre, Int64 rutTutor)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = Utiles.SubStringSQL(Nombre);
            prms[0].ParameterName = "@Nombre";

            prms[1] = db.GetParameter();
            prms[1].Value = rutTutor;
            prms[1].ParameterName = "@rut_tutor";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_buscador_actividades_TUTOR_NOMBRE", prms);


            List<EACTIVIDADTUTOR> lst = new List<EACTIVIDADTUTOR>();

            while (dr.Read())
            {
                EACTIVIDADTUTOR objACTIVIDADTUTOR = new EACTIVIDADTUTOR();

                //Poner las rutinas del Tools que se necesiten

                objACTIVIDADTUTOR.CodActividad = Utiles.ConvertToInt16(dr["cod_actividad"]);

                objACTIVIDADTUTOR.Nombre = Utiles.ConvertToString(dr["nombre_act"]);

                objACTIVIDADTUTOR.RutUsuario = Utiles.ConvertToInt32(dr["rut_usuario"]);

                objACTIVIDADTUTOR.Fechainicio = Utiles.ConvertToDateTime(dr["fecha_inicio"]);

                objACTIVIDADTUTOR.FechaFin = Convert.ToDateTime(dr["fecha_fin"]);

                objACTIVIDADTUTOR.CodActividadTutor = Utiles.ConvertToInt32(dr["cod_actividad_tutor"]);



                lst.Add(objACTIVIDADTUTOR);
            }
            dr.Close();
            return lst;
        }

        //public Boolean GetTerminoUnidad(long CodActivUsr, long CodUnidad)
        //{
        //    DB db = DatabaseFactory.Instance.GetDatabase();
        //    IDbDataParameter[] prms;
        //    prms = db.GetArrayParameter(2);

        //    prms[0] = db.GetParameter();
        //    prms[0].Value = CodActivUsr;
        //    prms[0].ParameterName = "@CODACTIVUSR";

        //    prms[1] = db.GetParameter();
        //    prms[1].Value = CodUnidad;
        //    prms[1].ParameterName = "@CODUNIDAD";

        //    DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_TERMINO_UNIDAD", prms);

        //    if (Utiles.ConvertToInt16(dt.Rows[0][0]) > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        #endregion
    }
}
