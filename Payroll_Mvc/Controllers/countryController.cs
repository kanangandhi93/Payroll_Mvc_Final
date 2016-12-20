using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Payroll_Mvc.Models;

namespace Payroll_Mvc.Controllers
{
    public class countryController : Controller
    {
        // GET: country
        public ActionResult Index()
        {
            PayrollContext db = new PayrollContext();
            List<country> Countries = db.Country.ToList();
            return View(Countries);
        }

        public ActionResult Edit(Int64 id)
        {
            PayrollContext db = new PayrollContext();
            country Countries = db.Country.Single(x => x.Id == id);
            return View(Countries);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
    }
}