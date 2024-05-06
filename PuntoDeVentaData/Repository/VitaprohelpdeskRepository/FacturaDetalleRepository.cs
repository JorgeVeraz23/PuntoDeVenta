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
    public class FacturaDetalleRepository : FacturaDetalleInterface
    {
        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWorkRepository _unit;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private MessageInfoDTO infoDTO = new MessageInfoDTO();
        private readonly string _username;
        private readonly string _ip;


        public FacturaDetalleRepository(
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

        public async Task<MessageInfoDTO> Create(FacturaDetalleDto data)
        {


            FacturaDetalle facturaDetalle = new FacturaDetalle();
            facturaDetalle.Active = true;
            facturaDetalle.IdFactura = data.IdFactura;
            facturaDetalle.IdProducto = data.IdProducto;
            facturaDetalle.Cantidad = data.Cantidad;
            facturaDetalle.IVA = data.IVA;
            facturaDetalle.DateRegister = DateTime.Now;
            facturaDetalle.UserRegister = _username;
            facturaDetalle.IpRegister = _ip;

            await _context.FacturaDetalles.AddAsync(facturaDetalle);
            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("Se ha creado el detalle de la factura");
            return infoDTO;
        }

        public async Task<MessageInfoDTO> Desactive(long Id)
        {
            var facturaDetalleToDelete = await _context.FacturaDetalles.Where(x => x.Active && x.IdFacturaDetalle == Id).FirstOrDefaultAsync();
            if (facturaDetalleToDelete != null)
            {
                infoDTO.AccionFallida("El detalle de la factura seleccionado no se encuentra disponible", 400);
            }
            facturaDetalleToDelete.DateDelete = DateTime.Now;
            facturaDetalleToDelete.Active = false;
            facturaDetalleToDelete.UserDelete = _username;
            facturaDetalleToDelete.IpDelete = _ip;

            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("El detalle de la factura seleccionado a sido eliminado correctamente");

            return infoDTO;
        }

        public async  Task<MessageInfoDTO> Edit(FacturaDetalleDto data)
        {

            try
            {
                var model = await _context.FacturaDetalles.Where(x => x.Active && x.IdFacturaDetalle == data.IdFacturaDetalle).FirstOrDefaultAsync() ?? throw new Exception("No se encontro el detalle de factura");

                model.IdFactura = data.IdFactura;
                model.IdProducto = data.IdProducto;
                model.Cantidad = data.Cantidad;
                model.IVA = data.IVA;
                model.Total = data.Total;

                model.UserModification = _username;
                model.DateModification = DateTime.Now;
                model.IpModification = _ip;

                await _context.SaveChangesAsync();

                return infoDTO;
            }
            catch (Exception ex)
            {
                return infoDTO.ErrorInterno(ex, "FacturaDetalleRepository", "Error al intentar actualizar el detalle de la factura");
            }
        }

        public async  Task<FacturaDetalleDto> Get(long Id)
        {
            var detalleFacturaSelected = await _context.FacturaDetalles.Where(x => x.Active && x.IdFacturaDetalle == Id).Select(c => new FacturaDetalleDto
            {
                IdFacturaDetalle = c.IdFacturaDetalle,
                IdFactura = c.IdFactura,
                IdProducto = c.IdProducto,
                Cantidad = c.Cantidad,
                IVA = c.IVA,
                Total = c.Total,
            }
                ).FirstOrDefaultAsync();
            return detalleFacturaSelected;
        }

        public async Task<List<MostrrarFacturaDetalleDto>> GetAll()
        {
            var detallleFactura = await _context.FacturaDetalles.Where(x => x.Active).Select(c => new MostrrarFacturaDetalleDto
            {
                IdFacturaDetalle = c.IdFacturaDetalle,
                IdFactura = c.IdFactura,
                IdProducto = c.IdProducto,
                ProductoNombre = c.Productos.Nombre,
                Cantidad = c.Cantidad,
                IVA = c.IVA,
                Total = c.Total,
            }).ToListAsync();
            return detallleFactura;
        }
    }
}
