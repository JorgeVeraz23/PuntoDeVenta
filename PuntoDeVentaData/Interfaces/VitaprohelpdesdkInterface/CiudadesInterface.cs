using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;

using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface CiudadesInterface
    {
        public Task<List<CiudadesDto>> GetAll();
        public Task<CiudadesDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(CiudadesDto data);
        public Task<MessageInfoDTO> Edit(CiudadesDto data);
    }
}
