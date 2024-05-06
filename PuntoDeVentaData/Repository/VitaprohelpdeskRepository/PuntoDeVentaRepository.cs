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
    public class PuntoDeVentaRepository : PuntoDeVentaInterface
    {
        public Task<MessageInfoDTO> Create(PuntoDeVentaDto data)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> Desactive(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> Edit(PuntoDeVentaDto data)
        {
            throw new NotImplementedException();
        }

        public Task<PuntoDeVentaDto> Get(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PuntoDeVentaDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
