using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface;
using NicoAssistRemake.Data;
using NLog;
using Data;
using PuntoDeVentaAPI.Services;
using PuntoDeVentaData.Dto.UtilitiesDTO;

namespace NicoAssitRemake.Api.Controllers.VitaprohelpdeskController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguimientoIncidenciaController : ControllerBase
    {
        private readonly SeguimentoIncideciasInterface _seguimientoIncidenciaInterface;
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _service;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ApplicationUserManager _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static Logger _log = LogManager.GetLogger("SeguimientoIncidenciaController");
        MessageInfoDTO infoDTO = new MessageInfoDTO();
        public readonly string _usuario;
        private readonly string _ip;
        private readonly string _nombreController;

        public SeguimientoIncidenciaController(SeguimentoIncideciasInterface seguimentoIncideciasInterface, ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor, ApplicationUserManager userManager, IServiceProvider service, IMapper mapper, IConfiguration configuration)
        {
            _seguimientoIncidenciaInterface = seguimentoIncideciasInterface;
            this._context = applicationDbContext;
            _service = service;
            _mapper = mapper;
            _configuration = configuration;
            _nombreController = "SeguimientoIncidenciaController";
            _httpContextAccessor = httpContextAccessor;
            _ip = _httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
            _usuario = Task.Run(async () =>
            (await userManager.FindByNameAsync(httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c =>
            c.Type.Contains("email", StringComparison.CurrentCultureIgnoreCase))?.Value ?? ""))?.UserName ?? "Desconocido").Result;
        }


        [HttpGet]
        [Route("GetAllSeguimientoIncidencias")]
        public async Task<ActionResult> GetAllSeguimientoIncidencias()
        {
            try
            {
                var result = await _seguimientoIncidenciaInterface.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al listar los seguimientos de incidencias"));
            }
        }

        [HttpGet]
        [Route("GetSeguimientoIncidenciaByFilter")]
        public async Task<ActionResult> GetSeguimientoIncidenciaByFilter(DateTime FechaDesde, DateTime FechaHasta, long IdTipoIncidencia, long IdAreaReclamo, long IdMotivo, long IdEstadoProceso, long IdGestorReclamo, long IdTerritorio)
        {
            try
            {
                var questionResponse = await _seguimientoIncidenciaInterface.GetSeguimientoIncidenciaByFilter(FechaDesde, FechaHasta, IdTipoIncidencia, IdAreaReclamo, IdMotivo, IdEstadoProceso, IdGestorReclamo, IdTerritorio);
                return Ok(questionResponse);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, $"Error al filtrar la matriz. {ex.Message}"));
            }
        }

        [HttpGet]
        [Route("GetSeguimientoIncidencia")]
        public async Task<ActionResult> GetSeguimientoIncidencia(string Codigo)
        {
            try
            {
                var result = await _seguimientoIncidenciaInterface.Get(Codigo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al consultar el seguimiento"));
            }
        }
    }
}
