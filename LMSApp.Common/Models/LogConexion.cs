namespace LMSApp.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class LogConexion
    {
        [Key]
        public int CodActividadUsuario { get; set; }
        public DateTime Inicio { get; set; }
        public int CodUnidad { get; set; }
        public DateTime Fin { get; set; }
        public bool FlagTerminada { get; set; }
        public int TiempoRestanteSegunto { get; set; }
        public int PasoUltimaVisita { get; set; }
        public bool Cerrada { get; set; }
        public decimal Nota { get; set; }
        public string Dispositivo { get; set; }
        public string Browser { get; set; }
        public string Ip { get; set; }
        public int CodEmpresa { get; set; }

    }
}
