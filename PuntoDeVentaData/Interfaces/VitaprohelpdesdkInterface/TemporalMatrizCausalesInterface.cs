using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;
using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface TemporalMatrizCausalesInterface
    {
        public Task<List<TemporalMatrizCausalesDto>> GetAll();
        public Task<TemporalMatrizCausalesDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(TemporalMatrizCausalesDto data);
        public Task<MessageInfoDTO> Edit(TemporalMatrizCausalesDto data);
    }
}
