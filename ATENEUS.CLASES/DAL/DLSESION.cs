
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLSESION.
	/// </summary>
	public class DLSESION : DLBase
	{
		public DLSESION()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_SESION";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_SESION";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_SESION";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_SESION";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@codigo_bitacora";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ESESION objSESION = obj as ESESION;

            prms[0] = db.GetParameter();
            prms[0].Value = objSESION.CodigoBitacora;
            prms[0].ParameterName = "@codigo_bitacora";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ESESION objSESION = obj as ESESION;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objSESION.FechaHora;
            prms[1].ParameterName = "@fecha_hora";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objSESION.PaginaNavegacion;
            prms[2].ParameterName = "@pagina_navegacion";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            ESESION objSESION = obj as ESESION;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objSESION.CodigoBitacora;
            prms[0].ParameterName = "@codigo_bitacora";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objSESION.FechaHora;
            prms[1].ParameterName = "@fecha_hora";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objSESION.PaginaNavegacion;
            prms[2].ParameterName = "@pagina_navegacion";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ESESION objRoot = obj as ESESION;

            objRoot.CodigoBitacora = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ESESION objSESION = obj as ESESION;
    
            //Poner las rutinas del Tools que se necesiten
            
            objSESION.CodigoBitacora = Utiles.ConvertToDecimal(dr["codigo_bitacora"]);
            
            objSESION.FechaHora = Utiles.ConvertToDateTime(dr["fecha_hora"]);

            objSESION.PaginaNavegacion = Utiles.ConvertToString(dr["pagina_navegacion"]);
            
        }

        #endregion

	}
}
