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
    public class MatrizRepository : MatrizInterface
    {
        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWorkRepository _unit;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private MessageInfoDTO infoDTO = new MessageInfoDTO();
        private readonly string _username;
        private readonly string _ip;


        public MatrizRepository(
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

        public async Task<MessageInfoDTO> Create(MatrizDto data)
        {
            

            Matriz matriz = new Matriz();
            matriz.Active = true;
            matriz.IdCasos = data.IdCasos;
            matriz.IdMotivos = data.IdMotivos;
            matriz.IdSubMotivo = data.IdSubMotivo;
            matriz.IdTipoFicha = data.IdTipoFicha;
            matriz.IdAreaReclamos = data.IdAreaReclamos;
            matriz.IdRequisitoFicha = data.IdRequisitoFicha;
            matriz.CodigoMotivo = data.CodigoMotivo;
            matriz.CodigoSubMotivo = data.CodigoSubMotivo;
            matriz.IdAccionesRequisitoFicha = data.IdAccionesRequisitoFicha;
            matriz.IdTipoReconocimiento = data.IdTipoReconocimiento;
            matriz.IdResponsableReclamo1 = data.IdResponsableReclamos;
            matriz.Plazo1 = data.Plazo1;
            matriz.Plazo2 = data.Plazo2;
            matriz.CODRCSAP = data.CODRCSAP;
            matriz.CausalSAP = data.CausalSAP;
            matriz.DateRegister = DateTime.Now;
            matriz.UserRegister = _username;
            matriz.IpRegister = _ip;

            await _context.Matrizs.AddAsync(matriz);
            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("Se ha creado la matriz");
            return infoDTO;
        }

        public async Task<MessageInfoDTO> Desactive(long Id)
        {
            var matrizToDelete = await _context.Matrizs.Where(x => x.Active && x.IdMatriz == Id).FirstOrDefaultAsync();
            if (matrizToDelete != null)
            {
                infoDTO.AccionFallida("La matriz seleccionada no se encuentra seleccionada", 400);
            }
            matrizToDelete.DateDelete = DateTime.Now;
            matrizToDelete.Active = false;
            matrizToDelete.UserDelete = _username;
            matrizToDelete.IpDelete = _ip;

            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("La matriz seleccionada a sido eliminada correctamente");

            return infoDTO;
        }

        public async Task<MessageInfoDTO> Edit(MatrizDto data)
        {
            try
            {
                var model = await _context.Matrizs.Where(x => x.Active && x.IdMatriz == data.IdMatriz).FirstOrDefaultAsync() ?? throw new Exception("No se encontro la matriz");

                ///*model*/.Nombre = data.Nombre;
                //model.IdMotivo = data.IdMotivo;
                model.IdCasos = data.IdCasos;
                model.IdMotivos = data.IdMotivos;
                model.IdSubMotivo = data.IdSubMotivo;
                model.IdTipoFicha = data.IdTipoFicha;
                model.IdAreaReclamos = data.IdAreaReclamos;
                model.IdRequisitoFicha = data.IdRequisitoFicha;
                model.IdAccionesRequisitoFicha = data.IdAccionesRequisitoFicha;
                model.IdTipoReconocimiento = data.IdTipoReconocimiento;
                model.IdResponsableReclamo1 = data.IdResponsableReclamos;
                model.CODRCSAP = data.CODRCSAP;
                model.CausalSAP = data.CausalSAP;
                model.CodigoSubMotivo = data.CodigoSubMotivo;
                model.CodigoMotivo = data.CodigoMotivo;
                model.Plazo1 = data.Plazo1;
                model.Plazo2 = data.Plazo2;
                

                model.UserModification = _username;
                model.DateModification = DateTime.Now;
                model.IpModification = _ip;

                await _context.SaveChangesAsync();

                return infoDTO;
            }
            catch (Exception ex)
            {
                return infoDTO.ErrorInterno(ex, "MatrizRepository", "Error al intentar actualizar la matriz");
            }
        }

        public async Task<MatrizDto> Get(long Id)
        {
            var matrizSelected = await _context.Matrizs.Where(x => x.Active && x.IdMatriz == Id).Select(c => new MatrizDto
            {
            IdMatriz = c.IdMatriz,
            IdCasos = c.IdCasos,
            IdMotivos = c.IdMotivos,
            IdSubMotivo = c.IdSubMotivo,
            IdTipoFicha = c.IdTipoFicha,
            IdAreaReclamos = c.IdAreaReclamos,
            IdRequisitoFicha = c.IdRequisitoFicha,
            IdAccionesRequisitoFicha = c.IdAccionesRequisitoFicha,
            IdTipoReconocimiento = c.IdTipoReconocimiento,
            CodigoMotivo = c.CodigoMotivo,
            CodigoSubMotivo = c.CodigoSubMotivo,
            Plazo1 = c.Plazo1,
            Plazo2 = c.Plazo2,
            IdResponsableReclamos = c.IdResponsableReclamo1,
            CODRCSAP = c.CODRCSAP,
            CausalSAP = c.CausalSAP,

        }
                ).FirstOrDefaultAsync();
            return matrizSelected;
        }

        public async Task<List<MostrarMatrizDto>> GetAll()
        {

            var matriz = await _context.Matrizs.Where(x => x.Active).Select(c => new MostrarMatrizDto
            {
                IdMatriz = c.IdMatriz,
                CasosNombre = c.Casos.Caso,
                MotivosNombre = c.Motivos.Nombre,
                SubMotivoNombre = c.SubMotivo.NombreSubMotivo,
                TipoFichaNombre = c.TipoFicha.Nombre,
                AreaReclamosNombre = c.AreasReclamos.AreaReclamo,
                Plazo1 = c.Plazo1,
                Plazo2 = c.Plazo2,
                CodigoMotivo = c.CodigoMotivo,
                CodigoSubMotivo = c.CodigoSubMotivo,
                RequisitoFichaNombre = c.RequisitosTipoFicha.Requisito,
                AccionesRequisitoFichaNombre = c.AccionesRequisitoFicha.NombreAccion,
                TipoReconocimientoNombre = c.TipoReconocimiento.NombreTipoReconocimiento,
                ResponsableReclamosNombre = c.ResponsableReclamo1.NombreResposable,
                CODRCSAP = c.CODRCSAP,
                CausalSAP = c.CausalSAP,

            }).ToListAsync();
            return matriz;
        }

        public  async Task<List<MostrarMatrizDto>> GetMatrizByFilter(long IdArea, long IdMotivo)
        {
            //var query = _ctx.Matrizs
            //    .Where(c => c.Activo);
            var query = _context.Matrizs.Where(c => c.Active);
            if(IdArea != null && IdArea != 0)
            {
                query = query.Where(c => c.IdAreaReclamos == IdArea);
            }
            else
            {
                query = _context.Matrizs.Where(x => x.Active);
            }
            if(IdMotivo != null && IdMotivo != 0)
            {
                query = query.Where(x => x.IdMotivos == IdMotivo);
            }
            var resultList = await query.Select(c => new MostrarMatrizDto
            {
                IdMatriz = c.IdMatriz,
                CasosNombre = c.Casos.Caso,
                MotivosNombre = c.Motivos.Nombre,
                SubMotivoNombre = c.SubMotivo.NombreSubMotivo,
                TipoFichaNombre = c.TipoFicha.Nombre,
                AreaReclamosNombre = c.AreasReclamos.AreaReclamo,
                Plazo1 = c.Plazo1,
                Plazo2 = c.Plazo2,
                CodigoMotivo = c.CodigoMotivo,
                CodigoSubMotivo = c.CodigoSubMotivo,
                RequisitoFichaNombre = c.RequisitosTipoFicha.Requisito,
                AccionesRequisitoFichaNombre = c.AccionesRequisitoFicha.NombreAccion,
                TipoReconocimientoNombre = c.TipoReconocimiento.NombreTipoReconocimiento,
                ResponsableReclamosNombre = c.ResponsableReclamo1.NombreResposable,
                CODRCSAP = c.CODRCSAP,
                CausalSAP = c.CausalSAP,
            }).ToListAsync() ?? [];

            return resultList;
        }

        public async Task<List<BuscarEnMatricesMotivosPorIdArea>> BuscarEnMatricesLosMotivosPorIdArea(long IdArea)
        {
            var busqueda = await _context.Matrizs.Where(x => x.Active && x.IdAreaReclamos == IdArea).Select(c => new BuscarEnMatricesMotivosPorIdArea
            {
                IdMotivo = c.Motivos.IdMotivo,
                MotivoNombre = c.Motivos.Nombre,
            }).ToListAsync();

            return busqueda;
        }
    }
}
