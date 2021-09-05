
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLMOTIVOCORREO.
	/// </summary>
	public class DLMOTIVOCORREO : DLBase
	{
		public DLMOTIVOCORREO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_MOTIVO_CORREO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_MOTIVO_CORREO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_MOTIVO_CORREO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_MOTIVO_CORREO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_motivo_correo";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EMOTIVOCORREO objMOTIVOCORREO = obj as EMOTIVOCORREO;

            prms[0] = db.GetParameter();
            prms[0].Value = objMOTIVOCORREO.CodMotivoCorreo;
            prms[0].ParameterName = "@cod_motivo_correo";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EMOTIVOCORREO objMOTIVOCORREO = obj as EMOTIVOCORREO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objMOTIVOCORREO.Descripcion;
            prms[1].ParameterName = "@descripcion";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EMOTIVOCORREO objMOTIVOCORREO = obj as EMOTIVOCORREO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objMOTIVOCORREO.CodMotivoCorreo;
            prms[0].ParameterName = "@cod_motivo_correo";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objMOTIVOCORREO.Descripcion;
            prms[1].ParameterName = "@descripcion";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EMOTIVOCORREO objRoot = obj as EMOTIVOCORREO;

            objRoot.CodMotivoCorreo = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EMOTIVOCORREO objMOTIVOCORREO = obj as EMOTIVOCORREO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objMOTIVOCORREO.CodMotivoCorreo = Utiles.ConvertToInt16(dr["cod_motivo_correo"]);

            objMOTIVOCORREO.Descripcion = Utiles.ConvertToString(dr["descripcion"]);
            
        }

        #endregion

	}
}
