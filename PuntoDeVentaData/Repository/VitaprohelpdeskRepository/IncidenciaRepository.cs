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
    public class IncidenciaRepository : IncidenciaInterface
    {
        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWorkRepository _unit;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private MessageInfoDTO infoDTO = new MessageInfoDTO();
        private readonly string _username;
        private readonly string _ip;


        public IncidenciaRepository(
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
        public async Task<MessageInfoDTO> Create(IncideniaDto data)
        {
            

            Incidencias incidencias = new Incidencias();
            incidencias.Active = true;
            incidencias.IdCaso = data.IdCaso;
            incidencias.IdTipoIncidencias = data.IdTipoIncidencias;
            incidencias.IdAsesorComercial = data.IdAsesorComercial;
            incidencias.IdAsesorTecnico = data.IdAsesorTecnico;
            incidencias.IdTerritorio = data.IdTerritorio;
            incidencias.FechaReporteIncidencia = data.FechaReporteIncidencia;
            incidencias.FechaFicha = data.FechaFicha;
            incidencias.ReceptorIncidencia = data.ReceptorIncidencia;
            incidencias.IdGestorReclamo = data.IdGestorReclamo;
            incidencias.CambioProducto = data.CambioProducto;
            incidencias.DevolucionProducto = data.DevolucionProducto;
            incidencias.Compensacion = data.Compensacion;
            incidencias.Otros = data.Otros;
            incidencias.IdSolicitante = data.IdSolicitante;
            
           

           
            incidencias.DateRegister = DateTime.Now;
            incidencias.UserRegister = _username;
            incidencias.IpRegister = _ip;

            await _context.Incidencias.AddAsync(incidencias);
            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("Se ha creado la incidencia");
            return infoDTO;
        }

        public async Task<MessageInfoDTO> Desactive(long Id)
        {
            var incidenciaToDelete = await _context.Incidencias.Where(x => x.Active && x.IdIncidencias == Id).FirstOrDefaultAsync();
            if (incidenciaToDelete != null)
            {
                infoDTO.AccionFallida("La incidencia seleccionado no se encuentra disponible", 400);
            }
            incidenciaToDelete.DateDelete = DateTime.Now;
            incidenciaToDelete.Active = false;
            incidenciaToDelete.UserDelete = _username;
            incidenciaToDelete.IpDelete = _ip;

            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("La incidencia seleccionada a sido eliminado correctamente");

            return infoDTO;
        }

        public async Task<MessageInfoDTO> Edit(IncideniaDto data)
        {
            try
            {
                var model = await _context.Incidencias.Where(x => x.Active && x.IdIncidencias == data.IdAsesorTecnico).FirstOrDefaultAsync() ?? throw new Exception("No se encontro la incidencia");

                

                model.IdCaso = data.IdCaso;
                model.IdTipoIncidencias = data.IdTipoIncidencias;
                model.IdAsesorComercial = data.IdAsesorComercial;
                model.IdAsesorTecnico = data.IdAsesorTecnico;
                model.IdTerritorio = data.IdTerritorio;
                model.FechaReporteIncidencia = data.FechaReporteIncidencia;
                model.FechaFicha = data.FechaFicha;
                model.ReceptorIncidencia = data.ReceptorIncidencia;
                model.IdGestorReclamo = data.IdGestorReclamo;
                model.CambioProducto = data.CambioProducto;
                model.DevolucionProducto = data.DevolucionProducto;
                model.Compensacion = data.Compensacion;
                model.Otros = data.Compensacion;
                model.IdSolicitante = data.IdSolicitante;


                model.UserModification = _username;
                model.DateModification = DateTime.Now;
                model.IpModification = _ip;

                await _context.SaveChangesAsync();

                return infoDTO;
            }
            catch (Exception ex)
            {
                return infoDTO.ErrorInterno(ex, "IncidenciaRepository", "Error al intentar actualizar la incidencia");
            }
        }

        public async Task<IncideniaDto> Get(long Id)
        {
            var incidenciaSelected = await _context.Incidencias.Where(x => x.Active && x.IdIncidencias == Id).Select(c => new IncideniaDto
            {
                IdIncidencias = c.IdIncidencias,
                IdTipoIncidencias = c.IdTipoIncidencias,
                IdAsesorComercial = c.IdAsesorComercial,
                IdAsesorTecnico = c.IdAsesorTecnico,
                IdTerritorio = c.IdTerritorio,
                FechaReporteIncidencia = c.FechaReporteIncidencia,
                FechaFicha = c.FechaFicha,
                ReceptorIncidencia = c.ReceptorIncidencia,
                IdGestorReclamo = c.IdGestorReclamo,
                CambioProducto = c.CambioProducto,
                DevolucionProducto = c.DevolucionProducto,
                Compensacion = c.Compensacion,
                Otros = c.Otros,
                IdSolicitante = c.IdSolicitante,

            }
               ).FirstOrDefaultAsync();
            return incidenciaSelected;
        }

        public async Task<List<MostrarIncidenciaDto>> GetAll()
        {
            var incidenciaGetAll = await _context.Incidencias.Where(x => x.Active).Select(c => new MostrarIncidenciaDto
            {
               IdIncidencias = c.IdIncidencias,
               CodigoIncidencia = c.CodigoFicha,
               TipoIncidencia = c.TipoIncidencia.Nombre,
               FechaFicha = c.FechaFicha,
               Motivo = c.Motivo.Nombre,
               Submovito = c.SubMotivo.NombreSubMotivo,
               AreaResponsable = c.AreaReclamos.AreaReclamo,
               PlazoEvaluacion = c.PlazoTotal,
               FechaRealCierreAnalisis = c.FechaAnalisisConcluido,
               FechaCierreEfectivo = c.FechaCierreEfectivo,
               EstadoIncidencia = c.EstadosIncidencias.NombreEstado,
               TerritorioNombre = c.Territorio.Nombre,
               CodigoSap = c.CodigoSAP,
               

            }).ToListAsync();
            return incidenciaGetAll;
        }

        //public async Task<List<IncideniaDto>> ListaMatrizSeguimientoIncidencia()
        //{

        //    var diasPlazo1 = Convert.ToDecimal(Inc.SubMotivo.PlazoNivel1);
        //    var diasPlazo2 = Convert.ToDecimal(Inc.SubMotivo.PlazoNivel2);
        //    var diasTotales = Convert.ToInt32(diasPlazo1 + diasPlazo2);
        //    var numero = Inc.CodigoFicha.Substring(2);
        //    var numeroEC = numero.PadLeft(8, '0').Substring(0, 6);

        //}

        public async Task<List<MostrarIncidenciaDto>> GetIncidenciaByFilter(DateTime FechaReporteIncidencia, DateTime FechaCierreEfectivo, long IdGestorReclamo, long IdTerritorio)
        {
            var query = _context.Incidencias.Where(c => c.Active);
            if(FechaReporteIncidencia != null)
            {
                query = query.Where(c => c.FechaReporteIncidencia == FechaReporteIncidencia);
            }
            else
            {
                query = _context.Incidencias.Where(x => x.Active);
            }
            if(FechaCierreEfectivo != null)
            {
                query = query.Where(c => c.FechaCierreEfectivo == FechaCierreEfectivo);
            }
            if(IdGestorReclamo != null)
            {
                query = query.Where(c => c.IdGestorReclamo == IdGestorReclamo);
            }
            if(IdTerritorio != null)
            {
                query = query.Where(c => c.IdTerritorio == IdTerritorio);
            }
            var resultList = await query.Select(c => new MostrarIncidenciaDto
            {
                IdIncidencias = c.IdIncidencias,
               CodigoIncidencia = c.CodigoFicha,
               TipoIncidencia = c.TipoIncidencia.Nombre,
               FechaFicha = c.FechaFicha,
               Motivo = c.Motivo.Nombre,
               Submovito = c.SubMotivo.NombreSubMotivo,
               AreaResponsable = c.AreaReclamos.AreaReclamo,
               PlazoEvaluacion = c.PlazoTotal,
               FechaRealCierreAnalisis = c.FechaAnalisisConcluido,
               FechaCierreEfectivo = c.FechaCierreEfectivo,
               EstadoIncidencia = c.EstadosIncidencias.NombreEstado,
               TerritorioNombre = c.Territorio.Nombre,
               CodigoSap = c.CodigoSAP,
            }).ToListAsync();
            return resultList;
        }

        
    }
    }

