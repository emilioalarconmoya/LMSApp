
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLMODULOPAGINA.
	/// </summary>
	public class DLMODULOPAGINA : DLBase
	{
		public DLMODULOPAGINA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_MODULO_PAGINA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_MODULO_PAGINA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_MODULO_PAGINA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_MODULO_PAGINA";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_modulo";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EMODULOPAGINA objMODULOPAGINA = obj as EMODULOPAGINA;

            prms[0] = db.GetParameter();
            prms[0].Value = objMODULOPAGINA.CodModulo;
            prms[0].ParameterName = "@cod_modulo";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EMODULOPAGINA objMODULOPAGINA = obj as EMODULOPAGINA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objMODULOPAGINA.PathOrigen;
            prms[1].ParameterName = "@path_origen";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objMODULOPAGINA.Path;
            prms[2].ParameterName = "@path";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            EMODULOPAGINA objMODULOPAGINA = obj as EMODULOPAGINA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objMODULOPAGINA.CodModulo;
            prms[0].ParameterName = "@cod_modulo";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objMODULOPAGINA.PathOrigen;
            prms[1].ParameterName = "@path_origen";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objMODULOPAGINA.Path;
            prms[2].ParameterName = "@path";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EMODULOPAGINA objRoot = obj as EMODULOPAGINA;

            objRoot.CodModulo = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EMODULOPAGINA objMODULOPAGINA = obj as EMODULOPAGINA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objMODULOPAGINA.CodModulo = Utiles.ConvertToInt16(dr["cod_modulo"]);
            
            objMODULOPAGINA.PathOrigen = Utiles.ConvertToString(dr["path_origen"]);

            objMODULOPAGINA.Path = Utiles.ConvertToString(dr["path"]);
            
        }

        #endregion

	}
}
