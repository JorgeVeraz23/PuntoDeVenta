using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;

using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface ContinentesInterface
    {
        public Task<List<ContinentesDto>> GetAll();
        public Task<ContinentesDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(ContinentesDto data);
        public Task<MessageInfoDTO> Edit(ContinentesDto data);
    }
}
