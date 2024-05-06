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
    public class AreaReclamoController : ControllerBase
    {
        private readonly AreasReclamosInterface _areaReclamoInterface;
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _service;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ApplicationUserManager _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static Logger _log = LogManager.GetLogger("AreaReclamoController");
        MessageInfoDTO infoDTO = new MessageInfoDTO();
        public readonly string _usuario;
        private readonly string _ip;
        private readonly string _nombreController;

        public AreaReclamoController(AreasReclamosInterface areaReclamoInterface, ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor, ApplicationUserManager userManager, IServiceProvider service, IMapper mapper, IConfiguration configuration)
        {
            _areaReclamoInterface = areaReclamoInterface;
            this._context = applicationDbContext;
            _service = service;
            _mapper = mapper;
            _configuration = configuration;
            _nombreController = "AreaReclamoController";
            _httpContextAccessor = httpContextAccessor;
            _ip = _httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
            _usuario = Task.Run(async () =>
            (await userManager.FindByNameAsync(httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c =>
            c.Type.Contains("email", StringComparison.CurrentCultureIgnoreCase))?.Value ?? ""))?.UserName ?? "Desconocido").Result;
        }
        [HttpGet]
        [Route("GetAllAreaReclamos")]
        public async Task<ActionResult> GetAllAreaReclamos()
        {
            try
            {
                var result = await _areaReclamoInterface.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al listar las areas de reclamos"));
            }
        }

        [HttpGet]
        [Route("KeyValue")]
        public async Task<ActionResult> KeyValue()
        {
            try
            {
                var result = await _areaReclamoInterface.KeyValues();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al listar las areas de reclamos"));
            }
        }

        [HttpPost]
        [Route("CreateAreasReclamos")]
        public async Task<ActionResult> CreateAreasReclamos(AreasReclamosDto areasReclamos)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }
                var resultSave = await _areaReclamoInterface.Create(areasReclamos);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al crear las areas de reclamos"));
            }
        }

        [HttpGet]
        [Route("GetAreasReclamos")]
        public async Task<ActionResult> GetAreasReclamos(long IdAreasReclamos)
        {
            try
            {
                var result = await _areaReclamoInterface.Get(IdAreasReclamos);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al consultar el area de reclamos"));
            }
        }

        [HttpDelete]
        [Route("EliminarAreaReclamos")]
        public async Task<ActionResult> EliminarAreaReclamos(long IdAreaReclamos)
        {
            try
            {
                var resultDelete = await _areaReclamoInterface.Desactive(IdAreaReclamos);
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
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al eliminar las areas de reclamos"));
            }
        }

        [HttpPut]
        [Route("ActualizarAreasReclamos")]
        public async Task<ActionResult> ActualizarAreasReclamos(AreasReclamosDto areasReclamos)
        {
            try
            {
                var resultSave = await _areaReclamoInterface.Edit(areasReclamos);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al actualizar las areas de reclamos"));
            }
        }
    }
}
