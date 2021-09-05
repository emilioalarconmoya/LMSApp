
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
    public class DLTIPONOTIFICACION : DLBase
    {
        public DLTIPONOTIFICACION()
        {
        }

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_TIPO_NOTIFICACION";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_TIPO_NOTIFICACION";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_TIPO_ANOTIFICACION";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_TIPO_NOTIFICACION";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_tipo";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ETIPONOTIFICACION objTIPOACTIVIDAD = obj as ETIPONOTIFICACION;

            prms[0] = db.GetParameter();
            prms[0].Value = objTIPOACTIVIDAD.CodTipoNotificacion;
            prms[0].ParameterName = "@cod_tipo";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ETIPONOTIFICACION objTIPOACTIVIDAD = obj as ETIPONOTIFICACION;

            //Poner las rutinas del Tools que se necesiten

            prms[1] = db.GetParameter();
            prms[1].Value = objTIPOACTIVIDAD.Nombrenotificacion;
            prms[1].ParameterName = "@nombre";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ETIPONOTIFICACION objTIPOACTIVIDAD = obj as ETIPONOTIFICACION;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objTIPOACTIVIDAD.CodTipoNotificacion;
            prms[0].ParameterName = "@cod_tipo";

            prms[1] = db.GetParameter();
            prms[1].Value = objTIPOACTIVIDAD.Nombrenotificacion;
            prms[1].ParameterName = "@nombre";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ETIPONOTIFICACION objRoot = obj as ETIPONOTIFICACION;

            objRoot.CodTipoNotificacion = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

        public override void Fill(DomainObject obj, IDataReader dr)
        {
            ETIPONOTIFICACION objTIPOACTIVIDAD = obj as ETIPONOTIFICACION;

            //Poner las rutinas del Tools que se necesiten

            objTIPOACTIVIDAD.CodTipoNotificacion = Utiles.ConvertToInt16(dr["COD_TIPO_NOTIFICACION"]);

            objTIPOACTIVIDAD.Nombrenotificacion = Utiles.ConvertToString(dr["NOMBRE_TIPO_NOTIFICCION"]);

        }

        #endregion
    }
}
