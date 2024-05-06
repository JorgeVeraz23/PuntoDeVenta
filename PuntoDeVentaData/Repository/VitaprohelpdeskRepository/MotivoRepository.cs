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

    public class MotivoRepository : MotivoInterface
    {
        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWorkRepository _unit;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private MessageInfoDTO infoDTO = new MessageInfoDTO();
        private readonly string _username;
        private readonly string _ip;


        public MotivoRepository(
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


        public async Task<MessageInfoDTO> Create(MotivoDto data)
        {
            var isAlreadyExist = await _context.Motivos.Where(x => x.Active && x.Nombre.ToUpper().Equals(data.Nombre.ToUpper())).AnyAsync();

            if (isAlreadyExist)
            {
                infoDTO.AccionFallida("Ya existe un Motivo registrado con ese nombre", 400);
                return infoDTO;
            }

            Motivo motivo = new Motivo();
            motivo.Active = true;
            motivo.Nombre = data.Nombre;
            motivo.IdCaso = data.IdCaso;
            motivo.DateRegister = DateTime.Now;
            motivo.UserRegister = _username;
            motivo.IpRegister = _ip;

            await _context.Motivos.AddAsync(motivo);
            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("Se ha creado el motivo");
            return infoDTO;
        }

        public async Task<MessageInfoDTO> Desactive(long Id)
        {
            var motivosToDelete = await _context.Motivos.Where(x => x.Active && x.IdMotivo == Id).FirstOrDefaultAsync();
            if (motivosToDelete != null)
            {
                infoDTO.AccionFallida("El motivo seleccionado no se encuentra disponible", 400);
            }
            motivosToDelete.DateDelete = DateTime.Now;
            motivosToDelete.Active = false;
            motivosToDelete.UserDelete = _username;
            motivosToDelete.IpDelete = _ip;

            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("El motivo seleccionado a sido eliminado correctamente");

            return infoDTO;
        }

        public async Task<MessageInfoDTO> Edit(MotivoDto data)
        {
            try
            {
                var model = await _context.Motivos.Where(x => x.Active && x.IdMotivo == data.IdMotivo).FirstOrDefaultAsync() ?? throw new Exception("No se encontro el motivo");

                model.Nombre = data.Nombre;
                model.IdMotivo = data.IdMotivo;

                model.UserModification = _username;
                model.DateModification = DateTime.Now;
                model.IpModification = _ip;

                await _context.SaveChangesAsync();

                return infoDTO;
            }
            catch (Exception ex)
            {
                return infoDTO.ErrorInterno(ex, "MotivoRepository", "Error al intentar actualizar el motivo");
            }
        }

        public async Task<MotivoDto> Get(long Id)
        {
            var motivoSelected = await _context.Motivos.Where(x => x.Active && x.IdMotivo == Id).Select(c => new MotivoDto
            {
                IdMotivo = c.IdMotivo,
                Nombre = c.Nombre,
                IdCaso = c.IdCaso,
                
            }
                ).FirstOrDefaultAsync();
            return motivoSelected;
        }

        public async Task<List<MostrarMotivoDto>> GetAll()
        {
            var motivos = await _context.Motivos.Where(x => x.Active).Select(c => new MostrarMotivoDto
            {
                IdMotivo = c.IdMotivo,
                Nombre = c.Nombre,
                Caso = c.Casos.Caso,
                
            }).ToListAsync();
            return motivos;
        }

        public async Task<List<KeyValue>> KeyValue()
        {
            var motivos = await _context.Motivos.Where(x => x.Active).Select(c => new KeyValue
            {
                Key = c.IdMotivo,
                Value = c.Nombre,
            }).ToListAsync();
            return motivos;
        }

        
    }
}
