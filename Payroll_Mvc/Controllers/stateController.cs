using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
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
    }
}