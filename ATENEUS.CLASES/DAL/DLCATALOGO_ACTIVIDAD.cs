using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;


namespace ATENEUS.CLASES.DAL
{
    public class DLCATALOGOACTIVIDAD : DLBase
    {
        public DLCATALOGOACTIVIDAD()
        {
        }

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_CATALOGO_ACTIVIDAD";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_CATALOGO_ACTIVIDAD";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_CATALOGO_ACTIVIDAD";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_CATALOGO_ACTIVIDAD";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_CATALOGO";

            return prms;
        }


        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ECATALOGOACTIVIDAD objCATALOGO = obj as ECATALOGOACTIVIDAD;

            prms[0] = db.GetParameter();
            prms[0].Value = objCATALOGO.Codcatalogo;
            prms[0].ParameterName = "@cod_CATALOGO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(8);
            ECATALOGOACTIVIDAD objCATALOGO = obj as ECATALOGOACTIVIDAD;

            //Poner las rutinas del Tools que se necesiten

           
            prms[0] = db.GetParameter();
            prms[0].Value = objCATALOGO.Stock;
            prms[0].ParameterName = "@STOCK";

            prms[1] = db.GetParameter();
            prms[1].Value = objCATALOGO.CodActividad;
            prms[1].ParameterName = "@COD_ACTIVIDAD";

            prms[2] = db.GetParameter();
            prms[2].Value = objCATALOGO.Codcatalogo;
            prms[2].ParameterName = "@COD_CATALOGO";

            prms[3] = db.GetParameter();
            prms[3].Value = objCATALOGO.DiasAutoInscripcion;
            prms[3].ParameterName = "@dias_auto_inscripcion";

            prms[4] = db.GetParameter();
            prms[4].Value = objCATALOGO.FlagInscribirCurso;
            prms[4].ParameterName = "@flag_inscribir_curso";

            prms[5] = db.GetParameter();
            prms[5].Value = objCATALOGO.FlagDiploma;
            prms[5].ParameterName = "@flag_diploma";

            prms[6] = db.GetParameter();
            prms[6].Value = objCATALOGO.NotaMinima;
            prms[6].ParameterName = "@nota_minima";

            prms[7] = db.GetParameter();
            prms[7].Value = objCATALOGO.CodEmpresa;
            prms[7].ParameterName = "@cod_empresa";


            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(8);
            ECATALOGOACTIVIDAD objCATALOGO = obj as ECATALOGOACTIVIDAD;

            //Poner las rutinas del Tools que se necesiten


            prms[0] = db.GetParameter();
            prms[0].Value = objCATALOGO.Stock;
            prms[0].ParameterName = "@STOCK";

            prms[1] = db.GetParameter();
            prms[1].Value = objCATALOGO.CodActividad;
            prms[1].ParameterName = "@COD_ACTIVIDAD";

            prms[2] = db.GetParameter();
            prms[2].Value = objCATALOGO.Codcatalogo;
            prms[2].ParameterName = "@COD_CATALOGO";

            prms[3] = db.GetParameter();
            prms[3].Value = objCATALOGO.DiasAutoInscripcion;
            prms[3].ParameterName = "@dias_auto_inscripcion";

            prms[4] = db.GetParameter();
            prms[4].Value = objCATALOGO.FlagInscribirCurso;
            prms[4].ParameterName = "@flag_inscribir_curso";

            prms[5] = db.GetParameter();
            prms[5].Value = objCATALOGO.FlagDiploma;
            prms[5].ParameterName = "@flag_diploma";

            prms[6] = db.GetParameter();
            prms[6].Value = objCATALOGO.NotaMinima;
            prms[6].ParameterName = "@nota_minima";

            prms[7] = db.GetParameter();
            prms[7].Value = objCATALOGO.CodEmpresa;
            prms[7].ParameterName = "@cod_empresa";


            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ECATALOGOACTIVIDAD objRoot = obj as ECATALOGOACTIVIDAD;

            objRoot.CodcatalogoActividad = Utiles.ConvertToInt16(id);
        }

        public Int32 Serial()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_serial_CATALOGO_actividad");
            return Utiles.ConvertToInt32(dt.Rows[0][0]);
        }


        #endregion

        #region Public Methods

        public override void Fill(DomainObject obj, IDataReader dr)
        {
            ECATALOGOACTIVIDAD objCATALOGO = obj as ECATALOGOACTIVIDAD;

            //Poner las rutinas del Tools que se necesiten

            objCATALOGO.CodcatalogoActividad = Utiles.ConvertToInt32(dr["cod_CATALOGO_actividad"]);

            objCATALOGO.Stock = Utiles.ConvertToInt16(dr["STOCK"]);

            objCATALOGO.CodActividad = Utiles.ConvertToInt32(dr["COD_ACTIVIDAD"]);

            objCATALOGO.Codcatalogo = Utiles.ConvertToInt32(dr["COD_CATALOGO"]);

            objCATALOGO.DiasAutoInscripcion = Utiles.ConvertToInt32(dr["dias_auto_inscripcion"]);

            objCATALOGO.FlagInscribirCurso = Utiles.ConvertToBoolean(dr["flag_inscribir_curso"]);

            objCATALOGO.NotaMinima = Utiles.ConvertToInt32(dr["nota_minima"]);

            objCATALOGO.FlagDiploma = Utiles.ConvertToBoolean(dr["flag_diploma"]);

            objCATALOGO.CodEmpresa = Utiles.ConvertToInt32(dr["cod_empresa"]);

        }


        public Int32 StockDisponible(Int32 CodActividad, int codCATALOGO, long codEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActividad;
            prms[0].ParameterName = "@cod_actividad";

            prms[1] = db.GetParameter();
            prms[1].Value = codCATALOGO;
            prms[1].ParameterName = "@cod_CATALOGO";

            prms[2] = db.GetParameter();
            prms[2].Value = codEmpresa;
            prms[2].ParameterName = "@cod_empresa";




            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_stock_diplonible", prms);

            if (dt.Rows.Count > 0)
            {
                return Utiles.ConvertToInt32(dt.Rows.Count);
            }
            else
            {
                return 0;
            }

        }

        public Int32 CodCATALOGOUsuario(long rutUsuario)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = rutUsuario;
            prms[0].ParameterName = "@rut_usuario";



            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "[proc_select_cod_CATALOGO_usuario]", prms);

            if (dt.Rows.Count > 0)
            {
                return Utiles.ConvertToInt32(dt.Rows[0][0]);
            }
            else
            {
                return 0;
            }

        }

        public DataTable SelectActividadesCatalogo(long CodCatalogo)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodCatalogo;
            prms[0].ParameterName = "@COD_CATALOGO";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "[proc_select_actividades_catalogo]", prms);

            return dt;
        }

        #endregion
    }
}
