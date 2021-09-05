
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLPERFIL.
	/// </summary>
	public class DLPERFIL : DLBase
	{
		public DLPERFIL()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_PERFIL";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_PERFIL";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_PERFIL";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_PERFIL";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_perfil";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EPERFIL objPERFIL = obj as EPERFIL;

            prms[0] = db.GetParameter();
            prms[0].Value = objPERFIL.CodPerfil;
            prms[0].ParameterName = "@cod_perfil";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EPERFIL objPERFIL = obj as EPERFIL;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPERFIL.Nombre;
            prms[1].ParameterName = "@nombre";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EPERFIL objPERFIL = obj as EPERFIL;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPERFIL.CodPerfil;
            prms[0].ParameterName = "@cod_perfil";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPERFIL.Nombre;
            prms[1].ParameterName = "@nombre";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EPERFIL objRoot = obj as EPERFIL;

            objRoot.CodPerfil = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EPERFIL objPERFIL = obj as EPERFIL;
    
            //Poner las rutinas del Tools que se necesiten
            
            objPERFIL.CodPerfil = Utiles.ConvertToInt16(dr["cod_perfil"]);
            
            objPERFIL.Nombre = Utiles.ConvertToString(dr["nombre"]);
            
        }

        #endregion

	}
}
