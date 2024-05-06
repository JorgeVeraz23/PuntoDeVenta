using Data;
using Data.Interfaces.SecurityInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Abstractions;
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
    public class ProductosIncidenciasRepository : ProductosIncidenciasInterface
    {
        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWorkRepository _unit;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private MessageInfoDTO infoDTO = new MessageInfoDTO();
        private readonly string _username;
        private readonly string _ip;

        public ProductosIncidenciasRepository(
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


        public async Task<MessageInfoDTO> Create(ProductosIncidenciasDto data)
        {
            
            ProductosIncidencias productosIncidencias = new ProductosIncidencias();
            productosIncidencias.Active = true;
            productosIncidencias.IdIncidencias = data.IdIncidencias;
            productosIncidencias.IdProducto = data.IdProducto;
            productosIncidencias.Lote = data.Lote;
            productosIncidencias.FechaEntrega = data.FechaEntrega;
            productosIncidencias.NoFactura = data.NoFactura;
            productosIncidencias.NoGuiaRemision = data.NoGuiaRemision;
            productosIncidencias.CantidadComprada = data.CantidadComprada;
            productosIncidencias.CantidadReclamo = data.CantidadReclamo;
            productosIncidencias.DetalleProblema = data.DetalleProblema;
            productosIncidencias.Observacion = data.Observacion;


            productosIncidencias.DateRegister = DateTime.Now;
            productosIncidencias.UserRegister = _username;
            productosIncidencias.IpRegister = _ip;

            await _context.ProductosIncidencias.AddAsync(productosIncidencias);
            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("Se ha creado el producto con incidencia");
            return infoDTO;
        }

        public async Task<MessageInfoDTO> Desactive(long Id)
        {
            var productoIncidenciaToDelete = await _context.ProductosIncidencias.Where(x => x.Active && x.IdProductosIncidencias == Id).FirstOrDefaultAsync();
            if (productoIncidenciaToDelete != null)
            {
                infoDTO.AccionFallida("El producto con incidencia seleccionado no se encuentra disponible", 400);
            }
            productoIncidenciaToDelete.DateDelete = DateTime.Now;
            productoIncidenciaToDelete.Active = false;
            productoIncidenciaToDelete.UserDelete = _username;
            productoIncidenciaToDelete.IpDelete = _ip;

            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("El producto con incidencia seleccionado a sido eliminado correctamente");

            return infoDTO;
        }

        public async Task<MessageInfoDTO> Edit(ProductosIncidenciasDto data)
        {
            try
            {
                var model = await _context.ProductosIncidencias.Where(x => x.Active && x.IdProductosIncidencias == data.IdProductosIncidencias).FirstOrDefaultAsync() ?? throw new Exception("No se encontro el producto incidencia");

                model.IdIncidencias = data.IdIncidencias;
                model.IdProducto = data.IdProducto;
                model.Lote = data.Lote;
                model.FechaEntrega = data.FechaEntrega;
                model.NoFactura = data.NoFactura;
                model.NoGuiaRemision = data.NoGuiaRemision;
                model.CantidadComprada = data.CantidadComprada;
                model.CantidadReclamo = data.CantidadReclamo;
                model.DetalleProblema = data.DetalleProblema;
                model.Observacion = data.Observacion;

                model.UserModification = _username;
                model.DateModification = DateTime.Now;
                model.IpModification = _ip;

                await _context.SaveChangesAsync();

                return infoDTO;
            }
            catch (Exception ex)
            {
                return infoDTO.ErrorInterno(ex, "ProductoIncidenciaRepository", "Error al intentar actualizar el producto");
            }
        }

        public async Task<ProductosIncidenciasDto> Get(long Id)
        {
            var productoIncidenciaSelected = await _context.ProductosIncidencias.Where(x => x.Active && x.IdProductosIncidencias == Id).Select(c => new ProductosIncidenciasDto
            {
                IdProductosIncidencias = c.IdProductosIncidencias,
                IdIncidencias = c.IdIncidencias,
                IdProducto = c.IdProducto,
                Lote = c.Lote,
                FechaEntrega = c.FechaEntrega,
                NoFactura = c.NoFactura,
                NoGuiaRemision = c.NoGuiaRemision,
                CantidadComprada = c.CantidadComprada,
                CantidadReclamo = c.CantidadReclamo,
                DetalleProblema = c.DetalleProblema,
                Observacion = c.Observacion,


            }
               ).FirstOrDefaultAsync();
            return productoIncidenciaSelected;
        }

        public async Task<List<ProductosIncidenciasDto>> GetAll()
        {
            //var gestorDeReclamo = await _context.GestorReclamos.Where(x => x.Active).Select(c => new MostrarGestorReclamoDto
            //{
            //    IdGestorReclamo = c.IdGestorReclamo,
            //    Nombre = c.Nombre,
            //    Telefono = c.Telefono,
            //    Mail = c.Mail,
            //    Territorio = c.Territorio.Nombre,
            //}).ToListAsync();
            return null;
        }
    }
}
