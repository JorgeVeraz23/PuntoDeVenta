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
    public interface TipoIncidenciaInterface
    {
        public Task<List<TipoIncidenciaDto>> GetAll();
        public Task<List<KeyValue>> KeyValues();
        public Task<TipoIncidenciaDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(TipoIncidenciaDto data);
        public Task<MessageInfoDTO> Edit(TipoIncidenciaDto data);
    }
}
