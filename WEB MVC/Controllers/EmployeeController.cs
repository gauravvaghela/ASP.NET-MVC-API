using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WEB_MVC.Models;

namespace WEB_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<mvcEmployee> empList;
            HttpResponseMessage response = GlobalVariable.WebApi.GetAsync("Employees").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<mvcEmployee>>().Result;
            return View(empList);
        }

        [HttpGet]
        public ActionResult AddOrDelete(int id=0)
        {
            if (id == 0)
            {
                return View(new mvcEmployee());
            }
            else
            {
                HttpResponseMessage respose = GlobalVariable.WebApi.GetAsync("Employees/"+id.ToString()).Result;
                return View(respose.Content.ReadAsAsync<mvcEmployee>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrDelete(mvcEmployee employee)
        {
            if (employee.EmpId == 0) {
                HttpResponseMessage response = GlobalVariable.WebApi.PostAsJsonAsync("Employees", employee).Result;
                return RedirectToAction("Index");
            }
            else
            {
                HttpResponseMessage response = GlobalVariable.WebApi.PutAsJsonAsync("Employees/"+employee.EmpId, employee).Result;
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariable.WebApi.DeleteAsync("Employees/" +id).Result;
            return RedirectToAction("Index");
        }

    }
}