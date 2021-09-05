
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLCAMPO.
	/// </summary>
	public class DLCAMPO : DLBase
	{
		public DLCAMPO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_CAMPO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_CAMPO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_CAMPO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_CAMPO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_campo";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ECAMPO objCAMPO = obj as ECAMPO;

            prms[0] = db.GetParameter();
            prms[0].Value = objCAMPO.CodCampo;
            prms[0].ParameterName = "@cod_campo";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(5);
            ECAMPO objCAMPO = obj as ECAMPO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCAMPO.Orden;
            prms[1].ParameterName = "@orden";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objCAMPO.Campo;
            prms[2].ParameterName = "@campo";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objCAMPO.Cabecera;
            prms[3].ParameterName = "@cabecera";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objCAMPO.CampoBD;
            prms[4].ParameterName = "@campoBD";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objCAMPO.Tipo;
            prms[5].ParameterName = "@tipo";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(6);
            ECAMPO objCAMPO = obj as ECAMPO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCAMPO.CodCampo;
            prms[0].ParameterName = "@cod_campo";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCAMPO.Orden;
            prms[1].ParameterName = "@orden";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objCAMPO.Campo;
            prms[2].ParameterName = "@campo";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objCAMPO.Cabecera;
            prms[3].ParameterName = "@cabecera";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objCAMPO.CampoBD;
            prms[4].ParameterName = "@campoBD";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objCAMPO.Tipo;
            prms[5].ParameterName = "@tipo";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ECAMPO objRoot = obj as ECAMPO;

            objRoot.CodCampo = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ECAMPO objCAMPO = obj as ECAMPO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objCAMPO.CodCampo = Utiles.ConvertToDecimal(dr["cod_campo"]);
            
            //objCAMPO.Orden = Utiles.ConvertToInt32(dr["orden"]);
            
            objCAMPO.Campo = Utiles.ConvertToString(dr["campo"]);
            
            objCAMPO.Cabecera = Utiles.ConvertToString(dr["cabecera"]);
            
            objCAMPO.CampoBD = Utiles.ConvertToString(dr["campoBD"]);

            objCAMPO.Tipo = Utiles.ConvertToInt32(dr["tipo"]);
            
        }

        #endregion

	}
}
