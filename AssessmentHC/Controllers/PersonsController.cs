using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssessmentHC.Models;
using System.IO;

namespace AssessmentHC.Controllers
{
    public class PersonsController : Controller
    {
        IPersonRepository _repository;
        public PersonsController() : this(new EntityPersonRepository())
        {
        }
        public PersonsController(IPersonRepository repository)
        {
            _repository = repository;
        }
       
        private PersonContext db = new PersonContext();

        // GET: Students
        public ActionResult Index()
        {
            return View();
            //return View(db.students.ToList());
        }

        //Get Student by Name 
        public ActionResult Search(string searchText)
        {
            
           IEnumerable<Person> results = _repository.GetAllPersonsByName(searchText);          
            return PartialView("_SearchPartial", results);
        }
        
        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FName,LName,Age,Address,Interests")] Person person, HttpPostedFileBase file)
        {

                if (ModelState.IsValid)
                {
                    if (file != null)
                    {
                        if (file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/Content/ProfileImages"), person.Id.ToString() + "_" + fileName);
                            file.SaveAs(path);
                            person.ProfileImgPath = Path.Combine("~/Content/ProfileImages", person.Id.ToString() + "_" + fileName);
                        }
                    }
                    _repository.CreateNewPerson(person);
                    _repository.SaveChanges();
                    ViewBag.Message = "Upload successful";
                return RedirectToAction("Index");
                }
                return View(person);
           
            
        }

              protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
