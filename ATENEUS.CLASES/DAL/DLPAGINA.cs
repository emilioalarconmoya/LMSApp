
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLPAGINA.
	/// </summary>
	public class DLPAGINA : DLBase
	{
		public DLPAGINA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_PAGINA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_PAGINA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_PAGINA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_PAGINA";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@path";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EPAGINA objPAGINA = obj as EPAGINA;

            prms[0] = db.GetParameter();
            prms[0].Value = objPAGINA.Path;
            prms[0].ParameterName = "@path";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EPAGINA objPAGINA = obj as EPAGINA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPAGINA.NombreExterno;
            prms[1].ParameterName = "@nombre_externo";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EPAGINA objPAGINA = obj as EPAGINA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPAGINA.Path;
            prms[0].ParameterName = "@path";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPAGINA.NombreExterno;
            prms[1].ParameterName = "@nombre_externo";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EPAGINA objRoot = obj as EPAGINA;

            objRoot.Path = Utiles.ConvertToString(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EPAGINA objPAGINA = obj as EPAGINA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objPAGINA.Path = Utiles.ConvertToString(dr["path"]);
            
            objPAGINA.NombreExterno = Utiles.ConvertToString(dr["nombre_externo"]);
            
        }

        #endregion

	}
}
