using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using System.IO;

namespace Payroll_Mvc.Controllers
{
    public class companydetailController : Controller
    {
        // GET: companydetail
        public ActionResult Index()
        {
            CompanyDetailBusinessLayer companyDetailBusinessLayer = new CompanyDetailBusinessLayer();
            List<companydetails> Companydetails = companyDetailBusinessLayer.Companydetails.ToList();
            if (Companydetails.Count>0)
            {
                return View(Companydetails); 
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        // GET: companydetail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: companydetail/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: companydetail/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, HttpPostedFileBase postedFile)
        {
            //try
            //{
            // TODO: Add insert logic here
            if (postedFile != null)
            {
                string path = Server.MapPath("~/Company_Logo/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var fileName = Path.GetFileName(postedFile.FileName);
                var paths = Path.Combine(Server.MapPath("~/Company_Logo/"), fileName);
                postedFile.SaveAs(paths);
                // postedFile.SaveAs(Server.MapPath("~/Company_Logo/" + Path.GetFileName(postedFile.FileName)));
                ViewBag.Message = "File uploaded successfully.";
                CompanyDetailBusinessLayer companyDetailBusinessLayer = new CompanyDetailBusinessLayer();
                companydetails Companydetails = new companydetails();
                Companydetails.AddressLine1 = collection["AddressLine1"];
                Companydetails.AddressLine2 = collection["AddressLine2"];
                Companydetails.AddressLine3 = collection["AddressLine3"];
                Companydetails.city = collection["city"];
                Companydetails.CompanyLogo = "~/Company_Logo/" + fileName;
                Companydetails.CompanyName = collection["CompanyName"];
                Companydetails.ContactNo1 = Convert.ToInt64(collection["ContactNo1"]);
                Companydetails.ContactNo2 = Convert.ToInt64(collection["ContactNo2"]);
                Companydetails.Country = collection["Country"];
                Companydetails.CUser = 1;
                Companydetails.EmailId = collection["EmailId"];
                Companydetails.FaxNo = Convert.ToInt64(collection["FaxNo"]);
                Companydetails.FoundedYear = collection["FoundedYear"];
                Companydetails.Founder1 = collection["Founder1"];
                Companydetails.Founder2 = collection["Founder2"];
                Companydetails.Founder3 = collection["Founder3"];
                Companydetails.Founder4 = collection["Founder4"];
                Companydetails.Founder5 = collection["Founder5"];
                Companydetails.potalcode = collection["potalcode"];
                Companydetails.state = collection["state"];
                int rv = companyDetailBusinessLayer.Addcompanydetails(Companydetails);
                if (rv != -1 && rv != 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
            //return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: companydetail/Edit/5
        public ActionResult Edit(int id)
        {
            CompanyDetailBusinessLayer companyDetailBusinessLayer = new CompanyDetailBusinessLayer();
            companydetails Companydetails = companyDetailBusinessLayer.Companydetails.Single(x => x.Id == Convert.ToInt64(id));
            ViewBag.Img = Companydetails.CompanyLogo;
            return View(Companydetails);
        }

        // POST: companydetail/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                // postedFile.SaveAs(Server.MapPath("~/Company_Logo/" + Path.GetFileName(postedFile.FileName)));
                //  ViewBag.Message = "File uploaded successfully.";
                CompanyDetailBusinessLayer companyDetailBusinessLayer = new CompanyDetailBusinessLayer();
                companydetails Companydetails = new companydetails();
                Companydetails.AddressLine1 = collection["AddressLine1"];
                Companydetails.AddressLine2 = collection["AddressLine2"];
                Companydetails.AddressLine3 = collection["AddressLine3"];
                Companydetails.city = ViewBag.Img;
                Companydetails.CompanyLogo = collection["CompanyLogo"];
                Companydetails.CompanyName = collection["CompanyName"];
                Companydetails.city = collection["City"];
                Companydetails.ContactNo1 = Convert.ToInt64(collection["ContactNo1"]);
                Companydetails.ContactNo2 = Convert.ToInt64(collection["ContactNo2"]);
                Companydetails.Country = collection["Country"];
                Companydetails.UUser = 1;
                Companydetails.EmailId = collection["EmailId"];
                Companydetails.FaxNo = Convert.ToInt64(collection["FaxNo"]);
                Companydetails.FoundedYear = collection["FoundedYear"];
                Companydetails.Founder1 = collection["Founder1"];
                Companydetails.Founder2 = collection["Founder2"];
                Companydetails.Founder3 = collection["Founder3"];
                Companydetails.Founder4 = collection["Founder4"];
                Companydetails.Founder5 = collection["Founder5"];
                Companydetails.potalcode = collection["potalcode"];
                Companydetails.state = collection["state"];
                Companydetails.Id = Convert.ToInt64(id);
                int rv = companyDetailBusinessLayer.Updatecompanydetails(Companydetails);
                if (rv != -1 && rv != 0)
                {
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: companydetail/Delete/5
        public ActionResult EditLogo(int id)
        {
            return View();
        }

        // POST: companydetail/Delete/5
        [HttpPost]
        public ActionResult EditLogo(int id, FormCollection collection, HttpPostedFileBase postedFile)
        {
            try
            {
                // TODO: Add delete logic here
                CompanyDetailBusinessLayer companyDetailBusinessLayer = new CompanyDetailBusinessLayer();
                companydetails Companydetails = new companydetails();

                if (postedFile != null)
                {
                    string path = Server.MapPath("~/Company_Logo/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    var fileName = Path.GetFileName(postedFile.FileName);
                    var paths = Path.Combine(Server.MapPath("~/Company_Logo/"), fileName);
                    postedFile.SaveAs(paths);
                    collection["CompanyLogo"] = "~/Company_Logo/" + fileName;
                }
                else
                {
                    collection["CompanyLogo"] = collection["CompanyLogo"];
                }
                Companydetails.CompanyLogo = collection["CompanyLogo"];
                Companydetails.Id = Convert.ToInt64(id);
                int rv = companyDetailBusinessLayer.UpdatecompanyLogo(Companydetails);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
