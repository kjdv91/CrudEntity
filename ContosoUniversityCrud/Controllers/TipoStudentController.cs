using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContosoUniversityCrud.Data;
using ContosoUniversityCrud.Models;

namespace ContosoUniversityCrud.Controllers
{
    public class TipoStudentController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: TipoStudent
        public ActionResult Index()
        {
            var tipoStudents = db.TipoStudents.Include(t => t.Student);
            return View(tipoStudents.ToList());
        }

        // GET: TipoStudent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoStudent tipoStudent = db.TipoStudents.Find(id);
            if (tipoStudent == null)
            {
                return HttpNotFound();
            }
            return View(tipoStudent);
        }

        // GET: TipoStudent/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Students, "ID", "LastName");
            return View();
        }

        // POST: TipoStudent/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cod,Modalidad,Jornada,ID")] TipoStudent tipoStudent)
        {
            if (ModelState.IsValid)
            {
                db.TipoStudents.Add(tipoStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Students, "ID", "LastName", tipoStudent.ID);
            return View(tipoStudent);
        }

        // GET: TipoStudent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoStudent tipoStudent = db.TipoStudents.Find(id);
            if (tipoStudent == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Students, "ID", "LastName", tipoStudent.ID);
            return View(tipoStudent);
        }

        // POST: TipoStudent/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cod,Modalidad,Jornada,ID")] TipoStudent tipoStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Students, "ID", "LastName", tipoStudent.ID);
            return View(tipoStudent);
        }

        // GET: TipoStudent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoStudent tipoStudent = db.TipoStudents.Find(id);
            if (tipoStudent == null)
            {
                return HttpNotFound();
            }
            return View(tipoStudent);
        }

        // POST: TipoStudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoStudent tipoStudent = db.TipoStudents.Find(id);
            db.TipoStudents.Remove(tipoStudent);
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
