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
    public class GestorReclamoRepository : GestorReclamoInterface
    {
        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWorkRepository _unit;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private MessageInfoDTO infoDTO = new MessageInfoDTO();
        private readonly string _username;
        private readonly string _ip;


        public GestorReclamoRepository(
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

        public async Task<MessageInfoDTO> Create(GestorReclamoDto data)
        {
            var isAlreadyExist = await _context.GestorReclamos.Where(x => x.Active && x.Nombre.ToUpper().Equals(data.Nombre.ToUpper())).AnyAsync();

            if (isAlreadyExist)
            {
                infoDTO.AccionFallida("Ya existe un gestor registrado con ese nombre", 400);
                return infoDTO;
            }

            GestorReclamo gestorReclamo = new GestorReclamo();
            gestorReclamo.Active = true;
            gestorReclamo.Nombre = data.Nombre;
            gestorReclamo.Mail = data.Mail;
            gestorReclamo.Telefono = data.Telefono;
            gestorReclamo.IdTerritorio = data.IdTerritorio;
            gestorReclamo.DateRegister = DateTime.Now;
            gestorReclamo.UserRegister = _username;
            gestorReclamo.IpRegister = _ip;

            await _context.GestorReclamos.AddAsync(gestorReclamo);
            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("Se ha creado el gestor de reclamos");
            return infoDTO;
        }

        public async Task<MessageInfoDTO> Desactive(long Id)
        {
            
            var gestoresToDelete = await _context.GestorReclamos.Where(x => x.Active && x.IdGestorReclamo == Id).FirstOrDefaultAsync();
            if (gestoresToDelete != null)
            {
                infoDTO.AccionFallida("El gestor seleccionado no se encuentra disponible", 400);
            }
            gestoresToDelete.DateDelete = DateTime.Now;
            gestoresToDelete.Active = false;
            gestoresToDelete.UserDelete = _username;
            gestoresToDelete.IpDelete = _ip;

            await _unit.SaveChangesAsync();

        infoDTO.AccionCompletada("El gestor seleccionado a sido eliminado correctamente");

            return infoDTO;
        }

    public async Task<MessageInfoDTO> Edit(GestorReclamoDto data)
    {
            try
            {
                var model = await _context.GestorReclamos.Where(x => x.Active && x.IdGestorReclamo == data.IdGestorReclamo).FirstOrDefaultAsync() ?? throw new Exception("No se encontro el caso");

                model.Nombre = data.Nombre;
                model.Telefono = data.Telefono;
                model.Mail = data.Mail;
                model.IdTerritorio = data.IdTerritorio;

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

    public async Task<GestorReclamoDto> Get(long Id)
    {
            var gestorDeReclamoSelected = await _context.GestorReclamos.Where(x => x.Active && x.IdGestorReclamo == Id).Select(c => new GestorReclamoDto
            {
                IdGestorReclamo = c.IdGestorReclamo,
                Nombre = c.Nombre,
                Telefono = c.Telefono,
                Mail = c.Mail,
                IdTerritorio = c.IdTerritorio,
            }
                ).FirstOrDefaultAsync();
            return gestorDeReclamoSelected;
        }

    public async Task<List<MostrarGestorReclamoDto>> GetAll()
    {
        var gestorDeReclamo = await _context.GestorReclamos.Where(x => x.Active).Select(c => new MostrarGestorReclamoDto
        {
                IdGestorReclamo = c.IdGestorReclamo,
                Nombre = c.Nombre,
                Telefono = c.Telefono,
                Mail = c.Mail,
                Territorio = c.Territorio.Nombre,
            }).ToListAsync();
            return gestorDeReclamo;
    }

        public async Task<List<KeyValue>> KeyValues()
        {
            var gestorDeReclamoKeyValue = await _context.GestorReclamos.Where(x => x.Active).Select(c => new KeyValue
            {
                Key = c.IdGestorReclamo,
                Value = c.Nombre,
               
            }).ToListAsync();
            return gestorDeReclamoKeyValue;
        }

    }
}
