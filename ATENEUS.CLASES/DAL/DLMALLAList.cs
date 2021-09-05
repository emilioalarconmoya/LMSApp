
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
	/// Summary description for DLMALLAList.
	/// </summary>
    public class DLMALLAList : DLGenericBaseList<EMALLA>
	{
		public DLMALLAList()
		{
            this._proc_select_all = "proc_select_MALLA_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EMALLA> SelectAll(Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodEmpresa;
            prms[0].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, prms);

            return GetCollection(dr);
        }

        public List<EMALLA> SelectMallasParametros(string Nombre, Int16 codEstado, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = Utiles.SubStringSQL(Nombre);
            prms[0].ParameterName = "@Nombre";

            prms[1] = db.GetParameter();
            prms[1].Value = codEstado;
            prms[1].ParameterName = "@codestado";
			
			prms[2] = db.GetParameter();
            prms[2].Value = CodEmpresa; 
            prms[2].ParameterName = "@cod_empresa";


            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_buscador_mallas", prms);


            List<EMALLA> lst = new List<EMALLA>();

            while (dr.Read())
            {
                EMALLA objMALLA = new EMALLA();

                objMALLA.CodMalla = Utiles.ConvertToInt16(dr["cod_malla"]);

                objMALLA.Nombre = Utiles.ConvertToString(dr["nombre"]);

                objMALLA.Descripcion = Utiles.ConvertToString(dr["descripcion"]);

                objMALLA.Vigente = Utiles.ConvertToBoolean(dr["flag_vigente"]);
				
				objMALLA.CodEmpresa = Utiles.ConvertToInt64(dr["COD_EMPRESA"]);

                lst.Add(objMALLA);
            }
            dr.Close();
            return lst;
        }
public List<EMALLA> SelectMallasParametrosConCaracteristicas(string Nombre, Int16 codEstado, Int16 codCaracteristica, Int16 codAtributo,  Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(5);

            prms[0] = db.GetParameter();
            prms[0].Value = Utiles.SubStringSQL(Nombre);
            prms[0].ParameterName = "@Nombre";

            prms[1] = db.GetParameter();
            prms[1].Value = codEstado;
            prms[1].ParameterName = "@codestado";

            prms[2] = db.GetParameter();
            prms[2].Value = codCaracteristica;
            prms[2].ParameterName = "@codcaracteristica";

            if(codAtributo==0)
            {
                codAtributo = -1;
            }
            prms[3] = db.GetParameter();
            prms[3].Value = codAtributo;
            prms[3].ParameterName = "@codatributo";
			
			prms[4] = db.GetParameter();
            prms[4].Value = CodEmpresa; 
            prms[4].ParameterName = "@codempresa";


            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_buscador_mallas_por_caracteristica", prms);


            List<EMALLA> lst = new List<EMALLA>();

            while (dr.Read())
            {
                EMALLA objMALLA = new EMALLA();

                objMALLA.CodMalla = Utiles.ConvertToInt16(dr["cod_malla"]);

                objMALLA.Nombre = Utiles.ConvertToString(dr["nombre_malla"]);

                objMALLA.Descripcion = Utiles.ConvertToString(dr["descripcion"]);

                objMALLA.Vigente = Utiles.ConvertToBoolean(dr["flag_vigente"]);
				
				objMALLA.CodEmpresa = Utiles.ConvertToInt64(dr["COD_EMPRESA"]);

                lst.Add(objMALLA);
            }
            dr.Close();
            return lst;
        }
			

        public string GetNombreMalla(Int64 CodMalla, Int64 CodEmpresa)
        {
            string strNombre = "";
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = CodMalla;
            prms[0].ParameterName = "@CODMALLA";
			
			prms[1] = db.GetParameter();
            prms[1].Value = CodEmpresa; 
            prms[1].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_NOMBRE_ACTIVIDAD", prms);
            while (dr.Read())
            {
                strNombre = Utiles.ConvertToString(dr["nombre"]);
            }
            dr.Close();
            return strNombre;
        }

        #endregion
    }
}
