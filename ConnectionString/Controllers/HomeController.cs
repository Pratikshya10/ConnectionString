using ConnectionString.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConnectionString.Controllers
{
    public class HomeController : Controller
    {
        Student obj = new Student();
        // GET: Home
        public ActionResult Index()
        {
            var response = obj.GetStudentsDetails();
            return View(response);
        }

        // GET: Home/Details/5
        public ActionResult Details(string id)
        {
            //create view and filter single user and pass that value to view
            var singleUser = obj.GetStudentsDetails().Find(obj => obj.StuId == id);
            return View(singleUser);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            //create view here
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, Student data)
        {
            try
            {
                // TODO: Add insert logic here
                obj.CreateUser(data);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
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

        // GET: Home/Delete/5
        public ActionResult Delete(string id)
        {
            var singleUser = obj.GetStudentsDetails().Find(obj => obj.StuId == id);
            return View(singleUser);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                obj.DeleteUser(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
