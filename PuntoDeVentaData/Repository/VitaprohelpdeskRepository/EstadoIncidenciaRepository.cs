using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;

using NicoAssistRemake.Data.Entities.Utilities;
using NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface;
using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Repository.VitaprohelpdeskRepository
{
    public class EstadoIncidenciaRepository : EstadoIncidenciaInterface
    {
        public Task<MessageInfoDTO> Create(EstadoIncidenciaDto data)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> Desactive(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> Edit(EstadoIncidenciaDto data)
        {
            throw new NotImplementedException();
        }

        public Task<EstadoIncidenciaDto> Get(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<EstadoIncidenciaDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async  Task<List<KeyValue>> KeyValues()
        {
            //var estadoIncidenciaKeyValue = await _context.AreasReclamos.Where(x => x.Active).Select(c => new KeyValue
            //{
            //    Key = c.IdAreaReclamos,
            //    Value = c.AreaReclamo,

            //}).ToListAsync();
            return null;
        }
    }
}
