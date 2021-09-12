namespace LMSApp.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UnidadesActividad
    {
        [Key]
        public int CodActividadUsuario { get; set; }
        public int CodUnidad { get; set; }
        public string Nombre { get; set; }
        public int OrdenRelativo { get; set; }
        public int NivelPrerequisito { get; set; }
        public bool AvisaTermino { get; set; }
        public int CodTipoUnidad { get; set; }
        public string Archivo { get; set; }
        public int NumeroVisitas { get; set; }
        public string TiempoConexion { get; set; }
        public DateTime UltimaVisita { get; set; }
        public bool Terminada { get; set; }
        public int IdForo { get; set; }
        public int TemasForos { get; set; }
        public string Descripcion { get; set; }
        public string NombreActividad { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal NotaAprobacion { get; set; }
        public decimal Asistencia { get; set; }
        public bool FlagNuevaConexion { get; set; }
        public string RutOtec { get; set; }
        public string CodigoSence { get; set; }
        public string Token { get; set; }
        public string RutUsuario { get; set; }
        public int IdRegistroSence { get; set; }
        public bool FlagActivo { get; set; }
        public DateTime FechaHora { get; set; }
        public int CodActividad { get; set; }
        public int RutTutor { get; set; }
        public int CodActividadTutor { get; set; }
        public decimal NotaFinal { get; set; }
        public bool FlagEstadoAprobacion { get; set; }
        public string Mensaje { get; set; }
        public int Nivel { get; set; }
        public int MinutosEvaluacion { get; set; }

        public override string ToString()
        {
            return this.Nombre;
        }
    }
}
