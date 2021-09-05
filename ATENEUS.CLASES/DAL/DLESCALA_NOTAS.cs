
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLESCALANOTAS.
	/// </summary>
	public class DLESCALANOTAS : DLBase
	{
		public DLESCALANOTAS()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_ESCALA_NOTAS";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_ESCALA_NOTAS";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_ESCALA_NOTAS";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_ESCALA_NOTAS";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_escala";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EESCALANOTAS objESCALANOTAS = obj as EESCALANOTAS;

            prms[0] = db.GetParameter();
            prms[0].Value = objESCALANOTAS.CodEscala;
            prms[0].ParameterName = "@cod_escala";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(6);
            EESCALANOTAS objESCALANOTAS = obj as EESCALANOTAS;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objESCALANOTAS.Exigencia;
            prms[0].ParameterName = "@exigencia";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objESCALANOTAS.Nombre;
            prms[1].ParameterName = "@nombre";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objESCALANOTAS.NotaMinima;
            prms[2].ParameterName = "@nota_minima";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objESCALANOTAS.NotaMaxima;
            prms[3].ParameterName = "@nota_maxima";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objESCALANOTAS.NotaAprobacion;
            prms[4].ParameterName = "@nota_aprobacion";

            prms[5] = db.GetParameter();
            prms[5].Value = objESCALANOTAS.CodEmpresa;
            prms[5].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(6);
            EESCALANOTAS objESCALANOTAS = obj as EESCALANOTAS;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objESCALANOTAS.CodEscala;
            prms[0].ParameterName = "@cod_escala";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objESCALANOTAS.Nombre;
            prms[1].ParameterName = "@nombre";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objESCALANOTAS.NotaMinima;
            prms[2].ParameterName = "@nota_minima";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objESCALANOTAS.NotaMaxima;
            prms[3].ParameterName = "@nota_maxima";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objESCALANOTAS.NotaAprobacion;
            prms[4].ParameterName = "@nota_aprobacion";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objESCALANOTAS.Exigencia;
            prms[5].ParameterName = "@exigencia";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EESCALANOTAS objRoot = obj as EESCALANOTAS;

            objRoot.CodEscala = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EESCALANOTAS objESCALANOTAS = obj as EESCALANOTAS;
    
            //Poner las rutinas del Tools que se necesiten
            
            objESCALANOTAS.CodEscala = Utiles.ConvertToDecimal(dr["cod_escala"]);
            
            objESCALANOTAS.Nombre = Utiles.ConvertToString(dr["nombre"]);
            
            objESCALANOTAS.NotaMinima = Utiles.ConvertToDouble(dr["nota_minima"]);
            
            objESCALANOTAS.NotaMaxima = Utiles.ConvertToDouble(dr["nota_maxima"]);
            
            objESCALANOTAS.NotaAprobacion = Utiles.ConvertToDouble(dr["nota_aprobacion"]);
            
            objESCALANOTAS.Exigencia = Utiles.ConvertToDouble(dr["exigencia"]);
            
        }

        #endregion

	}
}
