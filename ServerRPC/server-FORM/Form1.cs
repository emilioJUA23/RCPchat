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

namespace server_FORM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TcpChannel serverchannel;
        private void btnstart_Click(object sender, EventArgs e)
        {
            try
            {
                int puerto_server = Convert.ToInt32(tb_puertoserver.Text);
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

        private void btnstop_Click(object sender, EventArgs e)
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
