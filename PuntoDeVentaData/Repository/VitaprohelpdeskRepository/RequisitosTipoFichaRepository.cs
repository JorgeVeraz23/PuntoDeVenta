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
    public class RequisitosTipoFichaRepository : RequisitosTipoFichaInterface
    {
        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWorkRepository _unit;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private MessageInfoDTO infoDTO = new MessageInfoDTO();
        private readonly string _username;
        private readonly string _ip;


        public RequisitosTipoFichaRepository(
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

        public async Task<MessageInfoDTO> Create(RequisitosTipoFichaDto data)
        {
            var isAlreadyExist = await _context.RequisitosTipoFichas.Where(x => x.Active && x.Requisito.ToUpper().Equals(data.Requisito.ToUpper())).AnyAsync();

            if (isAlreadyExist)
            {
                infoDTO.AccionFallida("Ya existe un requisito tipo ficha registrado con ese nombre", 400);
                return infoDTO;
            }

            RequisitosTipoFicha requisitosTipoFicha = new RequisitosTipoFicha();
            requisitosTipoFicha.Active = true;
            requisitosTipoFicha.Requisito = data.Requisito;
            requisitosTipoFicha.IdTipoFicha = data.IdTipoFicha;

            requisitosTipoFicha.DateRegister = DateTime.Now;
            requisitosTipoFicha.UserRegister = _username;
            requisitosTipoFicha.IpRegister = _ip;

            await _context.RequisitosTipoFichas.AddAsync(requisitosTipoFicha);
            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("Se ha creado el requisito tipo ficha");
            return infoDTO;
        }

        public async Task<MessageInfoDTO> Desactive(long Id)
        {
            var requisitosTipoFichaToDelete = await _context.RequisitosTipoFichas.Where(x => x.Active && x.IdRequisitoTipoFicha == Id).FirstOrDefaultAsync();
            if (requisitosTipoFichaToDelete != null)
            {
                infoDTO.AccionFallida("El asesor comercial seleccionado no se encuentra disponible", 400);
            }
            requisitosTipoFichaToDelete.DateDelete = DateTime.Now;
            requisitosTipoFichaToDelete.Active = false;
            requisitosTipoFichaToDelete.UserDelete = _username;
            requisitosTipoFichaToDelete.IpDelete = _ip;

            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("El tipo de ficha seleccionado a sido eliminado correctamente");

            return infoDTO;
        }

        public async Task<MessageInfoDTO> Edit(RequisitosTipoFichaDto data)
        {
            try
            {
                var model = await _context.RequisitosTipoFichas.Where(x => x.Active && x.IdRequisitoTipoFicha == data.IdRequisitoTipoFicha).FirstOrDefaultAsync() ?? throw new Exception("No se encontro el requisito tipo ficha");

                model.Requisito = data.Requisito;
                model.IdTipoFicha = data.IdTipoFicha;
                

                model.UserModification = _username;
                model.DateModification = DateTime.Now;
                model.IpModification = _ip;

                await _context.SaveChangesAsync();

                return infoDTO;
            }
            catch (Exception ex)
            {
                return infoDTO.ErrorInterno(ex, "RequisitoTipoFichaRepository", "Error al intentar actualizar el requisito tipo ficha");
            }
        }

        public async Task<RequisitosTipoFichaDto> Get(long Id)
        {
            var requisitoTipoFichaSelected = await _context.RequisitosTipoFichas.Where(x => x.Active && x.IdRequisitoTipoFicha == Id).Select(c => new RequisitosTipoFichaDto
            {
                IdRequisitoTipoFicha = c.IdRequisitoTipoFicha,
                Requisito = c.Requisito,
                IdTipoFicha = c.IdTipoFicha,
            }
                ).FirstOrDefaultAsync();
            return requisitoTipoFichaSelected;
        }

        public async Task<List<RequisitosTipoFichaDto>> GetAll()
        {
            var requisitoTipoFicha = await _context.RequisitosTipoFichas.Where(x => x.Active).Select(c => new RequisitosTipoFichaDto
            {
                IdRequisitoTipoFicha = c.IdRequisitoTipoFicha,
                Requisito = c.Requisito,
                IdTipoFicha = c.IdTipoFicha,
                
            }).ToListAsync();
            return requisitoTipoFicha;
        }

        public async Task<List<KeyValue>> KeyValues()
        {
            var requisitoTipoFichaKeyValue = await _context.RequisitosTipoFichas.Where(x => x.Active).Select(c => new KeyValue
            {
                Key = c.IdRequisitoTipoFicha,
                Value = c.Requisito,

            }).ToListAsync();
            return requisitoTipoFichaKeyValue;
        }
    }
}
