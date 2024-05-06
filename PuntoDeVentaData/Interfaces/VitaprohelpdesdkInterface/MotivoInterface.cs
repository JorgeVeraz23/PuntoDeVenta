using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;

using NicoAssistRemake.Data.Entities.Utilities;
using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface MotivoInterface
    {
        public Task<List<MostrarMotivoDto>> GetAll();
        
        public Task<List<KeyValue>> KeyValue();
        public Task<MotivoDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(MotivoDto data);
        public Task<MessageInfoDTO> Edit(MotivoDto data);
    }
}
