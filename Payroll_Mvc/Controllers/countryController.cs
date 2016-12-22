using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Payroll_Mvc.Models;
using BusinessLayer;

namespace Payroll_Mvc.Controllers
{
    public class countryController : Controller
    {
        // GET: country
        public ActionResult Index()
        {
            //PayrollContext db = new PayrollContext();
            CountryBusinessLayer countryBusinessLayer = new CountryBusinessLayer();
            List<Country> countries = countryBusinessLayer.countries.ToList();
            //List<country> Countries = db.Country.ToList();
            return View(countries);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection formcollection)
        {
            Country country = new Country();
            country.CountryName = formcollection["CountryName"];

            CountryBusinessLayer countryBusinessLayer = new CountryBusinessLayer();
            int rv = countryBusinessLayer.AddCountry(country);
            if (rv != 0 && rv != -1)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(Int64 id)
        {
            CountryBusinessLayer db = new CountryBusinessLayer();
            Country country = db.countries.SingleOrDefault(x => x.Id == id);
            Session["EditId"] = id;
            return View(country);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection formcollection)
        {
            CountryBusinessLayer countryBusinessLayer = new CountryBusinessLayer();
            Country country = new Country();
            country.CountryName = formcollection["CountryName"];
            countryBusinessLayer.Id = Convert.ToInt64(Session["EditId"].ToString());

            int rv = countryBusinessLayer.UpdateCountry(country);
            if (rv != 0 && rv != -1)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(Int64 id)
        {
            CountryBusinessLayer db = new CountryBusinessLayer();
            Country country = db.countries.SingleOrDefault(x => x.Id == id);
            Session["DeleteId"] = id;
            return View(country);
        }

        [HttpPost]
        public ActionResult Delete(FormCollection formcollection)
        {
            CountryBusinessLayer countryBusinessLayer = new CountryBusinessLayer();
            Country country = new Country();
            country.Id = Convert.ToInt64(Session["DeleteId"].ToString());

            int rv = countryBusinessLayer.DeleteCountry(country);
            if (rv != 0 && rv != -1)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}