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

namespace Chat
{
    public partial class Form1 : Form
    {
        Class1 local;
        List<Class1> remotes = new List<Class1>();
        TcpChannel Channel;
        user n_user;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                if (Channel == null)
                {
                    Channel = new TcpChannel();
                    ChannelServices.RegisterChannel(Channel, false);
                }
                remotes.Add((Class1)Activator.GetObject(typeof(Class1), tb_server_tcp_chan.Text));
                if (remotes[remotes.Count-1].its_in_tha_room(n_user.nickname, n_user.ip, n_user.port))
                {
                    MessageBox.Show("ususario ya esta en sala o nickname ya tomado.");
                }
                else
                {
                    remotes[remotes.Count - 1].Subscribe(n_user.nickname, n_user.ip, n_user.port);
                    MessageBox.Show("te has unido a la sala");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido crear unis a sala: " + ex.Message);
            }
        }


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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Class1 c in remotes)
                {
                    List<string> usr = c.connected_server();
                    foreach (string d in usr)
                    {
                        listBox2.Items.Add(d);
                    }

                }
     
            }
            catch (Exception ex)
            {
               
            }
        }


        #region server_side
        //este boton tiene la instancia que levanta el server
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int puerto_server = Convert.ToInt32(tb_client_port.Text);
                if (Channel != null)
                { }
                else
                {
                    Channel = new TcpChannel(puerto_server);
                    if (ChannelServices.GetChannel(Channel.ChannelName) != null)
                    { }
                    else
                    {
                        ChannelServices.RegisterChannel(Channel, false);
                    }
                }
                RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(Libreria.Class1), "chat",
                WellKnownObjectMode.Singleton);
                local = (Class1)Activator.GetObject(typeof(Class1), "tcp://localhost:" + tb_client_port.Text + "/chat");
                MessageBox.Show("servidor ha sido montado!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        //este boton da de baja el server que levanto la intancia previa
        private void button2_Click(object sender, EventArgs e)
        {
            if (Channel != null)
            {
                ChannelServices.UnregisterChannel(Channel);
                Channel = null;
                MessageBox.Show("el servidor ha sido apagado.");
            }
        }

        private void btnexecute_Click(object sender, EventArgs e)
        {
            string[] comando = tbcomando_s.Text.ToLower().Split(' ');
            if (comando[0] == "kill" && comando[1] == "user")
            {
                if (local.its_in_tha_room(comando[2]))
                {
                    int aux = local.expell(comando[2]);
                    if (aux == 1)
                    {
                        listBox1.Items.Add("usuario " + comando[2] + " eliminado.");
                    }
                    else
                    {
                        listBox1.Items.Add("usuario " + comando[2] + " no pudo ser eliminado.");
                    }
                }
                else
                {
                    MessageBox.Show("no existe el ususario.");
                }
            }
            else if (comando[0] == "list" && comando[1] == "connected")
            {
                List<string> users = local.connected_server();
                listBox1.Items.Add("los usuarios conectados son:");
                foreach (string c in users)
                {
                    listBox1.Items.Add('\t'+c);
                }
            }
            else
            {
                MessageBox.Show("commando no reconocible.");
            }
        }
        #endregion
    }
}
