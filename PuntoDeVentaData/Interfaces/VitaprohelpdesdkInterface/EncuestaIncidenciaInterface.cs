using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;

using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface EncuestaIncidenciaInterface
    {
        public Task<List<EncuestaIncidenciaDto>> GetAll();
        public Task<EncuestaIncidenciaDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(EncuestaIncidenciaDto data);
        public Task<MessageInfoDTO> Edit(EncuestaIncidenciaDto data);
    }
}
