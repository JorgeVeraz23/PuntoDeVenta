using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class SolicitanteDto
    {
        public long idSolicitante { get; set; }
        public string? SolicitateSap { get; set; }
        public string? NombreContacto { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? ClienteFinal { get; set; }
        public string? ContactoNombre { get; set; }
        public string? Correo { get; set; }
        public string? Celular { get; set; }
        public string? CodigoSolicitante { get; set; }
        public string? CodigoNodo { get; set; }
        public string? Nodo { get; set; }
        public string? CodigoDestinatario { get; set; }
        public string COD_GRUPO_CLIENTE_PRE { get; set; }
        public string? GRUPO_CLIENTE_PRE { get; set; }
    }
}
