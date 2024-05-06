using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;

using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface CargaCorreoInterface
    {
        public Task<List<CargaCorreoDto>> GetAll();
        public Task<CargaCorreoDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(CargaCorreoDto data);
        public Task<MessageInfoDTO> Edit(CargaCorreoDto data);
    }
}
