﻿using BCommerce.Core.DomainClasses;
using BCommerce.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCommerce.Application.UOWAndRepo.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> GetFilteredProducts(ProductFilterModelDTO productFilterModelDTO);

        public Product GetProductDetail(int id);

    }
}
