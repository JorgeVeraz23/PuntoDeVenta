using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;

using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface AreasResponsablesInterface
    {
        public Task<List<AreasResponsablesDto>> GetAll();
        public Task<AreasResponsablesDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(AreasResponsablesDto data);
        public Task<MessageInfoDTO> Edit(AreasResponsablesDto data);
    }
}
