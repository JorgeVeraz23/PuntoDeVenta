using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;

using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface FacturaDetalleInterface
    {
        public Task<List<MostrrarFacturaDetalleDto>> GetAll();
        public Task<FacturaDetalleDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(FacturaDetalleDto data);
        public Task<MessageInfoDTO> Edit(FacturaDetalleDto data);
    }
}
