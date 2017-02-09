using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using shanuMVCUserRoles.Models;

namespace shanuMVCUserRoles.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using shanuMVCUserRoles.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Blog>("BlogsAPI");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class BlogsAPIController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/BlogsAPI
        [EnableQuery]
        public IQueryable<Blog> GetBlogsAPI()
        {
            return db.Blogs;
        }

        // GET: odata/BlogsAPI(5)
        [EnableQuery]
        public SingleResult<Blog> GetBlog([FromODataUri] string key)
        {
            return SingleResult.Create(db.Blogs.Where(blog => blog.BlogId == key));
        }

        // PUT: odata/BlogsAPI(5)
        public async Task<IHttpActionResult> Put([FromODataUri] string key, Delta<Blog> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Blog blog = await db.Blogs.FindAsync(key);
            if (blog == null)
            {
                return NotFound();
            }

            patch.Put(blog);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(blog);
        }

        // POST: odata/BlogsAPI
        public async Task<IHttpActionResult> Post(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Blogs.Add(blog);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BlogExists(blog.BlogId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(blog);
        }

        // PATCH: odata/BlogsAPI(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] string key, Delta<Blog> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Blog blog = await db.Blogs.FindAsync(key);
            if (blog == null)
            {
                return NotFound();
            }

            patch.Patch(blog);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(blog);
        }

        // DELETE: odata/BlogsAPI(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] string key)
        {
            Blog blog = await db.Blogs.FindAsync(key);
            if (blog == null)
            {
                return NotFound();
            }

            db.Blogs.Remove(blog);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BlogExists(string key)
        {
            return db.Blogs.Count(e => e.BlogId == key) > 0;
        }
    }
}
