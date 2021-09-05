using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.CLASES.DAL
{
    public class DLCURSOMALLAList : DLGenericBaseList<ECURSOMALLA>
    {
        public DLCURSOMALLAList()
        {
            this._proc_select_all = "proc_select_curso_MALLA_all";
        }

        #region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<ECURSOMALLA> SelectAll(Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodEmpresa;
            prms[0].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, prms);

            return GetCollection(dr);
        }

        public DataTable SelectCursoMalla(long CodMalla, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = CodMalla;
            prms[0].ParameterName = "@COD_MALLA";
			
			prms[1] = db.GetParameter();
            prms[1].Value = CodEmpresa; 
            prms[1].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_curso_malla", prms);

            return dt;
        }

        public DataTable SelectMallaUsuario(long RutUsuario, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = RutUsuario;
            prms[0].ParameterName = "@rut_usuario";
			
			prms[1] = db.GetParameter();
            prms[1].Value = CodEmpresa; 
            prms[1].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_malla_usuario", prms);

            return dt;
        }

        //indica si el alumno aprobó el curso o cualquier curso de la misma categoria (cod_tipo_curso)
        public bool SelectAproboActividad(long RutUsuario, int CodTipoCurso, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = CodTipoCurso;
            prms[0].ParameterName = "@cod_tipo_curso";

            prms[1] = db.GetParameter();
            prms[1].Value = RutUsuario;
            prms[1].ParameterName = "@rut_usuario";
			
			prms[2] = db.GetParameter();
            prms[2].Value = CodEmpresa; 
            prms[2].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "sp_select_aprobo_actividad", prms);

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        #endregion
    }
}
