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
    public class TipoFichaRepository : TipoFichaInterface
    {
        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWorkRepository _unit;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private MessageInfoDTO infoDTO = new MessageInfoDTO();
        private readonly string _username;
        private readonly string _ip;


        public TipoFichaRepository(
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
        public async Task<MessageInfoDTO> Create(TipoFichaDto data)
        {
            TipoFicha tipoFicha = new TipoFicha();
            tipoFicha.Active = true;
            tipoFicha.IdCaso = data.IdCaso;
            tipoFicha.Nombre = data.Nombre;
            tipoFicha.IdCaso = data.IdCaso;
            tipoFicha.DateRegister = DateTime.Now;
            tipoFicha.UserRegister = _username;
            tipoFicha.IpRegister = _ip;

            await _context.TipoFichas.AddAsync(tipoFicha);
            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("Se ha creado el tipo de ficha");
            return infoDTO;
        }

        public async Task<MessageInfoDTO> Desactive(long Id)
        {
            var tipoFichaToDelete = await _context.TipoFichas.Where(x => x.Active && x.IdTipoFicha == Id).FirstOrDefaultAsync();
            if (tipoFichaToDelete != null)
            {
                infoDTO.AccionFallida("El tipo de ficha seleccionado no se encuentra disponible", 400);
            }
            tipoFichaToDelete.DateDelete = DateTime.Now;
            tipoFichaToDelete.Active = false;
            tipoFichaToDelete.UserDelete = _username;
            tipoFichaToDelete.IpDelete = _ip;

            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("El tipo de ficha seleccionado a sido eliminado correctamente");

            return infoDTO;
        }

        public async Task<MessageInfoDTO> Edit(TipoFichaDto data)
        {
            try
            {
                var model = await _context.TipoFichas.Where(x => x.Active && x.IdTipoFicha == data.IdTipoFicha).FirstOrDefaultAsync() ?? throw new Exception("No se encontro el tipo de ficha");

                model.Nombre = data.Nombre;
                model.IdCaso = data.IdCaso;
                model.UserModification = _username;
                model.DateModification = DateTime.Now;
                model.IpModification = _ip;

                await _context.SaveChangesAsync();

                return infoDTO;
            }
            catch (Exception ex)
            {
                return infoDTO.ErrorInterno(ex, "TipoFichaRepository", "Error al intentar actualizar el tipo de ficha");
            }
        }

        public async Task<TipoFichaDto> Get(long Id)
        {
            var tipoFichaSelected = await _context.TipoFichas.Where(x => x.Active && x.IdTipoFicha == Id).Select(c => new TipoFichaDto
            {
                
                Nombre = c.Nombre,
                IdCaso = c.IdCaso,
                
            }
                ).FirstOrDefaultAsync();
            return tipoFichaSelected;
        }

        public async Task<List<MostrarTipoFichaDto>> GetAll()
        {
            var tipoFicha = await _context.TipoFichas.Where(x => x.Active).Select(c => new MostrarTipoFichaDto
            {
                IdTipoFicha = c.IdTipoFicha,
                Nombre = c.Nombre,
                Caso = c.Casos.Caso,
                
            }).ToListAsync();
            return tipoFicha;
        }

        public async Task<List<KeyValue>> KeyValues()
        {
            var tipoFichaKeyValue = await _context.TipoFichas.Where(x => x.Active).Select(c => new KeyValue
            {
                Key = c.IdTipoFicha,
                Value = c.Nombre,

            }).ToListAsync();
            return tipoFichaKeyValue;
        }
    }
}
