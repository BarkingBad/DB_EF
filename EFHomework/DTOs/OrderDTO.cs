using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFHomework.DTOs
{
	public class OrderDTO
	{
		public int OrderID { get; set; }
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public string CustomerName { get; set; }
		public int Quantity { get; set; }
	}
}