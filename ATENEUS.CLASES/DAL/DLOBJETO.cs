
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLOBJETO.
	/// </summary>
	public class DLOBJETO : DLBase
	{
		public DLOBJETO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_OBJETO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_OBJETO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_OBJETO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_OBJETO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_objeto";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EOBJETO objOBJETO = obj as EOBJETO;

            prms[0] = db.GetParameter();
            prms[0].Value = objOBJETO.CodObjeto;
            prms[0].ParameterName = "@cod_objeto";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EOBJETO objOBJETO = obj as EOBJETO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objOBJETO.Nombre;
            prms[1].ParameterName = "@nombre";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EOBJETO objOBJETO = obj as EOBJETO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objOBJETO.CodObjeto;
            prms[0].ParameterName = "@cod_objeto";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objOBJETO.Nombre;
            prms[1].ParameterName = "@nombre";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EOBJETO objRoot = obj as EOBJETO;

            objRoot.CodObjeto = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EOBJETO objOBJETO = obj as EOBJETO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objOBJETO.CodObjeto = Utiles.ConvertToInt16(dr["cod_objeto"]);
            
            objOBJETO.Nombre = Utiles.ConvertToString(dr["nombre"]);
            
        }

        #endregion

	}
}
