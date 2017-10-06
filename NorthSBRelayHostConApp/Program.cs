using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using NorthServices;
using Microsoft.ServiceBus;
using System.Configuration;
using System.ServiceModel.Description;

namespace NorthSBRelayHostConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region With Local End Point
            //ServiceHost host = new ServiceHost(typeof(NorthSVC));
            //host.Open();
            //Console.WriteLine("Service is running, press any key to exist!!");
            //Console.ReadKey(true);
            //host.Close();
            #endregion

            #region With ServiceBus EndPoint
            TransportClientEndpointBehavior tcep = new TransportClientEndpointBehavior();
            NamespaceManager nm = NamespaceManager.CreateFromConnectionString(ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"].ToString());
            tcep.TokenProvider = nm.Settings.TokenProvider;

            ServiceHost host = new ServiceHost(typeof(NorthSVC));
            foreach(ServiceEndpoint item in host.Description.Endpoints)
            {
                item.EndpointBehaviors.Add(tcep);
            }
            host.Open();
            Console.WriteLine("Service Bus Service is running, press any key to stop!!");
            Console.ReadKey(true);
            host.Close();
            #endregion

        }
    }
}
