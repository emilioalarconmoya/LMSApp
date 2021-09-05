

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
	public class DLCATEGORIAACTIVIDAD : DLBase
	{
		public DLCATEGORIAACTIVIDAD()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_CATEGORIA_ACTIVIDAD";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_CATEGORIA_ACTIVIDAD";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_CATEGORIA_ACTIVIDAD";
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
            ECATAGORIAACTIVIDAD objCATEGORIAACTIVIDAD = obj as ECATAGORIAACTIVIDAD;

            prms[0] = db.GetParameter();
            prms[0].Value = objCATEGORIAACTIVIDAD.CodCategoria;
            prms[0].ParameterName = "@COD_CATEGORIA";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            ECATAGORIAACTIVIDAD objCATEGORIAACTIVIDAD = obj as ECATAGORIAACTIVIDAD;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objCATEGORIAACTIVIDAD.NombreCategoria;
            prms[0].ParameterName = "@NOMBRE_CATEGORIA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCATEGORIAACTIVIDAD.NombreClass;
            prms[1].ParameterName = "@NOMBRE_CLASS";

            prms[2] = db.GetParameter();
            prms[2].Value = objCATEGORIAACTIVIDAD.CodEmpresa;
            prms[2].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ECATAGORIAACTIVIDAD objCATEGORIAACTIVIDAD = obj as ECATAGORIAACTIVIDAD;

            //Poner las rutinas del Tools que se necesiten

            //prms[0] = db.GetParameter();
            //prms[0].Value = objCATEGORIAACTIVIDAD.CODCATEGORIA;
            //prms[0].ParameterName = "@COD_CATEGORIA";
            	
            //prms[1] = db.GetParameter();
            //prms[1].Value = objCATEGORIAACTIVIDAD.NOMBRE;
            //prms[1].ParameterName = "@NOMBRE";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ECATAGORIAACTIVIDAD objRoot = obj as ECATAGORIAACTIVIDAD;

            objRoot.CodCategoria = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ECATAGORIAACTIVIDAD objCATEGORIAACTIVIDAD = obj as ECATAGORIAACTIVIDAD;

            //Poner las rutinas del Tools que se necesiten

            objCATEGORIAACTIVIDAD.CodCategoria = Utiles.ConvertToInt16(dr["COD_CATEGORIA"]);

            objCATEGORIAACTIVIDAD.NombreCategoria = Utiles.ConvertToString(dr["NOMBRE_CATEGORIA"]);

            objCATEGORIAACTIVIDAD.NombreClass = Utiles.ConvertToString(dr["NOMBRE_CLASS"]);

            objCATEGORIAACTIVIDAD.CodEmpresa = Utiles.ConvertToInt32(dr["cod_empresa"]);



        }

        #endregion

	}
}
