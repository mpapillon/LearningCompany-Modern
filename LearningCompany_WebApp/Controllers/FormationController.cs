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
    public class FormationController : Controller
    {
        private LearningCompanyContext db = new LearningCompanyContext();

        // GET: /Formation/
        public ActionResult Index()
        {
            var formations = db.Formations.Include(f => f.Theme);
            return View(formations.ToList());
        }

        // GET: /Formation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formation formation = db.Formations.Find(id);
            if (formation == null)
            {
                return HttpNotFound();
            }
            return View(formation);
        }

        // GET: /Formation/CreateElearning
        public ActionResult CreateElearning()
        {
            ViewBag.ThemeID = new SelectList(db.Themes, "ThemeID", "Libelle");
            return View();
        }

        // POST: /Formation/CreateElearning
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateElearning([Bind(Include="FormationID,Reference,Libelle,NombreJours,Prix,Decription, Url,ThemeID")] FormationElearning formation)
        {
            if (ModelState.IsValid)
            {
                db.Formations.Add(formation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ThemeID = new SelectList(db.Themes, "ThemeID", "Libelle", formation.ThemeID);
            return View(formation);
        }

        // GET: /Formation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formation formation = db.Formations.Find(id);
            if (formation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ThemeID = new SelectList(db.Themes, "ThemeID", "Libelle", formation.ThemeID);
            return View(formation);
        }

        // POST: /Formation/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="FormationID,Reference,Libelle,NombreJours,Prix,Decription,ThemeID")] Formation formation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formation).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ThemeID = new SelectList(db.Themes, "ThemeID", "Libelle", formation.ThemeID);
            return View(formation);
        }

        // GET: /Formation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formation formation = db.Formations.Find(id);
            if (formation == null)
            {
                return HttpNotFound();
            }
            return View(formation);
        }

        // POST: /Formation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Formation formation = db.Formations.Find(id);
            db.Formations.Remove(formation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
