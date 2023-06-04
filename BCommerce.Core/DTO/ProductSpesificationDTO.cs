using BCommerce.Core.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCommerce.Core.DTO
{
    public class ProductSpesificationDTO
    {
        public int SpesificationId { get; set; }


        public SpesificationDTO Spesification { get; set; }


        public int SpesificationItemId { get; set; }



        public SpesificationItemDTO SpesificationItem { get; set; }
    }
}
