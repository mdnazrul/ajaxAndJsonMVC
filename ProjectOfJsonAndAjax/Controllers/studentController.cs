using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectOfJsonAndAjax.Models;

namespace ProjectOfJsonAndAjax.Controllers
{
    public class studentController : Controller
    {
        //
        // GET: /student/
       private StudentDBEntities db = new StudentDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult studentList()
        {
            var resultList=(from item in db.tbl_student select item).ToList();
            return View(resultList);
        }

        public ActionResult StdPart()
        {
            var resultList = (from item in db.tbl_student select item).ToList();
            return PartialView(resultList);
        }

        public JsonResult AddStudent(tbl_student ts, string Name, string MobNo)
        {
            ts.Name = Name;
            ts.MobNo = MobNo;
            ts.DepartmentId = 1;
            db.tbl_student.Add(ts);
            db.SaveChanges();
            var jsonData = new { success = true, message = "Student Added Successfully." };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateStudent(tbl_student ts, int StudentId, string Name, string MobNo)
        {
            ts = db.tbl_student.FirstOrDefault(x => x.StudentId == StudentId);
            ts.Name = Name;
            ts.MobNo = MobNo;
            ts.DepartmentId = 1;
            db.SaveChanges();
            var jsonData = new { success = true, message = "Student Updated Successfully." };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        //Delete
        public JsonResult DeleteStudent(int id = 0)
        {
            tbl_student course = db.tbl_student.Where(x => x.StudentId == id).FirstOrDefault();

            db.tbl_student.Remove(course);
            db.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

	}
}