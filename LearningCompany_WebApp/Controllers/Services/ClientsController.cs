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
using LearningCompany.Entities;

namespace LearningCompany.Controllers
{
    public class ClientsController : ApiController
    {
        private LearningCompanyContext _db = new LearningCompanyContext();

        public ClientsController()
        {
            this._db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/Clients
        public IQueryable<Client> GetClients()
        {
            return _db.Clients;
        }

        // GET: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetClient(int id)
        {
            Client client = _db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.ClientID)
            {
                return BadRequest();
            }

            _db.Entry(client).State = System.Data.Entity.EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        [ResponseType(typeof(Client))]
        public IHttpActionResult PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Clients.Add(client);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = client.ClientID }, client);
        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult DeleteClient(int id)
        {
            Client client = _db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            _db.Clients.Remove(client);
            _db.SaveChanges();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return _db.Clients.Count(e => e.ClientID == id) > 0;
        }
    }
}