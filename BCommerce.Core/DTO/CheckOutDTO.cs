using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCommerce.Core.DTO
{
    public class CheckOutDTO
    {
      
        public string Country { get; set; }

   
        public string City { get; set; }

        public string PostCode { get; set; }


        public string Street { get; set; }

   
        public string Description { get; set; }


  
        public string CCNumber { get; set; }

     
        public int Cvv { get; set; }

      
        public int LastDate { get; set; }

        public string Name { get; set; }
    }
}
