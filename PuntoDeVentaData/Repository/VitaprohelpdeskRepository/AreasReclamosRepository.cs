using Data;
using Data.Interfaces.SecurityInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;


using NicoAssistRemake.Data.Entities.Utilities;
using NicoAssistRemake.Data.Entities.Vitaprohelpdesk;

using NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface;
using PuntoDeVentaData.Dto.UtilitiesDTO;
using PuntoDeVentaData.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Repository.VitaprohelpdeskRepository
{
    public class AreasReclamosRepository : AreasReclamosInterface
    {
        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWorkRepository _unit;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private MessageInfoDTO infoDTO = new MessageInfoDTO();
        private readonly string _username;
        private readonly string _ip;


        public AreasReclamosRepository(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            IServiceProvider serviceProvider,
            IConfiguration configuration,
            IUnitOfWorkRepository unitOfWorkRepository,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _context = context;
            _serviceProvider = serviceProvider;
            _configuration = configuration;
            _unit = unitOfWorkRepository;

            _ip = httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
            _username = Task.Run(async () =>
            (
                await userManager.FindByNameAsync(
                    httpContextAccessor?.HttpContext?.User.Claims.FirstOrDefault(c => c.Type.Contains("email", StringComparison.CurrentCultureIgnoreCase))?.Value ?? ""
                )
            )?.UserName ?? "Desconocido").Result;
        }

        public async Task<MessageInfoDTO> Create(AreasReclamosDto data)
        {
            var isAlreadyExist = await _context.AreasReclamos.Where(x => x.Active && x.AreaReclamo.ToUpper().Equals(data.NombreAreaReclamo.ToUpper())).AnyAsync();

            if (isAlreadyExist)
            {
                infoDTO.AccionFallida("Ya existe un Area de reclamos registrado con ese nombre", 400);
                return infoDTO;
            }

            AreasReclamos areasReclamos = new AreasReclamos();
            areasReclamos.Active = true;
            areasReclamos.AreaReclamo = data.NombreAreaReclamo;

            areasReclamos.DateRegister = DateTime.Now;
            areasReclamos.UserRegister = _username;
            areasReclamos.IpRegister = _ip;

            await _context.AreasReclamos.AddAsync(areasReclamos);
            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("Se ha creado el area de reclamos");
            return infoDTO;
        }

        public async Task<MessageInfoDTO> Desactive(long Id)
        {
            var areasToDelete = await _context.AreasReclamos.Where(x => x.Active && x.IdAreaReclamos == Id).FirstOrDefaultAsync();
            if (areasToDelete != null)
            {
                infoDTO.AccionFallida("El area de  reclamos seleccionado no se encuentra disponible", 400);
            }
            areasToDelete.DateDelete = DateTime.Now;
            areasToDelete.Active = false;
            areasToDelete.UserDelete = _username;
            areasToDelete.IpDelete = _ip;

            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("El area seleccionada a sido eliminado correctamente");

            return infoDTO;
        }

        public async Task<MessageInfoDTO> Edit(AreasReclamosDto data)
        {
            try
            {
                var model = await _context.AreasReclamos.Where(x => x.Active && x.IdAreaReclamos == data.IdAreaReclamos).FirstOrDefaultAsync() ?? throw new Exception("No se encontro el area de reclamos");

                model.AreaReclamo = data.NombreAreaReclamo;
                

                model.UserModification = _username;
                model.DateModification = DateTime.Now;
                model.IpModification = _ip;

                await _context.SaveChangesAsync();

                return infoDTO;
            }
            catch (Exception ex)
            {
                return infoDTO.ErrorInterno(ex, "AreaReclamosRepository", "Error al intentar actualizar el area reclamo");
            }
        }

        public async Task<AreasReclamosDto> Get(long Id)
        {
            var asesorReclamoSelected = await _context.AreasReclamos.Where(x => x.Active && x.IdAreaReclamos == Id).Select(c => new AreasReclamosDto
            {
                IdAreaReclamos = c.IdAreaReclamos,
                NombreAreaReclamo = c.AreaReclamo,
                
            }
                ).FirstOrDefaultAsync();
            return asesorReclamoSelected;
        }

        public async Task<List<AreasReclamosDto>> GetAll()
        {
            var areaReclamo = await _context.AreasReclamos.Where(x => x.Active).Select(c => new AreasReclamosDto
            {
                IdAreaReclamos = c.IdAreaReclamos,
                NombreAreaReclamo = c.AreaReclamo,
                
            }).ToListAsync();
            return areaReclamo;
        }

        public async Task<List<KeyValue>> KeyValues()
        {
            var areaReclamoKeyValue = await _context.AreasReclamos.Where(x => x.Active).Select(c => new KeyValue
            {
                Key = c.IdAreaReclamos,
                Value = c.AreaReclamo,

            }).ToListAsync();
            return areaReclamoKeyValue;
        }
    }
}
