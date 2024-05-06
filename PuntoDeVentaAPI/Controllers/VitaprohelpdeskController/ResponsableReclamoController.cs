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
    public class ResponsableReclamoController : ControllerBase
    {
        private readonly ResponsableReclamoInterface _responsableReclamoInterface;
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _service;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ApplicationUserManager _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static Logger _log = LogManager.GetLogger("ResponsableReclamoController");
        MessageInfoDTO infoDTO = new MessageInfoDTO();
        public readonly string _usuario;
        private readonly string _ip;
        private readonly string _nombreController;

        public ResponsableReclamoController(ResponsableReclamoInterface responsableReclamoInterface, ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor, ApplicationUserManager userManager, IServiceProvider service, IMapper mapper, IConfiguration configuration)
        {
            _responsableReclamoInterface = responsableReclamoInterface;
            this._context = applicationDbContext;
            _service = service;
            _mapper = mapper;
            _configuration = configuration;
            _nombreController = "ResponsableReclamoController";
            _httpContextAccessor = httpContextAccessor;
            _ip = _httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
            _usuario = Task.Run(async () =>
            (await userManager.FindByNameAsync(httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c =>
            c.Type.Contains("email", StringComparison.CurrentCultureIgnoreCase))?.Value ?? ""))?.UserName ?? "Desconocido").Result;
        }

        [HttpGet]
        [Route("GetAllResponsableReclamos")]
        public async Task<ActionResult> GetAllResponsableReclamos()
        {
            try
            {
                var result = await _responsableReclamoInterface.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al listar los reclamos"));
            }
        }

        [HttpGet]
        [Route("KeyValue")]
        public async Task<ActionResult> KeyValue()
        {
            try
            {
                var result = await _responsableReclamoInterface.KeyValues();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al listar los reclamos"));
            }
        }

        [HttpPost]
        [Route("CreateResponsableReclamos")]
        public async Task<ActionResult> CreateResponsableReclamos(ResponsablesReclamosDto responsablesReclamos)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }
                var resultSave = await _responsableReclamoInterface.Create(responsablesReclamos);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al crear los responsables de reclamos"));
            }
        }

        [HttpGet]
        [Route("GetResponsablesReclamos")]
        public async Task<ActionResult> GetResponsablesReclamos(long IdResponsableReclamo)
        {
            try
            {
                var result = await _responsableReclamoInterface.Get(IdResponsableReclamo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al consultar los responsables de reclamos"));
            }
        }

        [HttpDelete]
        [Route("EliminarResponsableReclamo")]
        public async Task<ActionResult> EliminarResponsableReclamo(long IdResponsableReclamo)
        {
            try
            {
                var resultDelete = await _responsableReclamoInterface.Desactive(IdResponsableReclamo);
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
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al eliminar los responsables de reclamos"));
            }
        }

        [HttpPut]
        [Route("ActualizarResponsablesReclamos")]
        public async Task<ActionResult> ActualizarResponsablesReclamos(ResponsablesReclamosDto responsablesReclamos)
        {
            try
            {
                var resultSave = await _responsableReclamoInterface.Edit(responsablesReclamos);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al actualizar los responsables de reclamos"));
            }
        }
    }
}
