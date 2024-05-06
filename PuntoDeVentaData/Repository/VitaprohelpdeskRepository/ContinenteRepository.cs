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
    public class ContinenteRepository : ContinentesInterface
    {
        public Task<MessageInfoDTO> Create(ContinentesDto data)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> Desactive(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> Edit(ContinentesDto data)
        {
            throw new NotImplementedException();
        }

        public Task<ContinentesDto> Get(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ContinentesDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
