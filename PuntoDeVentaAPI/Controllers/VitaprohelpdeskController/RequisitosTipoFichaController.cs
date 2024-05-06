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
    public class RequisitosTipoFichaController : ControllerBase
    {
        private readonly RequisitosTipoFichaInterface  _requisitosTipoFichaInterface;
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _service;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ApplicationUserManager _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static Logger _log = LogManager.GetLogger("RequisitosTipoFichaController");
        MessageInfoDTO infoDTO = new MessageInfoDTO();
        public readonly string _usuario;
        private readonly string _ip;
        private readonly string _nombreController;

        public RequisitosTipoFichaController(RequisitosTipoFichaInterface requisitosTipoFichaInterface, ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor, ApplicationUserManager userManager, IServiceProvider service, IMapper mapper, IConfiguration configuration)
        {
            _requisitosTipoFichaInterface = requisitosTipoFichaInterface;
            this._context = applicationDbContext;
            _service = service;
            _mapper = mapper;
            _configuration = configuration;
            _nombreController = "RequisitosTipoFichaController";
            _httpContextAccessor = httpContextAccessor;
            _ip = _httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
            _usuario = Task.Run(async () =>
            (await userManager.FindByNameAsync(httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c =>
            c.Type.Contains("email", StringComparison.CurrentCultureIgnoreCase))?.Value ?? ""))?.UserName ?? "Desconocido").Result;
        }

        [HttpGet]
        [Route("GetAllRequisitosTipoFicha")]
        public async Task<ActionResult> GetAllRequisitosTipoFicha()
        {
            try
            {
                var result = await _requisitosTipoFichaInterface.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al listar los requisitos tipo ficha"));
            }
        }


        [HttpGet]
        [Route("KeyValue")]
        public async Task<ActionResult> KeyValue()
        {
            try
            {
                var result = await _requisitosTipoFichaInterface.KeyValues();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al listar los requisitos tipo ficha"));
            }
        }

        [HttpPost]
        [Route("CreateRequisitosTipoFicha")]
        public async Task<ActionResult> CreateRequisitosTipoFicha(RequisitosTipoFichaDto requisitosTipoFicha)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }
                var resultSave = await _requisitosTipoFichaInterface.Create(requisitosTipoFicha);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al crear los requisitos tipo ficha"));
            }
        }

        [HttpGet]
        [Route("GetRequisitosTipoFicha")]
        public async Task<ActionResult> GetRequisitosTipoFicha(long IdRequisitoTipoFicha)
        {
            try
            {
                var result = await _requisitosTipoFichaInterface.Get(IdRequisitoTipoFicha);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al consultar los requisitos tipo ficha"));
            }
        }

        [HttpDelete]
        [Route("EliminarRequisitosTipoFicha")]
        public async Task<ActionResult> EliminarRequisitosTipoFicha(long IdRequisitoTipoFicha)
        {
            try
            {
                var resultDelete = await _requisitosTipoFichaInterface.Desactive(IdRequisitoTipoFicha);
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
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al eliminar los requisitos tipo ficha"));
            }
        }

        [HttpPut]
        [Route("ActualizarAsesorComercial")]
        public async Task<ActionResult> ActualizarAsesorComercial(RequisitosTipoFichaDto requisitosTipoFicha)
        {
            try
            {
                var resultSave = await _requisitosTipoFichaInterface.Edit(requisitosTipoFicha);
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
