using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class AsesorTecnicoDto
    {
        public long IdAsesorTecnico { get; set; }
        public string Nombre { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }

        public long IdTerritorio { get; set; }
    }
    public class MostrarAsesorTecnicoDto
    {
        public long IdAsesorTecnico { get; set; }
        public string Nombre { get; set;}
        public string Mail { get; set;}
        public string Telefono { get; set;}
        public string Territorio { get; set;}
    }
}
