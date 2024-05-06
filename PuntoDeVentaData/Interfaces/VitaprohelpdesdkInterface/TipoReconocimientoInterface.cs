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
    public interface TipoReconocimientoInterface
    {
        public Task<List<TipoReconocimientoDto>> GetAll();
        public Task<List<KeyValue>> KeyValues();
        public Task<TipoReconocimientoDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(TipoReconocimientoDto data);
        public Task<MessageInfoDTO> Edit(TipoReconocimientoDto data);
    }
}
