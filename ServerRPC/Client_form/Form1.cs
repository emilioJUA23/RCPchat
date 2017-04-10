using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                MessageBox.Show("ususario creado.");
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
                    MessageBox.Show("ususario ya esta en sala o nickname ya tomado.");
                    if (ChannelServices.GetChannel(client_channel.ChannelName) != null)
                    {
                        ChannelServices.UnregisterChannel(client_channel);
                    }
                }
                else
                {
                    remota.Subscribe(n_user.nickname, n_user.ip, n_user.port);
                    MessageBox.Show("te has unido a la sala");
                    timer1.Start();
                }
            }
            catch (Exception ex)
            {
                if (ChannelServices.GetChannel(client_channel.ChannelName)!=null)
                {
                    ChannelServices.UnregisterChannel(client_channel);
                }
                MessageBox.Show("No se ha podido crear unis a sala: " + ex.Message);
            }
        }

        private void btnleave_Click(object sender, EventArgs e)
        {
            try
            {

                if (remota.its_in_tha_room(n_user.nickname, n_user.ip, n_user.port))
                {
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
           
                List<string> buzon_aux = remota.mail_delivery(n_user.nickname);
                foreach (string c in buzon_aux)
                {
                    lb_pantalla_chat.Items.Add(c);
                }
            
        }

        private void btnmensaje_Click(object sender, EventArgs e)
        {
            int a = remota.broadcast(tbmensaje.Text, n_user.nickname);
            //de aqui para abajo es demostrativo para retornar mensaje
            List<string> buzon_aux = remota.mail_delivery(n_user.nickname);
            foreach (string c in buzon_aux)
            {
                lb_pantalla_chat.Items.Add(c);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            chequear_chat();
        }
    }
}
