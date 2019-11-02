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
    public class ProductsController : ApiController
    {
        private EFHomeworkContext db = new EFHomeworkContext();

        // GET: api/Products
        public IQueryable<ProductDTO> GetProductDTOs()
        {
            return from product in db.Products
				   select new ProductDTO
				   {
					   ProductID = product.ProductID,
					   CategoryName = product.Category.Name,
					   Name = product.Name,
					   UnitPrice = product.UnitPrice,
					   UnitsInStock = product.UnitsInStock
				   };
        }

        // POST: api/Products
        public IHttpActionResult PostProduct(ProductDTO productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			var product = new Product
			{
				CategoryID = db.Categories.Where(s => s.Name == productDto.CategoryName).Select(r => r.CategoryID).FirstOrDefault(),
				Name = productDto.Name,
				UnitPrice = productDto.UnitPrice,
				UnitsInStock = productDto.UnitsInStock
			};

            db.Products.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.ProductID }, product);
        }
    }
}