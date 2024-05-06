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
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Repository.VitaprohelpdeskRepository
{
    public class CasosRepository : CasosInterface
    {

        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWorkRepository _unit;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private MessageInfoDTO infoDTO = new MessageInfoDTO();
        private readonly string _username;
        private readonly string _ip;

        public CasosRepository(
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


        public async Task<MessageInfoDTO> Create(CasosDto data)
        {
            var isAlreadyExist = await _context.Casos.Where(x => x.Active && x.Caso.ToUpper().Equals(data.Caso.ToUpper())).AnyAsync();

            if (isAlreadyExist)
            {
                infoDTO.AccionFallida("Ya existe un caso registrado con ese nombre", 400);
                return infoDTO;
            }

            Casos casos = new Casos();
            casos.Active = true;
            casos.Caso = data.Caso;
            casos.Motivo = data.Motivo;
            casos.SubMotivo = data.SubMotivo;
            
            casos.DateRegister = DateTime.Now;
            casos.UserRegister = _username;
            casos.IpRegister = _ip;

            await _context.Casos.AddAsync(casos);
            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("Se ha creado el caso");
            return infoDTO;
        }

        public async Task<MessageInfoDTO> Desactive(long IdCasos)
        {
            var casosToDelete = await _context.Casos.Where(x => x.Active && x.IdCasos == IdCasos).FirstOrDefaultAsync();
            if(casosToDelete != null)
            {
                infoDTO.AccionFallida("El caso seleccionado no se encuentra disponible", 400);
            }
            casosToDelete.DateDelete = DateTime.Now;
            casosToDelete.Active = false;
            casosToDelete.UserDelete = _username;
            casosToDelete.IpDelete = _ip;

            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("El caso seleccionado a sido seleccionado correctamente");

            return infoDTO;
        }

        public async Task<MessageInfoDTO> Edit(CasosDto data)
        {
            try
            {
                var model = await _context.Casos.Where(x => x.Active && x.IdCasos == data.IdCasos).FirstOrDefaultAsync() ?? throw new Exception("No se encontro el caso");

                model.Caso = data.Caso;
                model.Motivo = data.Motivo;
                model.SubMotivo = data.SubMotivo;
                

                model.UserModification = _username;
                model.DateModification = DateTime.Now;
                model.IpModification = _ip;

                await _context.SaveChangesAsync();

                return infoDTO;
            }
            catch (Exception ex)
            {
                return infoDTO.ErrorInterno(ex, "CasosRepository", "Error al intentar actualizar el caso");
            }

        }

        public async Task<List<CasosDto>> GetAll()
        {
            var casos = await _context.Casos.Where(x => x.Active).Select(c => new CasosDto
            {
                IdCasos = c.IdCasos,
                Caso = c.Caso,
                Motivo = c.Motivo,
                SubMotivo = c.SubMotivo,
                
            }).ToListAsync();
            return casos;
        }

        public async Task<List<KeyValue>> KeyValues()
        {
            var casos = await _context.Casos.Where(x => x.Active).Select(c => new KeyValue
            {
                Key = c.IdCasos,
                Value = c.Caso,
            }).ToListAsync();
            return casos;
        }


        public async Task<CasosDto> GetCasos(long IdCasos)
        {
            var casosSelected = await _context.Casos.Where(x => x.Active && x.IdCasos == IdCasos).Select(c => new CasosDto
            {
                IdCasos = c.IdCasos,
                Caso = c.Caso,
                Motivo = c.Motivo,
                SubMotivo = c.SubMotivo,
                
            }
            ).FirstOrDefaultAsync();
            return casosSelected;
        }




    }
}
