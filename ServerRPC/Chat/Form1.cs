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
                WellKnownObjectMode.SingleCall);
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
    }
}
