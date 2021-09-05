
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
	/// Summary description for DLUNIDADList.
	/// </summary>
    public class DLUNIDADList : DLGenericBaseList<EUNIDAD>
	{
		public DLUNIDADList()
		{
            this._proc_select_all = "proc_select_UNIDAD_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EUNIDAD> SelectAll(Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodEmpresa;
            prms[0].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, prms);

            return GetCollection(dr);
        }
		 public List<EUNIDAD> SelectAllTutor(Int64 rutTutor, long CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = rutTutor;
            prms[0].ParameterName = "@rut_tutor";

            prms[1] = db.GetParameter();
            prms[1].Value = CodEmpresa;
            prms[1].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_UNIDAD_all_tutor", prms);

            return GetCollection(dr);
        }

        public string SelectNombreUnidad(int codUnidad, long CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = codUnidad;
            prms[0].ParameterName = "@cod_unidad";
			
			prms[1] = db.GetParameter();
            prms[1].Value = CodEmpresa;
            prms[1].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_nombre_unidad", prms);

            string nombreUnidad = "";

            if (dt.Rows.Count > 0)
            {
                nombreUnidad = Utiles.ConvertToString(dt.Rows[0][0]);
            }

            return nombreUnidad;
        }
        public List<EUNIDAD> GetUNIDADESACTIVIDADTIPO(Int32 CodActividad, Int16 CodTipo)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActividad;
            prms[0].ParameterName = "@CODACTIVIDAD";

            prms[1] = db.GetParameter();
            prms[1].Value = CodTipo;
            prms[1].ParameterName = "@CODTIPO";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_UNIDADES_ACTIVIDAD_TIPO", prms);

            return GetCollection(dr);
        }

        public DataTable SelectAvanceUnidades(long CodActivUsr,Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActivUsr;
            prms[0].ParameterName = "@cod_activ_usr";

            prms[1] = db.GetParameter();
            prms[1].Value = CodEmpresa;
            prms[1].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_avance_unidades", prms);

            return dt;
        }

        public DataTable SelectActividadSU(long CodActividad)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActividad;
            prms[0].ParameterName = "@COD_ACTIVIDAD";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_actividad_super_usaurio", prms);

            return dt;
        }

        public Int32 TiempoRestante(Int64 CodActivUsr, Int32 CodUnidad)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActivUsr;
            prms[0].ParameterName = "@CodActivUsr";

            prms[1] = db.GetParameter();
            prms[1].Value = CodUnidad;
            prms[1].ParameterName = "@CodUnidad";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_tiempo_restante", prms);

            Int32 Tiempo = 0;

            if (dt.Rows.Count > 0)
            {
                Tiempo = Utiles.ConvertToInt32(dt.Rows[0][0]);
            }

            return Tiempo;
        }

        public List<EUNIDAD> SelectBuscadorUnidad(String Nombre, Int16 CodTipo, Int32 CodActividad, Int64 CodEmpresa, Int64 rutTutor, Int16 codEstado)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;


            IDataReader dr;

            if (rutTutor > 0)
            {
                prms = db.GetArrayParameter(6);

                prms[0] = db.GetParameter();
                prms[0].Value = Utiles.SubStringSQL(Nombre);
                prms[0].ParameterName = "@Nombre";

                prms[1] = db.GetParameter();
                prms[1].Value = CodTipo;
                prms[1].ParameterName = "@CodTipo";

                prms[2] = db.GetParameter();
                prms[2].Value = CodActividad;
                prms[2].ParameterName = "@CodActividad";

                prms[3] = db.GetParameter();
                prms[3].Value = rutTutor;
                prms[3].ParameterName = "@rut_tutor";

                prms[4] = db.GetParameter();
                prms[4].Value = CodEmpresa;
                prms[4].ParameterName = "@cod_empresa";

                prms[5] = db.GetParameter();
                prms[5].Value = codEstado;
                prms[5].ParameterName = "@cod_estado";

                dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_buscador_unidades_tutor", prms);
            }
            else
            {
                prms = db.GetArrayParameter(5);

                prms[0] = db.GetParameter();
                prms[0].Value = Utiles.SubStringSQL(Nombre);
                prms[0].ParameterName = "@Nombre";

                prms[1] = db.GetParameter();
                prms[1].Value = CodTipo;
                prms[1].ParameterName = "@CodTipo";

                prms[2] = db.GetParameter();
                prms[2].Value = CodActividad;
                prms[2].ParameterName = "@CodActividad";

                prms[3] = db.GetParameter();
                prms[3].Value = CodEmpresa;
                prms[3].ParameterName = "@cod_empresa";

                prms[4] = db.GetParameter();
                prms[4].Value = codEstado;
                prms[4].ParameterName = "@cod_estado";


                dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_buscador_unidades", prms);
            }



            //DB db = DatabaseFactory.Instance.GetDatabase();
            //IDbDataParameter[] prms;
            //prms = db.GetArrayParameter(4);

            //prms[0] = db.GetParameter();
            //prms[0].Value = Utiles.SubStringSQL(Nombre);
            //prms[0].ParameterName = "@Nombre";

            //prms[1] = db.GetParameter();
            //prms[1].Value = CodTipo;
            //prms[1].ParameterName = "@CodTipo";

            //prms[2] = db.GetParameter();
            //prms[2].Value = CodActividad;
            //prms[2].ParameterName = "@CodActividad";

            //prms[3] = db.GetParameter();
            //prms[3].Value = CodEmpresa;
            //prms[3].ParameterName = "@cod_empresa";

            //IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_buscador_unidades", prms);

            List<EUNIDAD> lst = new List<EUNIDAD>();

            while (dr.Read())
            {

                EUNIDAD objUNIDAD = new EUNIDAD();

                objUNIDAD.CodUnidad = Utiles.ConvertToInt16(dr["cod_unidad"]);

                objUNIDAD.CodTemaUnidad = Utiles.ConvertToInt16(dr["cod_tema_unidad"]);

                objUNIDAD.CodTipoUnidad = Utiles.ConvertToInt16(dr["cod_tipo_unidad"]);

                objUNIDAD.Nombre = Utiles.ConvertToString(dr["nombre"]);

                objUNIDAD.Descripcion = Utiles.ConvertToString(dr["descripcion"]);

                objUNIDAD.Archivo = Utiles.ConvertToString(dr["archivo"]);

                objUNIDAD.AvisaTermino = Utiles.ConvertToBoolean(dr["avisa_termino"]);

                objUNIDAD.Contenido = Utiles.ConvertToString(dr["contenido"]);

                objUNIDAD.Criterios = Utiles.ConvertToString(dr["criterios"]);

                objUNIDAD.NumPregAleatorias = Utiles.ConvertToInt32(dr["num_preg_aleatorias"]);

                objUNIDAD.TiempoSegs = Utiles.ConvertToInt32(dr["tiempo_segs"]);

                objUNIDAD.MostrarResultados = Utiles.ConvertToBoolean(dr["Mostrar_Resultados"]);

                objUNIDAD.MostrarRespCorrectas = Utiles.ConvertToBoolean(dr["mostrar_resp_correctas"]);

                objUNIDAD.NomTipoUnidad = Utiles.ConvertToString(dr["nom_tipo_unidad"]);

                objUNIDAD.NomTemaUnidad = Utiles.ConvertToString(dr["nom_tema_unidad"]);

                objUNIDAD.CodEmpresa = Utiles.ConvertToInt64(dr["COD_EMPRESA"]);

                objUNIDAD.RutTutor = Utiles.ConvertToInt64(dr["rut_tutor"]);

                objUNIDAD.FlagActivo = Utiles.ConvertToBoolean(dr["flag_Activo"]);

                lst.Add(objUNIDAD);
            }
            dr.Close();
            return lst;
        }

        public Int16 SerialUnidad()
        {
            Int16 intResultado = 0;

            DB db = DatabaseFactory.Instance.GetDatabase();

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_serial_unidad", null);

            intResultado = Utiles.ConvertToInt16(dt.Rows[0][0]);

            return intResultado;
        }

        #endregion
    }
}
