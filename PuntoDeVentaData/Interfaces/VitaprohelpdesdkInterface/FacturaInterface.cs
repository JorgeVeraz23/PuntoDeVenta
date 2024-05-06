using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;

using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface FacturaInterface
    {
        public Task<List<MostrarFacturaDto>> GetAll();
        public Task<FacturaDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(FacturaDto data);
        public Task<MessageInfoDTO> Edit(FacturaDto data);
    }
}
