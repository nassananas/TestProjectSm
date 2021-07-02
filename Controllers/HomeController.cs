using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class HomeController : Controller
    {
        IEmployeeRepository repo;
        public HomeController(IEmployeeRepository r)
        {
            repo = r;
        }

        public ActionResult Index()
        {
            return View(repo.GetByCompany(10));
        }

        [HttpPost]
        public ActionResult Add([FromBody]Employee employee)
        {
            try
            {
                if (repo.GetDepartment(employee.DepartmentId) != null) { 
                    repo.Add(employee);
                    return Json(employee.Id);
                }
                else
                {
                    return Json("Not found department");
                }
            }
            catch
            {
                return Json("Error");
            }
        }

        [HttpPost]
        public ActionResult Edit([FromBody] Employee employee)
        {
            try
            {
                if (repo.GetEmployee(employee.Id) != null)
                {
                    repo.Update(employee);
                    return Json("Success");
                }
                else return Json("Not found employee");
            }
            catch
            {
                return Json("Error");
            }
        }

        [HttpPost]
        public ActionResult Delete([FromBody]IdParam idParam)
        {
            try
            {
                if (repo.GetEmployee(idParam.id) != null) { 
                    repo.Delete(idParam.id);
                    return Json("success");
                }
                else return Json("Not found employee");
            }
            catch 
            {
                return Json("Error");
            }         
        }

        [HttpGet]
        public ActionResult ByCompany([FromBody]IdParam idParam)
        {
            try
            {
                List<Object> list = repo.GetByCompany(idParam.id);
                return Json(list);
            }
            catch
            {
                return Json("Error");
            }
        }

        [HttpGet]
        public ActionResult ByDepartment([FromBody]IdParam idParam)
        {
            try
            {
                List<Object> list = repo.GetByDepartment(idParam.id);
                return Json(list);
            }
            catch
            {
                return Json("Error");
            }
        }       
    }
}
