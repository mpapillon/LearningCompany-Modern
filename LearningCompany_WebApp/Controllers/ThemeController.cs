using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningCompany.Entities;

namespace LearningCompany.Controllers
{
    public class ThemeController : Controller
    {
        private LearningCompanyContext _db = new LearningCompanyContext();

        // GET: /Theme/Navigation
        public ActionResult Navigation()
        {
            var themes = _db.Themes.ToList().OrderBy(t => t.Libelle);
            return PartialView("_Navigation", themes);
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