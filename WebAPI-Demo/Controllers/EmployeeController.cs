using EmployeeDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_Demo.Controllers
{
    public class EmployeeController : ApiController
    {
        
        public IEnumerable<tblEmployee> Get()
        {
            using (EmployeeEntities entities = new EmployeeEntities())
            {
                return entities.tblEmployees.ToList();
            }
            
        }
        public tblEmployee Get(int id)
        {
            using (EmployeeEntities entities = new EmployeeEntities())
            {
                return entities.tblEmployees.FirstOrDefault(emp => emp.Id == id);
             }
        }
    }
}
