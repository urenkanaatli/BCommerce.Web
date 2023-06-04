using BCommerce.Admin.Models;
using BCommerce.Application.Data;
using BCommerce.Core.DomainClasses;
using BCommerce.Insfrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BCommerce.Admin.Controllers
{
    public class OrderController : Controller
    {
        private readonly IApplicationDbContext applicationDbContext;
        public OrderController(IApplicationDbContext applicationDbContext)
        {

            this.applicationDbContext = applicationDbContext;
        }

        public IActionResult List()
        {
            return View();
        }

        public IActionResult GetOrderProducts(int orderid)
        {

            var relatedOrder = applicationDbContext.Orders.Include(t => t.OrderItems).ThenInclude(t => t.Product).Where(t => t.Id == orderid).First();

            var Products = relatedOrder.OrderItems.Select(t => new ProductInfo
            {
                Count = t.Count,
                Id = t.Id,
                Name = t.Product.Name,
                Price = t.Price
            });




            return Json(Products);

        }


        public IActionResult WaitingOrderList()
        {


            var orders = applicationDbContext.Orders.Include(t => t.OrderAddress).Where(t => t.OrderStatus != Core.Enums.OrderStatus.COMPLETED).Select(t => new OrderModel
            {

                Date = t.Date,
                OrderId = t.Id,
                OrderStatus = (int)t.OrderStatus,
                Total = t.Total,
                AddressInfo = new AddressInfo
                {
                    City = t.OrderAddress.City,
                    Country = t.OrderAddress.Country,
                    Description = t.OrderAddress.Address,
                    Phone = "-"

                }


            }).ToList();
            return Json(orders);




        }
    }
}
