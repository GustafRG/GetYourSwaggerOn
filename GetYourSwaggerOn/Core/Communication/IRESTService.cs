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
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "v1/myclass/")]
        MyClass DoStuff(MyClass myclass);
    }
}
