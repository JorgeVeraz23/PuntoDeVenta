using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class TerritorioDto
    {
        public long IdTerritorio { get; set; }
        public string? Nombre { get; set; }
        public string? CodigoTerritorio { get; set; }
    }
}
