using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;

using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface ArchivosCargaInterface
    {
        public Task<List<ArchivosCargaDto>> GetAll();
        public Task<ArchivosCargaDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(ArchivosCargaDto data);
        public Task<MessageInfoDTO> Edit(ArchivosCargaDto data);
    }
}
