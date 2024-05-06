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
    public class GestorReclamoController : ControllerBase
    {
        private readonly GestorReclamoInterface _gestorReclamoInterface;
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _service;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ApplicationUserManager _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static Logger _log = LogManager.GetLogger("GestorReclamoController");
        MessageInfoDTO infoDTO = new MessageInfoDTO();
        public readonly string _usuario;
        private readonly string _ip;
        private readonly string _nombreController;

        public GestorReclamoController(GestorReclamoInterface gestorReclamoInterface, ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor, ApplicationUserManager userManager, IServiceProvider service, IMapper mapper, IConfiguration configuration)
        {
            _gestorReclamoInterface = gestorReclamoInterface;
            this._context = applicationDbContext;
            _service = service;
            _mapper = mapper;
            _configuration = configuration;
            _nombreController = "GestorReclamoController";
            _httpContextAccessor = httpContextAccessor;
            _ip = _httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
            _usuario = Task.Run(async () =>
            (await userManager.FindByNameAsync(httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c =>
            c.Type.Contains("email", StringComparison.CurrentCultureIgnoreCase))?.Value ?? ""))?.UserName ?? "Desconocido").Result;
        }

        [HttpGet]
        [Route("GetAllGestorReclamos")]
        public async Task<ActionResult> GetAllGestoresReclamos()
        {
            try
            {
                var result = await _gestorReclamoInterface.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al listar los territorios"));
            }
        }


        [HttpGet]
        [Route("KeyValues")]
        public async Task<ActionResult> KeyValues()
        {
            try
            {
                var result = await _gestorReclamoInterface.KeyValues();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al listar los territorios"));
            }
        }

        [HttpPost]
        [Route("CreateGestorReclamo")]
        public async Task<ActionResult> CreateGestorReclamo(GestorReclamoDto gestorReclamo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }
                var resultSave = await _gestorReclamoInterface.Create(gestorReclamo);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al crear gestor de reclamo"));
            }
        }

        [HttpGet]
        [Route("GetGestorReclamo")]
        public async Task<ActionResult> GetGestorReclamo(long IdGestorReclamo)
        {
            try
            {
                var result = await _gestorReclamoInterface.Get(IdGestorReclamo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al consultar el territorio seleccionado"));
            }
        }

        [HttpDelete]
        [Route("EliminarGestorReclamo")]
        public async Task<ActionResult> EliminarGestorReclamo(long IdGestorReclamo)
        {
            try
            {
                var resultDelete = await _gestorReclamoInterface.Desactive(IdGestorReclamo);
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
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al eliminar los gestores de reclamos"));
            }
        }

        [HttpPut]
        [Route("ActualizarGestores")]
        public async Task<ActionResult> updateGestoresReclamos(GestorReclamoDto gestorReclamo)
        {
            try
            {
                var resultSave = await _gestorReclamoInterface.Edit(gestorReclamo);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al actualizar los gestores de reclamos"));
            }
        }
    }
}
