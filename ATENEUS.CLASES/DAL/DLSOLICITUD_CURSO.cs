using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;


namespace ATENEUS.CLASES.DAL
{
    public class DLSOLICITUDCURSO : DLBase
    {
        public DLSOLICITUDCURSO()
        {
        }

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_SOLICITUD_CURSO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_SOLICITUD_CURSO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_SOLICITUD_CURSOD";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_SOLICITUD_CURSO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_CURSO";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(4);
            ESOLICITUDCURSO objsOLICITUDCURSO = obj as ESOLICITUDCURSO;

            prms[0] = db.GetParameter();
            prms[0].Value = objsOLICITUDCURSO.CodCurso;
            prms[0].ParameterName = "@COD_CURSO";

            prms[1] = db.GetParameter();
            prms[1].Value = objsOLICITUDCURSO.CodActividad;
            prms[1].ParameterName = "@COD_ACTIVIDAD";

            prms[2] = db.GetParameter();
            prms[2].Value = objsOLICITUDCURSO.RutUsuario;
            prms[2].ParameterName = "@RUT_USUARIO";
			
			prms[3] = db.GetParameter();
            prms[3].Value = objsOLICITUDCURSO.CodEmpresa; 
            prms[3].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(6);
            ESOLICITUDCURSO objsOLICITUDCURSO = obj as ESOLICITUDCURSO;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objsOLICITUDCURSO.CodCurso;
            prms[0].ParameterName = "@COD_CURSO";

            prms[1] = db.GetParameter();
            prms[1].Value = objsOLICITUDCURSO.CodActividad;
            prms[1].ParameterName = "@COD_ACTIVIDAD";

            prms[2] = db.GetParameter();
            prms[2].Value = objsOLICITUDCURSO.RutUsuario;
            prms[2].ParameterName = "@RUT_USUARIO";

            prms[3] = db.GetParameter();
            prms[3].Value = objsOLICITUDCURSO.FlagSolicitado;
            prms[3].ParameterName = "@FLAG_SOLICITADO";

            prms[4] = db.GetParameter();
            prms[4].Value = objsOLICITUDCURSO.FechaHora;
            prms[4].ParameterName = "@FECHA_HORA";
			
			prms[5] = db.GetParameter();
            prms[5].Value = objsOLICITUDCURSO.CodEmpresa; 
            prms[5].ParameterName = "@cod_empresa";



            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(6);
            ESOLICITUDCURSO objsOLICITUDCURSO = obj as ESOLICITUDCURSO;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objsOLICITUDCURSO.CodCurso;
            prms[0].ParameterName = "@COD_CURSO";

            prms[1] = db.GetParameter();
            prms[1].Value = objsOLICITUDCURSO.CodActividad;
            prms[1].ParameterName = "@COD_ACTIVIDAD";

            prms[2] = db.GetParameter();
            prms[2].Value = objsOLICITUDCURSO.RutUsuario;
            prms[2].ParameterName = "@RUT_USUARIO";

            prms[3] = db.GetParameter();
            prms[3].Value = objsOLICITUDCURSO.FlagSolicitado;
            prms[3].ParameterName = "@FLAG_SOLICITADO";

            prms[4] = db.GetParameter();
            prms[4].Value = objsOLICITUDCURSO.FechaAprobacion;
            prms[4].ParameterName = "@FECHA_APROBACION";
			
			prms[5] = db.GetParameter();
            prms[5].Value = objsOLICITUDCURSO.CodEmpresa; 
            prms[5].ParameterName = "@cod_empresa";


            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ESOLICITUDCURSO objRoot = obj as ESOLICITUDCURSO;

            objRoot.CodCurso = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

        public override void Fill(DomainObject obj, IDataReader dr)
        {
            ESOLICITUDCURSO objsOLICITUDCURSO = obj as ESOLICITUDCURSO;

            //Poner las rutinas del Tools que se necesiten

            objsOLICITUDCURSO.CodCurso = Convert.ToInt32(dr["cod_curso"]);

            objsOLICITUDCURSO.CodActividad = Convert.ToInt32(dr["cod_actividad"]);

            objsOLICITUDCURSO.RutUsuario = Convert.ToInt32(dr["RUT_USUARIO"]);

            objsOLICITUDCURSO.FlagSolicitado = Convert.ToBoolean(dr["flag_solicitado"]);

            objsOLICITUDCURSO.FechaHora = Convert.ToDateTime(dr["FECHA_HORA"]);
			
			 objsOLICITUDCURSO.CodEmpresa = Convert.ToInt64(dr["cod_empresa"]);

        }

        public ESOLICITUDCURSO SelectSolicitud(Int32 CodCurso, Int32 codActividad, Int32 rutUsuario, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(4);

            prms[0] = db.GetParameter();
            prms[0].Value = CodCurso;
            prms[0].ParameterName = "@COD_CURSO";

            prms[1] = db.GetParameter();
            prms[1].Value = codActividad;
            prms[1].ParameterName = "@COD_ACTIVIDAD";

            prms[2] = db.GetParameter();
            prms[2].Value = rutUsuario;
            prms[2].ParameterName = "@RUT_USUARIO";
			
			prms[3] = db.GetParameter();
            prms[3].Value = CodEmpresa; 
            prms[3].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_SOLICITUD_CURSO", prms);


            DLSOLICITUDCURSO lst = new DLSOLICITUDCURSO();
            ESOLICITUDCURSO objsOLICITUDCURSO = new ESOLICITUDCURSO();
            while (dr.Read())
            {
                objsOLICITUDCURSO.CodCurso = Convert.ToInt32(dr["cod_curso"]);

                objsOLICITUDCURSO.CodActividad = Convert.ToInt32(dr["cod_actividad"]);

                objsOLICITUDCURSO.RutUsuario = Convert.ToInt32(dr["RUT_USUARIO"]);

                objsOLICITUDCURSO.FlagSolicitado = Convert.ToBoolean(dr["flag_solicitado"]);
				
				objsOLICITUDCURSO.CodEmpresa = Convert.ToInt64(dr["cod_empresa"]);

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
