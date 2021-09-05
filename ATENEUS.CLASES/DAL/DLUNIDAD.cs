
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLUNIDAD.
	/// </summary>
	public class DLUNIDAD : DLBase
	{
		public DLUNIDAD()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_UNIDAD";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_UNIDAD";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_UNIDAD";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_UNIDAD";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_unidad";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EUNIDAD objUNIDAD = obj as EUNIDAD;

            prms[0] = db.GetParameter();
            prms[0].Value = objUNIDAD.CodUnidad;
            prms[0].ParameterName = "@cod_unidad";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(22);
            EUNIDAD objUNIDAD = obj as EUNIDAD;

            //Poner las rutinas del Tools que se necesiten  

            prms[0] = db.GetParameter();
            prms[0].Value = Serial();
            prms[0].ParameterName = "@cod_unidad";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objUNIDAD.CodTemaUnidad;
            prms[1].ParameterName = "@cod_tema_unidad";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objUNIDAD.CodTipoUnidad;
            prms[2].ParameterName = "@cod_tipo_unidad";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objUNIDAD.Nombre;
            prms[3].ParameterName = "@nombre";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objUNIDAD.Descripcion;
            prms[4].ParameterName = "@descripcion";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objUNIDAD.Archivo;
            prms[5].ParameterName = "@archivo";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objUNIDAD.AvisaTermino;
            prms[6].ParameterName = "@avisa_termino";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objUNIDAD.Contenido;
            prms[7].ParameterName = "@contenido";
            	
            prms[8] = db.GetParameter();
            prms[8].Value = objUNIDAD.Criterios;
            prms[8].ParameterName = "@criterios";
            	
            prms[9] = db.GetParameter();
            prms[9].Value = objUNIDAD.NumPregAleatorias;
            prms[9].ParameterName = "@num_preg_aleatorias";
            	
            prms[10] = db.GetParameter();
            prms[10].Value = objUNIDAD.TiempoSegs;
            prms[10].ParameterName = "@tiempo_segs";
            	
            prms[11] = db.GetParameter();
            prms[11].Value = objUNIDAD.MostrarResultados;
            prms[11].ParameterName = "@Mostrar_Resultados";
            	
            prms[12] = db.GetParameter();
            prms[12].Value = objUNIDAD.MostrarRespCorrectas;
            prms[12].ParameterName = "@mostrar_resp_correctas";

            prms[13] = db.GetParameter();
            prms[13].Value = objUNIDAD.CodEmpresa;
            prms[13].ParameterName = "@cod_empresa";

            prms[14] = db.GetParameter();
            prms[14].Value = objUNIDAD.RutTutor;
            prms[14].ParameterName = "@rut_tutor";

            prms[15] = db.GetParameter();
            prms[15].Value = objUNIDAD.FlagActivo;
            prms[15].ParameterName = "@flag_activo";
			
			prms[16] = db.GetParameter();
            prms[16].Value = objUNIDAD.PreguntaPorPagina;
            prms[16].ParameterName = "@pregunta_por_pagina";

            prms[17] = db.GetParameter();
            prms[17].Value = objUNIDAD.NombreUsuario;
            prms[17].ParameterName = "@usuario_sala_vitrual";

            prms[18] = db.GetParameter();
            prms[18].Value = objUNIDAD.Contrasena;
            prms[18].ParameterName = "@pass_sala_virtual";

            prms[19] = db.GetParameter();
            prms[19].Value = objUNIDAD.URL;
            prms[19].ParameterName = "@url_sala_virtual";

            prms[20] = db.GetParameter();
            prms[20].Value = objUNIDAD.CodTipoSalaVirtual;
            prms[20].ParameterName = "@cod_tipo_sala_virtual";

            prms[21] = db.GetParameter();
            prms[21].Value = objUNIDAD.CodTipoEncuesta;
            prms[21].ParameterName = "@cod_tipo_encuesta";


            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(21);
            EUNIDAD objUNIDAD = obj as EUNIDAD;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objUNIDAD.CodUnidad;
            prms[0].ParameterName = "@cod_unidad";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objUNIDAD.CodTemaUnidad;
            prms[1].ParameterName = "@cod_tema_unidad";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objUNIDAD.CodTipoUnidad;
            prms[2].ParameterName = "@cod_tipo_unidad";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objUNIDAD.Nombre;
            prms[3].ParameterName = "@nombre";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objUNIDAD.Descripcion;
            prms[4].ParameterName = "@descripcion";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objUNIDAD.Archivo;
            prms[5].ParameterName = "@archivo";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objUNIDAD.AvisaTermino;
            prms[6].ParameterName = "@avisa_termino";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objUNIDAD.Contenido;
            prms[7].ParameterName = "@contenido";
            	
            prms[8] = db.GetParameter();
            prms[8].Value = objUNIDAD.Criterios;
            prms[8].ParameterName = "@criterios";
            	
            prms[9] = db.GetParameter();
            prms[9].Value = objUNIDAD.NumPregAleatorias;
            prms[9].ParameterName = "@num_preg_aleatorias";
            	
            prms[10] = db.GetParameter();
            prms[10].Value = objUNIDAD.TiempoSegs;
            prms[10].ParameterName = "@tiempo_segs";
            	
            prms[11] = db.GetParameter();
            prms[11].Value = objUNIDAD.MostrarResultados;
            prms[11].ParameterName = "@Mostrar_Resultados";
            	
            prms[12] = db.GetParameter();
            prms[12].Value = objUNIDAD.MostrarRespCorrectas;
            prms[12].ParameterName = "@mostrar_resp_correctas";

            prms[13] = db.GetParameter();
            prms[13].Value = objUNIDAD.RutTutor;
            prms[13].ParameterName = "@rut_tutor";

            prms[14] = db.GetParameter();
            prms[14].Value = objUNIDAD.FlagActivo;
            prms[14].ParameterName = "@flag_activo";

            prms[15] = db.GetParameter();
            prms[15].Value = objUNIDAD.PreguntaPorPagina;
            prms[15].ParameterName = "@pregunta_por_pagina";

            prms[16] = db.GetParameter();
            prms[16].Value = objUNIDAD.NombreUsuario;
            prms[16].ParameterName = "@usuario_sala_vitrual";

            prms[17] = db.GetParameter();
            prms[17].Value = objUNIDAD.Contrasena;
            prms[17].ParameterName = "@pass_sala_virtual";

            prms[18] = db.GetParameter();
            prms[18].Value = objUNIDAD.URL;
            prms[18].ParameterName = "@url_sala_virtual";

            prms[19] = db.GetParameter();
            prms[19].Value = objUNIDAD.CodTipoSalaVirtual;
            prms[19].ParameterName = "@cod_tipo_sala_virtual";

            prms[20] = db.GetParameter();
            prms[20].Value = objUNIDAD.CodTipoEncuesta;
            prms[20].ParameterName = "@cod_tipo_encuesta";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EUNIDAD objRoot = obj as EUNIDAD;

            objRoot.CodUnidad = Utiles.ConvertToInt16(id);
        }


        public Boolean Existe(long Cod)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = Cod;
            prms[0].ParameterName = "@codigo";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_existe_unidad", prms);

            return Utiles.ConvertToBoolean(dt.Rows[0][0]);
        }

        public Int16 Serial()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_serial_unidad");
            return Utiles.ConvertToInt16(dt.Rows[0][0]);
        }

        public void ActualizaEstadoUnidad(long CodUnidad, Boolean flagActivo)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = CodUnidad;
            prms[0].ParameterName = "@cod_unidad";

            prms[1] = db.GetParameter();
            prms[1].Value = flagActivo;
            prms[1].ParameterName = "@flag_activo";

            db.ExecuteNonQuery(CommandType.StoredProcedure, "proc_update_ESTADO_UNIDAD_FLAG_ACTIVO", prms);


        }

        #endregion

        #region Public Methods

        public override void Fill(DomainObject obj, IDataReader dr)
        {
            EUNIDAD objUNIDAD = obj as EUNIDAD;
    
            //Poner las rutinas del Tools que se necesiten
            
            objUNIDAD.CodUnidad = Utiles.ConvertToInt16(dr["cod_unidad"]);
            
            objUNIDAD.CodTemaUnidad = Utiles.ConvertToInt16(dr["cod_tema_unidad"]);
            
            objUNIDAD.CodTipoUnidad = Utiles.ConvertToInt16(dr["cod_tipo_unidad"]);
            
            objUNIDAD.Nombre = Utiles.ConvertToString(dr["nombre"]);
            
            objUNIDAD.Descripcion = Utiles.ConvertToString(dr["descripcion"]);
            
            objUNIDAD.Archivo = Utiles.ConvertToString(dr["archivo"]);
            
            objUNIDAD.AvisaTermino = Utiles.ConvertToBoolean(dr["avisa_termino"]);
            
            objUNIDAD.Contenido = Utiles.ConvertToString(dr["contenido"]);
            
            objUNIDAD.Criterios = Utiles.ConvertToString(dr["criterios"]);
            
            objUNIDAD.NumPregAleatorias = Utiles.ConvertToInt32(dr["num_preg_aleatorias"]);
            
            objUNIDAD.TiempoSegs = Utiles.ConvertToInt32(dr["tiempo_segs"]);
            
            objUNIDAD.MostrarResultados = Utiles.ConvertToBoolean(dr["Mostrar_Resultados"]);

            objUNIDAD.MostrarRespCorrectas = Utiles.ConvertToBoolean(dr["mostrar_resp_correctas"]);

            objUNIDAD.NomTipoUnidad = Utiles.ConvertToString(dr["nom_tipo_unidad"]);

            objUNIDAD.NomTemaUnidad = Utiles.ConvertToString(dr["nom_tema_unidad"]);

            objUNIDAD.RutTutor = Utiles.ConvertToInt32(dr["rut_tutor"]);

            objUNIDAD.FlagActivo = Utiles.ConvertToBoolean(dr["flag_activo"]);

            objUNIDAD.PreguntaPorPagina = Utiles.ConvertToInt32(dr["pregunta_por_pagina"]);

            objUNIDAD.NombreUsuario = Utiles.ConvertToString(dr["usuario_sala_vitrual"]);

            objUNIDAD.Contrasena = Utiles.ConvertToString(dr["pass_sala_virtual"]);

            objUNIDAD.URL = Utiles.ConvertToString(dr["url_sala_virtual"]);

            objUNIDAD.CodTipoSalaVirtual = Utiles.ConvertToInt32(dr["cod_tipo_sala_virtual"]);

            objUNIDAD.CodTipoEncuesta = Utiles.ConvertToInt16(dr["cod_tipo_encuesta"]);

        }

        #endregion

	}
}
