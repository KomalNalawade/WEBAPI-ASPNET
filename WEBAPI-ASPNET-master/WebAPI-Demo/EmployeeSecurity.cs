using EmployeeDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Demo
{
    public class EmployeeSecurity
    {
        public static bool Login(string username,string password)
        {
            EmployeeEntities entity = new EmployeeEntities();
            return entity.Users.Any(user=>user.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                        && user.Password == password);
        }
    }
}