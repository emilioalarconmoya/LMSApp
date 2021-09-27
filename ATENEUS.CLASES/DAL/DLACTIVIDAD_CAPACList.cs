
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
	/// Summary description for DLACTIVIDADCAPACList.
	/// </summary>
    public class DLACTIVIDADCAPACList : DLGenericBaseList<EACTIVIDADCAPAC>
	{
		public DLACTIVIDADCAPACList()
		{
            this._proc_select_all = "proc_select_ACTIVIDAD_CAPAC_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EACTIVIDADCAPAC> SelectAll(Int64 CodEmpresa)
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
		
		public List<EACTIVIDADCAPAC> SelectAllPorAtributo(int codCaracteristica, int codAtributo, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = codCaracteristica;
            prms[0].ParameterName = "@cod_caracteristica";

            prms[1] = db.GetParameter();
            prms[1].Value = codAtributo;
            prms[1].ParameterName = "@cod_atributo";
			
			prms[2] = db.GetParameter();
            prms[2].Value = CodEmpresa;
            prms[2].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_ACTIVIDAD_CAPAC_POR_ATRIBUTO", prms);

            return GetCollection(dr);
        }
        public DataTable SelectActividadAllWS(Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);
            

            prms[0] = db.GetParameter();
            prms[0].Value = CodEmpresa;
            prms[0].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_ACTIVIDAD_CAPAC_all_WS", prms);

            return dt;
        }

        public DataTable SelectActividadApp(int codActividad)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);


            prms[0] = db.GetParameter();
            prms[0].Value = codActividad;
            prms[0].ParameterName = "@COD_ACTIVIDAD";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_ACTIVIDAD_CAPAC_app", prms);

            return dt;
        }
        public List<EACTIVIDADCAPAC> SelectAllTutor(long rutTutor)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = rutTutor;
            prms[0].ParameterName = "@rut_tutor";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_ACTIVIDAD_CAPAC_all_tutor", prms);

            return GetCollection(dr);
        }
		public List<EACTIVIDADCAPAC> SelectActividad(Int32 codActividad)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = codActividad;
            prms[0].ParameterName = "@cod_actividad";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_ACTIVIDAD_CAPAC_cod_actividad", prms);

            return GetCollection(dr);
        }
        public List<EACTIVIDADCAPAC> SelectActividadMallaAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_curso_all", null);

            return GetCollection(dr);
        }

        public DataTable SelectFichaActividad(long CodActividad)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActividad;
            prms[0].ParameterName = "@cod_actividad";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_ficha_actividad", prms);

            return dt;
        }


        public List<EACTIVIDADCAPAC> SelectActividadesParametros(string Nombre, Int32 CodProveedor, Int16 CodTipo, string CodSence,Int64 CodEmpresa, Int64 rutTutor, Int16 codEstado)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;

            IDataReader dr;
            if (rutTutor > 0)
            {
                prms = db.GetArrayParameter(7);

                prms[0] = db.GetParameter();
                prms[0].Value = Utiles.SubStringSQL(Nombre);
                prms[0].ParameterName = "@Nombre";

                prms[1] = db.GetParameter();
                prms[1].Value = CodProveedor;
                prms[1].ParameterName = "@Proveedor";

                prms[2] = db.GetParameter();
                prms[2].Value = CodTipo;
                prms[2].ParameterName = "@Tipo";

                prms[3] = db.GetParameter();
                prms[3].Value = CodSence;
                prms[3].ParameterName = "@CodSence";
				
				prms[4] = db.GetParameter();
	            prms[4].Value = CodEmpresa;
	            prms[4].ParameterName = "@cod_empresa";

                prms[5] = db.GetParameter();
                prms[5].Value = rutTutor;
                prms[5].ParameterName = "@rut_tutor";

                prms[6] = db.GetParameter();
                prms[6].Value = codEstado;
                prms[6].ParameterName = "@cod_estado";

                dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_buscador_actividades_tutor", prms);
            }
            else
            {
                prms = db.GetArrayParameter(6);

                prms[0] = db.GetParameter();
                prms[0].Value = Utiles.SubStringSQL(Nombre);
                prms[0].ParameterName = "@Nombre";

                prms[1] = db.GetParameter();
                prms[1].Value = CodProveedor;
                prms[1].ParameterName = "@Proveedor";

                prms[2] = db.GetParameter();
                prms[2].Value = CodTipo;
                prms[2].ParameterName = "@Tipo";

                prms[3] = db.GetParameter();
                prms[3].Value = CodSence;
                prms[3].ParameterName = "@CodSence";
				
				prms[4] = db.GetParameter();
	            prms[4].Value = CodEmpresa;
	            prms[4].ParameterName = "@cod_empresa";

                prms[5] = db.GetParameter();
                prms[5].Value = codEstado;
                prms[5].ParameterName = "@cod_estado";

                dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_buscador_actividades", prms);
            }
                


            List<EACTIVIDADCAPAC> lst = new List<EACTIVIDADCAPAC>();

            while (dr.Read())
            {
                EACTIVIDADCAPAC objACTIVIDADCAPAC = new EACTIVIDADCAPAC();

                objACTIVIDADCAPAC.CodActividad = Utiles.ConvertToInt16(dr["cod_actividad"]);

                objACTIVIDADCAPAC.CodTipo = Utiles.ConvertToInt16(dr["cod_tipo"]);

                objACTIVIDADCAPAC.CodProveedor = Utiles.ConvertToInt16(dr["cod_proveedor"]);

                objACTIVIDADCAPAC.Nombre = Utiles.ConvertToString(dr["nombre"]);

                objACTIVIDADCAPAC.Contenido = Utiles.ConvertToString(dr["contenido"]);

                objACTIVIDADCAPAC.Horas = Utiles.ConvertToDouble(dr["horas"]);

                objACTIVIDADCAPAC.Costo = Utiles.ConvertToDouble(dr["costo"]);

                objACTIVIDADCAPAC.Duracion = Utiles.ConvertToInt32(dr["duracion"]);

                objACTIVIDADCAPAC.CodigoSence = Utiles.ConvertToString(dr["codigo_sence"]);

                objACTIVIDADCAPAC.Objetivos = Utiles.ConvertToString(dr["objetivos"]);

                objACTIVIDADCAPAC.DestacadoHome = Utiles.ConvertToInt16(dr["destacado_home"]);

                objACTIVIDADCAPAC.Imagen = Utiles.ConvertToString(dr["imagen"]);

                objACTIVIDADCAPAC.OrdenDestacados = Utiles.ConvertToInt16(dr["orden_destacados"]);

                objACTIVIDADCAPAC.Vigente = Utiles.ConvertToBoolean(dr["Vigente"]);

                objACTIVIDADCAPAC.Mensaje = Utiles.ConvertToString(dr["Mensaje"]);

                objACTIVIDADCAPAC.NotaMinima = Utiles.ConvertToDouble(dr["nota_minima"]);

                objACTIVIDADCAPAC.PorcMinimo = Utiles.ConvertToDouble(dr["porc_minimo"]);

                objACTIVIDADCAPAC.NotaEnPorc = Utiles.ConvertToBoolean(dr["nota_en_porc"]);

                objACTIVIDADCAPAC.NotaMaxima = Utiles.ConvertToDouble(dr["nota_maxima"]);

                objACTIVIDADCAPAC.NotaAprobacion = Utiles.ConvertToDouble(dr["nota_aprobacion"]);

                objACTIVIDADCAPAC.Exigencia = Utiles.ConvertToDouble(dr["exigencia"]);

                objACTIVIDADCAPAC.Publica = Utiles.ConvertToBoolean(dr["flag_publica"]);

                objACTIVIDADCAPAC.Abierta = Utiles.ConvertToBoolean(dr["flag_abierta"]);

                objACTIVIDADCAPAC.ParaInscripcion = Utiles.ConvertToBoolean(dr["flag_para_inscripcion"]);

                objACTIVIDADCAPAC.RutTutor = Utiles.ConvertToInt32(dr["rut_tutor"]);

                objACTIVIDADCAPAC.FlagActivo = Utiles.ConvertToBoolean(dr["flag_activo"]);

                lst.Add(objACTIVIDADCAPAC);
            }
            dr.Close();
            return lst;
        }

        public List<EACTIVIDADCAPAC> ListaActividadesConEncuesta(Int16 CodTipo,Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = CodTipo;
            prms[0].ParameterName = "@Tipo";

            prms[1] = db.GetParameter();
            prms[1].Value = CodEmpresa;
            prms[1].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_buscador_actividades_por_tipo", prms);


            List<EACTIVIDADCAPAC> lst = new List<EACTIVIDADCAPAC>();

            while (dr.Read())
            {
                EACTIVIDADCAPAC objACTIVIDADCAPAC = new EACTIVIDADCAPAC();

                objACTIVIDADCAPAC.CodActividad = Utiles.ConvertToInt16(dr["cod_actividad"]);

                objACTIVIDADCAPAC.CodTipo = Utiles.ConvertToInt16(dr["cod_tipo"]);

                objACTIVIDADCAPAC.CodProveedor = Utiles.ConvertToInt16(dr["cod_proveedor"]);

                objACTIVIDADCAPAC.Nombre = Utiles.ConvertToString(dr["nombre"]);

                objACTIVIDADCAPAC.Contenido = Utiles.ConvertToString(dr["contenido"]);

                objACTIVIDADCAPAC.Horas = Utiles.ConvertToDouble(dr["horas"]);

                objACTIVIDADCAPAC.Costo = Utiles.ConvertToDouble(dr["costo"]);

                objACTIVIDADCAPAC.Duracion = Utiles.ConvertToInt32(dr["duracion"]);

                objACTIVIDADCAPAC.CodigoSence = Utiles.ConvertToString(dr["codigo_sence"]);

                objACTIVIDADCAPAC.Objetivos = Utiles.ConvertToString(dr["objetivos"]);

                objACTIVIDADCAPAC.DestacadoHome = Utiles.ConvertToInt16(dr["destacado_home"]);

                objACTIVIDADCAPAC.Imagen = Utiles.ConvertToString(dr["imagen"]);

                objACTIVIDADCAPAC.OrdenDestacados = Utiles.ConvertToInt16(dr["orden_destacados"]);

                objACTIVIDADCAPAC.Vigente = Utiles.ConvertToBoolean(dr["Vigente"]);

                objACTIVIDADCAPAC.Mensaje = Utiles.ConvertToString(dr["Mensaje"]);

                objACTIVIDADCAPAC.NotaMinima = Utiles.ConvertToDouble(dr["nota_minima"]);

                objACTIVIDADCAPAC.PorcMinimo = Utiles.ConvertToDouble(dr["porc_minimo"]);

                objACTIVIDADCAPAC.NotaEnPorc = Utiles.ConvertToBoolean(dr["nota_en_porc"]);

                objACTIVIDADCAPAC.NotaMaxima = Utiles.ConvertToDouble(dr["nota_maxima"]);

                objACTIVIDADCAPAC.NotaAprobacion = Utiles.ConvertToDouble(dr["nota_aprobacion"]);

                objACTIVIDADCAPAC.Exigencia = Utiles.ConvertToDouble(dr["exigencia"]);

                objACTIVIDADCAPAC.Publica = Utiles.ConvertToBoolean(dr["flag_publica"]);

                objACTIVIDADCAPAC.Abierta = Utiles.ConvertToBoolean(dr["flag_abierta"]);

                objACTIVIDADCAPAC.ParaInscripcion = Utiles.ConvertToBoolean(dr["flag_para_inscripcion"]);

                objACTIVIDADCAPAC.Puntos_finalizacion = Utiles.ConvertToInt16(dr["puntaje_curso"]);

                objACTIVIDADCAPAC.Puntos_aprobacion = Utiles.ConvertToInt16(dr["puntaje_aprobacion"]);

                objACTIVIDADCAPAC.Dias_expiracion_puntos = Utiles.ConvertToInt16(dr["dias_expiracion_puntos"]);

                objACTIVIDADCAPAC.DiasAutoIncrip = Utiles.ConvertToInt16(dr["dias_autoinscripcion"]);

                objACTIVIDADCAPAC.EsConexionNueva = Utiles.ConvertToBoolean(dr["FLAG_ES_NUEVA_CONEXION"]);

                //objACTIVIDADCAPAC.CodTipoCurso = Utiles.ConvertToInt16(dr["COD_TIPO_CURSO"]);

                //objACTIVIDADCAPAC.FlagParaMalla = Utiles.ConvertToBoolean(dr["FLAG_ACTIVO_MALLA"]);

                lst.Add(objACTIVIDADCAPAC);
            }
            dr.Close();
            return lst;
        }
        public DataTable SelectCategoriaActividad(Int64 codEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = codEmpresa;
            prms[0].ParameterName = "@cod_empresa";


            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_categoria_actividad", prms);

            return dt;
        }
        public string GetNombreActividad(Int64 CodActividad)
        {
            string strNombre = "";
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActividad;
            prms[0].ParameterName = "@CODACTIVIDAD";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_NOMBRE_ACTIVIDAD", prms);
            while (dr.Read())
            {
                strNombre = Utiles.ConvertToString(dr["nombre"]);
            }
            dr.Close();
            return strNombre;
        }

        public List<EACTIVIDADCAPAC> SelectBuscadorActividad(string Nombre, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = Utiles.SubStringSQL(Nombre);
            prms[0].ParameterName = "@Nombre";

            prms[1] = db.GetParameter();
            prms[1].Value = CodEmpresa;
            prms[1].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_buscador_actividades_malla", prms);


            List<EACTIVIDADCAPAC> lst = new List<EACTIVIDADCAPAC>();

            while (dr.Read())
            {
                EACTIVIDADCAPAC objACTIVIDADCAPAC = new EACTIVIDADCAPAC();

                objACTIVIDADCAPAC.CodActividad = Utiles.ConvertToInt16(dr["cod_actividad"]);

                objACTIVIDADCAPAC.CodTipo = Utiles.ConvertToInt16(dr["cod_tipo"]);

                objACTIVIDADCAPAC.CodProveedor = Utiles.ConvertToInt16(dr["cod_proveedor"]);

                objACTIVIDADCAPAC.Nombre = Utiles.ConvertToString(dr["nombre"]);

                objACTIVIDADCAPAC.Contenido = Utiles.ConvertToString(dr["contenido"]);

                objACTIVIDADCAPAC.Horas = Utiles.ConvertToDouble(dr["horas"]);

                objACTIVIDADCAPAC.Costo = Utiles.ConvertToDouble(dr["costo"]);

                objACTIVIDADCAPAC.Duracion = Utiles.ConvertToInt32(dr["duracion"]);

                objACTIVIDADCAPAC.CodigoSence = Utiles.ConvertToString(dr["codigo_sence"]);

                objACTIVIDADCAPAC.Objetivos = Utiles.ConvertToString(dr["objetivos"]);

                objACTIVIDADCAPAC.DestacadoHome = Utiles.ConvertToInt16(dr["destacado_home"]);

                objACTIVIDADCAPAC.Imagen = Utiles.ConvertToString(dr["imagen"]);

                objACTIVIDADCAPAC.OrdenDestacados = Utiles.ConvertToInt16(dr["orden_destacados"]);

                objACTIVIDADCAPAC.Vigente = Utiles.ConvertToBoolean(dr["Vigente"]);

                objACTIVIDADCAPAC.Mensaje = Utiles.ConvertToString(dr["Mensaje"]);

                objACTIVIDADCAPAC.NotaMinima = Utiles.ConvertToDouble(dr["nota_minima"]);

                objACTIVIDADCAPAC.PorcMinimo = Utiles.ConvertToDouble(dr["porc_minimo"]);

                objACTIVIDADCAPAC.NotaEnPorc = Utiles.ConvertToBoolean(dr["nota_en_porc"]);

                objACTIVIDADCAPAC.NotaMaxima = Utiles.ConvertToDouble(dr["nota_maxima"]);

                objACTIVIDADCAPAC.NotaAprobacion = Utiles.ConvertToDouble(dr["nota_aprobacion"]);

                objACTIVIDADCAPAC.Exigencia = Utiles.ConvertToDouble(dr["exigencia"]);

                objACTIVIDADCAPAC.Publica = Utiles.ConvertToBoolean(dr["flag_publica"]);

                objACTIVIDADCAPAC.Abierta = Utiles.ConvertToBoolean(dr["flag_abierta"]);

                objACTIVIDADCAPAC.ParaInscripcion = Utiles.ConvertToBoolean(dr["flag_para_inscripcion"]);

                //objACTIVIDADCAPAC.Puntos_finalizacion = Utiles.ConvertToInt16(dr["puntaje_curso"]);

                //objACTIVIDADCAPAC.Puntos_aprobacion = Utiles.ConvertToInt16(dr["puntaje_aprobacion"]);

                //objACTIVIDADCAPAC.Dias_expiracion_puntos = Utiles.ConvertToInt16(dr["dias_expiracion_puntos"]);

                //objACTIVIDADCAPAC.DiasAutoIncrip = Utiles.ConvertToInt16(dr["dias_autoinscripcion"]);

                //objACTIVIDADCAPAC.EsConexionNueva = Utiles.ConvertToBoolean(dr["FLAG_ES_NUEVA_CONEXION"]);

                //objACTIVIDADCAPAC.CodTipoCurso = Utiles.ConvertToInt16(dr["COD_TIPO_CURSO"]);

                //objACTIVIDADCAPAC.FlagParaMalla = Utiles.ConvertToBoolean(dr["FLAG_ACTIVO_MALLA"]);

                lst.Add(objACTIVIDADCAPAC);
            }
            dr.Close();
            return lst;
        }

        #endregion
    }
}
