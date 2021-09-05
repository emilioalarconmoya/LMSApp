
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
	/// Summary description for DLPERFILList.
	/// </summary>
    public class DLPERFILList : DLGenericBaseList<EPERFIL>
	{
		public DLPERFILList()
		{
            this._proc_select_all = "proc_select_PERFIL_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EPERFIL> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }


        public List<EPERFIL> SelectPerfilesDisponibles(Int64 RutUsuario)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = RutUsuario;
            prms[0].ParameterName = "@RUT_USUARIO";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_perfiles_disponibles", prms);


            List<EPERFIL> lst = new List<EPERFIL>();

            while (dr.Read())
            {
                EPERFIL objPerfil = new EPERFIL();

                objPerfil.CodPerfil = Utiles.ConvertToInt16(dr["cod_perfil"]);

                objPerfil.Nombre = Utiles.ConvertToString(dr["nombre"]);

                lst.Add(objPerfil);
            }
            dr.Close();
            return lst;
        }

        public List<EPERFIL> SelectPerfilesAsignados(Int64 RutUsuario)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = RutUsuario;
            prms[0].ParameterName = "@RUT_USUARIO";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_perfiles_asignados", prms);


            List<EPERFIL> lst = new List<EPERFIL>();

            while (dr.Read())
            {
                EPERFIL objPerfil = new EPERFIL();

                objPerfil.CodPerfil = Utiles.ConvertToInt16(dr["cod_perfil"]);

                objPerfil.Nombre = Utiles.ConvertToString(dr["nombre"]);

                lst.Add(objPerfil);
            }
            dr.Close();
            return lst;
        }

		#endregion
	}
}
