﻿using Data.Dto.CatalogsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.CatalogsInterfaces
{
    public interface GeneralCatalogsInterface
    {
        public List<TypeDocumentDTO> GetAllTypeDocuments();
    }
}
