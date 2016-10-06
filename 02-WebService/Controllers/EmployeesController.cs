using _01_DAL.Classes;
using _01_DAL.DataModel;
using _01_DAL.Dto;
using _02_WebService.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _02_WebService.Controllers
{
    public class EmployeesController : AppApiController
    {
        //Database access
        private Context context = new Context();

        [HttpGet]
        [Route("api/employees/{id}")]
        //[ApiAuthorizedRoles(AppUserRoles.App.Authenticated)]
        public HttpResponseMessage GetById(int id)
        {
            //Search Employee for id in Database
            var dbEmployee = context.Employees.Where(e => e.Id == id).FirstOrDefault();

            //If employee doesn't exist in DB
            if (dbEmployee == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "Error. Employee with id " + id + " doesn't exist in this current database.");
            }

            else
            {
                //Search Products per Employee in Database
                dbEmployee.Products = context.Products.Where(p => p.Employee.Id == id).ToList();

                //Create clone for GUI
                var employee = _01_DAL.Dto.EmployeeDetail.CreateFromDBObject(dbEmployee);
                return Request.CreateResponse(HttpStatusCode.OK, employee);
            }
        }

        [HttpPost]
        [Route("api/employees")]
        //[ApiAuthorizedRoles(AppUserRoles.App.Authenticated)]
        public HttpResponseMessage CreateEmployee(EmployeeDetail employeeDetail)
        {
            if (employeeDetail == null ||
               string.IsNullOrWhiteSpace(employeeDetail.Firstname))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "Error. You can't create new employee without firstname.");
            }

            else
            {
                var newEmployee = employeeDetail.PersistToDb();
                return Request.CreateResponse(HttpStatusCode.OK, newEmployee);
            }
        }
    }
}
