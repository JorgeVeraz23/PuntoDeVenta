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
    public class CategoriaCamaronController : ControllerBase
    {
        private readonly CategoriaCamaronInterface _categoriaCamaronInterface;
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _service;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ApplicationUserManager _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static Logger _log = LogManager.GetLogger("CategoriaCamaronController");
        MessageInfoDTO infoDTO = new MessageInfoDTO();
        public readonly string _usuario;
        private readonly string _ip;
        private readonly string _nombreController;

        public CategoriaCamaronController(CategoriaCamaronInterface categoriaCamaronInterface, ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor, ApplicationUserManager userManager, IServiceProvider service, IMapper mapper, IConfiguration configuration)
        {
            _categoriaCamaronInterface = categoriaCamaronInterface;
            this._context = applicationDbContext;
            _service = service;
            _mapper = mapper;
            _configuration = configuration;
            _nombreController = "CategoriaCamaronController";
            _httpContextAccessor = httpContextAccessor;
            _ip = _httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
            _usuario = Task.Run(async () =>
            (await userManager.FindByNameAsync(httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c =>
            c.Type.Contains("email", StringComparison.CurrentCultureIgnoreCase))?.Value ?? ""))?.UserName ?? "Desconocido").Result;
        }

        [HttpGet]
        [Route("GetAllCasos")]
        public async Task<ActionResult> GetAllCategorias()
        {
            try
            {
                var result = await _categoriaCamaronInterface.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al listar las categorias"));
            }
        }

        //[HttpGet]
        //[Route("KeyValue")]
        //public async Task<ActionResult> KeyValue()
        //{
        //    try
        //    {
        //        var result = await _categoriaCamaronInterface.KeyValues();
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al listar los casos"));
        //    }
        //}

        [HttpGet]
        [Route("GetCategoriaCamaron")]
        public async Task<ActionResult> GetCategoriaCamaron(long idCategoriaCamaron)
        {
            try
            {
                var result = await _categoriaCamaronInterface.Get(idCategoriaCamaron);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al consultar la categoria de camaron seleccionado"));
            }
        }

        [HttpPost]
        [Route("CreateCategoriaCamaron")]
        public async Task<ActionResult> CreateCategoriaCamaron(CategoriaCamaronDto categoriaCamaron)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }
                var resultSave = await _categoriaCamaronInterface.Create(categoriaCamaron);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al consultar casos"));
            }
        }

        [HttpDelete]
        [Route("EliminarCategoriaCamaron")]
        public async Task<ActionResult> EliminarCasos(long idCategoriaCamaron)
        {
            try
            {
                var resultDelete = await _categoriaCamaronInterface.Desactive(idCategoriaCamaron);
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
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al eliminar las categorias de camaron"));
            }
        }

        [HttpPut]
        [Route("ActualizarCategoriasCamaron")]
        public async Task<ActionResult> ActualizarCategoriasCamaron(CategoriaCamaronDto categoriaCamaron)
        {
            try
            {
                var resultSave = await _categoriaCamaronInterface.Edit(categoriaCamaron);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al actualizar la categoria de camaron"));
            }
        }
    }
}
