using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFHomework.Models
{
	public class Customer
	{
		[Key]
		public string CompanyName { get; set; }
		public string Description { get; set; }

		public ICollection<Order> Orders { get; set; }
	}
}