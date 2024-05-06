using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface;
using NicoAssistRemake.Data;
using NLog;
using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;
using System.Net;
using DocumentFormat.OpenXml.Office2013.Excel;
using NicoAssistRemake.Data.Entities.Vitaprohelpdesk;
using Data;
using PuntoDeVentaAPI.Services;
using PuntoDeVentaData.Dto.UtilitiesDTO;

namespace NicoAssitRemake.Api.Controllers.VitaprohelpdeskController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerritorioController : ControllerBase
    {
        private readonly TerritorioInterface _territorioInterface;
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _service;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ApplicationUserManager _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static Logger _log = LogManager.GetLogger("TerritorioController");
        MessageInfoDTO infoDTO = new MessageInfoDTO();
        public readonly string _usuario;
        private readonly string _ip;
        private readonly string _nombreController;

        public TerritorioController(TerritorioInterface territorioInterface, ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor, ApplicationUserManager userManager, IServiceProvider service, IMapper mapper, IConfiguration configuration)
        {
            _territorioInterface = territorioInterface;
            this._context = applicationDbContext;
            _service = service;
            _mapper = mapper;
            _configuration = configuration;
            _nombreController = "TerritorioController";
            _httpContextAccessor = httpContextAccessor;
            _ip = _httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
            _usuario = Task.Run(async () =>
            (await userManager.FindByNameAsync(httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c =>
            c.Type.Contains("email", StringComparison.CurrentCultureIgnoreCase))?.Value ?? ""))?.UserName ?? "Desconocido").Result;
        }

        [HttpGet]
        [Route("GetAllTerritorios")]
        public async Task<ActionResult> GetAllCasos()
        {
            try
            {
                var result = await _territorioInterface.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al listar los territorios"));
            }
        }

        [HttpPost]
        [Route("CreateTerritorio")]
        public async Task<ActionResult> CreateTerritorio(TerritorioDto territorio)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }
                var resultSave = await _territorioInterface.Create(territorio);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al crear territorio"));
            }
        }

        [HttpGet]
        [Route("GetTerritorio")]
        public async Task<ActionResult> GetTerritorio(long idTerritorio)
        {
            try
            {
                var result = await _territorioInterface.Get(idTerritorio);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al consultar el territorio seleccionado"));
            }
        }

        [HttpGet]
        [Route("KeyValueTerritorio")]
        public async Task<ActionResult> KeyValueTerritorio()
        {
            try
            {
                var result = await _territorioInterface.GetKeyValue();
                return Ok(result);
            }catch(Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al consultar el territorio seleccionado"));

            }
        }

        [HttpDelete]
        [Route("EliminarTerritorio")]
        public async Task<ActionResult> EliminarTerritorio(long idTerritorio)
        {
            try
            {
                var resultDelete = await _territorioInterface.Desactive(idTerritorio);
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
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al eliminar los territorios"));
            }
        }

        [HttpPut]
        [Route("ActualizarTerritorio")]
        public async Task<ActionResult> updateTerritorio(TerritorioDto territorio)
        {
            try
            {
                var resultSave = await _territorioInterface.Edit(territorio);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al actualizar territorio"));
            }
        }

        


    }
}
