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
    public class CorreoNotificationRepository : CorreoNotificationInterface
    {
        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWorkRepository _unit;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private MessageInfoDTO infoDTO = new MessageInfoDTO();
        private readonly string _username;
        private readonly string _ip;


        public CorreoNotificationRepository(
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
        public async Task<MessageInfoDTO> Create(CorreoNotificationDto data)
        {
            var isAlreadyExist = await _context.CorreoNotifications.Where(x => x.Active && x.NombreCorreoNotification.ToUpper().Equals(data.NombreCorreoNotification.ToUpper())).AnyAsync();

            if (isAlreadyExist)
            {
                infoDTO.AccionFallida("Ya existe un notificacion de correo registrada con ese nombre", 400);
                return infoDTO;
            }

            CorreoNotification correoNotification = new CorreoNotification();
            correoNotification.Active = true;
            correoNotification.NombreCorreoNotification = data.NombreCorreoNotification;
            correoNotification.IdIncidencia = data.IdIncidencia;
            correoNotification.isSac = data.isSac;
            correoNotification.isEvaluacion = data.isEvaluacion;
            correoNotification.isResponsable = data.isResponsable;
            correoNotification.isExterno = data.isExterno;
            correoNotification.DateRegister = DateTime.Now;
            correoNotification.UserRegister = _username;
            correoNotification.IpRegister = _ip;

            await _context.CorreoNotifications.AddAsync(correoNotification);
            await _unit.SaveChangesAsync();

            infoDTO.AccionCompletada("Se ha creado la notificacion");
            return infoDTO;
        }

        public Task<MessageInfoDTO> Desactive(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> Edit(CorreoNotificationDto data)
        {
            throw new NotImplementedException();
        }

        public Task<CorreoNotificationDto> Get(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CorreoNotificationDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
