using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;
using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface TablaMatrizInterface
    {
        public Task<List<TablaMatrizDto>> GetAll();
        public Task<TablaMatrizDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(TablaMatrizDto data);
        public Task<MessageInfoDTO> Edit(TablaMatrizDto data);
    }
}
