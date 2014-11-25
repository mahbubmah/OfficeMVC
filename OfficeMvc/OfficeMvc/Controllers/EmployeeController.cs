using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OfficeMvc.Models;

namespace OfficeMvc.Controllers
{
    public class EmployeeController : Controller
    {
        private OfficeEntities db = new OfficeEntities();


        

     

        // GET: /Employee/
        public ActionResult Index()
        {
            var emp = db.tblOffices.ToList();
            double totalSalary = 0;
            foreach (var item in emp)
            {
                double total = (item.Basic + (item.Conveyance * (item.Basic / 100)) + (item.HouseRent * (item.Basic / 100)));
                totalSalary += total;
            }
            ViewBag.total = totalSalary;
            return View(db.tblOffices.ToList());
        }

        // GET: /Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOffice tbloffice = db.tblOffices.Find(id);
            if (tbloffice == null)
            {
                return HttpNotFound();
            }
            return View(tbloffice);
        }

        // GET: /Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Designation,Email,Basic,Conveyance,HouseRent,EmployeeId")] tblOffice tbloffice)
        {
            if (ModelState.IsValid)
            {
                db.tblOffices.Add(tbloffice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbloffice);
        }

        // GET: /Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOffice tbloffice = db.tblOffices.Find(id);
            if (tbloffice == null)
            {
                return HttpNotFound();
            }
            return View(tbloffice);
        }

        // POST: /Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Designation,Email,Basic,Conveyance,HouseRent,EmployeeId")] tblOffice tbloffice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbloffice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbloffice);
        }

        // GET: /Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOffice tbloffice = db.tblOffices.Find(id);
            if (tbloffice == null)
            {
                return HttpNotFound();
            }
            return View(tbloffice);
        }

        // POST: /Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblOffice tbloffice = db.tblOffices.Find(id);
            db.tblOffices.Remove(tbloffice);
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
