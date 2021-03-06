﻿using HPlusSportsAPITwo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPITwo.Contracts
{
    public interface IProductRepository
    {
        void Add(Product item);

        IEnumerable<Product> GetAll();

        Product Find(string key);

        Product Remove(string key);

        void Update(Product item);
    }
}