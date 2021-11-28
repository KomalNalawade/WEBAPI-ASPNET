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
        public tblEmployee Get(int id)
        {
            //using (EmployeeEntities entities = new EmployeeEntities())
            //{
                return entities.tblEmployees.FirstOrDefault(emp => emp.Id == id);
             //}
        }
        public bool post([FromBody] tblEmployee emp)
        {
            bool status = false;
            try
            {
                tblEmployee e = new tblEmployee();
                e.Name = emp.Name;
                e.City = emp.City;
                e.Gender = emp.Gender;
                e.DateOfBirth = emp.DateOfBirth;
                entities.tblEmployees.Add(e);
                entities.SaveChanges();
                status = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Message :" + ex.Message);
                status = false;
            }
            return status;

        }
        public bool put(int id,[FromBody] tblEmployee employee)
        {
            bool status = false;
            tblEmployee existingEmp = entities.tblEmployees.Where(e => e.Id == id).FirstOrDefault();
            try
            {
                if (existingEmp != null)
                {
                    existingEmp.Name = employee.Name;
                    existingEmp.Gender = employee.Gender;
                    existingEmp.City = employee.City;
                    existingEmp.DateOfBirth = employee.DateOfBirth;
                    entities.SaveChanges();
                    status = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Message :" + ex.Message);
                status = false;
            }
            return status;
        }
        public bool delete(int id)
        {
            bool status = false;
            tblEmployee emp = entities.tblEmployees.Where(e => e.Id == id).FirstOrDefault();
            try
            {
                entities.tblEmployees.Remove(emp);
                entities.SaveChanges();
                status = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Message :" + ex.Message);
                status = false;
            }
            return status;
            
        }
    }
}
