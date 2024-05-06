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
    public class SubMotivoRepository : SubMotivoInterfaces
    {
        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWorkRepository _unit;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private MessageInfoDTO infoDTO = new MessageInfoDTO();
        private readonly string _username;
        private readonly string _ip;


        public SubMotivoRepository(
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


        public async Task<MessageInfoDTO> Create(SubMotivoDto data)
        {
            var isAlreadyExist = await _context.SubMotivos.Where(x => x.Active && x.NombreSubMotivo.ToUpper().Equals(data.NombreSubMotivo.ToUpper())).AnyAsync();

            if (isAlreadyExist)
            {
                infoDTO.AccionFallida("Ya existe un submotivo registrado con ese nombre", 400);
                return infoDTO;
            }

            SubMotivo subMotivo = new SubMotivo();
            subMotivo.Active = true;
            subMotivo.NombreSubMotivo = data.NombreSubMotivo;
            subMotivo.CodigoSubMotivo = data.CodigoSubMotivo;
            subMotivo.IdMotivoss = data.IdMotivos;
            subMotivo.IdTipoReconocimiento = data.IdTipoReconocimiento;
            subMotivo.IdRequisitoTipoFicha = data.IdRequisitoTipoFicha;
            subMotivo.PlazoNivel1 = data.PlazoNivel1;
            subMotivo.PlazoNivel2 = data.PlazoNivel2;

            subMotivo.DateRegister = DateTime.Now;
            subMotivo.UserRegister = _username;
            subMotivo.IpRegister = _ip;

            await _context.SubMotivos.AddAsync(subMotivo);
            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("Se ha creado el SubMotivo");
            return infoDTO;
        }

        public async Task<MessageInfoDTO> Desactive(long Id)
        {
            var subMotivosToDelete = await _context.SubMotivos.Where(x => x.Active && x.IdSubMotivo == Id).FirstOrDefaultAsync();
            if (subMotivosToDelete != null)
            {
                infoDTO.AccionFallida("El subMotivo seleccionado no se encuentra disponible", 400);
            }
            subMotivosToDelete.DateDelete = DateTime.Now;
            subMotivosToDelete.Active = false;
            subMotivosToDelete.UserDelete = _username;
            subMotivosToDelete.IpDelete = _ip;

            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("El subMotivo seleccionado a sido eliminado correctamente");

            return infoDTO;
        }

        public async  Task<MessageInfoDTO> Edit(SubMotivoDto data)
        {
            try
            {
                var model = await _context.SubMotivos.Where(x => x.Active && x.IdSubMotivo == data.IdSubMotivo).FirstOrDefaultAsync() ?? throw new Exception("No se encontro el sub motivo");

                model.NombreSubMotivo = data.NombreSubMotivo;
                model.CodigoSubMotivo = data.CodigoSubMotivo;
                model.IdMotivoss = data.IdMotivos;
                model.IdTipoReconocimiento = data.IdTipoReconocimiento;
                model.IdRequisitoTipoFicha = data.IdRequisitoTipoFicha;
                model.PlazoNivel1 = data.PlazoNivel1;
                model.PlazoNivel2 = data.PlazoNivel2;


                model.UserModification = _username;
                model.DateModification = DateTime.Now;
                model.IpModification = _ip;

                await _context.SaveChangesAsync();

                return infoDTO;
            }
            catch (Exception ex)
            {
                return infoDTO.ErrorInterno(ex, "SubMotivoRepository", "Error al intentar actualizar el sub Motivo");
            }
        }

        public async Task<SubMotivoDto> Get(long Id)
        {
            var subMotivoSelected = await _context.SubMotivos.Where(x => x.Active && x.IdSubMotivo == Id).Select(c => new SubMotivoDto
            {
                IdSubMotivo = c.IdSubMotivo,
                CodigoSubMotivo = c.CodigoSubMotivo,
                IdMotivos = c.IdMotivoss,
                IdTipoReconocimiento = c.IdTipoReconocimiento,
                IdRequisitoTipoFicha = c.IdRequisitoTipoFicha,
                PlazoNivel1 = c.PlazoNivel1,
                PlazoNivel2 = c.PlazoNivel2
            }
                ).FirstOrDefaultAsync();
            return subMotivoSelected;
        }

        public async  Task<List<MostrarSubMotivoDto>> GetAll()
        {
            var subMotivo = await _context.SubMotivos.Where(x => x.Active).Select(c => new MostrarSubMotivoDto
            {
                IdSubMotivo = c.IdSubMotivo,
                NombreSubMotivo = c.NombreSubMotivo,
                RequisitoTipoFicha = c.RequisitosTipoFicha.Requisito,
                MotivoNombre = c.Motivo.Nombre,
                TipoReconocimientoNombre = c.TipoReconocimiento.NombreTipoReconocimiento,
                CodigoSubMotivo = c.CodigoSubMotivo,
                PlazoNivel1 = c.PlazoNivel1,
                PlazoNivel2 = c.PlazoNivel2

            }).ToListAsync();
            return subMotivo;
        }

        public async Task<List<KeyValue>> KeyValues()
        {
            var subMotivo = await _context.SubMotivos.Where(x => x.Active).Select(c => new KeyValue
            {
                Key = c.IdSubMotivo,
                Value = c.NombreSubMotivo,
            }).ToListAsync();
            return subMotivo;
        }
    }
}
