using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
    public class DLTIPOSALAVIRTUAL : DLBase
    {
        public DLTIPOSALAVIRTUAL()
        {
        }

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_TIPO_SALA_VIRTUAL";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_TIPO_SALA_VIRTUAL";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_TIPO_SALA_VIRTUAL";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_TIPO_SALA_VIRTUAL";
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
            ETIPOSALAVIRTUAL objTIPOSALA = obj as ETIPOSALAVIRTUAL;

            prms[0] = db.GetParameter();
            prms[0].Value = objTIPOSALA.CodTipo;
            prms[0].ParameterName = "@cod_tipo";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ETIPOSALAVIRTUAL objTIPOSALA = obj as ETIPOSALAVIRTUAL;

            //Poner las rutinas del Tools que se necesiten

            prms[1] = db.GetParameter();
            prms[1].Value = objTIPOSALA.Nombre;
            prms[1].ParameterName = "@nombre";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ETIPOSALAVIRTUAL objTIPOSALA = obj as ETIPOSALAVIRTUAL;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objTIPOSALA.CodTipo;
            prms[0].ParameterName = "@cod_tipo";

            prms[1] = db.GetParameter();
            prms[1].Value = objTIPOSALA.Nombre;
            prms[1].ParameterName = "@nombre";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ETIPOSALAVIRTUAL objRoot = obj as ETIPOSALAVIRTUAL;

            objRoot.CodTipo = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

        public override void Fill(DomainObject obj, IDataReader dr)
        {
            ETIPOSALAVIRTUAL objTIPOSALA = obj as ETIPOSALAVIRTUAL;

            //Poner las rutinas del Tools que se necesiten

            objTIPOSALA.CodTipo = Utiles.ConvertToInt16(dr["cod_tipo_sala_virtual"]);

            objTIPOSALA.Nombre = Utiles.ConvertToString(dr["nombre_sala_virtual"]);

        }

        #endregion
    }
}
