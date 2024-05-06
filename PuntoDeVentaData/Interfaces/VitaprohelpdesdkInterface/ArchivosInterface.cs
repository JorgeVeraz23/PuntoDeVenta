using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;

using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface ArchivosInterface
    {
        public Task<List<ArchivosDto>> GetAll();
        public Task<ArchivosDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(ArchivosDto data);
        public Task<MessageInfoDTO> Edit(ArchivosDto data);
    }
}
