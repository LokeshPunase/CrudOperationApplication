using CrudOperationApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrudOperationApplication.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly ConnectionContext connectionContext = new ConnectionContext();

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return connectionContext.Employee.AsEnumerable();
        }

        [HttpGet]
        public Employee Get(int id)
        {
            Employee employee = connectionContext.Employee.Find(id);
            if (employee == null)
            {
                return null;
            }
            return employee;
        }

        [HttpPost]
        public HttpResponseMessage Post(Employee employee)
        {
            if (ModelState.IsValid)
            {
                connectionContext.Employee.Add(employee);
                connectionContext.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, employee);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = employee.empid }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }


        [HttpPost]
        [Route("api/crudapi/put")]
        public HttpResponseMessage Put(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            connectionContext.Entry(employee).State = EntityState.Modified;
            connectionContext.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            Employee employee = connectionContext.Employee.Find(id);
            if (employee == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            connectionContext.Employee.Remove(employee);
            connectionContext.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, employee);
        }

        protected override void Dispose(bool disposing)
        {
            connectionContext.Dispose();
            base.Dispose(disposing);
        }

    }
}
