using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LearningCompany.Entities;

namespace LearningCompany.Controllers
{
    public class SessionFormationsController : Controller
    {
        private LearningCompanyContext _db = new LearningCompanyContext();

        // GET: SessionFormations
        public ActionResult Index()
        {
            var sessionsFormations = _db.SessionsFormations.Include(s => s.Commercial).Include(s => s.Formateur).Include(s => s.Formation);
            return View(sessionsFormations.ToList());
        }

        // GET: SessionFormations/Details/5
        public ActionResult Details(int? id, int? formationId)
        {
            if (id == null || formationId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SessionFormation sessionFormation = _db.SessionsFormations.Find(id, formationId);

            if (sessionFormation == null)
            {
                return HttpNotFound();
            }

            return View(sessionFormation);
        }

        // GET: SessionFormations/Create
        public ActionResult Create()
        {
            ViewBag.CommercialID = new SelectList(_db.Commerciaux, "CommercialID", "NomComplet");
            ViewBag.FormateurID = new SelectList(_db.Formateurs, "FormateurID", "NomComplet");
            ViewBag.FormationID = new SelectList(_db.Formations, "FormationID", "ShortDescription");
            return View();
        }

        // POST: SessionFormations/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SessionFormationID,FormationID,DateDebut,DateFin,Intervenant,FormateurID,CommercialID")] SessionFormation sessionFormation)
        {
            if (ModelState.IsValid)
            {
                _db.SessionsFormations.Add(sessionFormation);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CommercialID = new SelectList(_db.Commerciaux, "CommercialID", "NomComplet", sessionFormation.CommercialID);
            ViewBag.FormateurID = new SelectList(_db.Formateurs, "FormateurID", "NomComplet", sessionFormation.FormateurID);
            ViewBag.FormationID = new SelectList(_db.Formations, "FormationID", "ShortDescription", sessionFormation.FormationID);
            return View(sessionFormation);
        }

        // GET: SessionFormations/Edit/5
        public ActionResult Edit(int? id, int? formationId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionFormation sessionFormation = _db.SessionsFormations.Find(id, formationId);
            if (sessionFormation == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommercialID = new SelectList(_db.Commerciaux, "CommercialID", "NomUtilisateur", sessionFormation.CommercialID);
            ViewBag.FormateurID = new SelectList(_db.Formateurs, "FormateurID", "Nom", sessionFormation.FormateurID);
            ViewBag.FormationID = new SelectList(_db.Formations, "FormationID", "Reference", sessionFormation.FormationID);
            return View(sessionFormation);
        }

        // POST: SessionFormations/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SessionFormationID,FormationID,DateDebut,DateFin,Intervenant,FormateurID,CommercialID")] SessionFormation sessionFormation)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(sessionFormation).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CommercialID = new SelectList(_db.Commerciaux, "CommercialID", "NomUtilisateur", sessionFormation.CommercialID);
            ViewBag.FormateurID = new SelectList(_db.Formateurs, "FormateurID", "Nom", sessionFormation.FormateurID);
            ViewBag.FormationID = new SelectList(_db.Formations, "FormationID", "Reference", sessionFormation.FormationID);
            return View(sessionFormation);
        }

        // GET: SessionFormations/Delete/5
        public ActionResult Delete(int? id, int? formationId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionFormation sessionFormation = _db.SessionsFormations.Find(id, formationId);
            if (sessionFormation == null)
            {
                return HttpNotFound();
            }
            return View(sessionFormation);
        }

        // POST: SessionFormations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SessionFormation sessionFormation = _db.SessionsFormations.Find(id);
            _db.SessionsFormations.Remove(sessionFormation);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
