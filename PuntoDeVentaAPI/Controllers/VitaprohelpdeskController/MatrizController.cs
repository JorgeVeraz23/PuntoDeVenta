using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;

using NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface;
using NicoAssistRemake.Data;
using NLog;
using System.Net;
using PuntoDeVentaAPI.Services;
using Data;
using PuntoDeVentaData.Dto.UtilitiesDTO;

namespace NicoAssitRemake.Api.Controllers.VitaprohelpdeskController
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatrizController : ControllerBase
    {
        private readonly MatrizInterface _matrizInterface;
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _service;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ApplicationUserManager _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static Logger _log = LogManager.GetLogger("MatrizController");
        MessageInfoDTO infoDTO = new MessageInfoDTO();
        public readonly string _usuario;
        private readonly string _ip;
        private readonly string _nombreController;

        public MatrizController(MatrizInterface matrizInterface, ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor, ApplicationUserManager userManager, IServiceProvider service, IMapper mapper, IConfiguration configuration)
        {
            _matrizInterface = matrizInterface;
            this._context = applicationDbContext;
            _service = service;
            _mapper = mapper;
            _configuration = configuration;
            _nombreController = "MatrizController";
            _httpContextAccessor = httpContextAccessor;
            _ip = _httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
            _usuario = Task.Run(async () =>
            (await userManager.FindByNameAsync(httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c =>
            c.Type.Contains("email", StringComparison.CurrentCultureIgnoreCase))?.Value ?? ""))?.UserName ?? "Desconocido").Result;
        }

        [HttpGet]
        [Route("GetAllMatriz")]
        public async Task<ActionResult> GetAllMatriz()
        {
            try
            {
                var result = await _matrizInterface.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al listar la matriz"));
            }
        }

        [HttpGet]
        [Route("BuscarEnMatricesMotivosPorIdArea")]
        public async Task<ActionResult> BuscarEnMatricesMotivosPorIdArea(long IdArea)
        {
            try
            {
                var result = await _matrizInterface.BuscarEnMatricesLosMotivosPorIdArea(IdArea);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al buscar en las matrices los motivos por id area"));
            }
        }

        [HttpPost]
        [Route("CreateMatriz")]
        public async Task<ActionResult> CreateMatriz(MatrizDto matriz)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }
                var resultSave = await _matrizInterface.Create(matriz);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al crear la matriz"));
            }
        }

        [HttpGet]
        [Route("GetMatriz")]
        public async Task<ActionResult> GetMatriz(long IdMatriz)
        {
            try
            {
                var result = await _matrizInterface.Get(IdMatriz);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al consultar la matriz"));
            }
        }

        [HttpDelete]
        [Route("EliminarMatriz")]
        public async Task<ActionResult> EliminarMatriz(long IdMatriz)
        {
            try
            {
                var resultDelete = await _matrizInterface.Desactive(IdMatriz);
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
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al eliminar la matriz"));
            }
        }

        [HttpPut]
        [Route("ActualizarMatriz")]
        public async Task<ActionResult> ActualizarMatriz(MatrizDto matriz)
        {
            try
            {
                var resultSave = await _matrizInterface.Edit(matriz);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al actualizar la matriz"));
            }
        }

        [HttpGet]
        [Route("GetMatrizByFilter")]
        public async Task<ActionResult> GetMatrizByFilter(long IdArea, long IdMotivo)
        {
            try
            {
                var questionResponse = await _matrizInterface.GetMatrizByFilter(IdArea, IdMotivo);
                return Ok(questionResponse);
            }catch(Exception ex)
            {
                _log.Error(ex);
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, $"Error al filtrar la matriz. {ex.Message}"));
            }
        }
    }
}
