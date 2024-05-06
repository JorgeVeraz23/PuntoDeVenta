using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;

using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface CorreoNotificationInterface
    {
        public Task<List<CorreoNotificationDto>> GetAll();
        public Task<CorreoNotificationDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(CorreoNotificationDto data);
        public Task<MessageInfoDTO> Edit(CorreoNotificationDto data);
    }
}
