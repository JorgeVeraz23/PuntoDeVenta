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
    public class IdiomaRepository : IdiomaInterface
    {
        public Task<MessageInfoDTO> Create(IdiomasDto data)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> Desactive(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> Edit(IdiomasDto data)
        {
            throw new NotImplementedException();
        }

        public Task<IdiomasDto> Get(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<IdiomasDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
