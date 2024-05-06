using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface SeguimentoIncideciasInterface
    {
        public Task<List<SeguimientoIncidenciasDto>> GetAll();
        public Task<List<SeguimientoIncidenciasDto>> GetSeguimientoIncidenciaByFilter(DateTime FechaDesde, DateTime FechaHasta, long IdTipoIncidencia, long IdAreaReclamo, long IdMotivo, long IdEstadoProceso, long IdGestorReclamo,  long IdTerritorio);
        public Task<List<SeguimientoIncidenciasDto>> Get(string CodigoReclamo);

    }
}
