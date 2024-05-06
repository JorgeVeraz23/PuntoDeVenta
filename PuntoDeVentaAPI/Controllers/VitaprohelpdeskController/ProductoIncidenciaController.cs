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
    public class ProductoIncidenciaController : ControllerBase
    {
        private readonly ProductosIncidenciasInterface _productosIncidenciasInterface;
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _service;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ApplicationUserManager _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static Logger _log = LogManager.GetLogger("ProductoIncidenciaController");
        MessageInfoDTO infoDTO = new MessageInfoDTO();
        public readonly string _usuario;
        private readonly string _ip;
        private readonly string _nombreController;

        public ProductoIncidenciaController(ProductosIncidenciasInterface productosIncidenciasInterface, ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor, ApplicationUserManager userManager, IServiceProvider service, IMapper mapper, IConfiguration configuration)
        {
            _productosIncidenciasInterface = productosIncidenciasInterface;
            this._context = applicationDbContext;
            _service = service;
            _mapper = mapper;
            _configuration = configuration;
            _nombreController = "ProductoIncidenciaController";
            _httpContextAccessor = httpContextAccessor;
            _ip = _httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
            _usuario = Task.Run(async () =>
            (await userManager.FindByNameAsync(httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c =>
            c.Type.Contains("email", StringComparison.CurrentCultureIgnoreCase))?.Value ?? ""))?.UserName ?? "Desconocido").Result;
        }

        //[HttpGet]
        //[Route("GetAllProductosIncidencias")]
        //public async Task<ActionResult> GetAllProductosIncidencias()
        //{
        //    try
        //    {
        //        var result = await _productosIncidenciasInterface.GetAll();
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al listar las incidencias de los productos"));
        //    }
        //}

        [HttpPost]
        [Route("CreateProductoIncidencia")]
        public async Task<ActionResult> CreateProductoIncidencia(ProductosIncidenciasDto productoIncidencia)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }
                var resultSave = await _productosIncidenciasInterface.Create(productoIncidencia);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al consultar producto incidencia"));
            }
        }

        [HttpDelete]
        [Route("EliminarProductosIncidenciass")]
        public async Task<ActionResult> EliminarProductosIncidenciass(long IdProductosIncidencias)
        {
            try
            {
                var resultDelete = await _productosIncidenciasInterface.Desactive(IdProductosIncidencias);
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
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al eliminar el producto con incidencia"));
            }
        }

        [HttpGet]
        [Route("GetProductoIncidencia")]
        public async Task<ActionResult> GetProductoIncidencia(long IdProductoIncidencia)
        {
            try
            {
                var result = await _productosIncidenciasInterface.Get(IdProductoIncidencia);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Error al consultar el producto con incidencia"));
            }
        }

        [HttpPut]
        [Route("ActualizarProductosIncidencia")]
        public async Task<ActionResult> ActualizarProductosIncidencia(ProductosIncidenciasDto productosIncidencias)
        {
            try
            {
                var resultSave = await _productosIncidenciasInterface.Edit(productosIncidencias);
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
                return StatusCode((int)HttpStatusCode.BadRequest, new MessageInfoDTO().ErrorInterno(ex, _nombreController, "Errror al actualizar los productos con incidencias"));
            }
        }



    }
}
