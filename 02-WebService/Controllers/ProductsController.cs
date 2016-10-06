using _01_DAL.DataModel;
using _02_WebService.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _02_WebService.Controllers
{
    public class ProductsController : AppApiController
    {
        //Database access
        private Context context = new Context();

        [HttpGet]
        [Route("api/products/{id}")]
        //[ApiAuthorizedRoles(AppUserRoles.App.Authenticated)]
        public HttpResponseMessage GetById(int id)
        {
            //Search Product for id in Database
            var dbProduct = context.Products.Where(p => p.Id == id).FirstOrDefault();

            //If Product doesn't exist in DB
            if (dbProduct == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "Error. Product with id " + id + " doesn't exist in this current database.");
            }

            else
            {
                //Search Employee owner
                //duvida..

                //Create clone for GUI
                var product = _01_DAL.Dto.ProductDetail.CreateFromDBObject(dbProduct);
                return Request.CreateResponse(HttpStatusCode.OK, product);
            }
        }

        //[HttpPost]
        //[Route("api/products")]
        ////[ApiAuthorizedRoles(AppUserRoles.App.Authenticated)]
        //public HttpResponseMessage CreateEmployee(EmployeeDetail employeeDetail)
        //{
        //    if (employeeDetail == null ||
        //       string.IsNullOrWhiteSpace(employeeDetail.Firstname))
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
        //            "Error. You can't create new employee without firstname.");
        //    }

        //    else
        //    {
        //        var newEmployee = employeeDetail.PersistToDb();
        //        return Request.CreateResponse(HttpStatusCode.OK, newEmployee);
        //    }
        //}
    }
}
