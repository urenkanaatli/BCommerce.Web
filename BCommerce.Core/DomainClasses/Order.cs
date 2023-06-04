using BCommerce.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCommerce.Core.DomainClasses
{
    public class Order: BaseEntity
    {

        public DateTime Date { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public string CustomerId { get; set; }

        public decimal  Total { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public OrderAddress OrderAddress { get; set; }
    }
}
