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
    public class TemporalIncidenciasRepository : TemporalIncidenciasInterface
    {
        public Task<MessageInfoDTO> Create(TemporalIncidenciasDto data)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> Desactive(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> Edit(TemporalIncidenciasDto data)
        {
            throw new NotImplementedException();
        }

        public Task<TemporalIncidenciasDto> Get(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TemporalIncidenciasDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
