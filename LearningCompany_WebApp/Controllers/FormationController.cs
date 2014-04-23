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
        private LearningCompanyContext _db = new LearningCompanyContext();

        // GET: /Formation/
        public ActionResult Index(int? theme)
        {
            if (theme.HasValue)
            {
                return View(_db.Themes.Find(theme).Formations);
            }
            else
            {
                return View(_db.Formations.Include(f => f.Theme));
            }
        }

        // GET: /Formation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formation formation = _db.Formations.Find(id);
            if (formation == null)
            {
                return HttpNotFound();
            }
            return View(formation);
        }

        // GET: /Formation/Create
        [Authorize]
        public ActionResult Create(string type)
        {
            ViewBag.ThemeID = new SelectList(_db.Themes, "ThemeID", "Libelle");

            switch (type)
            {
                case "presentielle":
                    return View("CreatePresentielle");

                case "elearning":
                    return View("CreateElearning");

                default:
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: /Formation/Create
        [HttpPost, Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string type, [Bind(Include="FormationID,Reference,Libelle,NombreJours,Prix,Description,ThemeID")] Formation formation, FormCollection form)
        {
            ViewBag.ThemeID = new SelectList(_db.Themes, "ThemeID", "Libelle", formation.ThemeID);

            switch (type)
            {
                case "presentielle":
                    FormationPresentielle formationP = new FormationPresentielle(formation);
                    formationP.Lieu = form["Lieu"];
                    if (ModelState.IsValid)
                    {
                        _db.Formations.Add(formationP);
                        _db.SaveChanges();
                        return RedirectToAction("Details", new { id = formationP.FormationID });
                    }
                    return View("CreatePresentielle", formationP);

                case "elearning":
                    FormationElearning formationE = new FormationElearning(formation);
                    formationE.Url = form["Url"];
                    if (ModelState.IsValid)
                    {
                        _db.Formations.Add(formationE);
                        _db.SaveChanges();
                        return RedirectToAction("Details", new { id = formationE.FormationID });
                    }
                    return View("CreateElearning", formationE);

                default:
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //return View(formation);
        }

        // GET: /Formation/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formation formation = _db.Formations.Find(id);
            if (formation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ThemeID = new SelectList(_db.Themes, "ThemeID", "Libelle", formation.ThemeID);
            return View(formation);
        }

        // POST: /Formation/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="FormationID,Reference,Libelle,NombreJours,Prix,Description,ThemeID")] Formation formation)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(formation).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ThemeID = new SelectList(_db.Themes, "ThemeID", "Libelle", formation.ThemeID);
            return View(formation);
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
