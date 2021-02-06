using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TEST_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Add User Details",
                routeTemplate: "api/post-add-user-detail-save",
                defaults: new
                {
                    Controller = "WebApiTest",
                    Action = "Addnewuserdata",
                }
                );

            config.Routes.MapHttpRoute(
                name: "ALL User Details",
                routeTemplate: "api/get-alluser-detail",
                defaults: new
                {
                    Controller = "WebApiTest",
                    Action = "Get_All_Data",
                }
                );

            config.Routes.MapHttpRoute(
                name: " User Details",
                routeTemplate: "api/get-user-detail/{ID}",
                defaults: new
                {
                    Controller = "WebApiTest",
                    Action = "Get_user_details",
                    ID=RouteParameter.Optional,
                }
                );
            config.Routes.MapHttpRoute(
                name: " User Update",
                routeTemplate: "api/post-update-user-detail",
                defaults: new
                {
                    Controller = "WebApiTest",
                    Action = "Update_user_details",
                    
                }
                );
            config.Routes.MapHttpRoute(
                name: "ADD EMPLOYEE",
                routeTemplate: "api/add-employee-data",
                defaults: new
                {
                    Controller = "WebApiTest",
                    Action = "Add_Employee_Data",

                }
                );


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
