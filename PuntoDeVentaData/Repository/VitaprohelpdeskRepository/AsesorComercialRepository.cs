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

    public class AsesorComercialRepository : AsesorComercialInterface
    {
        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWorkRepository _unit;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private MessageInfoDTO infoDTO = new MessageInfoDTO();
        private readonly string _username;
        private readonly string _ip;


        public AsesorComercialRepository(
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

        public async Task<MessageInfoDTO> Create(AsesorComercialDto data)
        {
            var isAlreadyExist = await _context.AsesorComercials.Where(x => x.Active && x.Nombre.ToUpper().Equals(data.Nombre.ToUpper())).AnyAsync();

            if (isAlreadyExist)
            {
                infoDTO.AccionFallida("Ya existe un Asesor Comercial registrado con ese nombre", 400);
                return infoDTO;
            }

            AsesorComercial asesorComercial = new AsesorComercial();
            asesorComercial.Active = true;
            asesorComercial.Nombre = data.Nombre;
            asesorComercial.Mail = data.Mail;
            asesorComercial.Telefono = data.Telefono;
            asesorComercial.Codigo = data.Codigo;
            asesorComercial.IdTerritorio = data.IdTerritorio;
            asesorComercial.DateRegister = DateTime.Now;
            asesorComercial.UserRegister = _username;
            asesorComercial.IpRegister = _ip;

            await _context.AsesorComercials.AddAsync(asesorComercial);
            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("Se ha creado el asesor comercial");
            return infoDTO;
        }

        public async Task<MessageInfoDTO> Desactive(long Id)
        {
            var asesoresToDelete = await _context.AsesorComercials.Where(x => x.Active && x.IdAsesorComercial == Id).FirstOrDefaultAsync();
            if (asesoresToDelete != null)
            {
                infoDTO.AccionFallida("El asesor comercial seleccionado no se encuentra disponible", 400);
            }
            asesoresToDelete.DateDelete = DateTime.Now;
            asesoresToDelete.Active = false;
            asesoresToDelete.UserDelete = _username;
            asesoresToDelete.IpDelete = _ip;

            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("El asesor seleccionado a sido eliminado correctamente");

            return infoDTO;
        }

        public async Task<MessageInfoDTO> Edit(AsesorComercialDto data)
        {
            try
            {
                var model = await _context.AsesorComercials.Where(x => x.Active && x.IdAsesorComercial == data.IdAsesorComercial).FirstOrDefaultAsync() ?? throw new Exception("No se encontro el asesor comercial");

                model.Nombre = data.Nombre;
                model.Telefono = data.Telefono;
                model.Mail = data.Mail;
                model.IdTerritorio = data.IdTerritorio;
                model.Codigo = data.Codigo;

                model.UserModification = _username;
                model.DateModification = DateTime.Now;
                model.IpModification = _ip;

                await _context.SaveChangesAsync();

                return infoDTO;
            }
            catch (Exception ex)
            {
                return infoDTO.ErrorInterno(ex, "AsesorComercialRepository", "Error al intentar actualizar el asesor comercial");
            }
        }

        public async Task<AsesorComercialDto> Get(long Id)
        {
            var asesorComercialSelected = await _context.AsesorComercials.Where(x => x.Active && x.IdAsesorComercial == Id).Select(c => new AsesorComercialDto
            {
                IdAsesorComercial = c.IdAsesorComercial,
                Nombre = c.Nombre,
                Telefono = c.Telefono,
                Mail = c.Mail,
                IdTerritorio = c.IdTerritorio,
                Codigo = c.Codigo,
            }
                ).FirstOrDefaultAsync();
            return asesorComercialSelected;
        }

        public async Task<List<MostrarAsesorComercialDto>> GetAll()
        {
            var asesorComercial = await _context.AsesorComercials.Where(x => x.Active).Select(c => new MostrarAsesorComercialDto
            {
                IdAsesorComercial = c.IdAsesorComercial,
                Nombre = c.Nombre,
                Telefono = c.Telefono,
                Mail = c.Mail,
                Territorio = c.Territorio.Nombre,
                Codigo = c.Codigo,
            }).ToListAsync();
            return asesorComercial;
        }

        public async Task<List<KeyValue>> KeyValues()
        {
            var keyvalueasesor = await _context.AsesorComercials.Where(x => x.Active).Select(c => new KeyValue
            {
                Key = c.IdAsesorComercial,
                Value = c.Nombre
            }).ToListAsync();
            return keyvalueasesor;
        }
    }
}
