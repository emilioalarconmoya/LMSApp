
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLETIQUETA.
	/// </summary>
	public class DLETIQUETA : DLBase
	{
		public DLETIQUETA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_ETIQUETA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_ETIQUETA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_ETIQUETA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_ETIQUETA";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@nombre_pagina";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EETIQUETA objETIQUETA = obj as EETIQUETA;

            prms[0] = db.GetParameter();
            prms[0].Value = objETIQUETA.NombrePagina;
            prms[0].ParameterName = "@nombre_pagina";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EETIQUETA objETIQUETA = obj as EETIQUETA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objETIQUETA.CodTexto;
            prms[1].ParameterName = "@cod_texto";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objETIQUETA.DescripcionEspanol;
            prms[2].ParameterName = "@descripcion_espanol";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            EETIQUETA objETIQUETA = obj as EETIQUETA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objETIQUETA.NombrePagina;
            prms[0].ParameterName = "@nombre_pagina";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objETIQUETA.CodTexto;
            prms[1].ParameterName = "@cod_texto";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objETIQUETA.DescripcionEspanol;
            prms[2].ParameterName = "@descripcion_espanol";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EETIQUETA objRoot = obj as EETIQUETA;

            objRoot.NombrePagina = Utiles.ConvertToString(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EETIQUETA objETIQUETA = obj as EETIQUETA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objETIQUETA.NombrePagina = Utiles.ConvertToString(dr["nombre_pagina"]);
            
            objETIQUETA.CodTexto = Utiles.ConvertToString(dr["cod_texto"]);

            objETIQUETA.DescripcionEspanol = Utiles.ConvertToString(dr["descripcion_espanol"]);
            
        }

        #endregion

	}
}
