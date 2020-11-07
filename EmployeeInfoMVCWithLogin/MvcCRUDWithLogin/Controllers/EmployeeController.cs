using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCRUDWithLogin.Models;
using System.Data.Entity;
using System.Web.ModelBinding;

namespace MvcCRUDWithLogin.Controllers
{
    public class EmployeeController : Controller
    {
        [HandleError]
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            DBModel con = new DBModel();
            List<Employee> empList = con.Employees.ToList<Employee>();
            return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Employee());
            else
            {
                DBModel con = new DBModel();                
                return View(con.Employees.Where(x => x.EmployeeID == id).FirstOrDefault<Employee>());
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Employee emp)
        {
            DBModel con = new DBModel();
            if (emp.EmployeeID == 0)
            {


                #region If Employee Exist
                var isExist = IsEmployeeExist(emp.Name);
                if (isExist)
                {
                    
                    return Json(new { success = false, message = "Duplicate Name" }, JsonRequestBehavior.DenyGet);
                    //return View(emp);
                }
                //if (con.Employees.Select(dbemp => dbemp.Name == emp.Name).Count() > 0)
                //{
                //    return Json(new { success = false, message = "Duplicate Name" }, JsonRequestBehavior.DenyGet);
                //}
                #endregion
                else
                {
                    con.Employees.Add(emp);
                    con.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                con.Entry(emp).State = EntityState.Modified;
                con.SaveChanges();
                return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
            }            
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (DBModel db = new DBModel())
            {
                Employee emp = db.Employees.Where(x => x.EmployeeID == id).FirstOrDefault<Employee>();
                db.Employees.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool IsEmployeeExist(string employeeName)
        {
            using (DBModel con = new DBModel())
            {
                var x = con.Employees.Where(a => a.Name == employeeName).FirstOrDefault();
                return x != null;
            }
        }
    }
}