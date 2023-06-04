using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCommerce.Core.DTO
{
    public class FilteredProductDTO
    {
        public string CurrentCategory { get; set; }

        public string CurrentBrand { get; set; }
        public int ProductCount { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
