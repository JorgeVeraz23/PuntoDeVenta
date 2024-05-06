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
    public class TerritorioRepository : TerritorioInterface
    {
        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWorkRepository _unit;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private MessageInfoDTO infoDTO = new MessageInfoDTO();
        private readonly string _username;
        private readonly string _ip;
        private readonly CancellationTokenSource cancellationTokenSource;
        public TerritorioRepository(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            IServiceProvider serviceProvider,
            IConfiguration configuration,
            IUnitOfWorkRepository unitOfWorkRepository,
            IHttpContextAccessor httpContextAccessor
        )
        {
            cancellationTokenSource = new CancellationTokenSource();
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

       
        public async Task<List<TerritorioDto>> GetAll()
        {
            var casos = await _context.Territorios.Where(x => x.Active).Select(c => new TerritorioDto
            {
                IdTerritorio = c.IdTerritorio,
                Nombre = c.Nombre,
                CodigoTerritorio = c.CodigoTerritorio
            }).ToListAsync();
            return casos;
        }
        public async Task<TerritorioDto> Get(long Id)
        {
            var territorioSelected = await _context.Territorios.Where(x => x.Active && x.IdTerritorio == Id).Select(x => new TerritorioDto
            {
                IdTerritorio = x.IdTerritorio,
                Nombre = x.Nombre,
                CodigoTerritorio = x.CodigoTerritorio
            }
            ).FirstOrDefaultAsync();
            return territorioSelected;
        }

        public async Task<List<KeyValue>> GetKeyValue()
        {
            var territorios1 = await _context.Territorios.Where(x => x.Active).Select(c => new KeyValue
            {
                Key = c.IdTerritorio,
                Value = c.Nombre
            }).ToListAsync();

            return territorios1;
        }


        public async Task<MessageInfoDTO> Desactive(long Id)
        {
            var territorioToDelete = await _context.Territorios.Where(x => x.Active && x.IdTerritorio == Id).FirstOrDefaultAsync();
            if (territorioToDelete != null)
            {
                infoDTO.AccionFallida("El territorio seleccionado no se encuentra disponible", 400);
            }
            territorioToDelete.DateDelete = DateTime.Now;
            territorioToDelete.Active = false;
            territorioToDelete.UserDelete = _username;
            territorioToDelete.IpDelete = _ip;

            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("El territorio seleccionado a sido eliminado correctamente");

            return infoDTO;

        }

        public async Task<MessageInfoDTO> Create(TerritorioDto data)
        {
            var isAlreadyExist = await _context.Territorios.Where(x => x.Active && x.Nombre.ToUpper().Equals(data.Nombre.ToUpper())).AnyAsync();

            if (isAlreadyExist)
            {
                infoDTO.AccionFallida("Ya existe un caso registrado con ese nombre", 400);
                return infoDTO;
            }

            Territorio territorio = new Territorio();
            territorio.Active = true;
            territorio.Nombre = data.Nombre;
            territorio.CodigoTerritorio = data.CodigoTerritorio;
            territorio.DateRegister = DateTime.Now;
            territorio.UserRegister = _username;
            territorio.IpRegister = _ip;

            await _context.Territorios.AddAsync(territorio);
            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("Se ha creado el territorio");
            return infoDTO;

        }

        public async Task<MessageInfoDTO> Edit(TerritorioDto data)
        {
            try
            {
                var model = await _context.Territorios.Where(x => x.Active && x.IdTerritorio == data.IdTerritorio).FirstOrDefaultAsync() ?? throw new Exception("No se encontro el terreno");

                model.Nombre = data.Nombre;
                model.CodigoTerritorio = data.CodigoTerritorio;

                model.UserModification = _username;
                model.DateModification = DateTime.Now;
                model.IpModification = _ip;

                await _context.SaveChangesAsync();

                return infoDTO;
            }
            catch (Exception ex)
            {
               return  infoDTO.ErrorInterno(ex, "TerritoriRepository", "Error al intentar actualizar el territorio");
            }
            
        }

        
    }
}
