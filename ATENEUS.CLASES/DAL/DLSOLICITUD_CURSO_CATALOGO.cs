using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;


namespace ATENEUS.CLASES.DAL
{
    public class DLSOLICITUDCURSOCATALOGO : DLBase
    {
        public DLSOLICITUDCURSOCATALOGO()
        {
        }

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_SOLICITUD_CURSO_CATALOGO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_SOLICITUD_CURSO_CATALOGO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_SOLICITUD_CURSOD_CATALOGO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_SOLICITUD_CURSO_CATALOGO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_SOLICITUD";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ESOLICITUDCURSOCATALOGO objsOLICITUDCURSO = obj as ESOLICITUDCURSOCATALOGO;

            prms[0] = db.GetParameter();
            prms[0].Value = objsOLICITUDCURSO.CodSolicitud;
            prms[0].ParameterName = "@COD_SOLICITUD";

           

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(8);
            ESOLICITUDCURSOCATALOGO objsOLICITUDCURSO = obj as ESOLICITUDCURSOCATALOGO;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objsOLICITUDCURSO.CodActividad;
            prms[0].ParameterName = "@COD_ACTIVIDAD";

            prms[1] = db.GetParameter();
            prms[1].Value = objsOLICITUDCURSO.RutUsuario;
            prms[1].ParameterName = "@RUT_USUARIO";

            prms[2] = db.GetParameter();
            prms[2].Value = objsOLICITUDCURSO.FechaSolicitud;
            prms[2].ParameterName = "@FECHA_solicitud";

            prms[3] = db.GetParameter();
            prms[3].Value = objsOLICITUDCURSO.CodEstadoSolicitud;
            prms[3].ParameterName = "@cod_estado_solicitud";

            prms[4] = db.GetParameter();
            prms[4].Value = objsOLICITUDCURSO.CodCatalogo;
            prms[4].ParameterName = "@cod_catalogo";

            prms[5] = db.GetParameter();
            prms[5].Value = objsOLICITUDCURSO.FechaAceptada;
            prms[5].ParameterName = "@fecha_acepta_soli";

            prms[6] = db.GetParameter();
            prms[6].Value = objsOLICITUDCURSO.FechaRechaza;
            prms[6].ParameterName = "@fecha_rechaza_soli";

            prms[7] = db.GetParameter();
            prms[7].Value = objsOLICITUDCURSO.CodEmpresa;
            prms[7].ParameterName = "@cod_empresa";





            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(4);
            ESOLICITUDCURSOCATALOGO objsOLICITUDCURSO = obj as ESOLICITUDCURSOCATALOGO;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objsOLICITUDCURSO.CodSolicitud;
            prms[0].ParameterName = "@cod_solicitud";

            prms[1] = db.GetParameter();
            prms[1].Value = objsOLICITUDCURSO.FechaAceptada;
            prms[1].ParameterName = "@fecha_acepta_soli";

            prms[2] = db.GetParameter();
            prms[2].Value = objsOLICITUDCURSO.FechaRechaza;
            prms[2].ParameterName = "@fecha_rechaza_soli";

            prms[3] = db.GetParameter();
            prms[3].Value = objsOLICITUDCURSO.CodEstadoSolicitud;
            prms[3].ParameterName = "@cod_estado_solicitud";



            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ESOLICITUDCURSOCATALOGO objRoot = obj as ESOLICITUDCURSOCATALOGO;

            objRoot.CodSolicitud = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

        public override void Fill(DomainObject obj, IDataReader dr)
        {
            ESOLICITUDCURSOCATALOGO objsOLICITUDCURSO = obj as ESOLICITUDCURSOCATALOGO;

            //Poner las rutinas del Tools que se necesiten

            objsOLICITUDCURSO.CodSolicitud = Convert.ToInt32(dr["cod_solicitud"]);

            //objsOLICITUDCURSO.CodGrupoActividad = Convert.ToInt32(dr["cod_grupo_actividad"]);

            objsOLICITUDCURSO.RutUsuario = Convert.ToInt32(dr["RUT_USUARIO"]);

            objsOLICITUDCURSO.CodEstadoSolicitud = Convert.ToInt32(dr["cod_estado_solicitud"]);

            //objsOLICITUDCURSO.FechaHora = Convert.ToDateTime(dr["FECHA_HORA"]);


        }

        public ESOLICITUDCURSO SelectSolicitud(Int32 CodCurso, Int32 codActividad, Int32 rutUsuario)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = CodCurso;
            prms[0].ParameterName = "@COD_CURSO";

            prms[1] = db.GetParameter();
            prms[1].Value = codActividad;
            prms[1].ParameterName = "@COD_ACTIVIDAD";

            prms[2] = db.GetParameter();
            prms[2].Value = rutUsuario;
            prms[2].ParameterName = "@RUT_USUARIO";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_SOLICITUD_CURSO", prms);


            DLSOLICITUDCURSO lst = new DLSOLICITUDCURSO();
            ESOLICITUDCURSO objsOLICITUDCURSO = new ESOLICITUDCURSO();
            while (dr.Read())
            {
                objsOLICITUDCURSO.CodCurso = Convert.ToInt32(dr["cod_curso"]);

                objsOLICITUDCURSO.CodActividad = Convert.ToInt32(dr["cod_actividad"]);

                objsOLICITUDCURSO.RutUsuario = Convert.ToInt32(dr["RUT_USUARIO"]);

                objsOLICITUDCURSO.FlagSolicitado = Convert.ToBoolean(dr["flag_solicitado"]);

            }
            dr.Close();
            return objsOLICITUDCURSO;
        }


        //public DataTable SelectCursoActividad(Int32 CodCurso, Int32 CodActividad)
        //{
        //    DB db = DatabaseFactory.Instance.GetDatabase();
        //    IDbDataParameter[] prms;
        //    prms = db.GetArrayParameter(2);

        //    prms[0] = db.GetParameter();
        //    prms[0].Value = CodCurso;
        //    prms[0].ParameterName = "@COD_CURSO";

        //    prms[1] = db.GetParameter();
        //    prms[1].Value = CodActividad;
        //    prms[1].ParameterName = "@COD_ACTIVIDAD";

        //    DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_unidad_actividad", prms);

        //    return dt;
        //}
        #endregion
    }
}
