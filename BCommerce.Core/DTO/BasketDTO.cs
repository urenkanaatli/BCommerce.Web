﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCommerce.Core.DTO
{
    public class BasketDTO
    {
        public int Id { get; set; }

        public decimal Total { get; set; }

        public List<BasketItemDTO> Items { get; set; }
    }

    public class BasketItemDTO
    {
        public int Id { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }

        public decimal Price { get; set; }
    }
}
