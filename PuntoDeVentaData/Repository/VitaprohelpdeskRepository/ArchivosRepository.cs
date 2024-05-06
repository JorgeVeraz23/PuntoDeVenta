using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;

using NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface;
using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Repository.VitaprohelpdeskRepository
{
    public class ArchivosRepository : ArchivosInterface
    {
        public Task<MessageInfoDTO> Create(ArchivosDto data)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> Desactive(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> Edit(ArchivosDto data)
        {
            throw new NotImplementedException();
        }

        public Task<ArchivosDto> Get(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ArchivosDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
