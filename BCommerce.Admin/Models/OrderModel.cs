namespace BCommerce.Admin.Models
{

    public class AddressInfo {

        public string Country { get; set; }

        public string City { get; set; }

        public string Phone { get; set; }

        public string Description { get; set; }
    }

    public class ProductInfo
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }

        public decimal Price { get; set; }
    }

    public class OrderModel
    {


        public int OrderId { get; set; }
        
        public DateTime Date { get; set; }


        public int OrderStatus { get; set; }

        public decimal Total { get; set; }


        public AddressInfo AddressInfo { get; set; }

   


    }
}
