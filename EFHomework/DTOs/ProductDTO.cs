using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFHomework.DTOs
{
	public class ProductDTO
	{
		public int ProductID { get; set; }
		public string Name { get; set; }
		public int UnitsInStock { get; set; }
		public string CategoryName { get; set; }
		public decimal UnitPrice { get; set; }
	}
}