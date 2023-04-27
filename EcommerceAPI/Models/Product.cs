using System;
namespace EcommerceAPI.Models
{
	public class Product
	{
		public int ProductId { get; set; }
		public string? ProductName { get; set; }
		public string? ProductDesc { get; set; }
		public double ProductPrice { get; set; }
		public Discount? Discount { get; set; }
	}
}

