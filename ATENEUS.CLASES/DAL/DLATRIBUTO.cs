
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLATRIBUTO.
	/// </summary>
	public class DLATRIBUTO : DLBase
	{
		public DLATRIBUTO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_ATRIBUTO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_ATRIBUTO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_ATRIBUTO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_ATRIBUTO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_atributo";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EATRIBUTO objATRIBUTO = obj as EATRIBUTO;

            prms[0] = db.GetParameter();
            prms[0].Value = objATRIBUTO.CodAtributo;
            prms[0].ParameterName = "@cod_atributo";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EATRIBUTO objATRIBUTO = obj as EATRIBUTO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objATRIBUTO.CodCaracteristica;
            prms[1].ParameterName = "@cod_caracteristica";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objATRIBUTO.Nombre;
            prms[2].ParameterName = "@nombre";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            EATRIBUTO objATRIBUTO = obj as EATRIBUTO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objATRIBUTO.CodAtributo;
            prms[0].ParameterName = "@cod_atributo";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objATRIBUTO.CodCaracteristica;
            prms[1].ParameterName = "@cod_caracteristica";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objATRIBUTO.Nombre;
            prms[2].ParameterName = "@nombre";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EATRIBUTO objRoot = obj as EATRIBUTO;

            objRoot.CodAtributo = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EATRIBUTO objATRIBUTO = obj as EATRIBUTO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objATRIBUTO.CodAtributo = Utiles.ConvertToInt16(dr["cod_atributo"]);
            
            objATRIBUTO.CodCaracteristica = Utiles.ConvertToInt16(dr["cod_caracteristica"]);

            objATRIBUTO.Nombre = Utiles.ConvertToString(dr["nombre"]);
            
        }

        #endregion

	}
}
