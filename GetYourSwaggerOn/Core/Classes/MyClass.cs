﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using SwaggerWcf.Attributes;

namespace GetYourSwaggerOn.Core.Classes
{   
    [Serializable]
    [DataContract(Namespace = "")]
    class MyClass
    {
        public MyClass() { }

        private String myVar;

        [DataMember]
        public String MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

    }
}
