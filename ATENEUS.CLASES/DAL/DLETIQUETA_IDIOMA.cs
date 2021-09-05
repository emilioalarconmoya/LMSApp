
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLETIQUETAIDIOMA.
	/// </summary>
	public class DLETIQUETAIDIOMA : DLBase
	{
		public DLETIQUETAIDIOMA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_ETIQUETA_IDIOMA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_ETIQUETA_IDIOMA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_ETIQUETA_IDIOMA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_ETIQUETA_IDIOMA";
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
            EETIQUETAIDIOMA objETIQUETAIDIOMA = obj as EETIQUETAIDIOMA;

            prms[0] = db.GetParameter();
            prms[0].Value = objETIQUETAIDIOMA.NombrePagina;
            prms[0].ParameterName = "@nombre_pagina";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            EETIQUETAIDIOMA objETIQUETAIDIOMA = obj as EETIQUETAIDIOMA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objETIQUETAIDIOMA.CodTexto;
            prms[1].ParameterName = "@cod_texto";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objETIQUETAIDIOMA.CodIdioma;
            prms[2].ParameterName = "@cod_idioma";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objETIQUETAIDIOMA.Texto;
            prms[3].ParameterName = "@texto";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(4);
            EETIQUETAIDIOMA objETIQUETAIDIOMA = obj as EETIQUETAIDIOMA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objETIQUETAIDIOMA.NombrePagina;
            prms[0].ParameterName = "@nombre_pagina";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objETIQUETAIDIOMA.CodTexto;
            prms[1].ParameterName = "@cod_texto";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objETIQUETAIDIOMA.CodIdioma;
            prms[2].ParameterName = "@cod_idioma";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objETIQUETAIDIOMA.Texto;
            prms[3].ParameterName = "@texto";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EETIQUETAIDIOMA objRoot = obj as EETIQUETAIDIOMA;

            objRoot.NombrePagina = Utiles.ConvertToString(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EETIQUETAIDIOMA objETIQUETAIDIOMA = obj as EETIQUETAIDIOMA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objETIQUETAIDIOMA.NombrePagina = Utiles.ConvertToString(dr["nombre_pagina"]);
            
            objETIQUETAIDIOMA.CodTexto = Utiles.ConvertToString(dr["cod_texto"]);
            
            objETIQUETAIDIOMA.CodIdioma = Utiles.ConvertToInt16(dr["cod_idioma"]);

            objETIQUETAIDIOMA.Texto = Utiles.ConvertToString(dr["texto"]);
            
        }

        #endregion

	}
}
