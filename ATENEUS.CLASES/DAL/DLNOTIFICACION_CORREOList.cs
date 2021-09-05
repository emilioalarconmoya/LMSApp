using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.CLASES.DAL
{
    public class DLNOTIFICACIONCORREOList : DLGenericBaseList<ENOTIFICACIONCORREO>
    {
        public DLNOTIFICACIONCORREOList()
        {
            this._proc_select_all = "proc_select_NOTIFICACION_CORREO_ALL";
        }

        #region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<ENOTIFICACIONCORREO> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public List<ENOTIFICACIONCORREO> GetNotificacionCorreoByAsunto(string Asunto, Int64 codEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = Asunto;
            prms[0].ParameterName = "@ASUNTO";
			
			prms[1] = db.GetParameter();
            prms[1].Value = codEmpresa;
            prms[1].ParameterName = "@Cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_NOTIFICACION_CORREO_BY_ASUNTO", prms);

            return GetCollection(dr);
        }

        public Boolean DelNotificacionCampos(Int16 codNotificacionCorreo, Int64 codEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = codNotificacionCorreo;
            prms[0].ParameterName = "@COD_NOTIFICACION_CORREO";
			
			prms[1] = db.GetParameter();
            prms[1].Value = codEmpresa;
            prms[1].ParameterName = "@Cod_empresa";

            int resultado = db.ExecuteNonQuery(CommandType.StoredProcedure, "proc_delete_NOTIFICACION_CORREO", prms);

            return true;
        }

        public DataTable SelectBuscadornotificacioncorreo(String Asunto, Int16 CodTipo, Int64 codEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            

            //IDataReader dr;

            prms = db.GetArrayParameter(3);

            

            prms[0] = db.GetParameter();
            prms[0].Value = Utiles.SubStringSQL(Asunto);
            prms[0].ParameterName = "@Asunto";

            prms[1] = db.GetParameter();
            prms[1].Value = CodTipo;
            prms[1].ParameterName = "@CodTipo";
			
			prms[2] = db.GetParameter();
            prms[2].Value = codEmpresa;
            prms[2].ParameterName = "@Cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_buscador_notificacion_correo", prms);

            return dt;


            
        }

        public List<ENOTIFICACIONCORREO> NotificacionPorTipo(Int16 codtipoNotificacion, Int64 codEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = codtipoNotificacion;
            prms[0].ParameterName = "@COD_TIPO_NOTIFICACION";
			
			prms[1] = db.GetParameter();
            prms[1].Value = codEmpresa;
            prms[1].ParameterName = "@Cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_notificaciones_por_tipo", prms);

            return GetCollection(dr);
        }

        #endregion
    }
}
