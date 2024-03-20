using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KlioWebApplication.Controllers
{
    public class HomeController : Controller
    {
        KlioAppContext _Context = new KlioAppContext();
        public ActionResult Index()
        {
            
            var listofData = _Context.Students.ToList();
            return View(listofData);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student Model)
        {
            _Context.Students.Add(Model);
            _Context.SaveChanges();

            ViewBag.message = "Data Insert Successfully";
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Edit(int id )
        {
            var data = _Context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Student Model)
        {
            var data = _Context.Students.Where(x => x.StudentId == Model.StudentId).FirstOrDefault();
            if(data !=null)
            {
                data.StudentName = Model.StudentName;
                data.StudentFees = Model.StudentFees;
                data.StudentCity = Model.StudentCity;
                _Context.SaveChanges();
            }
            return RedirectToAction("index");
        }

        public ActionResult Details(int id)
        {
            var data = _Context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult Delete(int id )
        {
            var data = _Context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            _Context.Students.Remove(data);
            _Context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }

    }
}