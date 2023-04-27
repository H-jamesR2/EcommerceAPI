using System;
namespace EcommerceAPI.Models
{
	public class Discount
	{
		public int DiscountId { get; set; }
		public string? DiscountName { get; set; }
		public string? DiscountDesc { get; set; }
		public double DiscountPercent { get; set; }

	}
}

