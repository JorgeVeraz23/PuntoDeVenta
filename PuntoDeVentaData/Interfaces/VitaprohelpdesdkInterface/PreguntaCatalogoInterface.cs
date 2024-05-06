using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;
using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface PreguntaCatalogoInterface
    {
        public Task<List<PreguntaCatalogoDto>> GetAll();
        public Task<PreguntaCatalogoDto> Get(long Id);
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(PreguntaCatalogoDto data);
        public Task<MessageInfoDTO> Edit(PreguntaCatalogoDto data);
    }
}
