

using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLPRODUCTO.
	/// </summary>
	public class DLPRODUCTO : DLBase
	{
		public DLPRODUCTO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_PRODUCTO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_PRODUCTO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_PRODUCTO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_PRODUCTO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_PRODUCTO";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EPRODUCTO objPRODUCTO = obj as EPRODUCTO;

            prms[0] = db.GetParameter();
            prms[0].Value = objPRODUCTO.CODPRODUCTO;
            prms[0].ParameterName = "@COD_PRODUCTO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(6);
            EPRODUCTO objPRODUCTO = obj as EPRODUCTO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPRODUCTO.CODPRODUCTO;
            prms[0].ParameterName = "@COD_PRODUCTO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPRODUCTO.CODCATEGORIA;
            prms[1].ParameterName = "@COD_CATEGORIA";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objPRODUCTO.NOMBRE;
            prms[2].ParameterName = "@NOMBRE";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objPRODUCTO.DESCRIPCION;
            prms[3].ParameterName = "@DESCRIPCION";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objPRODUCTO.FOTO;
            prms[4].ParameterName = "@FOTO";

            prms[5] = db.GetParameter();
            prms[5].Value = objPRODUCTO.CodEmpresa;
            prms[5].ParameterName = "@cod_empresa";


            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(5);
            EPRODUCTO objPRODUCTO = obj as EPRODUCTO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPRODUCTO.CODPRODUCTO;
            prms[0].ParameterName = "@COD_PRODUCTO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPRODUCTO.CODCATEGORIA;
            prms[1].ParameterName = "@COD_CATEGORIA";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objPRODUCTO.NOMBRE;
            prms[2].ParameterName = "@NOMBRE";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objPRODUCTO.DESCRIPCION;
            prms[3].ParameterName = "@DESCRIPCION";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objPRODUCTO.FOTO;
            prms[4].ParameterName = "@FOTO";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EPRODUCTO objRoot = obj as EPRODUCTO;

            objRoot.CODPRODUCTO = Utiles.ConvertToString(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EPRODUCTO objPRODUCTO = obj as EPRODUCTO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objPRODUCTO.CODPRODUCTO = Utiles.ConvertToString(dr["COD_PRODUCTO"]);
            
            objPRODUCTO.CODCATEGORIA = Utiles.ConvertToInt16(dr["COD_CATEGORIA"]);
            
            objPRODUCTO.NOMBRE = Utiles.ConvertToString(dr["NOMBRE"]);
            
            objPRODUCTO.DESCRIPCION = Utiles.ConvertToString(dr["DESCRIPCION"]);
            
            objPRODUCTO.FOTO = Utiles.ConvertToString(dr["FOTO"]);
            
        }

        #endregion

	}
}
