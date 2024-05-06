using Data;
using Data.Interfaces.SecurityInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;

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
    public class LogAccionesIncidenciaRepository : LogAccionesIncidenciasInterface
    {
        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWorkRepository _unit;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private MessageInfoDTO infoDTO = new MessageInfoDTO();
        private readonly string _username;
        private readonly string _ip;


        public LogAccionesIncidenciaRepository(
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
        public async Task<MessageInfoDTO> Create(LogAccionesIncidenciasDto data)
        {
            var isAlreadyExist = await _context.LogAccionesIncidencias.Where(x => x.Active && x.Acciones.ToUpper().Equals(data.Acciones.ToUpper())).AnyAsync();

            if (isAlreadyExist)
            {
                infoDTO.AccionFallida("Ya existe un log de acciones registrado con ese nombre", 400);
                return infoDTO;
            }

            LogAccionesIncidencia logAccionesIncidencia = new LogAccionesIncidencia();
            logAccionesIncidencia.Active = true;
            logAccionesIncidencia.Acciones = data.Acciones;
            logAccionesIncidencia.DescripcionAccion = data.DescripcionAccion;
            logAccionesIncidencia.IdArchivo = data.IdArchivo;
            logAccionesIncidencia.CorreoEnviado = data.CorreoEnviado;
            logAccionesIncidencia.CorreoEnvioLog = data.CorreoEnvioLog;
            logAccionesIncidencia.CorreoEnviado = data.CorreoEnviado;
            logAccionesIncidencia.FechaEnvioCorreo = data.FechaEnvioCorreo;
            logAccionesIncidencia.Observacion = data.Observacion;
            logAccionesIncidencia.CorreoDerivado = data.CorreoDerivado;


            logAccionesIncidencia.DateRegister = DateTime.Now;
            logAccionesIncidencia.UserRegister = _username;
            logAccionesIncidencia.IpRegister = _ip;

            await _context.LogAccionesIncidencias.AddAsync(logAccionesIncidencia);
            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("Se ha creado el log acciones incidencia");
            return infoDTO;
        }

        public async Task<MessageInfoDTO> Desactive(long Id)
        {
            var logAccionesToDelete = await _context.LogAccionesIncidencias.Where(x => x.Active && x.IdLogAccionesInciencia == Id).FirstOrDefaultAsync();
            if (logAccionesToDelete != null)
            {
                infoDTO.AccionFallida("El log acciones seleccionado no se encuentra disponible", 400);
            }
            logAccionesToDelete.DateDelete = DateTime.Now;
            logAccionesToDelete.Active = false;
            logAccionesToDelete.UserDelete = _username;
            logAccionesToDelete.IpDelete = _ip;

            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("El log acciones seleccionado a sido eliminado correctamente");

            return infoDTO;
        }

        public async Task<MessageInfoDTO> Edit(LogAccionesIncidenciasDto data)
        {
            try
            {
                var model = await _context.LogAccionesIncidencias.Where(x => x.Active && x.IdLogAccionesInciencia == data.IdLogAccionesInciencia).FirstOrDefaultAsync() ?? throw new Exception("No se encontro el log acciones");

                model.Acciones = data.Acciones;
                model.DescripcionAccion = data.DescripcionAccion;
                model.IdArchivo = data.IdArchivo;
                model.CorreoEnvioLog = data.CorreoEnvioLog;
                model.CorreoEnviado = data.CorreoEnviado;
                model.FechaEnvioCorreo = data.FechaEnvioCorreo;
                model.Observacion = data.Observacion;
                model.CorreoDerivado = data.CorreoDerivado;

                model.UserModification = _username;
                model.DateModification = DateTime.Now;
                model.IpModification = _ip;

                await _context.SaveChangesAsync();

                return infoDTO;
            }
            catch (Exception ex)
            {
                return infoDTO.ErrorInterno(ex, "LogAccionesIncidenciasRepository", "Error al intentar actualizar el log acciones incidencias");
            }
        }

        public async Task<LogAccionesIncidenciasDto> Get(long Id)
        {
            var logAccionesSelected = await _context.LogAccionesIncidencias.Where(x => x.Active && x.IdLogAccionesInciencia == Id).Select(c => new LogAccionesIncidenciasDto
            {
                IdLogAccionesInciencia = c.IdLogAccionesInciencia,
                IdIncidencia = c.IdIncidencia,
                Acciones = c.Acciones,
                DescripcionAccion = c.DescripcionAccion,
                IdArchivo = c.IdArchivo,
                CorreoEnvioLog = c.CorreoEnvioLog,
                CorreoEnviado = c.CorreoEnviado,
                FechaEnvioCorreo = c.FechaEnvioCorreo,
                Observacion = c.Observacion,
                CorreoDerivado = c.CorreoDerivado
                
            }
                ).FirstOrDefaultAsync();
            return logAccionesSelected;
        }

        public async Task<List<MostrarLogAccionesIncidenciasDto>> GetAll()
        {
            var logAccionesIncidencias = await _context.LogAccionesIncidencias.Where(x => x.Active).Select(c => new MostrarLogAccionesIncidenciasDto
            {
                IdLogAccionesInciencia = c.IdLogAccionesInciencia,
                IdIncidencia = c.IdIncidencia,
                Acciones = c.Acciones,
                DescripcionAccion = c.DescripcionAccion,
                IdArchivo = c.IdArchivo,
                NombreArchivo = c.Archivos.NombreOriginal,
                CorreoEnvioLog = c.CorreoEnvioLog,
                CorreoEnviado = c.CorreoEnviado,
                FechaEnvioCorreo = c.FechaEnvioCorreo,
                Observacion = c.Observacion,
                CorreoDerivado = c.CorreoDerivado
            }).ToListAsync();
            return logAccionesIncidencias;
        }
    }
}
