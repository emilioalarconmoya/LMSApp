
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
    public class DLCURSO : DLBase
    {
        public DLCURSO()
        {
        }

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_curso";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_curso";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_CURSO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_CURSO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@Cod_curso";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ECURSO objCURSO = obj as ECURSO;

            prms[0] = db.GetParameter();
            prms[0].Value = objCURSO.CodCurso;
            prms[0].ParameterName = "@Cod_curso";
			
			prms[1] = db.GetParameter();
            prms[1].Value = objCURSO.CodEmpresa; 
            prms[1].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            ECURSO objCURSO = obj as ECURSO;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objCURSO.NombreCurso;
            prms[0].ParameterName = "@Nombre_curso";

            prms[1] = db.GetParameter();
            prms[1].Value = objCURSO.CodTipoCurso;
            prms[1].ParameterName = "@CODTIPOCURSO";
			
			prms[2] = db.GetParameter();
            prms[2].Value = objCURSO.CodEmpresa; 
            prms[2].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(4);
            ECURSO objCURSO = obj as ECURSO;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objCURSO.CodCurso;
            prms[0].ParameterName = "@Cod_curso";

            prms[1] = db.GetParameter();
            prms[1].Value = objCURSO.NombreCurso;
            prms[1].ParameterName = "@Nombre_curso";

            prms[2] = db.GetParameter();
            prms[2].Value = objCURSO.CodTipoCurso;
            prms[2].ParameterName = "@CODTIPOCURSO";
			
			prms[3] = db.GetParameter();
            prms[3].Value = objCURSO.CodEmpresa; 
            prms[3].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ECURSO objRoot = obj as ECURSO;

            objRoot.CodCurso = (int)id;
        }

        public Int16 Serial()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_serial_malla");
            return Utiles.ConvertToInt16(dt.Rows[0][0]);
        }

        #endregion

        #region Public Methods

        public override void Fill(DomainObject obj, IDataReader dr)
        {
            ECURSO objCURSO = obj as ECURSO;

            //Poner las rutinas del Tools que se necesiten

            objCURSO.CodCurso = Utiles.ConvertToInt32(dr["Cod_CURSO"]);

            objCURSO.CodTipoCurso = Utiles.ConvertToInt32(dr["Cod_tipo_CURSO"]);

            objCURSO.NombreCurso = Utiles.ConvertToString(dr["Nombre_CURSO"]);

            objCURSO.NombreTipoCurso = Utiles.ConvertToString(dr["NOMBRE_TIPO_CURSO"]);

            objCURSO.Color = Utiles.ConvertToString(dr["color"]);


        }



        #endregion
    }
}
