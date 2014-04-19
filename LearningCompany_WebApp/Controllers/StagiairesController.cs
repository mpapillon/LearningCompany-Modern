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
    public class StagiairesController : ApiController
    {
        private LearningCompanyContext _db = new LearningCompanyContext();

        public StagiairesController()
        {
            this._db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/Stagiaires
        public IQueryable<Stagiaire> GetStagiaires()
        {
            return _db.Stagiaires.Include(s => s.Civilite);
        }

        // GET: api/Stagiaires/5
        [ResponseType(typeof(Stagiaire))]
        public IHttpActionResult GetStagiaire(int id)
        {
            Stagiaire stagiaire = _db.Stagiaires.Include(s => s.Civilite).FirstOrDefault(s => s.StagiaireID == id);
            if (stagiaire == null)
            {
                return NotFound();
            }

            return Ok(stagiaire);
        }

        // PUT: api/Stagiaires/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStagiaire(int id, Stagiaire stagiaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stagiaire.StagiaireID)
            {
                return BadRequest();
            }

            _db.Entry(stagiaire).State = System.Data.Entity.EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StagiaireExists(id))
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

        // POST: api/Stagiaires
        [ResponseType(typeof(Stagiaire))]
        public IHttpActionResult PostStagiaire(Stagiaire stagiaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Stagiaires.Add(stagiaire);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = stagiaire.StagiaireID }, stagiaire);
        }

        // DELETE: api/Stagiaires/5
        [ResponseType(typeof(Stagiaire))]
        public IHttpActionResult DeleteStagiaire(int id)
        {
            Stagiaire stagiaire = _db.Stagiaires.Find(id);
            if (stagiaire == null)
            {
                return NotFound();
            }

            _db.Stagiaires.Remove(stagiaire);
            _db.SaveChanges();

            return Ok(stagiaire);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StagiaireExists(int id)
        {
            return _db.Stagiaires.Count(e => e.StagiaireID == id) > 0;
        }
    }
}