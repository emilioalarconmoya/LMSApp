
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLLOGCONEXION.
	/// </summary>
	public class DLLOGCONEXION : DLBase
	{
		public DLLOGCONEXION()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_LOG_CONEXION";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_LOG_CONEXION";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_LOG_CONEXION";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_LOG_CONEXION";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@inicio";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ELOGCONEXION objLOGCONEXION = obj as ELOGCONEXION;

            prms[0] = db.GetParameter();
            prms[0].Value = objLOGCONEXION.Inicio;
            prms[0].ParameterName = "@inicio";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(12);
            ELOGCONEXION objLOGCONEXION = obj as ELOGCONEXION;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objLOGCONEXION.CodUnidad;
            prms[0].ParameterName = "@cod_unidad";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objLOGCONEXION.CodActivUsr;
            prms[1].ParameterName = "@cod_activ_usr";

            prms[2] = db.GetParameter();
            prms[2].Value = objLOGCONEXION.Inicio;
            prms[2].ParameterName = "@inicio";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objLOGCONEXION.Fin;
            prms[3].ParameterName = "@fin";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objLOGCONEXION.Terminada;
            prms[4].ParameterName = "@terminada";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objLOGCONEXION.TiempoRestanteSeg;
            prms[5].ParameterName = "@tiempo_restante_seg";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objLOGCONEXION.PasoUltimaVisita;
            prms[6].ParameterName = "@paso_ultima_visita";

            prms[7] = db.GetParameter();
            prms[7].Value = objLOGCONEXION.Cerrada;
            prms[7].ParameterName = "@cerrada";

            prms[8] = db.GetParameter();
            prms[8].Value = objLOGCONEXION.CodEmpresa;
            prms[8].ParameterName = "@cod_empresa";
			
			prms[9] = db.GetParameter();
            prms[9].Value = objLOGCONEXION.Dispositivo;
            prms[9].ParameterName = "@dispositivo";

            prms[10] = db.GetParameter();
            prms[10].Value = objLOGCONEXION.Browser;
            prms[10].ParameterName = "@browser";

            prms[11] = db.GetParameter();
            prms[11].Value = objLOGCONEXION.IP;
            prms[11].ParameterName = "@ip";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(9);
            ELOGCONEXION objLOGCONEXION = obj as ELOGCONEXION;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objLOGCONEXION.Inicio;
            prms[0].ParameterName = "@inicio";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objLOGCONEXION.CodUnidad;
            prms[1].ParameterName = "@cod_unidad";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objLOGCONEXION.CodActivUsr;
            prms[2].ParameterName = "@cod_activ_usr";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objLOGCONEXION.Fin;
            prms[3].ParameterName = "@fin";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objLOGCONEXION.Terminada;
            prms[4].ParameterName = "@terminada";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objLOGCONEXION.TiempoRestanteSeg;
            prms[5].ParameterName = "@tiempo_restante_seg";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objLOGCONEXION.PasoUltimaVisita;
            prms[6].ParameterName = "@paso_ultima_visita";

            prms[7] = db.GetParameter();
            prms[7].Value = objLOGCONEXION.Cerrada;
            prms[7].ParameterName = "@cerrada";

            prms[8] = db.GetParameter();
            prms[8].Value = objLOGCONEXION.CodEmpresa;
            prms[8].ParameterName = "@cod_empresa";

            return prms;
        }

        public void TreminaUnidad(long CodActivUsr, long CodUnidad, long codEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActivUsr;
            prms[0].ParameterName = "@COD_ACTIV_USR";

            prms[1] = db.GetParameter();
            prms[1].Value = CodUnidad;
            prms[1].ParameterName = "@COD_UNIDAD";

            prms[2] = db.GetParameter();
            prms[2].Value = codEmpresa;
            prms[2].ParameterName = "@COD_EMPRESA";

            db.ExecuteNonQuery(CommandType.StoredProcedure, "proc_update_LOG_CONEXION_Adelantar_Unidad", prms);


        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ELOGCONEXION objRoot = obj as ELOGCONEXION;

            objRoot.Inicio = Utiles.ConvertToDateTime(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ELOGCONEXION objLOGCONEXION = obj as ELOGCONEXION;
    
            //Poner las rutinas del Tools que se necesiten
            
            objLOGCONEXION.Inicio = Utiles.ConvertToDateTime(dr["inicio"]);
            
            objLOGCONEXION.CodUnidad = Utiles.ConvertToInt16(dr["cod_unidad"]);
            
            objLOGCONEXION.CodActivUsr = Utiles.ConvertToDecimal(dr["cod_activ_usr"]);
            
            objLOGCONEXION.Fin = Utiles.ConvertToDateTime(dr["fin"]);
            
            objLOGCONEXION.Terminada = Utiles.ConvertToBoolean(dr["terminada"]);
            
            objLOGCONEXION.TiempoRestanteSeg = Utiles.ConvertToInt32(dr["tiempo_restante_seg"]);

            objLOGCONEXION.PasoUltimaVisita = Utiles.ConvertToInt32(dr["paso_ultima_visita"]);

            objLOGCONEXION.Cerrada = Utiles.ConvertToBoolean(dr["cerrada"]);
            
        }

        #endregion

	}
}
