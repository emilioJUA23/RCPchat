﻿using System;
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
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }

        }

        public int UnSubscribe(string nickname, string ip, string port)//this method delete the tcp channel where a new client is listening messages
        {
            try
            {
                user o_user = new user(nickname, ip, port);
                ususarios_server.Remove(o_user);
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
