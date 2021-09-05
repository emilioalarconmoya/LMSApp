
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLMODELODISPOSITIVO.
	/// </summary>
	public class DLMODELODISPOSITIVO : DLBase
	{
		public DLMODELODISPOSITIVO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_MODELO_DISPOSITIVO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_MODELO_DISPOSITIVO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_MODELO_DISPOSITIVO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_MODELO_DISPOSITIVO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@marca";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EMODELODISPOSITIVO objMODELODISPOSITIVO = obj as EMODELODISPOSITIVO;

            prms[0] = db.GetParameter();
            prms[0].Value = objMODELODISPOSITIVO.Marca;
            prms[0].ParameterName = "@marca";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(9);
            EMODELODISPOSITIVO objMODELODISPOSITIVO = obj as EMODELODISPOSITIVO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objMODELODISPOSITIVO.Modelo;
            prms[1].ParameterName = "@modelo";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objMODELODISPOSITIVO.Busqueda;
            prms[2].ParameterName = "@busqueda";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objMODELODISPOSITIVO.Width;
            prms[3].ParameterName = "@width";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objMODELODISPOSITIVO.Height;
            prms[4].ParameterName = "@height";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objMODELODISPOSITIVO.Css;
            prms[5].ParameterName = "@css";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objMODELODISPOSITIVO.Media;
            prms[6].ParameterName = "@media";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objMODELODISPOSITIVO.Viewport;
            prms[7].ParameterName = "@viewport";
            	
            prms[8] = db.GetParameter();
            prms[8].Value = objMODELODISPOSITIVO.Movil;
            prms[8].ParameterName = "@movil";
            	
            prms[9] = db.GetParameter();
            prms[9].Value = objMODELODISPOSITIVO.Carpeta;
            prms[9].ParameterName = "@carpeta";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(10);
            EMODELODISPOSITIVO objMODELODISPOSITIVO = obj as EMODELODISPOSITIVO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objMODELODISPOSITIVO.Marca;
            prms[0].ParameterName = "@marca";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objMODELODISPOSITIVO.Modelo;
            prms[1].ParameterName = "@modelo";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objMODELODISPOSITIVO.Busqueda;
            prms[2].ParameterName = "@busqueda";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objMODELODISPOSITIVO.Width;
            prms[3].ParameterName = "@width";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objMODELODISPOSITIVO.Height;
            prms[4].ParameterName = "@height";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objMODELODISPOSITIVO.Css;
            prms[5].ParameterName = "@css";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objMODELODISPOSITIVO.Media;
            prms[6].ParameterName = "@media";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objMODELODISPOSITIVO.Viewport;
            prms[7].ParameterName = "@viewport";
            	
            prms[8] = db.GetParameter();
            prms[8].Value = objMODELODISPOSITIVO.Movil;
            prms[8].ParameterName = "@movil";
            	
            prms[9] = db.GetParameter();
            prms[9].Value = objMODELODISPOSITIVO.Carpeta;
            prms[9].ParameterName = "@carpeta";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EMODELODISPOSITIVO objRoot = obj as EMODELODISPOSITIVO;

            objRoot.Marca = Utiles.ConvertToString(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EMODELODISPOSITIVO objMODELODISPOSITIVO = obj as EMODELODISPOSITIVO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objMODELODISPOSITIVO.Marca = Utiles.ConvertToString(dr["marca"]);
            
            objMODELODISPOSITIVO.Modelo = Utiles.ConvertToString(dr["modelo"]);
            
            objMODELODISPOSITIVO.Busqueda = Utiles.ConvertToString(dr["busqueda"]);
            
            objMODELODISPOSITIVO.Width = Utiles.ConvertToInt32(dr["width"]);
            
            objMODELODISPOSITIVO.Height = Utiles.ConvertToInt32(dr["height"]);
            
            objMODELODISPOSITIVO.Css = Utiles.ConvertToString(dr["css"]);
            
            objMODELODISPOSITIVO.Media = Utiles.ConvertToString(dr["media"]);
            
            objMODELODISPOSITIVO.Viewport = Utiles.ConvertToString(dr["viewport"]);
            
            objMODELODISPOSITIVO.Movil = Utiles.ConvertToBoolean(dr["movil"]);

            objMODELODISPOSITIVO.Carpeta = Utiles.ConvertToString(dr["carpeta"]);
            
        }

        #endregion

	}
}
