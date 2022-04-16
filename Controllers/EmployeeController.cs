using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Tutorial7.Models;
using System.Reflection;
using System.Collections.Generic;
namespace Tutorial7.Controllers

{
    public class EmployeeController : Controller
    {
        private EmployeeDBEntities db = new EmployeeDBEntities();

        // GET: Employee
        public ActionResult Index()
        {
            return View(db.EmployeeDetails.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetail);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
      
        public ActionResult Create([Bind(Include = "au_id,au_lname,au_fname,phone,address,city,state,zip,contract")] EmployeeDetail employeeDetail)
        {
            if (ModelState.IsValid)
            {
               db.Entry(employeeDetail).State = EntityState.Added;
               db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeDetail);	
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetail);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "au_id,au_lname,au_fname,phone,address,city,state,zip,contract")] EmployeeDetail employeeDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeDetail);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetail);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
    
        public ActionResult DeleteConfirmed(string id)
        {
            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(id);
            db.EmployeeDetails.Remove(employeeDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
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
