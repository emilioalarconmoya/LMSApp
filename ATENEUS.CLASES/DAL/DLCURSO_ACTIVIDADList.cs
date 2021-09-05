using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.CLASES.DAL
{
    public class DLCURSOACTIVIDADList : DLGenericBaseList<ECURSOACTIVIDAD>
    {
        public DLCURSOACTIVIDADList()
        {
            this._proc_select_all = "proc_select_CURSO_ACTIVIDAD_all";
        }

        #region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<ECURSOACTIVIDAD> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public DataTable SelectActividadesCurso(long CodCurso, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = CodCurso;
            prms[0].ParameterName = "@COD_CURSO";
			
			prms[1] = db.GetParameter();
            prms[1].Value = CodEmpresa; 
            prms[1].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_actividad_CURSO", prms);

            return dt;
        }


       
        public Boolean GetSolicitoCurso(long codCurso, long codActividad, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = codActividad;
            prms[0].ParameterName = "@COD_ACTIVIDAD";

            prms[1] = db.GetParameter();
            prms[1].Value = codCurso;
            prms[1].ParameterName = "@COD_CURSO";
			
			prms[2] = db.GetParameter();
            prms[2].Value = CodEmpresa; 
            prms[2].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_solicito_curso", prms);

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean GetTieneautoinscripcion(long codCurso, long codActividad, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = codActividad;
            prms[0].ParameterName = "@COD_ACTIVIDAD";

            prms[1] = db.GetParameter();
            prms[1].Value = codCurso;
            prms[1].ParameterName = "@COD_CURSO";
			
			prms[2] = db.GetParameter();
            prms[2].Value = CodEmpresa; 
            prms[2].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_tiene_auto_inscripcion", prms);

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // verifia si un alumno ha aprobado las actibvidades que se encuentran en los cursos de las mallas
        public DataTable GetAproboCurso(long codActividad, long rutUsuario, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = codActividad;
            prms[0].ParameterName = "@COD_ACTIVIDAD";

            prms[1] = db.GetParameter();
            prms[1].Value = rutUsuario;
            prms[1].ParameterName = "@RUT_USUARIO";
			
			prms[2] = db.GetParameter();
            prms[2].Value = CodEmpresa; 
            prms[2].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_aprobo_curso", prms);

            return dt;
        }


        public Boolean  ActualizaSolicitud(long codCurso, long codActividad, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = codActividad;
            prms[0].ParameterName = "@COD_ACTIVIDAD";

            prms[1] = db.GetParameter();
            prms[1].Value = codCurso;
            prms[1].ParameterName = "@COD_CURSO";
			
			prms[2] = db.GetParameter();
            prms[2].Value = CodEmpresa; 
            prms[2].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_update_solicitud", prms);

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<ECURSO> SelectBuscadorCurso(string Nombre, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = Utiles.SubStringSQL(Nombre);
            prms[0].ParameterName = "@Nombre";
			
			prms[1] = db.GetParameter();
            prms[1].Value = CodEmpresa; 
            prms[1].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_buscador_curso_malla", prms);


            List<ECURSO> lst = new List<ECURSO>();

            while (dr.Read())
            {
                ECURSO objCURSO = new ECURSO();

                objCURSO.CodCurso = Utiles.ConvertToInt16(dr["cod_curso"]);

                objCURSO.NombreCurso = Utiles.ConvertToString(dr["nombre_curso"]);

                objCURSO.CodTipoCurso = Utiles.ConvertToInt16(dr["cod_tipo_curso"]);
				
				objCURSO.CodEmpresa = Utiles.ConvertToInt64(dr["COD_EMPRESA"]);

               

                lst.Add(objCURSO);
            }
            dr.Close();
            return lst;
        }




        #endregion
    }
}
