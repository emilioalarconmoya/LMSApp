namespace LMSApp.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Unidad
    {
        [Key]
        public int CodUnidad { get; set; }
        public int CodTipoUnidad { get; set; }
        public int CodTemaUnidad { get; set; }
        public string Nombre { get; set; }
        public string Archivo { get; set; }
        public bool FlagAvisaTermino { get; set; }
        public string Contenido { get; set; }
        public string Criterios { get; set; }
        public int NumeroPreguntaAleatoria { get; set; }
        public int TiempoSegundos { get; set; }
        public bool FlagMostrarResultados { get; set; }
        public bool FlagMostrarRespuestaCorrecta { get; set; }
        public string Descripcion { get; set; }
        public string NombreTipoUnidad { get; set; }
        public string NombreTemaUnidad { get; set; }
        public int RutTutor { get; set; }
        public bool FlagActivo { get; set; }
        public int PreguntaPorPagina { get; set; }
        public string UsuarioSalaVirtual { get; set; }
        public string PassSalaVirtual { get; set; }
        public string UrlSalaVirtual { get; set; }
        public int CodtipoSalaVirtual { get; set; }
        public int CodTipoEncuesta { get; set; }
    }
}
