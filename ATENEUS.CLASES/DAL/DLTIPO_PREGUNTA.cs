
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLTIPOPREGUNTA.
	/// </summary>
	public class DLTIPOPREGUNTA : DLBase
	{
		public DLTIPOPREGUNTA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_TIPO_PREGUNTA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_TIPO_PREGUNTA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_TIPO_PREGUNTA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_TIPO_PREGUNTA";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_tipo_preg";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ETIPOPREGUNTA objTIPOPREGUNTA = obj as ETIPOPREGUNTA;

            prms[0] = db.GetParameter();
            prms[0].Value = objTIPOPREGUNTA.CodTipoPreg;
            prms[0].ParameterName = "@cod_tipo_preg";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ETIPOPREGUNTA objTIPOPREGUNTA = obj as ETIPOPREGUNTA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objTIPOPREGUNTA.Nombre;
            prms[1].ParameterName = "@nombre";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ETIPOPREGUNTA objTIPOPREGUNTA = obj as ETIPOPREGUNTA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objTIPOPREGUNTA.CodTipoPreg;
            prms[0].ParameterName = "@cod_tipo_preg";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objTIPOPREGUNTA.Nombre;
            prms[1].ParameterName = "@nombre";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ETIPOPREGUNTA objRoot = obj as ETIPOPREGUNTA;

            objRoot.CodTipoPreg = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ETIPOPREGUNTA objTIPOPREGUNTA = obj as ETIPOPREGUNTA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objTIPOPREGUNTA.CodTipoPreg = Utiles.ConvertToInt16(dr["cod_tipo_preg"]);
            
            objTIPOPREGUNTA.Nombre = Utiles.ConvertToString(dr["nombre"]);
            
        }

        #endregion

	}
}
