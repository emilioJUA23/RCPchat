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
        Class1 local;
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
                MessageBox.Show("El servidor ha sido montado");
                local = (Class1)Activator.GetObject(typeof(Class1), "tcp://localhost:"+tb_puertoserver.Text+"/chat");
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

        private void bntcommadn_Click(object sender, EventArgs e)
        {
            try
            {
                string[] comando = tbcomando.Text.ToLower().Split(' ');
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
                    foreach (string c in users)
                    {
                        listBox1.Items.Add(c);
                    }
                }
                else
                {
                    MessageBox.Show("Commando no reconocible.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Commando no reconocible.");
            }
        }
    }
}
