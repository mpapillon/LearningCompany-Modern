using LearningCompany.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningCompany.Controllers
{
    [Authorize]
    public class CommercialController : Controller
    {
        private LearningCompanyContext _db = new LearningCompanyContext();

        //
        // GET: /Commercial/Edit

        public ActionResult Edit()
        {
            var commercial = _db.Commerciaux.FirstOrDefault(c => c.NomUtilisateur == User.Identity.Name);
            ViewBag.CiviliteID = new SelectList(_db.Civilites, "CiviliteID", "LibelleCourt", commercial.CiviliteID);

            return View(commercial);
        }

        //
        // POST: /Commercial/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommercialID,NomUtilisateur,MotDePasse,Nom,Prenom,Courriel,CiviliteID")] Commercial commercial)
        {
            // Bind a automatiquement hydraté notre entité.
            if (ModelState.IsValid)
            {
                // On indique à EF que l'entité a été mondifiée, seul les attributs modifiés seront sauvegardés
                _db.Entry(commercial).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Edit");
            }

            ViewBag.CiviliteID = new SelectList(null, "CiviliteID", "LibelleCourt", commercial.CiviliteID);
            return View(commercial);
        }
    }
}
