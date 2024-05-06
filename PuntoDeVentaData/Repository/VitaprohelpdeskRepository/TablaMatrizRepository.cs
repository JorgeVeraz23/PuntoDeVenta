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
    public class TablaMatrizRepository : TablaMatrizInterface
    {
        public Task<MessageInfoDTO> Create(TablaMatrizDto data)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> Desactive(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> Edit(TablaMatrizDto data)
        {
            throw new NotImplementedException();
        }

        public Task<TablaMatrizDto> Get(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TablaMatrizDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
