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
    public class ProductoRepository : ProductoInterface
    {
        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWorkRepository _unit;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private MessageInfoDTO infoDTO = new MessageInfoDTO();
        private readonly string _username;
        private readonly string _ip;

        public ProductoRepository(
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
        public async Task<MessageInfoDTO> Create(ProductoDto data)
        {
            var isAlreadyExist = await _context.Productos.Where(x => x.Active && x.NombreProducto.ToUpper().Equals(data.NombreProducto.ToUpper())).AnyAsync();

            if (isAlreadyExist)
            {
                infoDTO.AccionFallida("Ya existe un producto registrado con ese nombre", 400);
                return infoDTO;
            }

            Producto producto = new Producto();
            producto.Active = true;
            producto.Sku = data.Sku;
            producto.NombreProducto = data.NombreProducto;
            producto.DateRegister = DateTime.Now;
            producto.UserRegister = _username;
            producto.IpRegister = _ip;

            await _context.Productos.AddAsync(producto);
            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("Se ha creado el producto");
            return infoDTO;
        }

        public async Task<MessageInfoDTO> Desactive(long Id)
        {
            var productoToDelete = await _context.Productos.Where(x => x.Active && x.IdProductos == Id).FirstOrDefaultAsync();
            if (productoToDelete != null)
            {
                infoDTO.AccionFallida("El producto seleccionado no se encuentra disponible", 400);
            }
            productoToDelete.DateDelete = DateTime.Now;
            productoToDelete.Active = false;
            productoToDelete.UserDelete = _username;
            productoToDelete.IpDelete = _ip;

            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("El producto seleccionado a sido eliminado correctamente");

            return infoDTO;
        }

        public async Task<MessageInfoDTO> Edit(ProductoDto data)
        {
            try
            {
                var model = await _context.Productos.Where(x => x.Active && x.IdProductos == data.IdProductos).FirstOrDefaultAsync() ?? throw new Exception("No se encontro el motivo");

                model.NombreProducto = data.NombreProducto;
                model.Sku = data.Sku;

                model.UserModification = _username;
                model.DateModification = DateTime.Now;
                model.IpModification = _ip;

                await _context.SaveChangesAsync();

                return infoDTO;
            }
            catch (Exception ex)
            {
                return infoDTO.ErrorInterno(ex, "MotivoRepository", "Error al intentar actualizar el motivo");
            }
        }

        public async Task<ProductoDto> Get(long Id)
        {
            var productoSelected = await _context.Productos.Where(x => x.Active && x.IdProductos == Id).Select(c => new ProductoDto
            {
                IdProductos = c.IdProductos,
                NombreProducto = c.NombreProducto,
                Sku = c.Sku,

            }
               ).FirstOrDefaultAsync();
            return productoSelected;
        }

        public async  Task<List<ProductoDto>> GetAll()
        {
            var producto = await _context.Productos.Where(x => x.Active).Select(c => new ProductoDto
            {
                IdProductos = c.IdProductos,
                NombreProducto = c.NombreProducto,
                Sku = c.Sku,

            }).ToListAsync();
            return producto;
        }
    }
}
