using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmplyeeDB;
namespace WebApiDemo.Controllers
{
    [AllowAnonymous]
    public class EmployeeController : ApiController
    {
        EmployeeDBEntities db = new EmployeeDBEntities();

        [HttpGet]
        public  IEnumerable<Employee> GetEmployeeList()
        {
            return db.Employees.ToList();
        }

        [HttpPost]
        public  Employee GetEmployeeById(string Id)
        {
            var a = Convert.ToInt32(Id);
            return db.Employees.Where(e => e.ID.Equals(a)).FirstOrDefault();
        }

    }
}
