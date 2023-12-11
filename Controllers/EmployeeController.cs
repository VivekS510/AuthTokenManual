using AuthTokenManual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuthWithToken.Controllers
{
    public class EmployeeController : ApiController
    {
        TokenAuthEntities dbContext = new TokenAuthEntities();

        [Authorize(Roles = ("User"))]
        public HttpResponseMessage GetEmployeeById(int id)
        {
            var user = dbContext.Employees.FirstOrDefault(e => e.Id == id);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [Authorize(Roles = ("Admin"))]
        [Route("api/Employee/GetSomeEmployee")]
        public HttpResponseMessage GetSomeEmployee()
        {
            var user = dbContext.Employees.FirstOrDefault(e => e.Id <= 3);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [Authorize(Roles = ("SuperAdmin"))]
        [Route("api/Employee/GetEmployee")]
        public HttpResponseMessage GetEmployee()
        {
            var user = dbContext.Employees.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }
    }
}
