using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using System.Data.Entity;

namespace WebApplication3.Controllers
{
    public class SyllabusController : Controller
    {

        StudentDBContext db = new StudentDBContext();
        // GET: Syllabus
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult AddData(Syllabus model)
        {
            string result = string.Empty;

            try
            {
                db.CourseSyllabus.Add(model);
                db.SaveChanges();
                result = "Inserted";
            }
            catch (Exception)
            {
                result = "failed";
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit()
        {
           
            return View();
        }

        public JsonResult UpdateRecord(Syllabus model)
        {
           
                using (StudentDBContext db = new StudentDBContext())
                {
                    Syllabus tblSyllabus = db.CourseSyllabus.Where(cs => cs.ID.Equals(model.ID)).FirstOrDefault();

                    tblSyllabus.CourseId = model.CourseId;
                    tblSyllabus.SubjectId = model.SubjectId;
                    db.SaveChanges();
                    //return "Successfully updated.";
                }

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, ActionName("DeleteSyllabus")]
        public JsonResult DeleteSyllabus(int id)
        {
            try
            {
                var result = db.CourseSyllabus.Where(cs => cs.ID.Equals(id)).FirstOrDefault();
                if (result != null)
                {
                    db.CourseSyllabus.Remove(result);
                    db.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }
            return new JsonResult { Data = "Deleted Record", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}