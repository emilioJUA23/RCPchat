using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Libreria;

namespace Client_form
{
    public partial class Form1 : Form
    {
        Class1 remota;
        Task remote_mail;
        public Form1()
        {
            InitializeComponent();
        }

        user n_user;
        private void btn_client_subscribe_Click(object sender, EventArgs e)
        {
            try
            {
                string nick = tbnick.Text;
                string puerto_cliente = tb_client_port.Text;
                n_user = new user(nick, "localhost", puerto_cliente);
                MessageBox.Show("usuario creado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido crear ususario: " + ex.Message);
            }
        }
        TcpChannel client_channel;
        private void btnjoin_Click(object sender, EventArgs e)
        {
            try
            {
                if (client_channel==null)
                {
                    client_channel = new TcpChannel();
                    ChannelServices.RegisterChannel(client_channel, false);
                }
                remota = (Class1)Activator.GetObject(typeof(Class1), tb_server_tcp_chan.Text);
                if (remota.its_in_tha_room(n_user.nickname, n_user.ip, n_user.port))
                {
                    MessageBox.Show("El usuario ya esta en sala o nickname ya tomado.");
                    if (ChannelServices.GetChannel(client_channel.ChannelName) != null)
                    {
                        ChannelServices.UnregisterChannel(client_channel);
                    }
                }
                else
                {
                    remota.Subscribe(n_user.nickname, n_user.ip, n_user.port);
                    MessageBox.Show("Te has unido a la sala");
                    timer1.Start();
                }
            }
            catch (Exception ex)
            {
                if (ChannelServices.GetChannel(client_channel.ChannelName)!=null)
                {
                    ChannelServices.UnregisterChannel(client_channel);
                }
                MessageBox.Show("No se ha podido unir a la sala: " + ex.Message);
            }
        }

        private void btnleave_Click(object sender, EventArgs e)
        {
            try
            {

                if (remota.its_in_tha_room(n_user.nickname, n_user.ip, n_user.port))
                {
                    timer1.Stop();
                    remota.UnSubscribe(n_user.nickname, n_user.ip, n_user.port);
                    ChannelServices.UnregisterChannel(client_channel);
                    client_channel = null;
                    MessageBox.Show("salimos de la sala!");
                }
                else
                {
                    MessageBox.Show("usuario no estaba en la sala.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido crear salir a sala: " + ex.Message);
            }
        }

        private void chequear_chat()
        {
            try
            {
                List<string> buzon_aux = remota.mail_delivery(n_user.nickname);
                foreach (string c in buzon_aux)
                {
                    string[] orden = c.Split(',');
                    if (orden.Length == 3)
                    {
                        if (orden[0] == "dir_init" && !c.Contains("dice:"))
                        {
                            remota.mensaje_privado(directory(orden[1]), orden[2]);
                        }
                        else { }
                        lb_pantalla_chat.Items.Add(orden[2]+" te ha pedido un directorio.");
                    }
                    else
                    {
                        lb_pantalla_chat.Items.Add(c);
                    }
                }
            }
            catch (Exception ex)
            {
                timer1.Stop();
                ChannelServices.UnregisterChannel(client_channel);
                client_channel = null;
                MessageBox.Show("se ha desconectado del chat" + ex.Message);
            }
               
            
        }

        private void btnmensaje_Click(object sender, EventArgs e)
        {
            try
            {
                int a = remota.broadcast(tbmensaje.Text, n_user.nickname);
             
            }
            catch (Exception)
            {
                MessageBox.Show("fallo en el envio de mensaje el servidor esta caido o usted no esta en la sala.");
            }
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            chequear_chat();
        }


        public string directory(string ruta)
        {
            string resp = n_user.nickname+": ";
            
            if (Directory.Exists(ruta))
            {
                string[] direntries = Directory.GetDirectories(ruta);
                string[] fileEntries = Directory.GetFiles(ruta);
                foreach (string direntrie in direntries)
                { resp = resp + direntries + ','; }
                foreach (string fileName in fileEntries)
                { resp = resp + fileName + ','; }
                resp = resp.Substring(0, resp.Length - 1);
            }
            else
            {
                resp = "direccion de ruta invalida";
            }

            return resp;
        }

        private void btnejecutar_Click(object sender, EventArgs e)
        {
            string[] comando = tbcomando.Text.ToLower().Split(' ');
            if (comando[0] == "list" && comando[1] == "sender")
            {

                List<string> users = remota.connected_server();
                lb_pantalla_chat.Items.Add("los usuarios conectados son:");
                foreach (string c in users)
                {
                    lb_pantalla_chat.Items.Add("\t"+c);
                }

            }
            else if (comando[0] == "list" && comando[1] == "dir")
            {
                string dir = tbcomando.Text;
                string aux = "";//aqui tengo la mera ruta;
                int contador_comillas = 0;
                for (int i = 0; i < dir.Length; i++)
                {
                   
                    if (dir[i]=='"'&&contador_comillas==0)
                    {
                        contador_comillas++;
                    }
                    else if(dir[i] == '"' && contador_comillas == 1)
                    {
                        contador_comillas++;
                    }
                    else if (contador_comillas == 1)
                    {
                        aux = aux + dir[i];
                    }
                    else { }

                }
               int comp =  remota.directories(aux, n_user.nickname);
                if (comp == 1)
                {

                }
                else MessageBox.Show("error al ejecutar instruccion.");
               
            }
            else
            {
                MessageBox.Show("commando no reconocible.");
            }
        }
    }
}
