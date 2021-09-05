
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLPERFILOBJETO.
	/// </summary>
	public class DLPERFILOBJETO : DLBase
	{
		public DLPERFILOBJETO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_PERFIL_OBJETO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_PERFIL_OBJETO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_PERFIL_OBJETO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_PERFIL_OBJETO";
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
            EPERFILOBJETO objPERFILOBJETO = obj as EPERFILOBJETO;

            prms[0] = db.GetParameter();
            prms[0].Value = objPERFILOBJETO.CodObjeto;
            prms[0].ParameterName = "@cod_objeto";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EPERFILOBJETO objPERFILOBJETO = obj as EPERFILOBJETO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPERFILOBJETO.CodPerfil;
            prms[1].ParameterName = "@cod_perfil";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EPERFILOBJETO objPERFILOBJETO = obj as EPERFILOBJETO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPERFILOBJETO.CodObjeto;
            prms[0].ParameterName = "@cod_objeto";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPERFILOBJETO.CodPerfil;
            prms[1].ParameterName = "@cod_perfil";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EPERFILOBJETO objRoot = obj as EPERFILOBJETO;

            objRoot.CodObjeto = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EPERFILOBJETO objPERFILOBJETO = obj as EPERFILOBJETO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objPERFILOBJETO.CodObjeto = Utiles.ConvertToInt16(dr["cod_objeto"]);

            objPERFILOBJETO.CodPerfil = Utiles.ConvertToInt16(dr["cod_perfil"]);
            
        }

        #endregion

	}
}
