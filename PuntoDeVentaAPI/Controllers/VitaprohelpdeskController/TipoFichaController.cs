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
    public class TipoFichaController : ControllerBase
    {
        private readonly TipoFichaInterface _tipoFichaInterface;
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _service;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ApplicationUserManager _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static Logger _log = LogManager.GetLogger("AsesorComercialController");
        MessageInfoDTO infoDTO = new MessageInfoDTO();
        public readonly string _usuario;
        private readonly string _ip;
        private readonly string _nombreController;

        public TipoFichaController(TipoFichaInterface tipoFichaInterface, ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor, ApplicationUserManager userManager, IServiceProvider service, IMapper mapper, IConfiguration configuration)
        {
            _tipoFichaInterface = tipoFichaInterface;
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
        [Route("GetAllTipoFichas")]
        public async Task<ActionResult> GetAllTipoFichas()
        {
            try
            {
                var result = await _tipoFichaInterface.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al listar los tipos de fichas"));
            }
        }

        [HttpGet]
        [Route("KeyValues")]
        public async Task<ActionResult> KeyValues()
        {
            try
            {
                var result = await _tipoFichaInterface.KeyValues();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al listar los tipos de fichas"));
            }
        }


        [HttpPost]
        [Route("CreateTipoFichas")]
        public async Task<ActionResult> CreateTerritorio(TipoFichaDto tipoFichas)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }
                var resultSave = await _tipoFichaInterface.Create(tipoFichas);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al crear los tipos de fichas"));
            }
        }

        [HttpGet]
        [Route("GetTiposFichas")]
        public async Task<ActionResult> GetTiposFichas(long IdTipoFicha)
        {
            try
            {
                var result = await _tipoFichaInterface.Get(IdTipoFicha);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al consultar el tipo de ficha"));
            }
        }

        [HttpDelete]
        [Route("EliminarTipoDeFicha")]
        public async Task<ActionResult> EliminarTipoDeFicha(long IdTipoFicha)
        {
            try
            {
                var resultDelete = await _tipoFichaInterface.Desactive(IdTipoFicha);
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
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al eliminar el tipo de ficha"));
            }
        }

        [HttpPut]
        [Route("ActualizarTipoFicha")]
        public async Task<ActionResult> ActualizarTipoFicha(TipoFichaDto tipoFicha)
        {
            try
            {
                var resultSave = await _tipoFichaInterface.Edit(tipoFicha);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al actualizar el tipo de ficha"));
            }
        }
    }
}
