﻿using EFHomework.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EFHomework.Models
{
	public class Order
	{
		public int OrderID { get; set; }

		public int ProductID { get; set; }
		public virtual Product Product { get; set; }

		[ForeignKey("Customer")]
		public string CustomerName { get; set; }
		public virtual Customer Customer { get; set; }

		public int Quantity { get; set; }

		public OrderDTO ToOrderDTO()
		{
			return new OrderDTO()
				{
					OrderID = this.OrderID,
					CustomerName = this.CustomerName,
					ProductID = this.ProductID,
					ProductName = this.Product.Name,
					Quantity = this.Quantity
				};
		}
	}
}