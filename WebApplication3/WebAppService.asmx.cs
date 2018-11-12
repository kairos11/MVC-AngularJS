using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using WebApplication3.Models;
using WebApplication3;
using System.Web.Script.Serialization;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Web.Script.Services;

namespace WebApplication3
{
    /// <summary>
    /// Summary description for WebAppService
    /// </summary>
    [ScriptService]
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebAppService : System.Web.Services.WebService
    {
        StudentDBContext db = new StudentDBContext();
        JavaScriptSerializer js = new JavaScriptSerializer();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";

        }

        [WebMethod]
        public void GetCourse()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(db.Courses.ToList()));
        }

        [WebMethod]
        public void GetSubject()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(db.Subjects.ToList()));
        }

        [WebMethod]
        public void GetSyllabus()
        {

            var model = db.CourseSyllabus
                        .Join(db.Subjects, cs => cs.SubjectId, s => s.SubjectId, (cs, s) => new { cs, s })
                        .Join(db.Courses, css => css.cs.CourseId, c => c.CourseId, (css, c) => new { css, c })
                        .Select(a => new
                        {
                            CourseName = a.c.CourseName,
                            SubjectName = a.css.s.SubjectName,
                            ID = a.css.cs.ID
                        });

            Context.Response.Write(js.Serialize(model));
        }


        [WebMethod]
        public void GetSyllabusById(int id)
        {

            var model = db.CourseSyllabus
                        .Join(db.Subjects, cs => cs.SubjectId, s => s.SubjectId, (cs, s) => new { cs, s })
                        .Join(db.Courses, css => css.cs.CourseId, c => c.CourseId, (css, c) => new { css, c })
                        .Select(a => new
                        {
                            CourseId = a.c.CourseId,
                            CourseName = a.c.CourseName,
                            SubjectId = a.css.cs.SubjectId,
                            SubjectName = a.css.s.SubjectName,
                            ID = a.css.cs.ID
                        })
                        .Where(b => b.ID == id);

            Context.Response.Write(js.Serialize(model));

        }

        [HttpPost]
        public void AddData(Syllabus model)
        {
            string result = string.Empty;
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";

            try
            {
                db.CourseSyllabus.Add(model);
                db.SaveChanges();
                result = "Save Successfully";
            }
            catch (Exception)
            {
                result = "Failed to save";
                throw new Exception();
            }

            Context.Response.Write(js.Serialize(model));
            //return JsonResult(model, JsonRequestBehavior.AllowGet);
        }

        [ScriptMethod()]
        [WebMethod]
        public void DeletebyId(int id)
        {
            try
            {
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                var result = db.CourseSyllabus.Where(cs => cs.ID.Equals(id)).FirstOrDefault();
                if (result != null)
                {
                    db.CourseSyllabus.Remove(result);
                    db.SaveChanges();
                }
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception)
            {

                throw;
            }
            
            //return new JsonResult { Data = "Deleted Record", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
