using Data;
using Data.Interfaces.SecurityInterfaces;
using DinkToPdf;
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
    public class FacturaRepository : FacturaInterface
    {
        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWorkRepository _unit;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private MessageInfoDTO infoDTO = new MessageInfoDTO();
        private readonly string _username;
        private readonly string _ip;


        public FacturaRepository(
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
        public async Task<MessageInfoDTO> Create(FacturaDto data)
        {

            Factura factura = new Factura();
            factura.Active = true;
            factura.IdCliente = data.IdCliente;
            factura.IdPuntoVenta = data.IdPuntoVenta;
            factura.Fecha = data.Fecha;
            factura.Iva = data.Iva;
            factura.Total = data.Total;
            factura.DateRegister = DateTime.Now;
            factura.UserRegister = _username;
            factura.IpRegister = _ip;

            await _context.Facturas.AddAsync(factura);
            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("Se ha creado la factura");
            return infoDTO;
        }

        public async Task<MessageInfoDTO> Desactive(long Id)
        {
            var facturaToDelete = await _context.Facturas.Where(x => x.Active && x.IdFactura == Id).FirstOrDefaultAsync();
            if (facturaToDelete != null)
            {
                infoDTO.AccionFallida("La factura seleccionada no se encuentra disponible", 400);
            }
            facturaToDelete.DateDelete = DateTime.Now;
            facturaToDelete.Active = false;
            facturaToDelete.UserDelete = _username;
            facturaToDelete.IpDelete = _ip;

            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("La factura seleccionada a sido eliminado correctamente");

            return infoDTO;
        }

        public async Task<MessageInfoDTO> Edit(FacturaDto data)
        {
            try
            {
                var model = await _context.Facturas.Where(x => x.Active && x.IdFactura == data.IdFactura).FirstOrDefaultAsync() ?? throw new Exception("No se encontro la factura");

                model.IdCliente = data.IdCliente;
                model.IdPuntoVenta = data.IdPuntoVenta;
                model.Fecha = data.Fecha;
                model.Iva = data.Iva;
                model.Total = data.Total;
                

                model.UserModification = _username;
                model.DateModification = DateTime.Now;
                model.IpModification = _ip;

                await _context.SaveChangesAsync();

                return infoDTO;
            }
            catch (Exception ex)
            {
                return infoDTO.ErrorInterno(ex, "FacturaRepository", "Error al intentar actualizar la factura");
            }
        }

        public async Task<FacturaDto> Get(long Id)
        {
            var facturaSelected = await _context.Facturas.Where(x => x.Active && x.IdFactura == Id).Select(c => new FacturaDto
            {
                IdFactura = c.IdFactura,
                IdCliente = c.IdCliente,
                Fecha = c.Fecha,
                Iva = c.Iva,
                Total = c.Total,
            }
                ).FirstOrDefaultAsync();
            return facturaSelected;
        }

        public async Task<List<MostrarFacturaDto>> GetAll()
        {
            var factura = await _context.Facturas.Where(x => x.Active).Select(c => new MostrarFacturaDto
            {
                IdFactura = c.IdFactura,
                ClienteNombre = c.Cliente.Nombre,
                PuntoVentaNombre = c.PuntoVenta.Nombre,
                Fecha = c.Fecha,
                Iva = c.Iva,
                Total = c.Total
            }).ToListAsync();
            return factura;
        }
    }
}
