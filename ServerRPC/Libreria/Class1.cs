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
        #region atributos
        List<user> ususarios_server = new List<user>();
        List<List<string>> buzon_de_mensajes = new List<List<string>>();
        #endregion
        public Class1() { }

        public int Suma(int a , int b)
        {
            return a + b;
        }

        public int Subscribe(string nickname, string ip,string port)//this method saves the tcp channel where a new client is listening messages
        {
            try
            {
                user n_user = new user(nickname, ip, port);
                ususarios_server.Add(n_user);
                List<string> buzonUsuario = new List<string>();
                buzon_de_mensajes.Add(buzonUsuario);
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }

        }

        public bool its_in_tha_room(string nickname, string ip, string port)
        {
            bool exist = false;
            for (int i = 0; i < ususarios_server.Count; i++)
            {
                if (nickname==ususarios_server[i].nickname||(ip+port)==(ususarios_server[i].ip+ususarios_server[i].port))
                {
                    exist = true;
                    break;
                }
            }
            return exist;
        }

        public int UnSubscribe(string nickname, string ip, string port)//this method delete the tcp channel where a new client is listening messages
        {
            try
            {
                //user o_user = new user(nickname, ip, port);
                //ususarios_server.Remove(o_user);
                for (int i = 0; i < ususarios_server.Count; i++)
                {
                    if (nickname==ususarios_server[i].nickname&&ip==ususarios_server[i].ip&&port==ususarios_server[i].port)
                    {
                        ususarios_server.RemoveAt(i);
                        buzon_de_mensajes.RemoveAt(i);
                    }

                }
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }

        }

        public int broadcast(string message,string usr)// this method sends to every client suscribe a message 
        {
            string mensaje = usr + " dice: " + message;
            try
            {
                for (int i = 0; i < buzon_de_mensajes.Count; i++)
                {
                    buzon_de_mensajes[i].Add(mensaje);
                }
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<string> mail_delivery(string nickname)
        {
            try
            {
                for (int i = 0; i < ususarios_server.Count; i++)
                {
                    if (nickname == ususarios_server[i].nickname)
                    {
                        List < string > buzon_aux= buzon_de_mensajes[i];
                        buzon_de_mensajes[i] = new List<string>();
                        return buzon_aux;
                    }

                }
                return null;
            }
            catch (Exception)
            {

                return null;
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
