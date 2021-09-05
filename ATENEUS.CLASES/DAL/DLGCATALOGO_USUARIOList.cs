
using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;
using ATENEUS.CLASES.DAO;
//using Moebius.ErrorManagement;
//using ATENEUS.BUSINESS.Collections;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLACTIVIDADUSUARIOList.
	/// </summary>
    public class DLCATALOGOUSUARIOList : DLGenericBaseList<ECATALOGOUSUARIO>
	{
		public DLCATALOGOUSUARIOList()
		{
            this._proc_select_all = "proc_select_CATALOGO_USUARIO_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<ECATALOGOUSUARIO> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public DataTable SelectActividadesVigentes(long RutUsuario, Int16 DiasEspera, Int32 horaZona)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = RutUsuario;
            prms[0].ParameterName = "@rut_usuario";

            prms[1] = db.GetParameter();
            prms[1].Value = DiasEspera;
            prms[1].ParameterName = "@dias_espera";

            prms[2] = db.GetParameter();
            prms[2].Value = horaZona;
            prms[2].ParameterName = "@hora_zona";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_actividades_vigentes", prms);
            
            return dt;
        }
        public DataTable SelectActividadesVigentes(long RutUsuario, Int16 DiasEspera)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = RutUsuario;
            prms[0].ParameterName = "@rut_usuario";

            prms[1] = db.GetParameter();
            prms[1].Value = DiasEspera;
            prms[1].ParameterName = "@dias_espera";





            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_actividades_vigentes", prms);

            return dt;
        }
        
       

        public DataTable GetCatalogoAsignados(string listaRuts, string listaActividades, Int64 codEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            if (listaRuts == "") { listaRuts = "-"; }
            prms[0] = db.GetParameter();
            prms[0].Value = listaRuts;
            prms[0].ParameterName = "@LISTRUTUSUARIOS";

            prms[1] = db.GetParameter();
            prms[1].Value = listaActividades;
            prms[1].ParameterName = "@LISTCATALOGO";

            prms[2] = db.GetParameter();
            prms[2].Value = codEmpresa;
            prms[2].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_catalogos_asignados", prms);

            return dt;
        }




        #endregion
    }
}
