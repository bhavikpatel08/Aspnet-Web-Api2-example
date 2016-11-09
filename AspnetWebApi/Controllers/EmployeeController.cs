using AspnetWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft;
using Newtonsoft.Json;

namespace AspnetWebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: api/Employee
        public IHttpActionResult Get()
        {
            using (DataContext context = new DataContext())
            {
                return Json(context.Employee.ToList());
            }
        }

        // GET: api/Employee/5
        public IHttpActionResult Get(int id)
        {
            using (DataContext context = new DataContext())
            {
                var emp = context.Employee.FirstOrDefault(e => e.EmployeeId == id);
                if (emp != null)
                {
                    return Json(emp);
                }

                return Json("No record found");
            }
        }

        // POST: api/Employee
        public IHttpActionResult Post([FromBody]Employee employee)
        {
            if (employee == null)
            {
                return Json(HttpStatusCode.BadRequest);
            }
            using (DataContext context = new DataContext())
            {
                context.Employee.Add(employee);
                context.SaveChanges();

                return Json(context.Employee.ToList());
            }
        }

        // PUT: api/Employee/5
        public IHttpActionResult Put(int id, Employee employee)
        {
            if (employee == null)
            {
                return Json(HttpStatusCode.BadRequest);
            }

            using (DataContext context = new DataContext())
            {
                var emp = context.Employee.FirstOrDefault(e => e.EmployeeId == id);
                if (emp != null)
                {
                    emp.Name = employee.Name;
                    emp.Email = employee.Email;
                    emp.ContactNumber = employee.ContactNumber;

                    context.SaveChanges();
                    return Ok();
                }

                return Json("No record found");
            }
        }

        // DELETE: api/Employee/5
        public IHttpActionResult Delete(int id)
        {
            using (DataContext context = new DataContext())
            {
                var emp = context.Employee.FirstOrDefault(e => e.EmployeeId == id);
                if (emp != null)
                {
                    context.Employee.Remove(emp);
                    return Ok();
                }

                return Json("No record found");
            }

        }
    }
}
