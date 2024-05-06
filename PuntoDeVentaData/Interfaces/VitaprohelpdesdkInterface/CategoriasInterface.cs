using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;

using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface CategoriasInterface
    {
        public Task<List<CategoriasDto>> GetAll();
        public Task<CategoriasDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(CategoriasDto data);
        public Task<MessageInfoDTO> Edit(CategoriasDto data);
    }
}
