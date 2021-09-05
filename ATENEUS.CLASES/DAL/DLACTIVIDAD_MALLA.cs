
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLACTIVIDADMALLA.
	/// </summary>
	public class DLACTIVIDADMALLA : DLBase
	{
		public DLACTIVIDADMALLA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_ACTIVIDAD_MALLA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_ACTIVIDAD_MALLA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_ACTIVIDAD_MALLA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_ACTIVIDAD_MALLA";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@Cod_Malla";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EACTIVIDADMALLA objACTIVIDADMALLA = obj as EACTIVIDADMALLA;

            prms[0] = db.GetParameter();
            prms[0].Value = objACTIVIDADMALLA.CodMalla;
            prms[0].ParameterName = "@Cod_Malla";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(9);
            EACTIVIDADMALLA objACTIVIDADMALLA = obj as EACTIVIDADMALLA;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objACTIVIDADMALLA.CodMalla;
            prms[0].ParameterName = "@cod_malla";

            prms[1] = db.GetParameter();
            prms[1].Value = objACTIVIDADMALLA.CodActividad;
            prms[1].ParameterName = "@cod_actividad";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objACTIVIDADMALLA.Duracion;
            prms[2].ParameterName = "@duracion";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objACTIVIDADMALLA.NotaAprobacion;
            prms[3].ParameterName = "@nota_aprobacion";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objACTIVIDADMALLA.DiasIntervalo;
            prms[4].ParameterName = "@dias_intervalo";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objACTIVIDADMALLA.Nivel;
            prms[5].ParameterName = "@nivel";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objACTIVIDADMALLA.NroDeReasignaciones;
            prms[6].ParameterName = "@nro_de_reasignaciones";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objACTIVIDADMALLA.NotaMaxima;
            prms[7].ParameterName = "@nota_maxima";

            prms[8] = db.GetParameter();
            prms[8].Value = objACTIVIDADMALLA.Orden;
            prms[8].ParameterName = "@orden";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(9);
            EACTIVIDADMALLA objACTIVIDADMALLA = obj as EACTIVIDADMALLA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objACTIVIDADMALLA.CodMalla;
            prms[0].ParameterName = "@Cod_Malla";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objACTIVIDADMALLA.CodActividad;
            prms[1].ParameterName = "@cod_actividad";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objACTIVIDADMALLA.Duracion;
            prms[2].ParameterName = "@duracion";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objACTIVIDADMALLA.NotaAprobacion;
            prms[3].ParameterName = "@nota_aprobacion";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objACTIVIDADMALLA.DiasIntervalo;
            prms[4].ParameterName = "@dias_intervalo";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objACTIVIDADMALLA.Nivel;
            prms[5].ParameterName = "@nivel";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objACTIVIDADMALLA.NroDeReasignaciones;
            prms[6].ParameterName = "@nro_de_reasignaciones";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objACTIVIDADMALLA.NotaMaxima;
            prms[7].ParameterName = "@nota_maxima";

            prms[8] = db.GetParameter();
            prms[8].Value = objACTIVIDADMALLA.Orden;
            prms[8].ParameterName = "@orden";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EACTIVIDADMALLA objRoot = obj as EACTIVIDADMALLA;

            objRoot.CodMalla = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EACTIVIDADMALLA objACTIVIDADMALLA = obj as EACTIVIDADMALLA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objACTIVIDADMALLA.CodMalla = Utiles.ConvertToDecimal(dr["Cod_Malla"]);
            
            objACTIVIDADMALLA.CodActividad = Utiles.ConvertToInt16(dr["cod_actividad"]);
            
            objACTIVIDADMALLA.Duracion = Utiles.ConvertToInt32(dr["duracion"]);
            
            objACTIVIDADMALLA.NotaAprobacion = Utiles.ConvertToDouble(dr["nota_aprobacion"]);
            
            objACTIVIDADMALLA.DiasIntervalo = Utiles.ConvertToInt32(dr["dias_intervalo"]);
            
            objACTIVIDADMALLA.Nivel = Utiles.ConvertToInt32(dr["nivel"]);
            
            objACTIVIDADMALLA.NroDeReasignaciones = Utiles.ConvertToInt32(dr["nro_de_reasignaciones"]);

            objACTIVIDADMALLA.NotaMaxima = Utiles.ConvertToInt32(dr["nota_maxima"]);

            objACTIVIDADMALLA.Orden = Utiles.ConvertToInt32(dr["orden"]);

        }

        #endregion

	}
}
