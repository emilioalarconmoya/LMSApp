

using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLCATEGORIAPRODUCTO.
	/// </summary>
	public class DLCATEGORIAPRODUCTO : DLBase
	{
		public DLCATEGORIAPRODUCTO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_CATEGORIA_PRODUCTO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_CATEGORIA_PRODUCTO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_CATEGORIA_PRODUCTO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_insert_CATEGORIA_PRODUCTO";
            //return "proc_update_CATEGORIA_PRODUCTO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_CATEGORIA";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ECATEGORIAPRODUCTO objCATEGORIAPRODUCTO = obj as ECATEGORIAPRODUCTO;

            prms[0] = db.GetParameter();
            prms[0].Value = objCATEGORIAPRODUCTO.CODCATEGORIA;
            prms[0].ParameterName = "@COD_CATEGORIA";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            ECATEGORIAPRODUCTO objCATEGORIAPRODUCTO = obj as ECATEGORIAPRODUCTO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCATEGORIAPRODUCTO.CODCATEGORIA;
            prms[0].ParameterName = "@COD_CATEGORIA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCATEGORIAPRODUCTO.NOMBRE;
            prms[1].ParameterName = "@NOMBRE";

            prms[2] = db.GetParameter();
            prms[2].Value = objCATEGORIAPRODUCTO.CODEMPRESA;
            prms[2].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ECATEGORIAPRODUCTO objCATEGORIAPRODUCTO = obj as ECATEGORIAPRODUCTO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCATEGORIAPRODUCTO.CODCATEGORIA;
            prms[0].ParameterName = "@COD_CATEGORIA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCATEGORIAPRODUCTO.NOMBRE;
            prms[1].ParameterName = "@NOMBRE";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ECATEGORIAPRODUCTO objRoot = obj as ECATEGORIAPRODUCTO;

            objRoot.CODCATEGORIA = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ECATEGORIAPRODUCTO objCATEGORIAPRODUCTO = obj as ECATEGORIAPRODUCTO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objCATEGORIAPRODUCTO.CODCATEGORIA = Utiles.ConvertToInt16(dr["COD_CATEGORIA"]);
            
            objCATEGORIAPRODUCTO.NOMBRE = Utiles.ConvertToString(dr["NOMBRE"]);
            
        }

        #endregion

	}
}
