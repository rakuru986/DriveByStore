﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models.Context;
using Models.Data;
using Models.Store;
using Models.Store.Interfaces;
using Repositories.Common;

namespace Repositories
{
    public sealed class ProductRepository : UniqueEntityRepository<Product, ProductData>, IProductRepository
    {
        public ProductRepository() : this(null) { }
        public ProductRepository(StoreDbContext c = null) : base(c, c?.Products) { }

        protected internal override Product toModelObject(ProductData periodData) => new Product();

        public override Product unspecifiedEntity() => new Product();
    }
}