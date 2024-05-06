using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;
using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface TemporalIncidenciasInterface
    {
        public Task<List<TemporalIncidenciasDto>> GetAll();
        public Task<TemporalIncidenciasDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(TemporalIncidenciasDto data);
        public Task<MessageInfoDTO> Edit(TemporalIncidenciasDto data);
    }
}
