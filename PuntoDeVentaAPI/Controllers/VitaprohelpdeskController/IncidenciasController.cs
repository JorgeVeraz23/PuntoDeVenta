using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface;
using NicoAssistRemake.Data;
using NLog;
using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;
using System.Net;
using Data;
using PuntoDeVentaAPI.Services;
using PuntoDeVentaData.Dto.UtilitiesDTO;

namespace NicoAssitRemake.Api.Controllers.VitaprohelpdeskController
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidenciasController : ControllerBase
    {
        private readonly IncidenciaInterface _incidenciaInterface;
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _service;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ApplicationUserManager _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static Logger _log = LogManager.GetLogger("IncidenciasController");
        MessageInfoDTO infoDTO = new MessageInfoDTO();
        public readonly string _usuario;
        private readonly string _ip;
        private readonly string _nombreController;

        public IncidenciasController(IncidenciaInterface incidenciaInterface, ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor, ApplicationUserManager userManager, IServiceProvider service, IMapper mapper, IConfiguration configuration)
        {
            _incidenciaInterface = incidenciaInterface;
            this._context = applicationDbContext;
            _service = service;
            _mapper = mapper;
            _configuration = configuration;
            _nombreController = "IncidenciasController";
            _httpContextAccessor = httpContextAccessor;
            _ip = _httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
            _usuario = Task.Run(async () =>
            (await userManager.FindByNameAsync(httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c =>
            c.Type.Contains("email", StringComparison.CurrentCultureIgnoreCase))?.Value ?? ""))?.UserName ?? "Desconocido").Result;
        }


        [HttpGet]
        [Route("GetAllIncidencias")]
        public async Task<ActionResult> GetAllIncidencias()
        {
            try
            {
                var result = await _incidenciaInterface.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al listar las incidencias"));
            }
        }

        [HttpGet]
        [Route("GetIncidenciasByFilter")]
        public async Task<ActionResult> GetIncidenciasByFilter(DateTime FechaDesde, DateTime FechaHasta, long IdGestorReclamo, long IdTerritorio)
        {
            try
            {
                var questionResponse = await _incidenciaInterface.GetIncidenciaByFilter(FechaDesde, FechaHasta, IdGestorReclamo, IdTerritorio);
                return Ok(questionResponse);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, $"Error al filtrar la matriz. {ex.Message}"));
            }
        }

        [HttpGet]
        [Route("GetIncidencias")]
        public async Task<ActionResult> GetIncidencias(long IdIncidencia)
        {
            try
            {
                var result = await _incidenciaInterface.Get(IdIncidencia);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al consultar la incidencia"));
            }
        }

        [HttpPost]
        [Route("CreateIncidencia")]
        public async Task<ActionResult> CreateIncidencia(IncideniaDto incidenia)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }
                var resultSave = await _incidenciaInterface.Create(incidenia);
                if (resultSave.Success)
                {
                    return Ok(new MessageInfoDTO().AccionCompletada(resultSave.Message ?? string.Empty));
                }
                else
                {
                    return BadRequest(new MessageInfoDTO().AccionFallida(resultSave.Message ?? string.Empty, (int)HttpStatusCode.BadRequest));
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al consultar incidencia"));
            }
        }

        [HttpDelete]
        [Route("EliminarIncidencia")]
        public async Task<ActionResult> EliminarIncidencia(long IdIncidencia)
        {
            try
            {
                var resultDelete = await _incidenciaInterface.Desactive(IdIncidencia);
                if (resultDelete.Success)
                {
                    return Ok(resultDelete.Success);
                }
                else
                {
                    return BadRequest(resultDelete.Message);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al eliminar los motivos"));
            }
        }

        [HttpPut]
        [Route("ActualizarIncidencia")]
        public async Task<ActionResult> ActualizarIncidencia(IncideniaDto incidenia)
        {
            try
            {
                var resultSave = await _incidenciaInterface.Edit(incidenia);
                if (resultSave.Success)
                {
                    return Ok(resultSave.Success);
                }
                else
                {
                    return BadRequest(resultSave.Message);
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al actualizar las incidencias"));
            }
        }


    }
}
