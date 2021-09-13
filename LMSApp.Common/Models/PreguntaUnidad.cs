namespace LMSApp.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class PreguntaUnidad
    {
        [Key]
        public int CodPregunta { get; set; }
        public int CodUnidad { get; set; }
        public int PuntajeMax { get; set; }
        public string Imagen { get; set; }
        public string Ancho { get; set; }
        public string Alto { get; set; }
        public string Link { get; set; }
        public string UrlVideo { get; set; }
    }
}
