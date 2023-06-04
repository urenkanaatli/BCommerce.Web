using System.ComponentModel.DataAnnotations;

namespace BCommerce.Web.Models
{

  

    public class CheckoutModel
    {
        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string PostCode { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string Description { get; set; }


        [Required]
        public string CCNumber { get; set; }

        [Required]
        public int Cvv { get; set; }

        [Required]
        public string LastDate { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
