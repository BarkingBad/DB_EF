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
using EFHomework.Models;

namespace EFHomework.Controllers
{
    public class CategoriesController : ApiController
    {
        private EFHomeworkContext db = new EFHomeworkContext();

        // GET: api/Categories
        public IQueryable<Category> GetCategories()
        {
            return db.Categories;
        }
    }
}