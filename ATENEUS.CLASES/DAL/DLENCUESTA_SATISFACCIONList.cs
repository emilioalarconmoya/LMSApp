
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
    public class DLENCUESTASATISFACCIONList : DLGenericBaseList<EENCUESTASATISFACCION>
	{
		public DLENCUESTASATISFACCIONList()
		{
            this._proc_select_all = "proc_select_ENCUESTA_SATISFACCION_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EENCUESTASATISFACCION> SelectAll(Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodEmpresa;
            prms[0].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, prms);

            return GetCollection(dr);
        }
		 public List<EENCUESTASATISFACCION> SelectAllTutor(Int64 rutTutor, long CodEmpresa)
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

        public string SelectNombreEncuestaSatisfaccion(int codEncuesta, long CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = codEncuesta;
            prms[0].ParameterName = "@COD_ENCUESTA_SATISFACCION";
			
			prms[1] = db.GetParameter();
            prms[1].Value = CodEmpresa;
            prms[1].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_nombre_encuesta_satisfaccion", prms);

            string nombreEncuesta = "";

            if (dt.Rows.Count > 0)
            {
                nombreEncuesta = Utiles.ConvertToString(dt.Rows[0][0]);
            }

            return nombreEncuesta;
        }
        

       

       

        

        public List<EENCUESTASATISFACCION> SelectBuscadorEncuestaSatisfaccion(String Nombre,  Int64 CodEmpresa,  Int16 codEstado)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;


            IDataReader dr;

            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = Utiles.SubStringSQL(Nombre);
            prms[0].ParameterName = "@Nombre";
            
            prms[1] = db.GetParameter();
            prms[1].Value = CodEmpresa;
            prms[1].ParameterName = "@cod_empresa";

            prms[2] = db.GetParameter();
            prms[2].Value = codEstado;
            prms[2].ParameterName = "@cod_estado";


            dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_buscador_encuesta_satisfaccion", prms);



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

            List<EENCUESTASATISFACCION> lst = new List<EENCUESTASATISFACCION>();

            while (dr.Read())
            {

                EENCUESTASATISFACCION objUNIDAD = new EENCUESTASATISFACCION();

                objUNIDAD.CodEncuestaSatisfaccion = Utiles.ConvertToInt16(dr["COD_ENCUESTA_SATISFACCION"]);

                objUNIDAD.Nombre = Utiles.ConvertToString(dr["NOMBRE_ENCUESTA"]);

                objUNIDAD.Descripcion = Utiles.ConvertToString(dr["descripcion"]);

                objUNIDAD.CodEmpresa = Utiles.ConvertToInt64(dr["COD_EMPRESA"]);

                objUNIDAD.Activo = Utiles.ConvertToBoolean(dr["flag_Activo"]);

                lst.Add(objUNIDAD);
            }
            dr.Close();
            return lst;
        }

        public Int16 SerialEncuestaSatis()
        {
            Int16 intResultado = 0;

            DB db = DatabaseFactory.Instance.GetDatabase();

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_serial_ENCUESTA_SATISFACCION", null);

            intResultado = Utiles.ConvertToInt16(dt.Rows[0][0]);

            return intResultado;
        }

        #endregion
    }
}
