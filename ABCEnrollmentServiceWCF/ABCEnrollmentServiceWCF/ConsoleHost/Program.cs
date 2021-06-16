using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using ABCEnrollmentServiceWCF;

namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(EnrollService));
            try
            {
                host.Open();
                PrintServiceInfo(host);
                Console.ReadLine();
                host.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                host.Abort();
            }
        }
        static void PrintServiceInfo(ServiceHost host)
        {
            Console.WriteLine("{0} is up and running with the following endpoints:", host.Description.ServiceType);

            foreach (ServiceEndpoint se in host.Description.Endpoints)
                Console.WriteLine(se.Address);
        }
    }
}
