using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
    public class DLCURSOACTIVIDAD : DLBase
    {
        public DLCURSOACTIVIDAD()
        {
        }

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_CURSO_ACTIVIDAD";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_CURSO_ACTIVIDAD";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_CURSO_ACTIVIDAD";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_CURSO_ACTIVIDAD";
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
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ECURSOACTIVIDAD objCURSOACTIVIDAD = obj as ECURSOACTIVIDAD;

            prms[0] = db.GetParameter();
            prms[0].Value = objCURSOACTIVIDAD.CodCurso;
            prms[0].ParameterName = "@COD_CURSO";
			
			prms[1] = db.GetParameter();
            prms[1].Value = objCURSOACTIVIDAD.CodEmpresa; 
            prms[1].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(7);
            ECURSOACTIVIDAD objCURSOACTIVIDAD = obj as ECURSOACTIVIDAD;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objCURSOACTIVIDAD.CodCurso;
            prms[0].ParameterName = "@COD_CURSO";

            prms[1] = db.GetParameter();
            prms[1].Value = objCURSOACTIVIDAD.CodActividad;
            prms[1].ParameterName = "@COD_ACTIVIDAD";

            prms[2] = db.GetParameter();
            prms[2].Value = objCURSOACTIVIDAD.FlagAutoInscripcion;
            prms[2].ParameterName = "@FLAG_AUTO_INSCRIPCION";

            prms[3] = db.GetParameter();
            prms[3].Value = objCURSOACTIVIDAD.FlagSolicitado;
            prms[3].ParameterName = "@FLAG_SOLICITADO";

            prms[4] = db.GetParameter();
            prms[4].Value = objCURSOACTIVIDAD.DiasAutoInscripcion;
            prms[4].ParameterName = "@DIAS_AUTOINSCRIPCION";

            prms[5] = db.GetParameter();
            prms[5].Value = objCURSOACTIVIDAD.NotaMinima;
            prms[5].ParameterName = "@NOTA_MINIMA";
			
			prms[6] = db.GetParameter();
            prms[6].Value = objCURSOACTIVIDAD.CodEmpresa; 
            prms[6].ParameterName = "@cod_empresa";
			
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(7);
            ECURSOACTIVIDAD objCURSOACTIVIDAD = obj as ECURSOACTIVIDAD;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objCURSOACTIVIDAD.CodCurso;
            prms[0].ParameterName = "@COD_CURSO";

            prms[1] = db.GetParameter();
            prms[1].Value = objCURSOACTIVIDAD.CodActividad;
            prms[1].ParameterName = "@COD_ACTIVIDAD";

            prms[2] = db.GetParameter();
            prms[2].Value = objCURSOACTIVIDAD.FlagAutoInscripcion;
            prms[2].ParameterName = "@FLAG_AUTO_INSCRIPCION";

            prms[3] = db.GetParameter();
            prms[3].Value = objCURSOACTIVIDAD.FlagSolicitado;
            prms[3].ParameterName = "@FLAG_SOLICITADO";

            prms[4] = db.GetParameter();
            prms[4].Value = objCURSOACTIVIDAD.DiasAutoInscripcion;
            prms[4].ParameterName = "@DIAS_AUTOINSCRIPCION";

            prms[5] = db.GetParameter();
            prms[5].Value = objCURSOACTIVIDAD.NotaMinima;
            prms[5].ParameterName = "@NOTA_MINIMA";
			
			prms[6] = db.GetParameter();
            prms[6].Value = objCURSOACTIVIDAD.CodEmpresa; 
            prms[6].ParameterName = "@cod_empresa";


            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ECURSOACTIVIDAD objRoot = obj as ECURSOACTIVIDAD;

            objRoot.CodCurso = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

        public override void Fill(DomainObject obj, IDataReader dr)
        {
            ECURSOACTIVIDAD objCURSOACTIVIDAD = obj as ECURSOACTIVIDAD;

            //Poner las rutinas del Tools que se necesiten

            objCURSOACTIVIDAD.CodCurso= Convert.ToInt32(dr["cod_curso"]);

            objCURSOACTIVIDAD.CodActividad = Convert.ToInt32(dr["cod_actividad"]);

            objCURSOACTIVIDAD.FlagAutoInscripcion= Convert.ToBoolean(dr["flag_auto_inscripcion"]);

            objCURSOACTIVIDAD.FlagSolicitado = Convert.ToBoolean(dr["flag_solicitado"]);

            objCURSOACTIVIDAD.DiasAutoInscripcion = Convert.ToInt32(dr["dias_autoinscripcion"]);

            objCURSOACTIVIDAD.NotaMinima = Convert.ToDouble(dr["nota_minima"]);

        }

        public ECURSOACTIVIDAD SelectActividad(Int32 CodCurso, Int32 codActividad, Int64 CodEmpresa)
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
            prms[2].Value = CodEmpresa; 
            prms[2].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_CURSO_ACTIVIDAD", prms);


            DLCURSOACTIVIDAD lst = new DLCURSOACTIVIDAD();
            ECURSOACTIVIDAD objCURSOACTIVIDAD = new ECURSOACTIVIDAD();
            while (dr.Read())
            {
                objCURSOACTIVIDAD.CodActividad = Utiles.ConvertToInt16(dr["cod_actividad"]);
                objCURSOACTIVIDAD.CodCurso = Utiles.ConvertToInt16(dr["COD_CURSO"]);
                objCURSOACTIVIDAD.FlagAutoInscripcion = Utiles.ConvertToBoolean(dr["FLAG_AUTO_INSCRIPCION"]);
                objCURSOACTIVIDAD.FlagSolicitado = Utiles.ConvertToBoolean(dr["FLAG_SOLICITADO"]);
                objCURSOACTIVIDAD.DiasAutoInscripcion = Utiles.ConvertToInt16(dr["dias_autoinscripcion"]);
                objCURSOACTIVIDAD.NotaMinima = Utiles.ConvertToDouble(dr["NOTA_MINIMA"]);
				objCURSOACTIVIDAD.CodEmpresa = Utiles.ConvertToInt64(dr["COD_EMPRESA"]);
                
            }
            dr.Close();
            return objCURSOACTIVIDAD;
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
