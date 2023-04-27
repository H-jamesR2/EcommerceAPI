using System;
namespace EcommerceAPI.Models
{
	public class Review
	{
		public int ReviewId { get; set; }
		public string? ReviewTitle { get; set; }
		public string? ReviewDesc { get; set; }
		public int ReviewRating { get; set; }
		public Product? Product { get; set; }
	}
}

