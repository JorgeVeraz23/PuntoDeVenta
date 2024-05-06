using Data;
using Data.Interfaces.SecurityInterfaces;
using DinkToPdf;
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
    public class ResponsableReclamoRepository : ResponsableReclamoInterface
    {
        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWorkRepository _unit;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private MessageInfoDTO infoDTO = new MessageInfoDTO();
        private readonly string _username;
        private readonly string _ip;


        public ResponsableReclamoRepository(
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
        public async Task<MessageInfoDTO> Create(ResponsablesReclamosDto data)
        {

           

            ResponsableReclamo responsableReclamo = new ResponsableReclamo();
            responsableReclamo.Active = true;
            responsableReclamo.NombreResposable = data.NombreResposable;
            responsableReclamo.Correo = data.Correo;
            responsableReclamo.IdTerritorio = data.IdTerritorio;
            responsableReclamo.NivelReclamo = data.NivelReclamo;
            responsableReclamo.IdAreaReclamo = data.IdAreaReclamo;
            responsableReclamo.DateRegister = DateTime.Now;
            responsableReclamo.UserRegister = _username;
            responsableReclamo.IpRegister = _ip;

            await _context.ResponsableReclamos.AddAsync(responsableReclamo);
            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("Se ha creado el responsable del reclamo");
            return infoDTO;
        }

        public async Task<MessageInfoDTO> Desactive(long Id)
        {
            var responsableReclamoToDelete = await _context.ResponsableReclamos.Where(x => x.Active && x.IdResponsableReclamos == Id).FirstOrDefaultAsync();
            if (responsableReclamoToDelete != null)
            {
                infoDTO.AccionFallida("El gestor seleccionado no se encuentra disponible", 400);
            }
            responsableReclamoToDelete.DateDelete = DateTime.Now;
            responsableReclamoToDelete.Active = false;
            responsableReclamoToDelete.UserDelete = _username;
            responsableReclamoToDelete.IpDelete = _ip;

            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("El responsable del reclamo seleccionado a sido eliminado correctamente");

            return infoDTO;
        }

        public async Task<MessageInfoDTO> Edit(ResponsablesReclamosDto data)
        {
            try
            {
                var model = await _context.ResponsableReclamos.Where(x => x.Active && x.IdResponsableReclamos == data.IdResponsableReclamos).FirstOrDefaultAsync() ?? throw new Exception("No se encontro el responsable del reclamo");

                model.NombreResposable = data.NombreResposable;
                model.Correo = data.Correo;
                model.NivelReclamo = data.NivelReclamo;
                model.IdAreaReclamo = data.IdAreaReclamo;
                model.IdTerritorio = data.IdTerritorio;

                model.UserModification = _username;
                model.DateModification = DateTime.Now;
                model.IpModification = _ip;

                await _context.SaveChangesAsync();

                return infoDTO;
            }
            catch (Exception ex)
            {
                return infoDTO.ErrorInterno(ex, "ResponsbleReclamoRepository", "Error al intentar actualizar el reclamo");
            }
        }

        public async Task<ResponsablesReclamosDto> Get(long Id)
        {
            var responsableDeReclamoSelected = await _context.ResponsableReclamos.Where(x => x.Active && x.IdResponsableReclamos == Id).Select(c => new ResponsablesReclamosDto
            {
                IdResponsableReclamos = c.IdResponsableReclamos,
                NombreResposable = c.NombreResposable,
                Correo = c.Correo,
                NivelReclamo = c.NivelReclamo,
                IdAreaReclamo = c.IdAreaReclamo,
                IdTerritorio = c.IdTerritorio,
            }
                ).FirstOrDefaultAsync();
            return responsableDeReclamoSelected;
        }

        public async Task<List<MostrarResponsableReclamoDto>> GetAll()
        {
            var responsableReclamo = await _context.ResponsableReclamos.Where(x => x.Active).Select(c => new MostrarResponsableReclamoDto
            {
                IdResponsableReclamos = c.IdResponsableReclamos,
                IdAreaReclamos  = c.IdAreaReclamo,
                NombreResponsable = c.NombreResposable,
                Correo = c.Correo,
                AreaReclamo = c.AreasReclamos.AreaReclamo,
                Territorio = c.Territorio.Nombre,
                NivelReclamo = c.NivelReclamo,
            }).ToListAsync();
            return responsableReclamo;
        }

        public async Task<List<KeyValue>> KeyValues()
        {
            var responsableReclamoKeyValue = await _context.ResponsableReclamos.Where(x => x.Active).Select(c => new KeyValue
            {
                Key = c.IdResponsableReclamos,
                Value = c.NombreResposable,
                
            }).ToListAsync();
            return responsableReclamoKeyValue;
        }
    }
}
