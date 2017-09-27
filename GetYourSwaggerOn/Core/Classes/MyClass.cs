using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using SwaggerWcf.Attributes;
using System.ComponentModel;

namespace GetYourSwaggerOn.Core.Classes
{
	//[Serializable]
	[DataContract(Name = "Foo", Namespace = "")]
	[Description("Book with title, first publish date, author and language")]
	[SwaggerWcfDefinition(ExternalDocsUrl = "http://en.wikipedia.org/wiki/Book", ExternalDocsDescription = "Description of a book")]
	class MyClass
    {
        public MyClass() { }

		private string id;
		private String myVar;
		private String myOtherVar;


		[DataMember(Name = "Id")]
		public string Id
		{
			get { return id; }
			set { id = value; }
		}

        [DataMember(Name= "Bar")]
        public String MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

		[DataMember(Name = "Yolo")]
		public String MyOtherProperty
		{
			get { return myOtherVar; }
			set { myOtherVar = value; }
		}

	}
}
