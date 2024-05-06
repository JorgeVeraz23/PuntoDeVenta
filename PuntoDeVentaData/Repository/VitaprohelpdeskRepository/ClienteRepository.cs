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
    public class ClienteRepository : ClienteInterface
    {

        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWorkRepository _unit;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private MessageInfoDTO infoDTO = new MessageInfoDTO();
        private readonly string _username;
        private readonly string _ip;

        public ClienteRepository(
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

        public async Task<MessageInfoDTO> Create(ClienteDto data)
        {
            var isAlreadyExist = await _context.Clientes.Where(x => x.Active && x.Nombre.ToUpper().Equals(data.Nombre.ToUpper())).AnyAsync();

            if (isAlreadyExist)
            {
                infoDTO.AccionFallida("Ya existe un cliente registrado con ese nombre", 400);
                return infoDTO;
            }

            Cliente cliente = new Cliente();
            cliente.Active = true;
            cliente.Nombre = data.Nombre;
            cliente.Identificacion = data.Identificacion;
        
            cliente.DateRegister = DateTime.Now;
            cliente.UserRegister = _username;
            cliente.IpRegister = _ip;

            await _context.Clientes.AddAsync(cliente);
            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("Se ha creado el cliente");
            return infoDTO;
        }

        public async Task<MessageInfoDTO> Desactive(long Id)
        {
            var clienteToDelete = await _context.Clientes.Where(x => x.Active && x.IdCliente == Id).FirstOrDefaultAsync();
            if (clienteToDelete != null)
            {
                infoDTO.AccionFallida("El cliente seleccionado no se encuentra disponible", 400);
            }
            clienteToDelete.DateDelete = DateTime.Now;
            clienteToDelete.Active = false;
            clienteToDelete.UserDelete = _username;
            clienteToDelete.IpDelete = _ip;

            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("El cliente seleccionado a sido seleccionado correctamente");

            return infoDTO;
        }

        public async Task<MessageInfoDTO> Edit(ClienteDto data)
        {
            try
            {
                var model = await _context.Clientes.Where(x => x.Active && x.IdCliente == data.IdCliente).FirstOrDefaultAsync() ?? throw new Exception("No se encontro el cliente");

                model.Nombre = data.Nombre;
                model.Identificacion = data.Identificacion;
                

                model.UserModification = _username;
                model.DateModification = DateTime.Now;
                model.IpModification = _ip;

                await _context.SaveChangesAsync();

                return infoDTO;
            }
            catch (Exception ex)
            {
                return infoDTO.ErrorInterno(ex, "ClienteRepository", "Error al intentar actualizar el cliente");
            }
        }

        public async Task<ClienteDto> Get(long Id)
        {
            var clienteSelected = await _context.Clientes.Where(x => x.Active && x.IdCliente == Id).Select(c => new ClienteDto
            {
                IdCliente = c.IdCliente,
                Nombre = c.Nombre,
                Identificacion = c.Identificacion,
            }
              ).FirstOrDefaultAsync();
            return clienteSelected;
        }

        public async Task<List<ClienteDto>> GetAll()
        {
            var clientes = await _context.Clientes.Where(x => x.Active).Select(c => new ClienteDto
            {
                IdCliente = c.IdCliente,
                Nombre = c.Nombre,
                Identificacion = c.Identificacion,
            }).ToListAsync();
            return clientes;
        }

        public async Task<List<KeyValue>> KeyValues()
        {
            var clientes = await _context.Clientes.Where(x => x.Active).Select(c => new KeyValue
            {
                Key = c.IdCliente,
                Value = c.Nombre,
            }).ToListAsync();
            return clientes;
        }
    }
}
