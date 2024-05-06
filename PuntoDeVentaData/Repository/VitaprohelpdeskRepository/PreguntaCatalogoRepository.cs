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
    public class PreguntaCatalogoRepository : PreguntaCatalogoInterface
    {
        public Task<MessageInfoDTO> Create(PreguntaCatalogoDto data)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> Desactive(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> Edit(PreguntaCatalogoDto data)
        {
            throw new NotImplementedException();
        }

        public Task<PreguntaCatalogoDto> Get(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PreguntaCatalogoDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
