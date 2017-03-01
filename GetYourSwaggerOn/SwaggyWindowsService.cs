using GetYourSwaggerOn.Core.Communication;
using SwaggerWcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace GetYourSwaggerOn
{
    class SwaggyWindowsService : ServiceBase
    {
        public ServiceHost serviceHost = null;
        public SwaggyWindowsService()
        {
            // Name the Windows Service
            ServiceName = "SwaggyWindowsService";
        }

        public static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                SwaggyWindowsService service1 = new SwaggyWindowsService();
                service1.TestStartupAndStop(args);
            }
            else
            {
                ServiceBase.Run(new SwaggyWindowsService());
            }
        }

        internal void TestStartupAndStop(string[] args)
        {
            this.OnStart(args);
            Console.ReadLine();
            this.OnStop();
        }

        // Start the Windows service.
        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            // Create a ServiceHost for the CalculatorService type and 
            // provide the base address.
            serviceHost = new WebServiceHost(typeof(RESTService));

            // Open the ServiceHostBase to create listeners and start 
            // listening for messages.
            serviceHost.Open();

            var swaggerHost = new WebServiceHost(typeof(SwaggerWcfEndpoint));
            swaggerHost.Open();
        }
        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }
}
