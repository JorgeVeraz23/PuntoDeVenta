using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;

using NicoAssistRemake.Data.Entities.Utilities;
using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface EstadoIncidenciaInterface
    {
        public Task<List<EstadoIncidenciaDto>> GetAll();
        public Task<List<KeyValue>> KeyValues();
        public Task<EstadoIncidenciaDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(EstadoIncidenciaDto data);
        public Task<MessageInfoDTO> Edit(EstadoIncidenciaDto data);
    }
}
