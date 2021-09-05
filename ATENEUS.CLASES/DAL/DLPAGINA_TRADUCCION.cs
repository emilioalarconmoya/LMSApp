
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLPAGINATRADUCCION.
	/// </summary>
	public class DLPAGINATRADUCCION : DLBase
	{
		public DLPAGINATRADUCCION()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_PAGINA_TRADUCCION";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_PAGINA_TRADUCCION";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_PAGINA_TRADUCCION";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_PAGINA_TRADUCCION";
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
            EPAGINATRADUCCION objPAGINATRADUCCION = obj as EPAGINATRADUCCION;

            prms[0] = db.GetParameter();
            prms[0].Value = objPAGINATRADUCCION.NombrePagina;
            prms[0].ParameterName = "@nombre_pagina";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EPAGINATRADUCCION objPAGINATRADUCCION = obj as EPAGINATRADUCCION;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPAGINATRADUCCION.Descripcion;
            prms[1].ParameterName = "@descripcion";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EPAGINATRADUCCION objPAGINATRADUCCION = obj as EPAGINATRADUCCION;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPAGINATRADUCCION.NombrePagina;
            prms[0].ParameterName = "@nombre_pagina";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPAGINATRADUCCION.Descripcion;
            prms[1].ParameterName = "@descripcion";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EPAGINATRADUCCION objRoot = obj as EPAGINATRADUCCION;

            objRoot.NombrePagina = Utiles.ConvertToString(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EPAGINATRADUCCION objPAGINATRADUCCION = obj as EPAGINATRADUCCION;
    
            //Poner las rutinas del Tools que se necesiten
            
            objPAGINATRADUCCION.NombrePagina = Utiles.ConvertToString(dr["nombre_pagina"]);
            
            objPAGINATRADUCCION.Descripcion = Utiles.ConvertToString(dr["descripcion"]);
            
        }

        #endregion

	}
}
