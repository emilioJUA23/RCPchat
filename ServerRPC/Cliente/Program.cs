using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Libreria;

namespace Cliente
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClientChannel chanel = new TcpClientChannel();
            ChannelServices.RegisterChannel(chanel, false);
            /* RemotingConfiguration.RegisterWellKnownClientType(
                 typeof(Class1),"tcp://localhost:1235/calculadora");*/


            
            List<WellKnownClientTypeEntry> listaServers = new List<WellKnownClientTypeEntry>();
            listaServers.Add(new WellKnownClientTypeEntry(typeof(Class1), "tcp://localhost:1235/calculadora"));
            listaServers.Add(new WellKnownClientTypeEntry(typeof(Class1), "tcp://localhost:1240/calculadora"));
            for (int i = 0; i < listaServers.Count; i++)
            {
                WellKnownClientTypeEntry[] s= RemotingConfiguration.GetRegisteredWellKnownClientTypes();
                RemotingConfiguration.RegisterWellKnownClientType(listaServers[i]);
                Class1 op = new Class1();
                Console.WriteLine(op.Suma(i, i));
            }
            
            

            /*try
            {
                while (true)
                {
                    Class1 op = new Class1();
                    Console.WriteLine(op.Suma(4, 3));
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }*/
            Console.ReadKey();
        }
    }
}
