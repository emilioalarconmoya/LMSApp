using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;


namespace ATENEUS.CLASES.DAL
{
    public class DLMATERIALAPOYOTUTOR : DLBase
    {
        public DLMATERIALAPOYOTUTOR()
        {
        }

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_MATERIAL_APOYO_TUTOR";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_MATERIAL_APOYO_TUTOR";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_MATERIAL_APOYO_TUTOR";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_MATERIAL_APOYO_TUTOR";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_material";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EMATERIALAPOYOTUTOR objMATERIALAPOYO = obj as EMATERIALAPOYOTUTOR;

            prms[0] = db.GetParameter();
            prms[0].Value = objMATERIALAPOYO.CodMaterial;
            prms[0].ParameterName = "@cod_material";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(5);
            EMATERIALAPOYOTUTOR objMATERIALAPOYO = obj as EMATERIALAPOYOTUTOR;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objMATERIALAPOYO.Descripcion;
            prms[0].ParameterName = "@descripcion";

            prms[1] = db.GetParameter();
            prms[1].Value = objMATERIALAPOYO.CodActividadTutor;
            prms[1].ParameterName = "@COD_ACTIVIDAD_TUTOR";

            prms[2] = db.GetParameter();
            prms[2].Value = objMATERIALAPOYO.Archivo;
            prms[2].ParameterName = "@archivo";

            prms[3] = db.GetParameter();
            prms[3].Value = objMATERIALAPOYO.Nombre;
            prms[3].ParameterName = "@nombre";

            prms[4] = db.GetParameter();
            prms[4].Value = objMATERIALAPOYO.CodEmpresa;
            prms[4].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(5);
            EMATERIALAPOYOTUTOR objMATERIALAPOYO = obj as EMATERIALAPOYOTUTOR;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objMATERIALAPOYO.CodMaterial;
            prms[0].ParameterName = "@cod_material";

            prms[1] = db.GetParameter();
            prms[1].Value = objMATERIALAPOYO.CodActividadTutor;
            prms[1].ParameterName = "@COD_ACTIVIDAD_TUTOR";

            prms[2] = db.GetParameter();
            prms[2].Value = objMATERIALAPOYO.Archivo;
            prms[2].ParameterName = "@archivo";

            prms[3] = db.GetParameter();
            prms[3].Value = objMATERIALAPOYO.Nombre;
            prms[3].ParameterName = "@nombre";

            prms[4] = db.GetParameter();
            prms[4].Value = objMATERIALAPOYO.Descripcion;
            prms[4].ParameterName = "@descripcion";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EMATERIALAPOYOTUTOR objRoot = obj as EMATERIALAPOYOTUTOR;

            objRoot.CodMaterial = id;
        }

        #endregion

        #region Public Methods

        public override void Fill(DomainObject obj, IDataReader dr)
        {
            EMATERIALAPOYOTUTOR objMATERIALAPOYO = obj as EMATERIALAPOYOTUTOR;

            //Poner las rutinas del Tools que se necesiten

            objMATERIALAPOYO.CodMaterial = Utiles.ConvertToDecimal(dr["cod_material"]);

            objMATERIALAPOYO.CodActividadTutor = Utiles.ConvertToInt32(dr["COD_ACTIVIDAD_TUTOR"]);

            objMATERIALAPOYO.Archivo = Utiles.ConvertToString(dr["archivo"]);

            objMATERIALAPOYO.Nombre = Utiles.ConvertToString(dr["nombre"]);

            objMATERIALAPOYO.Descripcion = Utiles.ConvertToString(dr["descripcion"]);

            objMATERIALAPOYO.CodEmpresa = Utiles.ConvertToInt32(dr["cod_empresa"]);


        }

        #endregion
    }
}
