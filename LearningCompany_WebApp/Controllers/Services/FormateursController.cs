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
    public class FormateursController : ApiController
    {
        private LearningCompanyContext _db = new LearningCompanyContext();

        public FormateursController()
        {
            this._db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/Formateurs
        public IQueryable<Formateur> GetFormateurs()
        {
            return _db.Formateurs.Include(f => f.Civilite);
        }

        // GET: api/Formateurs/5
        [ResponseType(typeof(Formateur))]
        public IHttpActionResult GetFormateur(int id)
        {
            Formateur formateur = _db.Formateurs.Include(f => f.Civilite).FirstOrDefault(f => f.FormateurID == id);
            if (formateur == null)
            {
                return NotFound();
            }

            return Ok(formateur);
        }

        // PUT: api/Formateurs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFormateur(int id, Formateur formateur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != formateur.FormateurID)
            {
                return BadRequest();
            }

            _db.Entry(formateur).State = System.Data.Entity.EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormateurExists(id))
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

        // POST: api/Formateurs
        [ResponseType(typeof(Formateur))]
        public IHttpActionResult PostFormateur(Formateur formateur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Formateurs.Add(formateur);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = formateur.FormateurID }, formateur);
        }

        // DELETE: api/Formateurs/5
        [ResponseType(typeof(Formateur))]
        public IHttpActionResult DeleteFormateur(int id)
        {
            Formateur formateur = _db.Formateurs.Find(id);
            if (formateur == null)
            {
                return NotFound();
            }

            _db.Formateurs.Remove(formateur);
            _db.SaveChanges();

            return Ok(formateur);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FormateurExists(int id)
        {
            return _db.Formateurs.Count(e => e.FormateurID == id) > 0;
        }
    }
}