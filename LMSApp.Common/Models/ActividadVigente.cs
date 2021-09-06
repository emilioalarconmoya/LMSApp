using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSApp.Common.Models
{
    public class ActividadVigente
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
        public bool FlagNuevaConexion { get; set; }
        public int RutTutor { get; set; }
        public int CodActividadTutor { get; set; }

        public override string ToString()
        {
            return this.Nombre;
        }
    }
}
