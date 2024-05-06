using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;

using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface IncidenciaInterface
    {
        public Task<List<MostrarIncidenciaDto>> GetAll();
       
        public Task<List<MostrarIncidenciaDto>> GetIncidenciaByFilter(DateTime FechaReporteIncidencia, DateTime FechaCierreEfectivo, long IdGestorReclamo, long IdTerritorio);
        public Task<IncideniaDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(IncideniaDto data);
        public Task<MessageInfoDTO> Edit(IncideniaDto data);
    }
}
