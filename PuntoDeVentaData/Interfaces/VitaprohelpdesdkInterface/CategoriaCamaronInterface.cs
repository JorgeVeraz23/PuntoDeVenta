using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;

using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface CategoriaCamaronInterface
    {
        public Task<List<CategoriaCamaronDto>> GetAll();
        public Task<CategoriaCamaronDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(CategoriaCamaronDto data);
        public Task<MessageInfoDTO> Edit(CategoriaCamaronDto data);
    }
}
