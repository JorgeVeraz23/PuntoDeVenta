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
    public class AsesorTecnicoRepository : AsesorTecnicoInterface
    {
        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWorkRepository _unit;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private MessageInfoDTO infoDTO = new MessageInfoDTO();
        private readonly string _username;
        private readonly string _ip;


        public AsesorTecnicoRepository(
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
        public async Task<MessageInfoDTO> Create(AsesorTecnicoDto data)
        {
            var isAlreadyExist = await _context.AsesorTecnicos.Where(x => x.Active && x.Nombre.ToUpper().Equals(data.Nombre.ToUpper())).AnyAsync();

            if (isAlreadyExist)
            {
                infoDTO.AccionFallida("Ya existe un Asesor registrado con ese nombre", 400);
                return infoDTO;
            }

            AsesorTecnico asesorTecnico = new AsesorTecnico();
            asesorTecnico.Active = true;
            asesorTecnico.Nombre = data.Nombre;
            asesorTecnico.Mail = data.Mail;
            asesorTecnico.Telefono = data.Telefono;
            asesorTecnico.IdTerritorio = data.IdTerritorio;
            asesorTecnico.DateRegister = DateTime.Now;
            asesorTecnico.UserRegister = _username;
            asesorTecnico.IpRegister = _ip;

            await _context.AsesorTecnicos.AddAsync(asesorTecnico);
            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("Se ha creado el asesor tecnico");
            return infoDTO;
        }

        public async Task<MessageInfoDTO> Desactive(long Id)
        {
            var asesoresToDelete = await _context.AsesorTecnicos.Where(x => x.Active && x.IdAsesorTecnico == Id).FirstOrDefaultAsync();
            if (asesoresToDelete != null)
            {
                infoDTO.AccionFallida("El asesor seleccionado no se encuentra disponible", 400);
            }
            asesoresToDelete.DateDelete = DateTime.Now;
            asesoresToDelete.Active = false;
            asesoresToDelete.UserDelete = _username;
            asesoresToDelete.IpDelete = _ip;

            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("El asesor seleccionado a sido eliminado correctamente");

            return infoDTO;
        }

        public async Task<MessageInfoDTO> Edit(AsesorTecnicoDto data)
        {
            try
            {
                var model = await _context.AsesorTecnicos.Where(x => x.Active && x.IdAsesorTecnico == data.IdAsesorTecnico).FirstOrDefaultAsync() ?? throw new Exception("No se encontro el asesor tecnico");

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
                return infoDTO.ErrorInterno(ex, "AsesorRepository", "Error al intentar actualizar el asesor tecnico");
            }
        }

        public async Task<AsesorTecnicoDto> Get(long Id)
        {
            var asesorTecnicoSelected = await _context.AsesorTecnicos.Where(x => x.Active && x.IdAsesorTecnico == Id).Select(c => new AsesorTecnicoDto
            {
                IdAsesorTecnico = c.IdAsesorTecnico,
                Nombre = c.Nombre,
                Telefono = c.Telefono,
                Mail = c.Mail,
                IdTerritorio = c.IdTerritorio,
            }
                ).FirstOrDefaultAsync();
            return asesorTecnicoSelected;
        }

        public async Task<List<MostrarAsesorTecnicoDto>> GetAll()
        {
            var asesorTecnico = await _context.AsesorTecnicos.Where(x => x.Active).Select(c => new MostrarAsesorTecnicoDto
            {
                IdAsesorTecnico = c.IdAsesorTecnico,
                Nombre = c.Nombre,
                Telefono = c.Telefono,
                Mail = c.Mail,
                Territorio = c.Territorio.Nombre,
            }).ToListAsync();
            return asesorTecnico;
        }

        public async Task<List<KeyValue>> KeyValues()
        {
            var asesorTecnicoKeyValue = await _context.AsesorTecnicos.Where(x => x.Active).Select(c => new KeyValue
            {
                Key = c.IdAsesorTecnico,
                Value = c.Nombre,
            }).ToListAsync();
            return asesorTecnicoKeyValue;
        }
    }
}
