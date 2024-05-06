using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;
using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface IdiomaInterface
    {
        public Task<List<IdiomasDto>> GetAll();
        public Task<IdiomasDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(IdiomasDto data);
        public Task<MessageInfoDTO> Edit(IdiomasDto data);
    }
}
