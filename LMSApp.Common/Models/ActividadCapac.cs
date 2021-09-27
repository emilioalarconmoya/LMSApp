namespace LMSApp.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class ActividadCapac
    {
        [Key]
        public int CodActividad { get; set; }
        public int CodProveedor { get; set; }
        public int CodTipo { get; set; }
        public string Nombre { get; set; }
        public string Contenido { get; set; }
        public decimal Horas { get; set; }
        public decimal Costo { get; set; }
        public int Duracion { get; set; }
        public string CodigoSence { get; set; }
        public string Objetivos { get; set; }
        public int DestacadoHome { get; set; }
        public string Imagen { get; set; }
        public int OrdenDestacados { get; set; }
        public bool FlagVigente { get; set; }
        public string Mensaje { get; set; }
        public decimal NotaMinima { get; set; }
        public decimal PorcentajeMinimo { get; set; }
        public bool FlagNotaEnPorcentaje { get; set; }
        public decimal NotaMaxima { get; set; }
        public decimal NotaAprobacion { get; set; }
        public decimal Exigencia { get; set; }
        public bool FlagPublica { get; set; }
        public bool FlagAbierta { get; set; }
        public bool FlagParaInscripcion { get; set; }
        public decimal PuntajeCurso { get; set; }
        public decimal PuntajeAprobacion { get; set; }
        public int DiasExpiracionPuntos { get; set; }
        public int DiasAutoInscripcion { get; set; }
        public bool FlaNuevaConexion { get; set; }
        public int RutTutor { get; set; }
        public bool FlagActivo { get; set; }
        public int CodCategoria { get; set; }
    }
}
