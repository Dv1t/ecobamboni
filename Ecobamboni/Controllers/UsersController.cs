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
    public class UsersController : ApiController
    {
        private UserContext db = new UserContext();

        // GET: api/Users
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        //public IHttpActionResult GetUser(string authorization)
        //{
        //    string[] auth = authorization.Split(';');
        //    if (db.Users.Find(auth[0]) != null)
        //    {
        //        User user = db.Users.Find(auth[0]);
        //        if (user.Password == auth[1])
        //            return CreatedAtRoute("DefaultApp/api/Users", user.Id, user.Role);
        //    }
        //    return BadRequest();
        //} 

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (db.Users.Find(user.Login) != null)
            {
                return CreatedAtRoute("DefaultApi", user.Login, "Login is already used");
            }
                

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        [ResponseType(typeof(int))]
        public IHttpActionResult PostUser(string login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //if (db.Users.Find(login) != null)
            //{
            //    User user = db.Users.Find(login);
            //    if (user.Password == password)
            //        return CreatedAtRoute("DefaultApi", user, user.Role);
            //    else return CreatedAtRoute("DefaultApi", null, -1);
            //}

            return CreatedAtRoute("DefaultApi", null, -1);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}