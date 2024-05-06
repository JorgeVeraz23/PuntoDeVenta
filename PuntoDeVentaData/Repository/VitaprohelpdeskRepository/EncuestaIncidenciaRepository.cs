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
    public class EncuestaIncidenciaRepository : EncuestaIncidenciaInterface
    {
        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWorkRepository _unit;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private MessageInfoDTO infoDTO = new MessageInfoDTO();
        private readonly string _username;
        private readonly string _ip;


        public EncuestaIncidenciaRepository(
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


        public async Task<MessageInfoDTO> Create(EncuestaIncidenciaDto data)
        {
            

            EncuestaIncidencia encuestaIncidencia = new EncuestaIncidencia();
            encuestaIncidencia.Active = true;
            encuestaIncidencia.IdIncidencia = data.IdIncidencia;
            


            encuestaIncidencia.DateRegister = DateTime.Now;
            encuestaIncidencia.UserRegister = _username;
            encuestaIncidencia.IpRegister = _ip;

            await _context.EncuestaIncidencias.AddAsync(encuestaIncidencia);
            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("Se ha creado la encuesta de la incidencia");
            return infoDTO;
        }

        public async Task<MessageInfoDTO> Desactive(long Id)
        {
            var encuestaToDelete = await _context.EncuestaIncidencias.Where(x => x.Active && x.IdEncuesta == Id).FirstOrDefaultAsync();
            if (encuestaToDelete != null)
            {
                infoDTO.AccionFallida("La encuesta no se encuentra disponible", 400);
            }
            encuestaToDelete.DateDelete = DateTime.Now;
            encuestaToDelete.Active = false;
            encuestaToDelete.UserDelete = _username;
            encuestaToDelete.IpDelete = _ip;

            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("La encuesta seleccionada a sido seleccionado correctamente");

            return infoDTO;
        }

        public async Task<MessageInfoDTO> Edit(EncuestaIncidenciaDto data)
        {
            try
            {
                var model = await _context.EncuestaIncidencias.Where(x => x.Active && x.IdEncuesta == data.IdEncuesta).FirstOrDefaultAsync() ?? throw new Exception("No se encontro la incidencia");

                model.IdEncuesta = data.IdEncuesta;
                

                model.UserModification = _username;
                model.DateModification = DateTime.Now;
                model.IpModification = _ip;

                await _context.SaveChangesAsync();

                return infoDTO;
            }
            catch (Exception ex)
            {
                return infoDTO.ErrorInterno(ex, "EncuestaRepository", "Error al intentar actualizar la encuesta");
            }
        }

        public async Task<EncuestaIncidenciaDto> Get(long Id)
        {
            var encuestaSelected = await _context.EncuestaIncidencias.Where(x => x.Active && x.IdEncuesta == Id).Select(c => new EncuestaIncidenciaDto
            {
                IdIncidencia = c.IdIncidencia,
            }
             ).FirstOrDefaultAsync();
            return encuestaSelected;
        }

        public async Task<List<EncuestaIncidenciaDto>> GetAll()
        {
            var encuestaIncidencia = await _context.EncuestaIncidencias.Where(x => x.Active).Select(c => new EncuestaIncidenciaDto
            {
                IdIncidencia = c.IdIncidencia
            }).ToListAsync();
            return encuestaIncidencia;
        }
    }
}
