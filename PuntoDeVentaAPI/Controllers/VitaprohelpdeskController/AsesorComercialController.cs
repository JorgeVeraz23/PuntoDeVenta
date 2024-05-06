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
    public class AsesorComercialController : ControllerBase
    {
        private readonly AsesorComercialInterface _asesorComercialInterface;
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

        public AsesorComercialController(AsesorComercialInterface asesorComercialInterface, ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor, ApplicationUserManager userManager, IServiceProvider service, IMapper mapper, IConfiguration configuration)
        {
            _asesorComercialInterface = asesorComercialInterface;
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
        [Route("GetAllAsesoresComerciales")]
        public async Task<ActionResult> GetAllAsesoresComerciales()
        {
            try
            {
                var result = await _asesorComercialInterface.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al listar los asesores comerciales"));
            }
        }

        [HttpGet]
        [Route("KeyValue")]
        public async Task<ActionResult> KeyValue()
        {
            try
            {
                var result = await _asesorComercialInterface.KeyValues();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al listar los asesores comerciales"));
            }
        }

        [HttpPost]
        [Route("CreateAsesoresComerciales")]
        public async Task<ActionResult> CreateAsesoresComerciales(AsesorComercialDto asesorComercial)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }
                var resultSave = await _asesorComercialInterface.Create(asesorComercial);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al crear los asesores comerciales"));
            }
        }

        [HttpGet]
        [Route("GetAsesorComerciales")]
        public async Task<ActionResult> GetAsesorComerciales(long IdAsesorComercial)
        {
            try
            {
                var result = await _asesorComercialInterface.Get(IdAsesorComercial);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al consultar el asesor comercial seleccionado"));
            }
        }

        [HttpDelete]
        [Route("EliminarAsesorComercial")]
        public async Task<ActionResult> EliminarAsesorComercial(long IdAsesorComercial)
        {
            try
            {
                var resultDelete = await _asesorComercialInterface.Desactive(IdAsesorComercial);
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
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al eliminar los asesores comerciales"));
            }
        }

        [HttpPut]
        [Route("ActualizarAsesorComercial")]
        public async Task<ActionResult> ActualizarAsesorComercial(AsesorComercialDto asesorComercial)
        {
            try
            {
                var resultSave = await _asesorComercialInterface.Edit(asesorComercial);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al actualizar los asesores comerciales"));
            }
        }
    }
}
