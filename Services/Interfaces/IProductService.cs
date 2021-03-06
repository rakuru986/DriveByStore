﻿using System.Threading.Tasks;
using Repositories.Interfaces;

namespace Services.Interfaces
{
    public interface IProductService
    {
        Task<bool> changeStock(string productId, int changeCount, string mode, IProductRepository pr);
    }
}
