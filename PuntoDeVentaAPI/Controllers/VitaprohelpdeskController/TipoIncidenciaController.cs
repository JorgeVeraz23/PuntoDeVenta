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
    public class TipoIncidenciaController : ControllerBase
    {
        private readonly TipoIncidenciaInterface _tipoIncidenciaInterface;
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _service;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ApplicationUserManager _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static Logger _log = LogManager.GetLogger("TipoIncidenciaController");
        MessageInfoDTO infoDTO = new MessageInfoDTO();
        public readonly string _usuario;
        private readonly string _ip;
        private readonly string _nombreController;

        public TipoIncidenciaController(TipoIncidenciaInterface tipoIncidenciaInterface, ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor, ApplicationUserManager userManager, IServiceProvider service, IMapper mapper, IConfiguration configuration)
        {
            _tipoIncidenciaInterface = tipoIncidenciaInterface;
            this._context = applicationDbContext;
            _service = service;
            _mapper = mapper;
            _configuration = configuration;
            _nombreController = "AsesorComercialController";
            _httpContextAccessor = httpContextAccessor;
            _ip = _httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
            _usuario = Task.Run(async () =>
            (await userManager.FindByNameAsync(httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c =>
            c.Type.Contains("email", StringComparison.CurrentCultureIgnoreCase))?.Value ?? ""))?.UserName ?? "Desconocido").Result;
        }

        [HttpGet]
        [Route("GetAllTipoIncidencias")]
        public async Task<ActionResult> GetAllTipoIncidencias()
        {
            try
            {
                var result = await _tipoIncidenciaInterface.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al listar los tipos de incidencias"));
            }
        }

        [HttpGet]
        [Route("KeyValues")]
        public async Task<ActionResult> KeyValues()
        {
            try
            {
                var result = await _tipoIncidenciaInterface.KeyValues();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al listar los tipos de incidencias"));
            }
        }

        [HttpPost]
        [Route("CreateTiposIncidencias")]
        public async Task<ActionResult> CreateTiposIncidencias(TipoIncidenciaDto tipoIncidencia)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }
                var resultSave = await _tipoIncidenciaInterface.Create(tipoIncidencia);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al crear los tipos de incidencia"));
            }
        }

        [HttpGet]
        [Route("GetTiposIncidencias")]
        public async Task<ActionResult> GetTiposIncidencias(long IdTipoIncidencias)
        {
            try
            {
                var result = await _tipoIncidenciaInterface.Get(IdTipoIncidencias);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al consultar el tipo de incidencia seleccionado"));
            }
        }

        [HttpDelete]
        [Route("EliminarTipoIncidencia")]
        public async Task<ActionResult> EliminarTipoIncidencia(long IdTipoIncidencia)
        {
            try
            {
                var resultDelete = await _tipoIncidenciaInterface.Desactive(IdTipoIncidencia);
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
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al eliminar los tipos de incidencia"));
            }
        }

        [HttpPut]
        [Route("ActualizarTiposIncidencias")]
        public async Task<ActionResult> ActualizarTiposIncidencias(TipoIncidenciaDto tipoIncidencia)
        {
            try
            {
                var resultSave = await _tipoIncidenciaInterface.Edit(tipoIncidencia);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al actualizar los tipos de incidencia"));
            }
        }
    }
}
