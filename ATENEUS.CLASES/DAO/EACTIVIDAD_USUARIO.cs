
using System;
using ATENEUS.CLASES.DAL;
using ATENEUS.COMMON;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EACTIVIDADUSUARIO.
    /// </summary>
    [Serializable()]
    public class EACTIVIDADUSUARIO : DomainObject
    {
	    	
	    private System.Decimal  _cod_activ_usr = 0;
        	
	    private System.Int64  _rut_usuario = 0;

        private System.String _rut_completo = String.Empty;

        private System.Int16 _cod_estado = 0;
        	
	    // private System.Int16  _cod_unidad = 0;
        	
	    private System.Int16  _cod_actividad = 0;
        	
	    private System.DateTime  _fecha_inicio = System.DateTime.Now;
        	
	    private System.DateTime  _hora_inicio = System.DateTime.Now;
        	
	    private System.DateTime  _fecha_fin = System.DateTime.Now;
        	
	    private System.DateTime  _hora_fin = System.DateTime.Now;
        	
	    private System.DateTime  _inicio_real = System.DateTime.Now;
        	
	    private System.DateTime  _hora_inicio_real = System.DateTime.Now;
        	
	    private System.DateTime  _fin_real = System.DateTime.Now;
        	
	    private System.DateTime  _hora_fin_real = System.DateTime.Now;
        	
	    private System.Double  _nota_final = 0.0;

        private System.Double _porc_final = 0.0;

        private System.Double _nota_minima = 0.0;

        private System.Double _porc_minimo = 0.0;

        private System.Double _asistencia = 0.0;
        	
	    private System.String  _comentarios = String.Empty;

        private System.Double _evaluacion_curso = 0.0;
        	
	    private System.Int64  _costo_sence = 0;
        	
	    private System.Int64  _costo_empresa = 0;
        	
	    private System.Boolean  _flag_comunica_sence = false;
        	
	    private System.DateTime  _Fecha_certificacion = System.DateTime.Now;
        	
	    private System.Boolean  _mostrar_certificado = false;
        	
	    private System.Boolean  _flag_estado_aprobacion = false;
        	
	    private System.Boolean  _flag_eval_con_hora = false;

        private System.Int64 _orden_compra = 0;

        private System.String _nombre_actividad = String.Empty;

        private System.String _nombre_usuario = String.Empty;

        private System.Int16 _ptje_total = 0;

        private System.Int16 _ptje_obtenido = 0;

        private System.Int16 _total_unidades = 0;

        private System.Int16 _unidades_terminadas = 0;

        private System.Int64 _cod_empresa = 0;

        private System.Int32 _id_registro_sence = 0;

        private System.Int32 _cod_actividad_tutor = 0;

        private System.String _dni = String.Empty;

        private System.Int32 _minutos_evaluacion = 0;

        private System.Boolean _flag_enviar_encuesta = false;

        private System.Int16 _cod_encuesta_satis = 0;

        private System.Double _nota_encuesta = 0.0;


        public EACTIVIDADUSUARIO() : base()
	    {
	    }
	    
		public EACTIVIDADUSUARIO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CodActivUsr
	    {
		    get { return _cod_activ_usr; }
		    set { _cod_activ_usr = value; }
	    }
	    
	    	
	    public System.Int64 RutUsuario
	    {
		    get { return _rut_usuario; }
		    set { _rut_usuario = value; }
        }
        public System.Int64 CodEmpresa
        {
            get { return _cod_empresa; }
            set { _cod_empresa = value; }
        }

        public System.String RutCompleto
        {
            get { return Utiles.RutLngAUsr(_rut_usuario); }
            set { _rut_completo = value; }
        }


        public System.Int16 CodEstado
	    {
		    get { return _cod_estado; }
		    set { _cod_estado = value; }
	    }
	    
	    	
	   /* public System.Int16 CodUnidad
	    {
		    get { return _cod_unidad; }
		    set { _cod_unidad = value; }
	    }*/
	    
	    	
	    public System.Int16 CodActividad
	    {
		    get { return _cod_actividad; }
		    set { _cod_actividad = value; }
	    }
	    
	    	
	    public System.DateTime FechaInicio
	    {
		    get { return _fecha_inicio; }
		    set { _fecha_inicio = value; }
	    }
	    
	    	
	    public System.DateTime HoraInicio
	    {
		    get { return _hora_inicio; }
		    set { _hora_inicio = value; }
	    }
	    
	    	
	    public System.DateTime FechaFin
	    {
		    get { return _fecha_fin; }
		    set { _fecha_fin = value; }
	    }
	    
	    	
	    public System.DateTime HoraFin
	    {
		    get { return _hora_fin; }
		    set { _hora_fin = value; }
	    }
	    
	    	
	    public System.DateTime InicioReal
	    {
		    get { return _inicio_real; }
		    set { _inicio_real = value; }
	    }
	    
	    	
	    public System.DateTime HoraInicioReal
	    {
		    get { return _hora_inicio_real; }
		    set { _hora_inicio_real = value; }
	    }
	    
	    	
	    public System.DateTime FinReal
	    {
		    get { return _fin_real; }
		    set { _fin_real = value; }
	    }
	    
	    	
	    public System.DateTime HoraFinReal
	    {
		    get { return _hora_fin_real; }
		    set { _hora_fin_real = value; }
	    }
	    
	    	
	    public System.Double NotaFinal
	    {
		    get { return _nota_final; }
		    set { _nota_final = value; }
	    }
	    
	    	
	    public System.Double PorcFinal
	    {
		    get { return _porc_final; }
		    set { _porc_final = value; }
	    }
	    
	    	
	    public System.Double NotaMinima
	    {
		    get { return _nota_minima; }
		    set { _nota_minima = value; }
	    }
	    
	    	
	    public System.Double PorcMinimo
	    {
		    get { return _porc_minimo; }
		    set { _porc_minimo = value; }
	    }
	    
	    	
	    public System.Double Asistencia
	    {
		    get { return _asistencia; }
		    set { _asistencia = value; }
	    }
	    
	    	
	    public System.String Comentarios
	    {
		    get { return _comentarios; }
		    set { _comentarios = value; }
	    }
	    
	    	
	    public System.Double EvaluacionCurso
	    {
		    get { return _evaluacion_curso; }
		    set { _evaluacion_curso = value; }
	    }
	    
	    	
	    public System.Int64 CostoSence
	    {
		    get { return _costo_sence; }
		    set { _costo_sence = value; }
	    }
	    
	    	
	    public System.Int64 CostoEmpresa
	    {
		    get { return _costo_empresa; }
		    set { _costo_empresa = value; }
	    }
	    
	    	
	    public System.Boolean FlagComunicaSence
	    {
		    get { return _flag_comunica_sence; }
		    set { _flag_comunica_sence = value; }
	    }
	    
	    	
	    public System.DateTime FechaCertificacion
	    {
		    get { return _Fecha_certificacion; }
		    set { _Fecha_certificacion = value; }
	    }
	    
	    	
	    public System.Boolean MostrarCertificado
	    {
		    get { return _mostrar_certificado; }
		    set { _mostrar_certificado = value; }
	    }
	    
	    	
	    public System.Boolean FlagEstadoAprobacion
	    {
		    get { return _flag_estado_aprobacion; }
		    set { _flag_estado_aprobacion = value; }
	    }
	    
	    	
	    public System.Boolean FlagEvalConHora
	    {
		    get { return _flag_eval_con_hora; }
		    set { _flag_eval_con_hora = value; }
	    }
	    
	    	
	    public System.Int64 OrdenCompra
	    {
		    get { return _orden_compra; }
		    set { _orden_compra = value; }
	    }

        public System.String NombreActividad
        {
            get { return _nombre_actividad; }
            set { _nombre_actividad = value; }
        }

        public System.String NombreUsuario
        {
            get { return _nombre_usuario; }
            set { _nombre_usuario = value; }
        }

        public System.Int16 PtjeTotal
        {
            get { return _ptje_total; }
            set { _ptje_total = value; }
        }

        public System.Int16 PtjeObtenido
        {
            get { return _ptje_obtenido; }
            set { _ptje_obtenido = value; }
        }

        public System.Int16 TotalUnidades
        {
            get { return _total_unidades; }
            set { _total_unidades = value; }
        }

        public System.Int16 UnidadesTerminadas
        {
            get { return _unidades_terminadas; }
            set { _unidades_terminadas = value; }
        }

        public System.Int32 IdRegistroSence
        {
            get { return _id_registro_sence; }
            set { _id_registro_sence = value; }
        }

        public System.Int32 CodActividadTutor
        {
            get { return _cod_actividad_tutor; }
            set { _cod_actividad_tutor = value; }
        }

        public System.String DNI
        {
            get { return _dni; }
            set { _dni = value; }
        }
        public System.Int32 MinutosEvaluacion
        {
            get { return _minutos_evaluacion; }
            set { _minutos_evaluacion = value; }
        }

        public System.Boolean EnviarEncuesta
        {
            get { return _flag_enviar_encuesta; }
            set { _flag_enviar_encuesta = value; }
        }

        public System.Int16 CodEncuestaSatisfaccion
        {
            get { return _cod_encuesta_satis; }
            set { _cod_encuesta_satis = value; }
        }

        public System.Double NotaEncuesta
        {
            get { return _nota_encuesta; }
            set { _nota_encuesta = value; }
        }



        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLACTIVIDADUSUARIO();
        }

        #endregion	    
    }
}