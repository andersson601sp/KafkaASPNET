﻿using application.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace application.Interface
{
    public interface IProductService
    {
        public Task<int> GenerateAsync(Product request);
    }
}
