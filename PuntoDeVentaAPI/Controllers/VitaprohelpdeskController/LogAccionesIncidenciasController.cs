using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface;
using NicoAssistRemake.Data;
using NLog;
using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;
using System.Net;
using PuntoDeVentaAPI.Services;
using Data;
using PuntoDeVentaData.Dto.UtilitiesDTO;

namespace NicoAssitRemake.Api.Controllers.VitaprohelpdeskController
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogAccionesIncidenciasController : ControllerBase
    {
        private readonly LogAccionesIncidenciasInterface _logAccionesIncidenciasInterface;
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _service;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ApplicationUserManager _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static Logger _log = LogManager.GetLogger("LogAccionesIncidenciasController");
        MessageInfoDTO infoDTO = new MessageInfoDTO();
        public readonly string _usuario;
        private readonly string _ip;
        private readonly string _nombreController;

        public LogAccionesIncidenciasController(LogAccionesIncidenciasInterface logAccionesIncidenciasInterface, ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor, ApplicationUserManager userManager, IServiceProvider service, IMapper mapper, IConfiguration configuration)
        {
            _logAccionesIncidenciasInterface = logAccionesIncidenciasInterface;
            this._context = applicationDbContext;
            _service = service;
            _mapper = mapper;
            _configuration = configuration;
            _nombreController = "LogAccionesIncidenciasController";
            _httpContextAccessor = httpContextAccessor;
            _ip = _httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
            _usuario = Task.Run(async () =>
            (await userManager.FindByNameAsync(httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c =>
            c.Type.Contains("email", StringComparison.CurrentCultureIgnoreCase))?.Value ?? ""))?.UserName ?? "Desconocido").Result;
        }

        [HttpGet]
        [Route("GetAllLogAccionesIncidenncias")]
        public async Task<ActionResult> GetAllLogAccionesIncidenncias()
        {
            try
            {
                var result = await _logAccionesIncidenciasInterface.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al listar los log accioes incidencias"));
            }
        }


        [HttpPost]
        [Route("CreateLogAccionesIncidencias")]
        public async Task<ActionResult> CreateLogAccionesIncidencias(LogAccionesIncidenciasDto logAccionesIncidencias)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }
                var resultSave = await _logAccionesIncidenciasInterface.Create(logAccionesIncidencias);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al crear los log acciones incidencias"));
            }
        }

        [HttpGet]
        [Route("GetLogAccionesDeIncidencia")]
        public async Task<ActionResult> GetLogAccionesDeIncidencia(long IdAccionesIncidencia)
        {
            try
            {
                var result = await _logAccionesIncidenciasInterface.Get(IdAccionesIncidencia);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al consultar el log de acciones de la incidencia"));
            }
        }

        [HttpDelete]
        [Route("EliminarLogAccionesIncidencia")]
        public async Task<ActionResult> EliminarLogAccionesIncidencia(long IdLogAccionesIncidencia)
        {
            try
            {
                var resultDelete = await _logAccionesIncidenciasInterface.Desactive(IdLogAccionesIncidencia);
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
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al eliminar el log de acciones de la incidencia"));
            }
        }

        [HttpPut]
        [Route("ActualizarLogAccionesIncidencia")]
        public async Task<ActionResult> ActualizarLogAccionesIncidencia(LogAccionesIncidenciasDto logAccionesIncidencias)
        {
            try
            {
                var resultSave = await _logAccionesIncidenciasInterface.Edit(logAccionesIncidencias);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al actualizar el log de acciones de incidencia"));
            }
        }
    }
}
