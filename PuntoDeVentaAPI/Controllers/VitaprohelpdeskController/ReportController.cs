using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface;
using NicoAssistRemake.Data;
using NLog;
using Amazon.S3;
using Data;
using LinkQuality.Api.Services;
using PuntoDeVentaAPI.Services;
using PuntoDeVentaData.Dto.UtilitiesDTO;

namespace NicoAssitRemake.Api.Controllers.VitaprohelpdeskController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly MatrizInterface _matrizInterface;
        
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _service;
        private readonly ReportsService _reportsService;
        private readonly FilesService _filesService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ApplicationUserManager _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static Logger _log = LogManager.GetLogger("ReportController");
        MessageInfoDTO infoDTO = new MessageInfoDTO();
        public readonly string _usuario;
        public readonly string _ip;
        private readonly string _nombreController;

        public ReportController(MatrizInterface matrizInterface, ApplicationDbContext context, IServiceProvider service, IMapper mapper, IConfiguration configuration, ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor, IAmazonS3 s3Client)
        {
            _matrizInterface = matrizInterface;
            _context = context;
            _service = service;
            _mapper = mapper;
            _configuration = configuration;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _ip = _httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
            _usuario = Task.Run(async () =>
            (await userManager.FindByNameAsync(httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c =>
            c.Type.Contains("email", StringComparison.CurrentCultureIgnoreCase))?.Value ?? ""))?.UserName ?? "Desconocido").Result;
            _nombreController = "ReportController";
            _reportsService = new ReportsService(_configuration, _context, _httpContextAccessor, _mapper, _userManager, _usuario, _ip);
            _filesService = new FilesService(_context, mapper, s3Client, configuration, userManager);
        }

        //[HttpGet("ObtenerExcelMatriz")]
        //public async Task<IActionResult> ObtenerExcelMatriz()
        //{
        //    try
        //    {
        //        var nameForm = $"Matrices.xlsx";
        //        var dataMatrices = await _matrizInterface.GetAll();
        //        var report = _reportsService.GenerarExcel(dataMatrices);
        //        return File(report.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", nameForm);

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
