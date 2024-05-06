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
    public class CargaCorreoRepository : CargaCorreoInterface
    {
        public Task<MessageInfoDTO> Create(CargaCorreoDto data)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> Desactive(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> Edit(CargaCorreoDto data)
        {
            throw new NotImplementedException();
        }

        public Task<CargaCorreoDto> Get(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CargaCorreoDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
