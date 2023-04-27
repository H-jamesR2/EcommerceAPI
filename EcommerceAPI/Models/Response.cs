using System;
namespace EcommerceAPI.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string? statusDescription { get; set; }

        public List<Discount>? discounts { get; set; }
        public List<Product>? products { get; set; }
        public List<Review>? reviews { get; set; }

        public Discount? discount { get; set; }
        public Product? product { get; set; }
        public Review? review { get; set; }
    }
}

