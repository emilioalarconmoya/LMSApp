using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
    public class DLNOTIFICACIONCORREO : DLBase
    {
        public DLNOTIFICACIONCORREO()
        {
        }
        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_NOTIFICACION_CORREO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_NOTIFICACION_CORREO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_NOTIFICACION_CORREO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_NOTIFICACION_CORREO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_NOTIFICACION_CORREO";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ENOTIFICACIONCORREO objACTIVIDADFORO = obj as ENOTIFICACIONCORREO;

            prms[0] = db.GetParameter();
            prms[0].Value = objACTIVIDADFORO.CodNotificacionCorreo;
            prms[0].ParameterName = "@cod_notificacion_correo";
			
			prms[1] = db.GetParameter();
            prms[1].Value = objACTIVIDADFORO.CodEmpresa;
            prms[1].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(4);
            ENOTIFICACIONCORREO objACTIVIDADFORO = obj as ENOTIFICACIONCORREO;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objACTIVIDADFORO.CodTipoNotificacion;
            prms[0].ParameterName = "@tipo_notificacion";

            prms[1] = db.GetParameter();
            prms[1].Value = objACTIVIDADFORO.Asunto;
            prms[1].ParameterName = "@asunto";

            prms[2] = db.GetParameter();
            prms[2].Value = objACTIVIDADFORO.Cuerpo;
            prms[2].ParameterName = "@cuerpo";
			
			prms[3] = db.GetParameter();
            prms[3].Value = objACTIVIDADFORO.CodEmpresa;
            prms[3].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(5);
            ENOTIFICACIONCORREO objACTIVIDADFORO = obj as ENOTIFICACIONCORREO;

            //Poner las rutinas del Tools que se necesiten
            prms[0] = db.GetParameter();
            prms[0].Value = objACTIVIDADFORO.CodNotificacionCorreo;
            prms[0].ParameterName = "@COD_NOTIFICACION_CORREO";

            prms[1] = db.GetParameter();
            prms[1].Value = objACTIVIDADFORO.CodTipoNotificacion;
            prms[1].ParameterName = "@COD_TIPO_NOTIFICACION";

            prms[2] = db.GetParameter();
            prms[2].Value = objACTIVIDADFORO.Asunto;
            prms[2].ParameterName = "@asunto";

            prms[3] = db.GetParameter();
            prms[3].Value = objACTIVIDADFORO.Cuerpo;
            prms[3].ParameterName = "@cuerpo";
			
			prms[4] = db.GetParameter();
            prms[4].Value = objACTIVIDADFORO.CodEmpresa;
            prms[4].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ENOTIFICACIONCORREO objRoot = obj as ENOTIFICACIONCORREO;

            objRoot.CodNotificacionCorreo = Utiles.ConvertToInt32(id);
        }

        #endregion

        #region Public Methods

        public override void Fill(DomainObject obj, IDataReader dr)
        {
            ENOTIFICACIONCORREO objACTIVIDADFORO = obj as ENOTIFICACIONCORREO;

            //Poner las rutinas del Tools que se necesiten

            objACTIVIDADFORO.CodNotificacionCorreo = Utiles.ConvertToInt32(dr["cod_notificacion_correo"]);

            objACTIVIDADFORO.CodTipoNotificacion = Utiles.ConvertToInt32(dr["cod_tipo_notificacion"]);

            objACTIVIDADFORO.Asunto = Utiles.ConvertToString(dr["asunto"]);

            objACTIVIDADFORO.Cuerpo = Utiles.ConvertToString(dr["cuerpo"]);
			
			objACTIVIDADFORO.CodEmpresa = Utiles.ConvertToInt32(dr["cod_empresa"]);

        }

        #endregion
    }
}
