using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;

using NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface;
using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Repository.VitaprohelpdeskRepository
{
    public class ArchivosCargaRepository : ArchivosCargaInterface
    {
        public Task<MessageInfoDTO> Create(ArchivosCargaDto data)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> Desactive(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> Edit(ArchivosCargaDto data)
        {
            throw new NotImplementedException();
        }

        public Task<ArchivosCargaDto> Get(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ArchivosCargaDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
