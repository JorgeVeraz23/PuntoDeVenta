using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class ArchivosDto
    {
        public long IdArchivo { get; set; }
        [MaxLength(1800)]
        public string EnlacePublico { get; set; }
        [MaxLength(1500)]
        public string EnlacePrivado { get; set; }
        [MaxLength(900)]
        public string NombreOriginal { get; set; }
        [MaxLength(1200)]
        public string NombreSistema { get; set; }
        public string Tipo { get; set; }
        public Boolean Lectura { get; set; }
        public Boolean Escritura { get; set; }
        public Boolean Descarga { get; set; }
        public Boolean Sistema { get; set; }
        public Boolean Disponible { get; set; }
        public Double TamanioKb { get; set; }
        public Double TamaniMb { get; set; }
        public Boolean Imagen { get; set; }
        public string Extension { get; set; }
        public Double Alto { get; set; }
        public Double Ancho { get; set; }
        public string FechaCarga { get; set; }
    }
}
