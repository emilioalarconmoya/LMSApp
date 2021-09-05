
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLAVISOSHOME.
	/// </summary>
	public class DLAVISOSHOME : DLBase
	{
		public DLAVISOSHOME()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_AVISOS_HOME";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_AVISOS_HOME";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_AVISOS_HOME";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_AVISOS_HOME";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_aviso";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EAVISOSHOME objAVISOSHOME = obj as EAVISOSHOME;

            prms[0] = db.GetParameter();
            prms[0].Value = objAVISOSHOME.CodAviso;
            prms[0].ParameterName = "@cod_aviso";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(6);
            EAVISOSHOME objAVISOSHOME = obj as EAVISOSHOME;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objAVISOSHOME.Titulo;
            prms[1].ParameterName = "@titulo";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objAVISOSHOME.Resumen;
            prms[2].ParameterName = "@resumen";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objAVISOSHOME.Texto;
            prms[3].ParameterName = "@texto";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objAVISOSHOME.Mostrar;
            prms[4].ParameterName = "@mostrar";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objAVISOSHOME.FechaHora;
            prms[5].ParameterName = "@fecha_hora";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objAVISOSHOME.Imagen;
            prms[6].ParameterName = "@imagen";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(7);
            EAVISOSHOME objAVISOSHOME = obj as EAVISOSHOME;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objAVISOSHOME.CodAviso;
            prms[0].ParameterName = "@cod_aviso";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objAVISOSHOME.Titulo;
            prms[1].ParameterName = "@titulo";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objAVISOSHOME.Resumen;
            prms[2].ParameterName = "@resumen";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objAVISOSHOME.Texto;
            prms[3].ParameterName = "@texto";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objAVISOSHOME.Mostrar;
            prms[4].ParameterName = "@mostrar";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objAVISOSHOME.FechaHora;
            prms[5].ParameterName = "@fecha_hora";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objAVISOSHOME.Imagen;
            prms[6].ParameterName = "@imagen";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EAVISOSHOME objRoot = obj as EAVISOSHOME;

            objRoot.CodAviso = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EAVISOSHOME objAVISOSHOME = obj as EAVISOSHOME;
    
            //Poner las rutinas del Tools que se necesiten
            
            objAVISOSHOME.CodAviso = Utiles.ConvertToDecimal(dr["cod_aviso"]);
            
            objAVISOSHOME.Titulo = Utiles.ConvertToString(dr["titulo"]);
            
            objAVISOSHOME.Resumen = Utiles.ConvertToString(dr["resumen"]);
            
            objAVISOSHOME.Texto = Utiles.ConvertToString(dr["texto"]);
            
            objAVISOSHOME.Mostrar = Utiles.ConvertToBoolean(dr["mostrar"]);
            
            objAVISOSHOME.FechaHora = Utiles.ConvertToDateTime(dr["fecha_hora"]);

            objAVISOSHOME.Imagen = Utiles.ConvertToString(dr["imagen"]);
            
        }

        #endregion

	}
}
