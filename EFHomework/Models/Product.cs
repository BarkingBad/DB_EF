using EFHomework.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EFHomework.Models
{
	public class Product
	{
		public int ProductID { get; set; }
		public string Name { get; set; }
		public int UnitsInStock { get; set; }
		public int CategoryID { get; set; }
		public virtual Category Category { get; set; }
		[Column(TypeName = "Money")]
		public decimal UnitPrice { get; set; }
		public virtual ICollection<Order> Orders { get; set; }

		public ProductDTO ToProductDTO()
		{
			return new ProductDTO()
				{
					ProductID = this.ProductID,
					CategoryName = this.Category.Name,
					Name = this.Name,
					UnitPrice = this.UnitPrice,
					UnitsInStock = this.UnitsInStock
				};
		}
	}
}