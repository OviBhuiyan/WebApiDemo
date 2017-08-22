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

        [HttpGet]
        public  HttpResponseMessage GetEmployeeById(int id)

        {

            try
            {
                

                //int a = Convert.ToInt32(emp.ID); //Convert.ToInt32(Id);

                //if (a == 9)
                //{
                //    Convert.ToDateTime("dfsdsdfsd");
                //}
                var result = db.Employees.Where(e => e.ID.Equals(id)).FirstOrDefault();
                return Request.CreateResponse(HttpStatusCode.Created, result); 
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,"Error:");
            }
           
            
        }

    }
}
