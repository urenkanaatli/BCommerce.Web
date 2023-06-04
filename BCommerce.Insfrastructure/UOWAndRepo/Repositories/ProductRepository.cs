﻿using BCommerce.Application.Data;
using BCommerce.Application.UOWAndRepo.Repositories;
using BCommerce.Core.DomainClasses;
using BCommerce.Core.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCommerce.Insfrastructure.UOWAndRepo.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly IApplicationDbContext dbContext;
        public ProductRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Product> GetFilteredProducts(ProductFilterModelDTO productFilterModelDTO)
        {

            var productQuery = dbContext.Products.Include(t => t.Images).AsQueryable();

            if (productFilterModelDTO.CategoryId > 0)
            {
                productQuery = productQuery.Where(t => t.CategoryId == productFilterModelDTO.CategoryId);
            }

            if (productFilterModelDTO.BrandId > 0)
            {
                productQuery = productQuery.Where(t => t.BrandId == productFilterModelDTO.BrandId);

            }

            if (productFilterModelDTO.MaxPrice > 0)
            {
                productQuery = productQuery.Where(t => t.Price <= productFilterModelDTO.MaxPrice);

            }

            if (productFilterModelDTO.MinPrice > 0)
            {
                productQuery = productQuery.Where(t => t.Price >= productFilterModelDTO.MinPrice);

            }


            if (productFilterModelDTO.Brands.Any())
            {

                productQuery = productQuery.Where(t => productFilterModelDTO.Brands.Contains(t.BrandId));
            }


            if (productFilterModelDTO.Spesifications.Any())
            {

                //1,2,3
                // 1 iphonex   2,1
                // 2 samsung   9,8

                productQuery = productQuery.Where(t => t.ProductSpesifications.Any(a => productFilterModelDTO.Spesifications.Contains(a.SpesificationItemId)));


            }


            return productQuery.ToList();
        }

        public Product GetProductDetail(int id)
        {

            var productDetail = dbContext.Products.Include(t => t.Images).Include(t => t.ProductSpesifications).ThenInclude(t => t.Spesification).Include(t => t.ProductSpesifications).ThenInclude(t => t.SpesificationItem).Include(t => t.Category).Include(t => t.Brand).FirstOrDefault(t => t.Id == id);

            return productDetail;
        }

   
    }
}
