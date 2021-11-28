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
        EmployeeEntities entities = new EmployeeEntities();
        public IEnumerable<tblEmployee> Get()
        {
            //using (EmployeeEntities entities = new EmployeeEntities())
            //{
                return entities.tblEmployees.ToList();
           // }
            
        }
        public HttpResponseMessage Get(int id)
        {
                var entity =  entities.tblEmployees.FirstOrDefault(emp => emp.Id == id);
                if(entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id = " + id.ToString() + " not Found");
                }
        }
        //public bool Post([FromBody] tblEmployee emp)
        //{
        //    bool status = false;
        //    try
        //    {
        //        tblEmployee e = new tblEmployee();
        //        e.Name = emp.Name;
        //        e.City = emp.City;
        //        e.Gender = emp.Gender;
        //        e.DateOfBirth = emp.DateOfBirth;
        //        entities.tblEmployees.Add(e);
        //        entities.SaveChanges();
        //        status = true;
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine("Message :" + ex.Message);
        //        status = false;
        //    }
        //    return status;

        //}
        public HttpResponseMessage Post([FromBody] tblEmployee emp)
        {
            try
            {
                entities.tblEmployees.Add(emp);
                entities.SaveChanges();
                var message = Request.CreateResponse(HttpStatusCode.Created, emp);
                message.Headers.Location = new Uri(Request.RequestUri + emp.Id.ToString());
                return message;
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            
        }
        //public bool Put(int id,[FromBody] tblEmployee employee)
        //{
        //    bool status = false;
        //    tblEmployee existingEmp = entities.tblEmployees.Where(e => e.Id == id).FirstOrDefault();
        //    try
        //    {
        //        if (existingEmp != null)
        //        {
        //            existingEmp.Name = employee.Name;
        //            existingEmp.Gender = employee.Gender;
        //            existingEmp.City = employee.City;
        //            existingEmp.DateOfBirth = employee.DateOfBirth;
        //            entities.SaveChanges();
        //            status = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Message :" + ex.Message);
        //        status = false;
        //    }
        //    return status;
        //}
        //public bool Delete(int id)
        //{
        //    bool status = false;
        //    tblEmployee emp = entities.tblEmployees.Where(e => e.Id == id).FirstOrDefault();
        //    try
        //    {
        //        entities.tblEmployees.Remove(emp);
        //        entities.SaveChanges();
        //        status = true;
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine("Message :" + ex.Message);
        //        status = false;
        //    }
        //    return status;
            
        //}

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var entity = entities.tblEmployees.Remove(entities.tblEmployees.FirstOrDefault(e => e.Id == id));
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id " + id.ToString() + " not found to delete");
                }
                else
                {
                    entities.tblEmployees.Remove(entity);
                    entities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public HttpResponseMessage Put(int id, [FromBody] tblEmployee emp)
        {
            try 
            { 
                var entity = entities.tblEmployees.FirstOrDefault(e => e.Id == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id= " + id + " not found for update");
                }
                else
                {
                    entity.Name = emp.Name;
                    entity.City = emp.City;
                    entity.Gender = emp.Gender;
                    entity.DateOfBirth = emp.DateOfBirth;
                    entities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }
    }
}
