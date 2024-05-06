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
    public interface ClienteInterface
    {
        public Task<List<ClienteDto>> GetAll();
        public Task<List<KeyValue>> KeyValues();
        public Task<ClienteDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(ClienteDto data);
        public Task<MessageInfoDTO> Edit(ClienteDto data);
    }
}
