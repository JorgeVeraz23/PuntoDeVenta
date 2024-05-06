using Data;
using Data.Interfaces.SecurityInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;


using NicoAssistRemake.Data.Entities.Utilities;

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
    public class TipoReconocimientoRepository : TipoReconocimientoInterface
    {
        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWorkRepository _unit;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private MessageInfoDTO infoDTO = new MessageInfoDTO();
        private readonly string _username;
        private readonly string _ip;


        public TipoReconocimientoRepository(
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


        public Task<MessageInfoDTO> Create(TipoReconocimientoDto data)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> Desactive(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> Edit(TipoReconocimientoDto data)
        {
            throw new NotImplementedException();
        }

        public Task<TipoReconocimientoDto> Get(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TipoReconocimientoDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<KeyValue>> KeyValues()
        {
            var tipoReconocimientoKeyValue = await _context.TipoReconocimientos.Where(x => x.Active).Select(c => new KeyValue
            {
                Key = c.IdTipoReconocimiento,
                Value = c.NombreTipoReconocimiento,

            }).ToListAsync();
            return tipoReconocimientoKeyValue;
        }
    }
}
