﻿using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface IModelRepository : IRepository<Model>
    {
        List<Model> GetAll(bool IncludeBrand, bool IncludeCars);
    }
}
