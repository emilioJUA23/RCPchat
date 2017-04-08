using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Libreria;

namespace Libreria
{
    public class Class1:MarshalByRefObject
    {
        public Class1() { }

        public int Suma(int a , int b)
        {
            return a + b;
        }

        public int Subscribe()//this method saves the tcp channel where a new client is listening messages
        {
            try
            {
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }

        }

        public int UnSubscribe()//this method delete the tcp channel where a new client is listening messages
        {
            try
            {
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }

        }

        public int broadcast(string message,string usr)// this method sends to every client suscribe a message 
        {
            try
            {
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<string> connecterd_usr()//este metodo debe desplegar todos los usuarios conectados a un server
        {
            return null;
        }

        public List<string> connecterd_server()//este metodo debe desplegar todos los servidores a los que estoy conectado
        {
            return null;
        }

        public string directory(string ruta)
        {
            string resp = "";
            if (Directory.Exists(ruta))
            {
                // This path is a directory
                string[] fileEntries = Directory.GetFiles(ruta);
                foreach (string fileName in fileEntries)
                { resp = resp + fileName + '\n'; }

            }
            else
            {
                resp = "direccion de ruta invalida";
            }

            return resp;
        }

    }
}
