namespace LMSApp.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class HistorialAlumno
    {
        [Key]
        public int CodActividadUsuario { get; set; }
        public int CodActividad { get; set; }
        public string Nombre { get; set; }
        public string Objetivos { get; set; }
        public string Imagen { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaInicio { get; set; }
        public int CodTipo { get; set; }
        public int CodEstado { get; set; }
        public int Asistencia { get; set; }
        public string Estado { get; set; }
        public bool Vigente { get; set; }
        public decimal NotaFinal { get; set; }
        public bool MostrarCertificado { get; set; }
        public bool ComunicaSence { get; set; }

        public override string ToString()
        {
            return this.Nombre;
        }
    }
}
