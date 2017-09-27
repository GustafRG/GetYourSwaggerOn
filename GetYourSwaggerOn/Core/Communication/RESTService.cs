using GetYourSwaggerOn.Core.Classes;
using System.Collections.Generic;
using System.Linq;
using SwaggerWcf.Attributes;
using System.Net;
using System.ServiceModel.Web;
using System.Net.Http;
using System.ServiceModel.Channels;
using System.Web;

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
        public MyClass DoStuff([SwaggerWcfParameter]MyClass myclass)
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

		//[SwaggerWcfTag("MyClass")]
		//[SwaggerWcfResponse(HttpStatusCode.OK, "MyClass(es) found")]
		//[SwaggerWcfResponse(HttpStatusCode.BadRequest, "Bad request", true)]
		//[SwaggerWcfResponse(HttpStatusCode.InternalServerError, "Internal error", true)]
		//List<MyClass> IRESTService.GetMyClasses()
		//{
		//	List<MyClass> classes = new List<MyClass>();
		//	for(int i = 0;i < 10;i++)
		//	{
		//		classes.Add(new MyClass { Id = i, MyProperty = "ClassProp " + i, MyOtherProperty = "ClassOtherProp " + i });
		//	}

		//	return classes;
		//}

		[SwaggerWcfTag("MyClass")]
		[SwaggerWcfResponse(HttpStatusCode.OK, "MyClass(es) found")]
		[SwaggerWcfResponse(HttpStatusCode.BadRequest, "Bad request", true)]
		[SwaggerWcfResponse(HttpStatusCode.InternalServerError, "Internal error", true)]
		public List<MyClass> GetMyClasses([SwaggerWcfParameter(false, null)] string id)
		{
			List<MyClass> classes = new List<MyClass>();

			List<MyClass> filteredClasses = new List<MyClass>();

			HttpContext ctx = HttpContext.Current;
			var filter = ctx.Request.QueryString.GetValues("id");

			for (int i = 0; i < 10; i++)
			{
				classes.Add(new MyClass { Id = i.ToString(), MyProperty = "ClassProp " + i, MyOtherProperty = "ClassOtherProp " + i });
			}

			foreach(string f in filter)
			{
				filteredClasses.Add(classes.FirstOrDefault<MyClass>(c => c.Id == f));
			}
				//classes.Where<MyClass>(c => c.Id == 


			return filteredClasses;
		}
	}
}
