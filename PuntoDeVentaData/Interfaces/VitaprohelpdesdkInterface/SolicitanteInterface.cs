using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;

using NicoAssistRemake.Data.Entities.Utilities;
using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface SolicitanteInterface
    {
        public Task<List<SolicitanteDto>> GetAll();
        public Task<List<KeyValue>> KeyValues();
        public Task<SolicitanteDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(SolicitanteDto data);
        public Task<MessageInfoDTO> Edit(SolicitanteDto data);
    }
}
