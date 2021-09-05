using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.CLASES.DAL
{
    public class DLSOLICITUDCURSOCATALOGOList : DLGenericBaseList<ESOLICITUDCURSOCATALOGO>
    {
        public DLSOLICITUDCURSOCATALOGOList()
        {
            this._proc_select_all = "proc_select_SOLICITUD_CURSO_CATALOGO_all";
        }

        #region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<ESOLICITUDCURSOCATALOGO> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        


        //CONSULTO SI YA HE SOLICITADO ESTA ACTIVIDAD DEL CURSO DE LA MALLA
        public Boolean GetSolicitoCurso(long codCurso, long codActividad, long rutUsuario)
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
            prms[2].Value = rutUsuario;
            prms[2].ParameterName = "@RUT_USUARIO";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_solicito_curso_actividad", prms);

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable ListaSolicitudesCursos(long rutUsuario, string nombreUsuario, int Estado, int codGrupo, int codActividad, long codEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(6);

            prms[0] = db.GetParameter();
            prms[0].Value = rutUsuario;
            prms[0].ParameterName = "@RUT_USUARIO";

            prms[1] = db.GetParameter();
            prms[1].Value = Utiles.SubStringSQL(nombreUsuario);
            prms[1].ParameterName = "@NOMBRE_USUARIO";

            prms[2] = db.GetParameter();
            prms[2].Value = Estado;
            prms[2].ParameterName = "@ESTADO";

            prms[3] = db.GetParameter();
            prms[3].Value = codGrupo;
            prms[3].ParameterName = "@cod_catalogo";

            prms[4] = db.GetParameter();
            prms[4].Value = codActividad;
            prms[4].ParameterName = "@CodActividad";

            prms[5] = db.GetParameter();
            prms[5].Value = codEmpresa;
            prms[5].ParameterName = "@cod_empresa";


            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "[proc_select_buscador_solicitud_curso_catalogo]", prms);


            
            return dt;
        }

        #endregion
    }
}
