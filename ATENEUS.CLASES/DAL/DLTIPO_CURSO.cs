using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
    /// <summary>
	/// Summary description for DLTIPOCURSO.
	/// </summary>
    public class DLTIPOCURSO : DLBase
    {
        public DLTIPOCURSO()
        {
        }

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_TIPO_CURSO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_TIPO_CURSO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_TIPO_CURSO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_TIPO_CURSO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_tipo_curso";
			
		

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ETIPOCURSO objTIPOCURSO = obj as ETIPOCURSO;

            prms[0] = db.GetParameter();
            prms[0].Value = objTIPOCURSO.CodTipoCurso;
            prms[0].ParameterName = "@cod_tipo_curso";
			
			prms[1] = db.GetParameter();
            prms[1].Value = objTIPOCURSO.CodEmpresa; 
            prms[1].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(4);
            ETIPOCURSO objTIPOCURSO = obj as ETIPOCURSO;

            //Poner las rutinas del Tools que se necesiten
            //prms[0] = db.GetParameter();
            //prms[0].Value = objTIPOCURSO.CodTipoCurso;
            //prms[0].ParameterName = "@cod_tipo_curso";

            prms[0] = db.GetParameter();
            prms[0].Value = objTIPOCURSO.NombreCurso;
            prms[0].ParameterName = "@nombre_curso";

            prms[1] = db.GetParameter();
            prms[1].Value = objTIPOCURSO.Observacion;
            prms[1].ParameterName = "@observacion";

            prms[2] = db.GetParameter();
            prms[2].Value = objTIPOCURSO.Color;
            prms[2].ParameterName = "@color";
			
			prms[3] = db.GetParameter();
            prms[3].Value = objTIPOCURSO.CodEmpresa; 
            prms[3].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(5);
            ETIPOCURSO objTIPOCURSO = obj as ETIPOCURSO;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objTIPOCURSO.CodTipoCurso;
            prms[0].ParameterName = "@COD_TIPO_CURSO";

            prms[1] = db.GetParameter();
            prms[1].Value = objTIPOCURSO.NombreCurso;
            prms[1].ParameterName = "@NOMBRE_CURSO";

            prms[2] = db.GetParameter();
            prms[2].Value = objTIPOCURSO.Observacion;
            prms[2].ParameterName = "@OBSERVACION";

            prms[3] = db.GetParameter();
            prms[3].Value = objTIPOCURSO.Color;
            prms[3].ParameterName = "@color";
			
			prms[4] = db.GetParameter();
            prms[4].Value = objTIPOCURSO.CodEmpresa; 
            prms[4].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ETIPOCURSO objRoot = obj as ETIPOCURSO;

            objRoot.CodTipoCurso = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

        public override void Fill(DomainObject obj, IDataReader dr)
        {
            ETIPOCURSO objTIPOACTIVIDAD = obj as ETIPOCURSO;

            //Poner las rutinas del Tools que se necesiten

            objTIPOACTIVIDAD.CodTipoCurso = Utiles.ConvertToInt16(dr["cod_tipo_curso"]);

            objTIPOACTIVIDAD.NombreCurso = Utiles.ConvertToString(dr["nombre_curso"]);

            objTIPOACTIVIDAD.Observacion = Utiles.ConvertToString(dr["observacion"]);

            objTIPOACTIVIDAD.Color = Utiles.ConvertToString(dr["color"]);
			
			objTIPOACTIVIDAD.CodEmpresa = Utiles.ConvertToInt64(dr["cod_empresa"]);

        }

        #endregion
    }
}
