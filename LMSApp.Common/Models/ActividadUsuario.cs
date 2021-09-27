namespace LMSApp.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class ActividadUsuario
    {
        [Key]
        public int CodActividadUsuario { get; set; }
        public int RutUsuario { get; set; }
        public int CodActividad { get; set; }
        public int CodEstado { get; set; }
        public int CodUltimaUnidad { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime InicioReal { get; set; }
        public DateTime FinReal { get; set; }
        public decimal NotaFinal { get; set; }
        public decimal Asistencia { get; set; }
        public string Comentarios { get; set; }
        public decimal EvaluacionCurso { get; set; }
        public int CostoSence { get; set; }
        public int GastoEmpresa { get; set; }
        public bool FlagComunicaSence { get; set; }
        public DateTime FechaCertificacion { get; set; }
        public bool FlagMostrarCertificado { get; set; }
        public decimal NotaMinima { get; set; }
        public bool FlagEstadoAprobacion { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public DateTime HoraInicioReal { get; set; }
        public DateTime HoraFinReal { get; set; }
        public bool FlagEvalConHora { get; set; }
        public decimal PorcentajeMinimo { get; set; }
        public int OrdenCompra { get; set; }
        public int IdRegistroSence { get; set; }
        public int CodActividadTutor { get; set; }
        public string Dni { get; set; }
        public int MinutosEvaluacion { get; set; }
        public bool FlagEnviarEncuesta { get; set; }
        public int CodEncuestaSatisfaccion { get; set; }
        public int PuntajeMaximo { get; set; }
        public int PuntajeObtenido { get; set; }
        public int TotalUnidades { get; set; }
        public int UnidadesTerminadas { get; set; }
        public int CodEmpresa { get; set; }

    }
}
