using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Services.Controllers
{
    public class EmployeeController : ApiController
    {
        EmployeeDBEntities context = new EmployeeDBEntities();

        public IEnumerable<tblEmployee> Get()
        {
            return context.tblEmployees.ToList();
        }
    }
}
