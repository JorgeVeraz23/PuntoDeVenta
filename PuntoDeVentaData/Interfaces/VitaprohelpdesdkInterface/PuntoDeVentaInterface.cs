using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;
using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface PuntoDeVentaInterface
    {
        public Task<List<PuntoDeVentaDto>> GetAll();
        public Task<PuntoDeVentaDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(PuntoDeVentaDto data);
        public Task<MessageInfoDTO> Edit(PuntoDeVentaDto data);
    }
}
