﻿using LibrarySystem.BL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL;

public interface IRetrievalManager
{
    IEnumerable<RetrievalReadDto> GetAll();

    bool Retrieve(RetrievalAddDto dto);
}
