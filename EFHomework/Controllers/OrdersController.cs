using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EFHomework.DTOs;
using EFHomework.Models;

namespace EFHomework.Controllers
{
    public class OrdersController : ApiController
    {
        private EFHomeworkContext db = new EFHomeworkContext();

        // GET: api/Orders
        public IQueryable<OrderDTO> GetOrderDTOs()
        {
			return from order in db.Orders
				   select new OrderDTO()
				   {
					   OrderID = order.OrderID,
					   CustomerName = order.CustomerName,
					   ProductID = order.ProductID,
					   ProductName = order.Product.Name,
					   Quantity = order.Quantity
				   };

		}


		[Route("api/Orders/GetOrdersForCustomer/{name}")]
		public IHttpActionResult GetOrdersForCustomer(string name)
		{
			return Ok(db.Orders.Where(o => o.CustomerName == name).Select(order => new OrderDTO()
			{
				OrderID = order.OrderID,
				CustomerName = order.CustomerName,
				ProductID = order.ProductID,
				ProductName = order.Product.Name,
				Quantity = order.Quantity
			}).ToList());
		}


        // POST: api/Orders
        public IHttpActionResult PostOrderDTO(OrderDTO orderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = db.Products.SingleOrDefault(p => p.ProductID == orderDto.ProductID);
            if (orderDto.Quantity > product.UnitsInStock)
            {
                return new System.Web.Http.Results.ResponseMessageResult(Request.CreateResponse(HttpStatusCode.NotAcceptable));
            }
            var order = new Order
			{
				CustomerName = orderDto.CustomerName,
				ProductID = orderDto.ProductID,
				Quantity = orderDto.Quantity
			};

            db.Orders.Add(order);
            product.UnitsInStock -= orderDto.Quantity;
            db.SaveChanges();

            return Ok();
        }

        // DELETE: api/Orders/5
        public IHttpActionResult DeleteOrderDTO(int id)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            Product product = db.Products.Find(order.ProductID);
            product.UnitsInStock += order.Quantity;
            db.Orders.Remove(order);
            db.SaveChanges();

            return Ok(order);
        }
    }
}