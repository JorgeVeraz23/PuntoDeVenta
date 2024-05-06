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
    public class AsesorTecnicoController : ControllerBase
    {
        private readonly AsesorTecnicoInterface _asesorTecnicoInterface;
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _service;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ApplicationUserManager _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static Logger _log = LogManager.GetLogger("AsesorTecnicoController");
        MessageInfoDTO infoDTO = new MessageInfoDTO();
        public readonly string _usuario;
        private readonly string _ip;
        private readonly string _nombreController;

        public AsesorTecnicoController(AsesorTecnicoInterface asesorTecnicoInterface, ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor, ApplicationUserManager userManager, IServiceProvider service, IMapper mapper, IConfiguration configuration)
        {
            _asesorTecnicoInterface = asesorTecnicoInterface;
            this._context = applicationDbContext;
            _service = service;
            _mapper = mapper;
            _configuration = configuration;
            _nombreController = "AsesorTecnicoController";
            _httpContextAccessor = httpContextAccessor;
            _ip = _httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
            _usuario = Task.Run(async () =>
            (await userManager.FindByNameAsync(httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c =>
            c.Type.Contains("email", StringComparison.CurrentCultureIgnoreCase))?.Value ?? ""))?.UserName ?? "Desconocido").Result;
        }

        [HttpGet]
        [Route("GetAllAsesoresTecnicos")]
        public async Task<ActionResult> GetAllAsesoresTecnicos()
        {
            try
            {
                var result = await _asesorTecnicoInterface.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al listar los asesores tecnicos"));
            }
        }

        [HttpGet]
        [Route("KeyValueAsesor")]
        public async Task<ActionResult> KeyValueAsesor()
        {
            try
            {
                var result = await _asesorTecnicoInterface.KeyValues();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al listar los asesores tecnicos"));
            }
        }


        [HttpPost]
        [Route("CreateAsesoresTecnicos")]
        public async Task<ActionResult> CreateAsesoresTecnicos(AsesorTecnicoDto asesorTecnico)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }
                var resultSave = await _asesorTecnicoInterface.Create(asesorTecnico);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al crear los asesores tecnicos"));
            }
        }

        [HttpGet]
        [Route("GetAsesorTecnico")]
        public async Task<ActionResult> GetAsesorTecnico(long IdAsesorTecnico)
        {
            try
            {
                var result = await _asesorTecnicoInterface.Get(IdAsesorTecnico);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al consultar el asesor tecnico seleccionado"));
            }
        }

        [HttpDelete]
        [Route("EliminarAsesorTecnico")]
        public async Task<ActionResult> EliminarAsesorTecnico(long IdAsesorTecnico)
        {
            try
            {
                var resultDelete = await _asesorTecnicoInterface.Desactive(IdAsesorTecnico);
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
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al eliminar los asesores tecnicos"));
            }
        }

        [HttpPut]
        [Route("ActualizarAsesorTecnico")]
        public async Task<ActionResult> ActualizarAsesorTecnico(AsesorTecnicoDto asesorTecnico)
        {
            try
            {
                var resultSave = await _asesorTecnicoInterface.Edit(asesorTecnico);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al actualizar los asesores tecnicos"));
            }
        }
    }
}
