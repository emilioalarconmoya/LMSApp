
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
    public class DLCURSOMALLA : DLBase
    {
        public DLCURSOMALLA()
        {
        }

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_curso_malla";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_curso_MALLA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_curso_MALLA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_curso_malla";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@Cod_Malla";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ECURSOMALLA objCURSOMALLA = obj as ECURSOMALLA;

            prms[0] = db.GetParameter();
            prms[0].Value = objCURSOMALLA.CodMalla;
            prms[0].ParameterName = "@Cod_Malla";
			
			prms[1] = db.GetParameter();
            prms[1].Value = objCURSOMALLA.CodEmpresa; 
            prms[1].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(6);
            ECURSOMALLA objCURSOMALLA = obj as ECURSOMALLA;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objCURSOMALLA.CodMalla;
            prms[0].ParameterName = "@cod_malla";

            prms[1] = db.GetParameter();
            prms[1].Value = objCURSOMALLA.CodCurso;
            prms[1].ParameterName = "@cod_curso";

            prms[2] = db.GetParameter();
            prms[2].Value = objCURSOMALLA.Nivel;
            prms[2].ParameterName = "@nivel";

            prms[3] = db.GetParameter();
            prms[3].Value = objCURSOMALLA.Prequisito;
            prms[3].ParameterName = "@pre_requisito";

            prms[4] = db.GetParameter();
            prms[4].Value = objCURSOMALLA.Orden;
            prms[4].ParameterName = "@orden";
			
			prms[5] = db.GetParameter();
            prms[5].Value = objCURSOMALLA.CodEmpresa; 
            prms[5].ParameterName = "@cod_empresa";

            

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(6);
            ECURSOMALLA objCURSOMALLA = obj as ECURSOMALLA;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objCURSOMALLA.CodMalla;
            prms[0].ParameterName = "@cod_malla";

            prms[1] = db.GetParameter();
            prms[1].Value = objCURSOMALLA.CodCurso;
            prms[1].ParameterName = "@cod_curso";

            prms[2] = db.GetParameter();
            prms[2].Value = objCURSOMALLA.Nivel;
            prms[2].ParameterName = "@nivel";

            prms[3] = db.GetParameter();
            prms[3].Value = objCURSOMALLA.Prequisito;
            prms[3].ParameterName = "@pre_requisito";

            prms[4] = db.GetParameter();
            prms[4].Value = objCURSOMALLA.Orden;
            prms[4].ParameterName = "@orden";
			
			prms[5] = db.GetParameter();
            prms[5].Value = objCURSOMALLA.CodEmpresa; 
            prms[5].ParameterName = "@cod_empresa";

           

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EACTIVIDADMALLA objRoot = obj as EACTIVIDADMALLA;

            objRoot.CodMalla = id;
        }

        #endregion

        #region Public Methods

        public override void Fill(DomainObject obj, IDataReader dr)
        {
            ECURSOMALLA objCURSOMALLA = obj as ECURSOMALLA;

            //Poner las rutinas del Tools que se necesiten

            objCURSOMALLA.CodMalla = Utiles.ConvertToDecimal(dr["Cod_Malla"]);

            objCURSOMALLA.CodCurso = Utiles.ConvertToInt16(dr["cod_actividad"]);

            objCURSOMALLA.Nivel = Utiles.ConvertToInt32(dr["nivel"]);
            
            objCURSOMALLA.Prequisito = Utiles.ConvertToInt32(dr["pre_requisito"]);

            objCURSOMALLA.Orden = Utiles.ConvertToInt32(dr["orden"]);
			
			objCURSOMALLA.CodEmpresa = Utiles.ConvertToInt32(dr["COD_EMPRESA"]);

            

        }

        #endregion
    }
}
