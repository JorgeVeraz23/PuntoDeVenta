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
    public interface SubMotivoInterfaces
    {
        public Task<List<MostrarSubMotivoDto>> GetAll();
        public Task<List<KeyValue>> KeyValues();
        public Task<SubMotivoDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(SubMotivoDto data);
        public Task<MessageInfoDTO> Edit(SubMotivoDto data);
    }
}
