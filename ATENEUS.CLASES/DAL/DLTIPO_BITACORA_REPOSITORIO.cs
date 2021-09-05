
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLTIPOBITACORAREPOSITORIO.
	/// </summary>
	public class DLTIPOBITACORAREPOSITORIO : DLBase
	{
		public DLTIPOBITACORAREPOSITORIO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_TIPO_BITACORA_REPOSITORIO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_TIPO_BITACORA_REPOSITORIO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_TIPO_BITACORA_REPOSITORIO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_TIPO_BITACORA_REPOSITORIO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_tipo_bitacora";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ETIPOBITACORAREPOSITORIO objTIPOBITACORAREPOSITORIO = obj as ETIPOBITACORAREPOSITORIO;

            prms[0] = db.GetParameter();
            prms[0].Value = objTIPOBITACORAREPOSITORIO.CodTipoBitacora;
            prms[0].ParameterName = "@cod_tipo_bitacora";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ETIPOBITACORAREPOSITORIO objTIPOBITACORAREPOSITORIO = obj as ETIPOBITACORAREPOSITORIO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objTIPOBITACORAREPOSITORIO.Nombre;
            prms[1].ParameterName = "@nombre";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ETIPOBITACORAREPOSITORIO objTIPOBITACORAREPOSITORIO = obj as ETIPOBITACORAREPOSITORIO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objTIPOBITACORAREPOSITORIO.CodTipoBitacora;
            prms[0].ParameterName = "@cod_tipo_bitacora";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objTIPOBITACORAREPOSITORIO.Nombre;
            prms[1].ParameterName = "@nombre";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ETIPOBITACORAREPOSITORIO objRoot = obj as ETIPOBITACORAREPOSITORIO;

            objRoot.CodTipoBitacora = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ETIPOBITACORAREPOSITORIO objTIPOBITACORAREPOSITORIO = obj as ETIPOBITACORAREPOSITORIO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objTIPOBITACORAREPOSITORIO.CodTipoBitacora = Utiles.ConvertToDecimal(dr["cod_tipo_bitacora"]);

            objTIPOBITACORAREPOSITORIO.Nombre = Utiles.ConvertToString(dr["nombre"]);
            
        }

        #endregion

	}
}
