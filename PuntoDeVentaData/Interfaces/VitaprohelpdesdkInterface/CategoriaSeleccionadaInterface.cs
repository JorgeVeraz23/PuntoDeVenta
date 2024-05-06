using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;

using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface CategoriaSeleccionadaInterface
    {
        public Task<List<CategoriaSeleccionadaDto>> GetAll();
        public Task<CategoriaSeleccionadaDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(CategoriaSeleccionadaDto data);
        public Task<MessageInfoDTO> Edit(CategoriaSeleccionadaDto data);
    }
}
