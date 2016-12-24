using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using System.Configuration;

namespace Payroll_Mvc.Controllers
{
    public class roleController : Controller
    {
        // GET: role
        public ActionResult Index()
        {
            RoleBusinessLayer roleBusinessLayer = new RoleBusinessLayer();
            List<Role> roles = roleBusinessLayer.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            Role role = new Role();
            role.RoleName = formCollection["RoleName"];
            role.cuser = 1;
            RoleBusinessLayer roleBusinessLayer = new RoleBusinessLayer();
            int rv = roleBusinessLayer.AddRole(role);
            if (rv != 0 && rv != -1)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            RoleBusinessLayer roleBusinessLayer = new RoleBusinessLayer();
            Role role = roleBusinessLayer.Roles.Single(x => x.Id == id);
            ConfigurationManager.AppSettings["EditId"] = id.ToString();
            return View(role);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection formCollection)
        {
            Role role = new Role();
            role.RoleName = formCollection["RoleName"];
            role.UUser = 1;
            role.Id = Convert.ToInt64(ConfigurationManager.AppSettings["EditId"]);
            RoleBusinessLayer roleBusinessLayer = new RoleBusinessLayer();
            int rv = roleBusinessLayer.UpdateRole(role);
            if (rv != 0 && rv != -1)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            RoleBusinessLayer roleBusinessLayer = new RoleBusinessLayer();
            Role role = roleBusinessLayer.Roles.Single(x => x.Id == id);
            ConfigurationManager.AppSettings["EditId"] = id.ToString();
            return View(role);
        }

        [HttpPost]
        public ActionResult Delete(FormCollection formCollection)
        {
            Role role = new Role();
            role.UUser = 1;
            role.Id = Convert.ToInt64(ConfigurationManager.AppSettings["EditId"]);
            RoleBusinessLayer roleBusinessLayer = new RoleBusinessLayer();
            int rv = roleBusinessLayer.DeleteRole(role);
            if (rv != 0 && rv != -1)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}