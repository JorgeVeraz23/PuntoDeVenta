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
    public class CategoriasRepository : CategoriasInterface
    {
        public Task<MessageInfoDTO> Create(CategoriasDto data)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> Desactive(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> Edit(CategoriasDto data)
        {
            throw new NotImplementedException();
        }

        public Task<CategoriasDto> Get(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoriasDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
