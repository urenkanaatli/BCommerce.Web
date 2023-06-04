using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCommerce.Core.DomainClasses
{
    public class Comment: BaseEntity
    {

        public string Meseage { get; set; }


        public Product Product { get; set; }

        public int ProductId { get; set; }

        public string UserId { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
