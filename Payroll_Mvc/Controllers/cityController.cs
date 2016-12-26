using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace Payroll_Mvc.Controllers
{
    public class cityController : Controller
    {
        // GET: city
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            CountryBusinessLayer countryBusinessLayer = new CountryBusinessLayer();
            ViewBag.countries = new SelectList(countryBusinessLayer.countries.ToList(), "Id", "CountryName");
            return View();
        }

        public ActionResult Create(FormCollection formCollection)
        {
            List<SelectListItem> selectlistitems = new List<SelectListItem>();
            List<SelectListItem> countryselectlistitems = new List<SelectListItem>();
            stateBusinessLayer StateBusinessLayer = new stateBusinessLayer();
            CountryBusinessLayer countryBusinessLayer = new CountryBusinessLayer();
            foreach (state State in StateBusinessLayer.States.Where(x => x.CountryId == Convert.ToInt64(formCollection["countries"])))
            {
                SelectListItem selectListItem = new SelectListItem
                {
                    Text = State.State,
                    Value = State.Id.ToString(),
                };
                selectlistitems.Add(selectListItem);
            }
            foreach (Country country in countryBusinessLayer.countries)
            {
                SelectListItem selectListItem1 = new SelectListItem
                {
                    Text = country.CountryName,
                    Value = country.Id.ToString(),
                    Selected = (country.Id == Convert.ToInt64(formCollection["countries"]) ? true : false)
                };
                countryselectlistitems.Add(selectListItem1);
            }
            //ViewBag.countries = new SelectList(countryBusinessLayer.countries.ToList(), "Id", "CountryName", formCollection["countries"]);
            ViewBag.States = new SelectList(selectlistitems, "Value", "Text");
            return View();
        }

    }
}