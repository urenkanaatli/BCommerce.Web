using BCommerce.Core.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCommerce.Application.UOWAndRepo.Repositories
{
    public interface IBasketRepository : IRepository<Basket>
    {

        Task<Basket> GetUserBasket(string userid);

        Task<Order> CreateOrerFromBasket(int basketId, string country, string city, string postcode, string detailaddress, string street);


    }
}
