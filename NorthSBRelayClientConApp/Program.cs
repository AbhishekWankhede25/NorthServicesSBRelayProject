using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using NorthServices;
using Microsoft.ServiceBus;
using System.Configuration;
//using System.ServiceModel.Description;

namespace NorthSBRelayClientConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region With Local End Point
            //ChannelFactory<INorthService> proxy = new ChannelFactory<INorthService>("tcpep");
            //INorthService obj = proxy.CreateChannel();
            //foreach (var item in obj.GetCategories())
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region With Service Bus EndPoint
            TransportClientEndpointBehavior tcep = new TransportClientEndpointBehavior();
            NamespaceManager nm = NamespaceManager.CreateFromConnectionString(ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"].ToString());
            tcep.TokenProvider = nm.Settings.TokenProvider;

            ChannelFactory<INorthService> proxy = new ChannelFactory<INorthService>("tcpsbep");
            proxy.Endpoint.EndpointBehaviors.Add(tcep);
            INorthService obj = proxy.CreateChannel();
            //foreach (var item in obj.GetProductsByCategory(2))
            //{
            //    Console.WriteLine(item);
            //}
            foreach (var item in obj.GetProducts())
            {
                Console.WriteLine(item);
            }
            #endregion
        }
    }
}
