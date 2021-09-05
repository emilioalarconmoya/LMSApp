
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLLINKEXTERNO.
	/// </summary>
	public class DLLINKEXTERNO : DLBase
	{
		public DLLINKEXTERNO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_LINK_EXTERNO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_LINK_EXTERNO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_LINK_EXTERNO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_LINK_EXTERNO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_link";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ELINKEXTERNO objLINKEXTERNO = obj as ELINKEXTERNO;

            prms[0] = db.GetParameter();
            prms[0].Value = objLINKEXTERNO.CodLink;
            prms[0].ParameterName = "@cod_link";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ELINKEXTERNO objLINKEXTERNO = obj as ELINKEXTERNO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objLINKEXTERNO.Url;
            prms[1].ParameterName = "@url";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objLINKEXTERNO.Nombre;
            prms[2].ParameterName = "@nombre";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            ELINKEXTERNO objLINKEXTERNO = obj as ELINKEXTERNO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objLINKEXTERNO.CodLink;
            prms[0].ParameterName = "@cod_link";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objLINKEXTERNO.Url;
            prms[1].ParameterName = "@url";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objLINKEXTERNO.Nombre;
            prms[2].ParameterName = "@nombre";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ELINKEXTERNO objRoot = obj as ELINKEXTERNO;

            objRoot.CodLink = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ELINKEXTERNO objLINKEXTERNO = obj as ELINKEXTERNO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objLINKEXTERNO.CodLink = Utiles.ConvertToInt16(dr["cod_link"]);
            
            objLINKEXTERNO.Url = Utiles.ConvertToString(dr["url"]);

            objLINKEXTERNO.Nombre = Utiles.ConvertToString(dr["nombre"]);
            
        }

        #endregion

	}
}
