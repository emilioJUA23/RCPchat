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
            List<string> servidores = new List<string>();
            servidores.Add("tcp://localhost:1235/");
            servidores.Add("tcp://localhost:1240/");

            TcpChannel chanel = new TcpChannel(9000);
            ChannelServices.RegisterChannel(chanel, false);

            for (int i = 0; i < servidores.Count; i++)
            {
               
                Class1 objectWellKnown = new Class1();
                // After the channel is registered, the object needs to be registered
                // with the remoting infrastructure.  So, Marshal is called.
                ObjRef objrefWellKnown = RemotingServices.Marshal(objectWellKnown, servidores[i] );
                Console.WriteLine("An instance of SampleWellKnown type is published at {0}.", objrefWellKnown.URI);
              
                Console.WriteLine("Press enter to unregister SampleWellKnown, so that it is no longer available on this channel.");
                Console.ReadLine();
              //  RemotingServices.Disconnect(objectWellKnown);
            }

            
            /* RemotingConfiguration.RegisterWellKnownClientType(
                 typeof(Class1),"tcp://localhost:1235/calculadora");
            try
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
