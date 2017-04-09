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
        Class1 remota;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        TcpChannel serverchannel;
        //este boton tiene la instancia que levanta el server
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int puerto_server = Convert.ToInt32(tbpuerto_server.Text);
                serverchannel = new TcpChannel(puerto_server);
                ChannelServices.RegisterChannel(serverchannel, false);
                RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(Libreria.Class1), "chat",
                WellKnownObjectMode.Singleton);
                MessageBox.Show("es servidor ha sido montado");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        //este boton da de baja el server que levanto la intancia previa
        private void button2_Click(object sender, EventArgs e)
        {
            if (serverchannel != null)
            {
                ChannelServices.UnregisterChannel(serverchannel);
                serverchannel = null;
                MessageBox.Show("es servidor ha sido apagado");
            }
        }
        TcpClientChannel client_channel;
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                client_channel = new TcpClientChannel();
                ChannelServices.RegisterChannel(client_channel, false);
                remota = (Class1)Activator.GetObject(typeof(Class1), tb_server_tcp_chan.Text);
                if (remota.its_in_tha_room(n_user.nickname,n_user.ip,n_user.port))
                {
                    MessageBox.Show("ususario ya esta en sala o nickname ya tomado.");
                }
                else
                {
                    remota.Subscribe(n_user.nickname,n_user.ip,n_user.port);
                    MessageBox.Show("te has unido a la sala");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido crear unis a sala: " + ex.Message);
            }
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
                MessageBox.Show("No se ha podido crear ususario: "+ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                if (remota.its_in_tha_room(n_user.nickname, n_user.ip, n_user.port))
                {
                    remota.UnSubscribe(n_user.nickname, n_user.ip, n_user.port);
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

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tb_client_port_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbnick_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_server_tcp_chan_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
