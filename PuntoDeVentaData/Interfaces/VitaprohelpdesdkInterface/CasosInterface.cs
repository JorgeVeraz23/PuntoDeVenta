using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;

using NicoAssistRemake.Data.Entities.Utilities;
using NicoAssistRemake.Data.Entities.Vitaprohelpdesk;
using PuntoDeVentaData.Dto.UtilitiesDTO;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface CasosInterface
    {
        public Task<List<CasosDto>> GetAll();
        public Task<List<KeyValue>> KeyValues();
        public Task<CasosDto> GetCasos(long IdCasos);
        public Task<MessageInfoDTO> Desactive(long IdCasos);
        public Task<MessageInfoDTO> Create(CasosDto data);
        public Task<MessageInfoDTO> Edit(CasosDto data);
    }
}
