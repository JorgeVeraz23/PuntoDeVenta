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
    public class TipoIncidenciaRepository : TipoIncidenciaInterface
    {
        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWorkRepository _unit;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private MessageInfoDTO infoDTO = new MessageInfoDTO();
        private readonly string _username;
        private readonly string _ip;


        public TipoIncidenciaRepository(
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
        public async Task<MessageInfoDTO> Create(TipoIncidenciaDto data)
        {
            var isAlreadyExist = await _context.TipoIncidencias.Where(x => x.Active && x.Nombre.ToUpper().Equals(data.Nombre.ToUpper())).AnyAsync();

            if (isAlreadyExist)
            {
                infoDTO.AccionFallida("Ya existe un Tipo de incidencia registrado con ese nombre", 400);
                return infoDTO;
            }

            TipoIncidencia tipoIncidencia = new TipoIncidencia();
            tipoIncidencia.Active = true;
            tipoIncidencia.Nombre = data.Nombre;

            tipoIncidencia.DateRegister = DateTime.Now;
            tipoIncidencia.UserRegister = _username;
            tipoIncidencia.IpRegister = _ip;

            await _context.TipoIncidencias.AddAsync(tipoIncidencia);
            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("Se ha creado el tipo de incidencia");
            return infoDTO;
        }

        public async Task<MessageInfoDTO> Desactive(long Id)
        {
            var tiposDeIncidenciasToDelete = await _context.TipoIncidencias.Where(x => x.Active && x.IdTipoIncidencia == Id).FirstOrDefaultAsync();
            if (tiposDeIncidenciasToDelete != null)
            {
                infoDTO.AccionFallida("El tipo de incidencia seleccionado no se encuentra disponible", 400);
            }
            tiposDeIncidenciasToDelete.DateDelete = DateTime.Now;
            tiposDeIncidenciasToDelete.Active = false;
            tiposDeIncidenciasToDelete.UserDelete = _username;
            tiposDeIncidenciasToDelete.IpDelete = _ip;

            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("El tipo de incidencia seleccionado a sido eliminado correctamente");

            return infoDTO;
        }

        public async Task<MessageInfoDTO> Edit(TipoIncidenciaDto data)
        {
            try
            {
                var model = await _context.TipoIncidencias.Where(x => x.Active && x.IdTipoIncidencia == data.IdTipoIncidencia).FirstOrDefaultAsync() ?? throw new Exception("No se encontro el tipo de incidencias");

                model.Nombre = data.Nombre;
                

                model.UserModification = _username;
                model.DateModification = DateTime.Now;
                model.IpModification = _ip;

                await _context.SaveChangesAsync();

                return infoDTO;
            }
            catch (Exception ex)
            {
                return infoDTO.ErrorInterno(ex, "TipoIncidenciaRepository", "Error al intentar actualizar el tipo de incidencia");
            }
        }

        public async Task<TipoIncidenciaDto> Get(long Id)
        {
            var tipoIncidenciaSelected = await _context.TipoIncidencias.Where(x => x.Active && x.IdTipoIncidencia == Id).Select(c => new TipoIncidenciaDto
            {
                IdTipoIncidencia = c.IdTipoIncidencia,
                Nombre = c.Nombre,
                
            }
                ).FirstOrDefaultAsync();
            return tipoIncidenciaSelected;
        }

        public async Task<List<TipoIncidenciaDto>> GetAll()
        {
            var tipoIncidencia = await _context.TipoIncidencias.Where(x => x.Active).Select(c => new TipoIncidenciaDto
            {
                IdTipoIncidencia = c.IdTipoIncidencia,
                Nombre = c.Nombre,
                
            }).ToListAsync();
            return tipoIncidencia;
        }

        public async Task<List<KeyValue>> KeyValues()
        {
            var tipoIncidenciaKeyValue = await _context.TipoIncidencias.Where(x => x.Active).Select(c => new KeyValue
            {
                Key = c.IdTipoIncidencia,
                Value = c.Nombre,

            }).ToListAsync();
            return tipoIncidenciaKeyValue;
        }
    }
}
