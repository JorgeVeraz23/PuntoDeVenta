using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class AsesorComercialDto
    {
        public long IdAsesorComercial { get; set; }
        public string Nombre { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        
        public long IdTerritorio { get; set; }
        public string Codigo { get; set; }
    }
    public class MostrarAsesorComercialDto
    {
        public long IdAsesorComercial { set; get; }
        public string Nombre { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set;}
        public string Territorio { get; set;}   
        public string Codigo { get; set;}   
    }
}
