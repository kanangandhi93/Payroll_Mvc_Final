using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using System.Configuration;

namespace Payroll_Mvc.Controllers
{
    public class stateController : Controller
    {
        // GET: state
        public ActionResult Index()
        {
            stateBusinessLayer StateBusinessLayer = new stateBusinessLayer();
            List<state> State = new List<state>();
            State = StateBusinessLayer.States.ToList();
            return View(State);
        }
        [HttpGet]
        public ActionResult Create()
        {
            CountryBusinessLayer countryBusinessLayer = new CountryBusinessLayer();
            ViewBag.Countries = new SelectList(countryBusinessLayer.countries, "Id", "CountryName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            state State = new state();
            State.State = formCollection["State"];
            State.CountryId = Convert.ToInt64(formCollection["countries"]);

            stateBusinessLayer StateBusinessLayer = new stateBusinessLayer();
            int rv = StateBusinessLayer.AddState(State);
            if (rv != 0 && rv != -1)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(Int64 id)
        {

            stateBusinessLayer StateBusinessLayer = new stateBusinessLayer();
            state State = StateBusinessLayer.States.Single(x => x.Id == id);
            ConfigurationManager.AppSettings["EditId"] = id.ToString();

            CountryBusinessLayer countryBusinessLayer = new CountryBusinessLayer();
            List<SelectListItem> selectlistitems = new List<SelectListItem>();
            foreach (Country country in countryBusinessLayer.countries)
            {
                SelectListItem selectListItem = new SelectListItem
                {
                    Text = country.CountryName,
                    Value = country.Id.ToString(),
                    Selected = country.Id == State.CountryId ? true : false
                };
                selectlistitems.Add(selectListItem);
            }
            ViewBag.countries = selectlistitems;
            return View(State);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection formCollection)
        {
            state State = new state();
            State.State = formCollection["State"];
            State.CountryId = Convert.ToInt64(formCollection["countries"]);
            State.Id = Convert.ToInt64(ConfigurationManager.AppSettings["EditId"].ToString());

            stateBusinessLayer StateBusinessLayer = new stateBusinessLayer();
            int rv = StateBusinessLayer.UpdateState(State);
            if (rv != 0 && rv != -1)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(Int64 id)
        {
            stateBusinessLayer StateBusinessLayer = new stateBusinessLayer();
            state State = StateBusinessLayer.States.Single(x => x.Id == id);
            ConfigurationManager.AppSettings["EditId"] = id.ToString();
            CountryBusinessLayer countryBusinessLayer = new CountryBusinessLayer();
            Country country = countryBusinessLayer.countries.Single(x => x.Id == State.CountryId);
            State.CountryName = country.CountryName;
            return View(State);
        }

        [HttpPost]
        public ActionResult Delete(FormCollection formCollection)
        {
            stateBusinessLayer StateBusinessLayer = new stateBusinessLayer();
            state State = new state();
            State.State = formCollection["State"];
            State.CountryId = Convert.ToInt64(formCollection["CountryId"]);
            State.Id = Convert.ToInt64(ConfigurationManager.AppSettings["EditId"].ToString());
            int rv = StateBusinessLayer.DeleteState(State);
            if (rv != 0 && rv != -1)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
