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
using Ecobamboni.Models;

namespace Ecobamboni.Controllers
{
    public class ContainersController : ApiController
    {
        private ContainerContext db = new ContainerContext();

        // GET: api/Containers
        public IQueryable<Container> GetContainers()
        {
            return db.Containers;
        }

        // GET: api/Containers/5
        [ResponseType(typeof(Container))]
        public IHttpActionResult GetContainer(int id)
        {
            Container container = db.Containers.Find(id);
            if (container == null)
            {
                return NotFound();
            }

            return Ok(container);
        }

        // PUT: api/Containers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContainer(int id, Container container)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != container.Id)
            {
                return BadRequest();
            }

            db.Entry(container).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContainerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Containers
        [ResponseType(typeof(Container))]
        public IHttpActionResult PostContainer(Container container)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (db.Containers.Find(container.Id) != null)
            {
                var oldContainer = db.Containers.Find(container.Id);
                oldContainer.Fullness = container.Fullness;
                oldContainer.Location = container.Location;
            }
            else
            {
                db.Containers.Add(container);
            }
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = container.Id }, container);
        }

        // DELETE: api/Containers/5
        [ResponseType(typeof(Container))]
        public IHttpActionResult DeleteContainer(int id)
        {
            Container container = db.Containers.Find(id);
            if (container == null)
            {
                return NotFound();
            }

            db.Containers.Remove(container);
            db.SaveChanges();

            return Ok(container);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContainerExists(int id)
        {
            return db.Containers.Count(e => e.Id == id) > 0;
        }
    }
}