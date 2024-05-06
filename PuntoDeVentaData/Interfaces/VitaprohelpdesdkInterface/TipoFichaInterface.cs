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
    public interface TipoFichaInterface
    {
        public Task<List<MostrarTipoFichaDto>> GetAll();
        public Task<List<KeyValue>> KeyValues();
        public Task<TipoFichaDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(TipoFichaDto data);
        public Task<MessageInfoDTO> Edit(TipoFichaDto data);
    }
}
