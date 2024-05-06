using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;

using NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface;
using NicoAssistRemake.Data;
using NLog;
using System.Net;
using Data;
using PuntoDeVentaAPI.Services;
using PuntoDeVentaData.Dto.UtilitiesDTO;

namespace NicoAssitRemake.Api.Controllers.VitaprohelpdeskController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccionesRequisitoFichaController : ControllerBase
    {
        private readonly AccionesRequisitosFichaInterface _accionesRequisitoFichaInterface;
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _service;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ApplicationUserManager _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static Logger _log = LogManager.GetLogger("AccionesRequisitoFichaController");
        MessageInfoDTO infoDTO = new MessageInfoDTO();
        public readonly string _usuario;
        private readonly string _ip;
        private readonly string _nombreController;

        public AccionesRequisitoFichaController(AccionesRequisitosFichaInterface accionesRequisitoFichaInterface, ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor, ApplicationUserManager userManager, IServiceProvider service, IMapper mapper, IConfiguration configuration)
        {
            _accionesRequisitoFichaInterface = accionesRequisitoFichaInterface;
            this._context = applicationDbContext;
            _service = service;
            _mapper = mapper;
            _configuration = configuration;
            _nombreController = "AccionesRequisitoFichaController";
            _httpContextAccessor = httpContextAccessor;
            _ip = _httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
            _usuario = Task.Run(async () =>
            (await userManager.FindByNameAsync(httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c =>
            c.Type.Contains("email", StringComparison.CurrentCultureIgnoreCase))?.Value ?? ""))?.UserName ?? "Desconocido").Result;
        }

        [HttpGet]
        [Route("GetAllRequisitosFicha")]
        public async Task<ActionResult> GetAllRequisitosFicha()
        {
            try
            {
                var result = await _accionesRequisitoFichaInterface.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al listar las acciones de requisito tipo ficha"));
            }
        }


        [HttpGet]
        [Route("KeyValue")]
        public async Task<ActionResult> KeyValue()
        {
            try
            {
                var result = await _accionesRequisitoFichaInterface.KeyValues();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al listar las acciones de requisito tipo ficha"));
            }
        }

        [HttpPost]
        [Route("CreateAccionesRequisitosFicha")]
        public async Task<ActionResult> CreateAccionesRequisitosFicha(AccionesRequisitoFichaDto accionesRequisitoFicha)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }
                var resultSave = await _accionesRequisitoFichaInterface.Create(accionesRequisitoFicha);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al crear las acciones de requisito tipo ficha"));
            }
        }

        [HttpGet]
        [Route("GetAccionesRequisitosFicha")]
        public async Task<ActionResult> GetAccionesRequisitosFicha(long IdAccionesRequisitosFicha)
        {
            try
            {
                var result = await _accionesRequisitoFichaInterface.Get(IdAccionesRequisitosFicha);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al consultar las acciones de requisitos ficha"));
            }
        }

        [HttpDelete]
        [Route("EliminarAccionesRequisitoFicha")]
        public async Task<ActionResult> EliminarAccionesRequisitoFicha(long IdAccionesRequisitosFicha)
        {
            try
            {
                var resultDelete = await _accionesRequisitoFichaInterface.Desactive(IdAccionesRequisitosFicha);
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
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al eliminar las acciones de requisitos tipo ficha"));
            }
        }

        [HttpPut]
        [Route("ActualizarAccionesRequisitoFicha")]
        public async Task<ActionResult> ActualizarAccionesRequisitoFicha(AccionesRequisitoFichaDto accionesRequisitoFicha)
        {
            try
            {
                var resultSave = await _accionesRequisitoFichaInterface.Edit(accionesRequisitoFicha);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al actualizar los requisitos tipo ficha"));
            }
        }
    }
}
