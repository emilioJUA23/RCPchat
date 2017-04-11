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

namespace Chat
{
    public partial class Form1 : Form
    {
        Class1 remota;
        Class1 local;
        List<Class1> remotes = new List<Class1>();
        List<string> server_name = new List<string>();
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

                if (Channel == null)                                        //verifica si el canal ya fue registrado tanto como server como por el 
                {
                    Channel = new TcpChannel(Convert.ToInt32(tb_client_port.Text));  //registra el canal y el puerto por el cual entramos                            
                    ChannelServices.RegisterChannel(Channel, false);
                }
                remotes.Add((Class1)Activator.GetObject(typeof(Class1), tb_server_tcp_chan.Text));    //invoca servicio remoto
                if (remotes[remotes.Count - 1].its_in_tha_room(n_user.nickname, n_user.ip, n_user.port))  //verifica si existo 
                {
                    remotes.RemoveAt(remotes.Count - 1);                                                  //elimina servicio 
                    MessageBox.Show("ususario ya esta en sala o nickname ya tomado.");
                }
                else
                {
                    remotes[remotes.Count - 1].Subscribe(n_user.nickname, n_user.ip, n_user.port);      //me agrega 
                    server_name.Add(tb_server_tcp_chan.Text);                                           //agrega direccio de la sala
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
                timer1.Start();
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
                timer1.Stop();
                for (int i = 0; i < server_name.Count; i++)
                {
                    if (server_name[i] == tb_server_tcp_chan.Text)
                    {
                        if (remotes[i].its_in_tha_room(n_user.nickname))
                        {
                            remotes[i].UnSubscribe(n_user.nickname, n_user.ip, n_user.port);
                            server_name.RemoveAt(i);
                            remotes.RemoveAt(i);
                            MessageBox.Show("Salimos de la sala.");
                        }
                        else
                        {
                            server_name.RemoveAt(i);
                            remotes.RemoveAt(i);
                            MessageBox.Show("usuario ya no estaba en la sala");
                        }

                        break;
                    }
                }
                timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    listBox1.Items.Add('\t' + c);
                }
            }
            else
            {
                MessageBox.Show("commando no reconocible.");
            }
        }
        #endregion


        #region timer_stuff
        private void timer1_Tick(object sender, EventArgs e)
        {
            chequear_chat();
        }

        private void chequear_chat()
        {
            try
            {
                for (int i = 0; i < remotes.Count; i++)
                {
                    remota = remotes[i];
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
                            listBox2.Items.Add(orden[2] + " te ha pedido un directorio.");
                        }
                        else
                        {
                            listBox2.Items.Add(server_name[i] + "," + c);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                timer1.Stop();
                MessageBox.Show("se ha desconectado del algun chat");
            }


        }

        public string directory(string ruta)
        {
            string resp = n_user.nickname + ": ";

            if (Directory.Exists(ruta))
            {
                string[] direntries = Directory.GetDirectories(ruta);
                string[] fileEntries = Directory.GetFiles(ruta);
                foreach (string direntrie in direntries)
                { resp = resp + direntrie + ','; }
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

        #endregion

        //envia mensajes 
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < server_name.Count; i++)
                {
                    if (server_name[i] == tb_server_tcp_chan.Text)
                    {
                        int a = remotes[i].broadcast(tbmessage.Text, n_user.nickname);
                        break;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //terminal de comandos tipo usuario
        private void button5_Click(object sender, EventArgs e)
        {
            remota = null;
            for (int i = 0; i < server_name.Count; i++)
            {
                if (server_name[i] == tb_server_tcp_chan.Text)
                {
                    remota = remotes[i];
                    break;
                }
            }
            if (remota == null)
            {
                MessageBox.Show("no exita subscrito a este chat");
            }
            else
            {
                string[] comando = tbcomando.Text.ToLower().Split(' ');
                if (comando[0] == "list" && comando[1] == "sender")
                {

                    List<string> users = remota.connected_server();
                    listBox2.Items.Add("los usuarios conectados son:");
                    foreach (string c in users)
                    {
                        listBox2.Items.Add("\t" + c);
                    }

                }
                else if (comando[0] == "list" && comando[1] == "dir")
                {
                    string dir = tbcomando.Text;
                    string aux = "";//aqui tengo la mera ruta;
                    int contador_comillas = 0;
                    for (int i = 0; i < dir.Length; i++)
                    {

                        if (dir[i] == '"' && contador_comillas == 0)
                        {
                            contador_comillas++;
                        }
                        else if (dir[i] == '"' && contador_comillas == 1)
                        {
                            contador_comillas++;
                        }
                        else if (contador_comillas == 1)
                        {
                            aux = aux + dir[i];
                        }
                        else { }

                    }
                    int comp = remota.directories(aux, n_user.nickname);
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
}
