using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;
using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface MatrizInterface
    {
        public Task<List<MostrarMatrizDto>> GetAll();
        public Task<List<BuscarEnMatricesMotivosPorIdArea>> BuscarEnMatricesLosMotivosPorIdArea(long IdArea);
        public Task<MatrizDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(MatrizDto data);
        public Task<MessageInfoDTO> Edit(MatrizDto data);
        public Task<List<MostrarMatrizDto>> GetMatrizByFilter(long IdArea, long IdMotivo);
    }
}
