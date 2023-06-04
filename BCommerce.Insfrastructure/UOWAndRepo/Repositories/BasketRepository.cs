using BCommerce.Application.Data;
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
    public class BasketRepository : Repository<Basket>, IBasketRepository
    {
        private readonly IApplicationDbContext dbContext;
        public BasketRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Order> CreateOrerFromBasket(int basketId, string country, string city, string postcode, string detailaddress, string street)
        {


            var basket = await dbContext.Baskets.Include(t => t.BasketItems).ThenInclude(t => t.Product).FirstOrDefaultAsync(t => t.Id == basketId);

            Order order = new Order
            {

                CustomerId = basket.UserId,
                Date = DateTime.Now,
                OrderStatus = Core.Enums.OrderStatus.CREATED,
                Total = basket.BasketItems.Sum(t => t.Count * t.Product.Price),
                OrderItems = new List<OrderItem>()
            };


            foreach (var item in basket.BasketItems)
            {
                order.OrderItems.Add(new OrderItem
                {
                    Count = item.Count,
                    ProductId = item.ProductId,
                    Price = item.Product.Price
                });

            }

            order.OrderAddress = new OrderAddress
            {
                Address = detailaddress,
                City = city,
                Country = country,
                PostCode = postcode,
                Street = street
            };


            await dbContext.Orders.AddAsync(order);
            dbContext.Baskets.Remove(basket);
            await dbContext.ChangesAsync(default);


            return order;
        }

        public Task<Basket> GetUserBasket(string userid)
        {
            return dbContext.Baskets.Include(t => t.BasketItems).ThenInclude(t => t.Product).FirstOrDefaultAsync(t => t.UserId == userid);

        }
    }
}
