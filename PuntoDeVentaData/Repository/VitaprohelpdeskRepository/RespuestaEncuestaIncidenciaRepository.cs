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
    public class RespuestaEncuestaIncidenciaRepository : RespuestaEncuestaIncidenciaInterface
    {
        public Task<MessageInfoDTO> Create(RespuestaEncuestaIncidenciaDto data)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> Desactive(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> Edit(RespuestaEncuestaIncidenciaDto data)
        {
            throw new NotImplementedException();
        }

        public Task<RespuestaEncuestaIncidenciaDto> Get(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<RespuestaEncuestaIncidenciaDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
