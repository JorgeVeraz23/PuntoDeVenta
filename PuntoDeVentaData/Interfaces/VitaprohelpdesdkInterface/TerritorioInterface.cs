﻿using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;

using NicoAssistRemake.Data.Entities.Utilities;
using PuntoDeVentaData.Dto.UtilitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface
{
    public interface TerritorioInterface
    {
        public Task<List<TerritorioDto>> GetAll();
        public Task<TerritorioDto> Get(long Id);
        public Task<List<KeyValue>> GetKeyValue();
        public Task<MessageInfoDTO> Desactive(long Id);
        public Task<MessageInfoDTO> Create(TerritorioDto data);
        public Task<MessageInfoDTO> Edit(TerritorioDto data);
    }
}
