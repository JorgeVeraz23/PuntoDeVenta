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
    public class EncuestaIncidenciaController : ControllerBase
    {

        private readonly EncuestaIncidenciaInterface _encuestaIncidenciaInterface;
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _service;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ApplicationUserManager _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static Logger _log = LogManager.GetLogger("EncuestaIncidenciaController");
        MessageInfoDTO infoDTO = new MessageInfoDTO();
        public readonly string _usuario;
        private readonly string _ip;
        private readonly string _nombreController;

        public EncuestaIncidenciaController(EncuestaIncidenciaInterface encuestaIncidenciaInterface, ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor, ApplicationUserManager userManager, IServiceProvider service, IMapper mapper, IConfiguration configuration)
        {
            _encuestaIncidenciaInterface = encuestaIncidenciaInterface;
            this._context = applicationDbContext;
            _service = service;
            _mapper = mapper;
            _configuration = configuration;
            _nombreController = "EncuestaIncidenciaController";
            _httpContextAccessor = httpContextAccessor;
            _ip = _httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
            _usuario = Task.Run(async () =>
            (await userManager.FindByNameAsync(httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c =>
            c.Type.Contains("email", StringComparison.CurrentCultureIgnoreCase))?.Value ?? ""))?.UserName ?? "Desconocido").Result;
        }

        [HttpGet]
        [Route("GetAllEncuestaIncidencia")]
        public async Task<ActionResult> GetAllEncuestaIncidencia()
        {
            try
            {
                var result = await _encuestaIncidenciaInterface.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al listar las encuestas"));
            }
        }

        [HttpPost]
        [Route("CreateEncuestaIncidencia")]
        public async Task<ActionResult> CreateAsesoresComerciales(EncuestaIncidenciaDto encuestaIncidencia)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }
                var resultSave = await _encuestaIncidenciaInterface.Create(encuestaIncidencia);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al crear las encuestas"));
            }
        }

        [HttpGet]
        [Route("GetEncuestas")]
        public async Task<ActionResult> GetEncuestas(long IdEncuesta)
        {
            try
            {
                var result = await _encuestaIncidenciaInterface.Get(IdEncuesta);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al consultar la encuesta"));
            }
        }

        [HttpDelete]
        [Route("EliminarEncuesta")]
        public async Task<ActionResult> EliminarEncuesta(long IdEncuesta)
        {
            try
            {
                var resultDelete = await _encuestaIncidenciaInterface.Desactive(IdEncuesta);
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
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al eliminar las encuestas"));
            }
        }

        [HttpPut]
        [Route("ActualizarEncuestaIncidencia")]
        public async Task<ActionResult> ActualizarEncuestaIncidencia(EncuestaIncidenciaDto encuestaIncidencia)
        {
            try
            {
                var resultSave = await _encuestaIncidenciaInterface.Edit(encuestaIncidencia);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al actualizar las encuestas"));
            }
        }
    }
}
