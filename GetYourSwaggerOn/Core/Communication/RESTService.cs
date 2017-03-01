using GetYourSwaggerOn.Core.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwaggerWcf.Attributes;
using System.Net;
using System.ServiceModel.Web;

namespace GetYourSwaggerOn.Core.Communication
{

    [SwaggerWcf("/get-your-swagger-on/")]
    class RESTService : IRESTService
    {
        WebOperationContext ctx = WebOperationContext.Current;

        [SwaggerWcfTag("MyClass")]
        [SwaggerWcfResponse(HttpStatusCode.Created, "MyClass created, value in the response body with id updated")]
        [SwaggerWcfResponse(HttpStatusCode.BadRequest, "Bad request", true)]
        [SwaggerWcfResponse(HttpStatusCode.InternalServerError, "Internal error", true)]
        public MyClass DoStuff(MyClass myclass)
        {
           MyClass retMyClass;
           if(myclass != null)
            {
                retMyClass = myclass;
            }
            else
            {
                retMyClass = new MyClass();
            }
           return retMyClass;
        }
    }
}
