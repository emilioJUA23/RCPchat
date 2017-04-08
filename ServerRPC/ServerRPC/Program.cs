using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;


namespace ServerRPC
{
    class Program
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(Libreria.Class1),"calculadora", 
            WellKnownObjectMode.SingleCall);
            Console.WriteLine("Servidor montandose por favor ingrese puerto para escuchar mensajes");
            int  tcpport=Convert.ToInt32(Console.ReadLine());
            TcpChannel chnl = new TcpChannel(tcpport);
            Console.WriteLine("estamos escuchando");
            Console.ReadKey();
        }
    }
}
