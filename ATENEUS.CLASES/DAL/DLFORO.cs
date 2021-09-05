
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLFORO.
	/// </summary>
	public class DLFORO : DLBase
	{
		public DLFORO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_FORO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_FORO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_FORO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_FORO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@IdForo";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EFORO objFORO = obj as EFORO;

            prms[0] = db.GetParameter();
            prms[0].Value = objFORO.IdForo;
            prms[0].ParameterName = "@IdForo";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(6);
            EFORO objFORO = obj as EFORO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objFORO.Nombre;
            prms[0].ParameterName = "@nombre";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objFORO.Total;
            prms[1].ParameterName = "@total";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objFORO.Ultimo;
            prms[2].ParameterName = "@ultimo";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objFORO.Descripcion;
            prms[3].ParameterName = "@descripcion";

            prms[4] = db.GetParameter();
            prms[4].Value = objFORO.IdForo;
            prms[4].ParameterName = "@idforo";

            prms[5] = db.GetParameter();
            prms[5].Value = objFORO.CodEmpresa;
            prms[5].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(5);
            EFORO objFORO = obj as EFORO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objFORO.IdForo;
            prms[0].ParameterName = "@IdForo";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objFORO.Nombre;
            prms[1].ParameterName = "@nombre";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objFORO.Total;
            prms[2].ParameterName = "@total";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objFORO.Ultimo;
            prms[3].ParameterName = "@ultimo";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objFORO.Descripcion;
            prms[4].ParameterName = "@descripcion";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EFORO objRoot = obj as EFORO;

            objRoot.IdForo = Utiles.ConvertToInt32(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EFORO objFORO = obj as EFORO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objFORO.IdForo = Utiles.ConvertToInt32(dr["IdForo"]);
            
            objFORO.Nombre = Utiles.ConvertToString(dr["nombre"]);
            
            objFORO.Total = Utiles.ConvertToInt32(dr["total"]);
            
            objFORO.Ultimo = Utiles.ConvertToDateTime(dr["ultimo"]);
            
            objFORO.Descripcion = Utiles.ConvertToString(dr["descripcion"]);
            
        }

        #endregion

	}
}
