using GetYourSwaggerOn.Core.Classes;
using SwaggerWcf.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace GetYourSwaggerOn.Core.Communication
{
   
    [ServiceContract]
    interface IRESTService
    {
        [SwaggerWcfPath("Create MyClass", "Create a MyClass instance")]
        [OperationContract]
        [WebInvoke(UriTemplate = "v1/myclass/", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        MyClass DoStuff([SwaggerWcfParameter]MyClass myclass);


		//[SwaggerWcfPath("Get Classes", "Get a list of classes")]
		//[OperationContract]
		//[WebGet(UriTemplate = "v1/myclass/", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
		//List<MyClass> GetMyClasses();

		[SwaggerWcfPath("Get Classes", "Get a list of classes with ids matching")]
		[OperationContract]
		[WebGet(UriTemplate = "v1/myclass/?id={id}", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
		List<MyClass> GetMyClasses([SwaggerWcfParameter]string id);
	}
}
