using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;
using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface ProductosIncidenciasInterface
    {
        public Task<List<ProductosIncidenciasDto>> GetAll();
        public Task<ProductosIncidenciasDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(ProductosIncidenciasDto data);
        public Task<MessageInfoDTO> Edit(ProductosIncidenciasDto data);
    }
}
