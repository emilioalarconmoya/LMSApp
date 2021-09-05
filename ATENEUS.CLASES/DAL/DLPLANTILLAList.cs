
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
	/// Summary description for DLPLANTILLAList.
	/// </summary>
    public class DLPLANTILLAList : DLGenericBaseList<EPLANTILLA>
	{
		public DLPLANTILLAList()
		{
            this._proc_select_all = "proc_select_PLANTILLA_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EPLANTILLA> SelectAll(Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodEmpresa;
            prms[0].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, prms);

            return GetCollection(dr);
        }

        public List<EPLANTILLA> GetPlantillasByNombre(string Nombre, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = Nombre;
            prms[0].ParameterName = "@Nombre";

            prms[1] = db.GetParameter();
            prms[1].Value = CodEmpresa;
            prms[1].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_PLANTILLAS_BY_NOMBRE", prms);

            return GetCollection(dr);
        }

        public Boolean DelPlantillaCampos(Decimal CodPlantilla)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodPlantilla;
            prms[0].ParameterName = "@CODPLANTILLA";

            int resultado = db.ExecuteNonQuery(CommandType.StoredProcedure, "proc_delete_PLANTILLA_Y_CAMPOS", prms);

            return true;
        }

        #endregion
    }
}
