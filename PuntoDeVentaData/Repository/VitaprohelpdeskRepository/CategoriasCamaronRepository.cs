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
    public class CategoriasCamaronRepository : CategoriaCamaronInterface
    {
        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWorkRepository _unit;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private MessageInfoDTO infoDTO = new MessageInfoDTO();
        private readonly string _username;
        private readonly string _ip;

        public CategoriasCamaronRepository(
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

        public async Task<MessageInfoDTO> Create(CategoriaCamaronDto data)
        {
            var isAlreadyExist = await _context.CategoriaCamarons.Where(x => x.Active && x.NombreCategoriaCamaron.ToUpper().Equals(data.NombreCategoriaCamaron.ToUpper())).AnyAsync();

            if (isAlreadyExist)
            {
                infoDTO.AccionFallida("Ya existe una categoria de camaron registrado con ese nombre", 400);
                return infoDTO;
            }

            CategoriaCamaron categoriaCamaron = new CategoriaCamaron();
            categoriaCamaron.Active = true;
            categoriaCamaron.NombreCategoriaCamaron = data.NombreCategoriaCamaron;


            categoriaCamaron.DateRegister = DateTime.Now;
            categoriaCamaron.UserRegister = _username;
            categoriaCamaron.IpRegister = _ip;

            await _context.CategoriaCamarons.AddAsync(categoriaCamaron);
            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("Se ha creado la categoria del camaron");
            return infoDTO;
        }

        public Task<MessageInfoDTO> Desactive(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> Edit(CategoriaCamaronDto data)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoriaCamaronDto> Get(long Id)
        {
            var categoriaCamaronSelected = await _context.CategoriaCamarons.Where(x => x.Active && x.IdCategoriaCamaron == Id).Select(c => new CategoriaCamaronDto
            {
                IdCategoriaCamaron = c.IdCategoriaCamaron,
                NombreCategoriaCamaron = c.NombreCategoriaCamaron,
            }
             ).FirstOrDefaultAsync();
            return categoriaCamaronSelected;
        }

        public async Task<List<CategoriaCamaronDto>> GetAll()
        {
            var cateogoriaCamaron = await _context.CategoriaCamarons.Where(x => x.Active).Select(c => new CategoriaCamaronDto
            {
                IdCategoriaCamaron = c.IdCategoriaCamaron,
                NombreCategoriaCamaron = c.NombreCategoriaCamaron,

            }).ToListAsync();
            return cateogoriaCamaron;
        }
    }
}
