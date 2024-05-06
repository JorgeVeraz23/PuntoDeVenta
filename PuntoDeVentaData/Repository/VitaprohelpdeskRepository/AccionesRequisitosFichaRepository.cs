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
    public class AccionesRequisitosFichaRepository : AccionesRequisitosFichaInterface
    {
        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWorkRepository _unit;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private MessageInfoDTO infoDTO = new MessageInfoDTO();
        private readonly string _username;
        private readonly string _ip;


        public AccionesRequisitosFichaRepository(
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

        public async Task<MessageInfoDTO> Create(AccionesRequisitoFichaDto data)
        {
            var isAlreadyExist = await _context.AccionesRequisitoFichas.Where(x => x.Active && x.NombreAccion.ToUpper().Equals(data.NombreAccion.ToUpper())).AnyAsync();

            if (isAlreadyExist)
            {
                infoDTO.AccionFallida("Ya existe una accion registrada con ese nombre", 400);
                return infoDTO;
            }

            AccionesRequisitoFicha accionesRequisitoFicha = new AccionesRequisitoFicha();
            accionesRequisitoFicha.Active = true;
            accionesRequisitoFicha.NombreAccion = data.NombreAccion;
            accionesRequisitoFicha.IdRequisitoTipoFicha = data.IdRequisitoTipoFicha;
            accionesRequisitoFicha.IdAreaReclamo = data.IdAreaReclamo;


            accionesRequisitoFicha.DateRegister = DateTime.Now;
            accionesRequisitoFicha.UserRegister = _username;
            accionesRequisitoFicha.IpRegister = _ip;

            await _context.AccionesRequisitoFichas.AddAsync(accionesRequisitoFicha);
            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("Se ha creado la accion");
            return infoDTO;
        }

        public async Task<MessageInfoDTO> Desactive(long Id)
        {
            var accionesToDelete = await _context.AccionesRequisitoFichas.Where(x => x.Active && x.IdAccionRequisitosFicha == Id).FirstOrDefaultAsync();
            if (accionesToDelete != null)
            {
                infoDTO.AccionFallida("La accion seleccionada no se encuentra disponible", 400);
            }
            accionesToDelete.DateDelete = DateTime.Now;
            accionesToDelete.Active = false;
            accionesToDelete.UserDelete = _username;
            accionesToDelete.IpDelete = _ip;

            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("La accion seleccionada a sido eliminada correctamente");

            return infoDTO;
        }

        public async Task<MessageInfoDTO> Edit(AccionesRequisitoFichaDto data)
        {
            try
            {
                var model = await _context.AccionesRequisitoFichas.Where(x => x.Active && x.IdAccionRequisitosFicha == data.IdAccionRequisitosFicha).FirstOrDefaultAsync() ?? throw new Exception("No se encontro la accion");

                model.NombreAccion = data.NombreAccion;
                model.IdRequisitoTipoFicha = data.IdRequisitoTipoFicha;
                model.IdAreaReclamo = data.IdAreaReclamo;
                

                model.UserModification = _username;
                model.DateModification = DateTime.Now;
                model.IpModification = _ip;

                await _context.SaveChangesAsync();

                return infoDTO;
            }
            catch (Exception ex)
            {
                return infoDTO.ErrorInterno(ex, "AccionesRepository", "Error al intentar actualizar la accion del requisito tipo ficha");
            }
        }

        public async Task<AccionesRequisitoFichaDto> Get(long Id)
        {
            var accioesRequisitosFichaSelected = await _context.AccionesRequisitoFichas.Where(x => x.Active && x.IdAccionRequisitosFicha == Id).Select(c => new AccionesRequisitoFichaDto
            {
                IdAccionRequisitosFicha = c.IdAccionRequisitosFicha,
                NombreAccion = c.NombreAccion,
                IdRequisitoTipoFicha = c.IdRequisitoTipoFicha,
                IdAreaReclamo = c.IdAreaReclamo,

                
            }
            ).FirstOrDefaultAsync();
            return accioesRequisitosFichaSelected;
        }

        public async Task<List<MostrarAccionesRequisitoFichaDto>> GetAll()
        {
            var accionesRequisitoFicha = await _context.AccionesRequisitoFichas.Where(x => x.Active).Select(c => new MostrarAccionesRequisitoFichaDto
            {
                IdAccionesRequisitoFicha = c.IdAccionRequisitosFicha,
                NombreAccion = c.NombreAccion,
                NombreRequisitoTipoFicha = c.RequisitosTipoFicha.Requisito,
                NombreAreaReclamo = c.AreasReclamos.AreaReclamo,
                
            }).ToListAsync();
            return accionesRequisitoFicha;
        }

        public async Task<List<KeyValue>> KeyValues()
        {
            var accionesRequisitoFichaKeyValue = await _context.AccionesRequisitoFichas.Where(x => x.Active).Select(c => new KeyValue
            {
                Key = c.IdAccionRequisitosFicha,
                Value = c.NombreAccion,

            }).ToListAsync();
            return accionesRequisitoFichaKeyValue;
        }
    }
}
