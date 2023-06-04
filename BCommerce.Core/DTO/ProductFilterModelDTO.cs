using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCommerce.Core.DTO
{
    public class ProductFilterModelDTO
    {
        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        public int? CategoryId { get; set; }

        public int? BrandId { get; set; }

        public List<int> Brands { get; set; } = new List<int>();

        public List<int> Spesifications { get; set; }=new List<int>();
    }
}
