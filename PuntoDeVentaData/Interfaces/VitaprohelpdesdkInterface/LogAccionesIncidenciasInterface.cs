using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;

using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface LogAccionesIncidenciasInterface
    {
        public Task<List<MostrarLogAccionesIncidenciasDto>> GetAll();
        public Task<LogAccionesIncidenciasDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(LogAccionesIncidenciasDto data);
        public Task<MessageInfoDTO> Edit(LogAccionesIncidenciasDto data);
    }
}
