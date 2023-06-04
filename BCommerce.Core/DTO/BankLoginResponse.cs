using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCommerce.Core.DTO
{
    public class BankLoginResponse
    {

        public string Token { get; set; }

        public DateTime LastDate { get; set; }

        public string Error { get; set; }


   
    }
}
