using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LUSSISADTeam10Web.Controllers
{
    public class HeadofDepartmentController : Controller
    {
        // GET: HeadofDepartment
        public ActionResult Index()
        {
            return View();
        }

        // GET: HeadofDepartment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HeadofDepartment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HeadofDepartment/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HeadofDepartment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HeadofDepartment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HeadofDepartment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HeadofDepartment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
