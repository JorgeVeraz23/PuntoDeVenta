using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;
using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    internal interface RespuestaEncuestaIncidenciaInterface
    {
        public Task<List<RespuestaEncuestaIncidenciaDto>> GetAll();
        public Task<RespuestaEncuestaIncidenciaDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(RespuestaEncuestaIncidenciaDto data);
        public Task<MessageInfoDTO> Edit(RespuestaEncuestaIncidenciaDto data);
    }
}
