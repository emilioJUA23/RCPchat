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
        List<int> tiempos = new List<int>();
        TcpChannel Channel;
        user n_user;

        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Try_Connect(tb_server_tcp_chan.Text, tbnick.Text);
        }

        private void btn_client_subscribe_Click(object sender, EventArgs e)
        {
            InstanciaUsuario(tbnick.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Disconnect(tb_server_tcp_chan.Text);
        }

        private void InstanciaUsuario(string nick)
        {
            try
            {
                string puerto_cliente = tb_client_port.Text;
                n_user = new user(nick, "localhost", puerto_cliente);
                MessageBox.Show("Usuario creado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido crear usuario: " + ex.Message);
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
                button1.Enabled = false;
                tb_client_port.Enabled = false;
               // button2.Enabled = true;
                timer1.Start();
                MessageBox.Show("Servidor ha sido montado!");
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
                button1.Enabled = true;
                tb_client_port.Enabled = true;
                button2.Enabled = false;
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
            if (server_name.Count >= 1)
            {
                chequear_chat();
            }
            if (local != null)
            {
             //   chequear_connected();
            }
        }

        private void chequear_chat()
        {
            try
            {
                for (int i = 0; i < remotes.Count; i++)
                {
                    string para_mostrar = "<" + server_name[i] + "> ";
                    remota = remotes[i];
                    List<string> buzon_aux;
                    try
                    {
                        buzon_aux = remota.mail_delivery(n_user.nickname);
                        foreach (string c in buzon_aux)
                        {
                            string[] orden = c.Split(',');
                            if (orden.Length == 3)
                            {
                                if (orden[0] == "dir_init")
                                {
                                    remota.mensaje_privado(directory(orden[1])+"\r\n\r\n", orden[2]);
                                }
                                else { }
                                rtb_Output.Text += (para_mostrar + orden[2] + " te ha pedido un directorio.\r\n");
                            }
                            else if (c == "sudo_kill_yourself")
                            {
                                remotes[i].UnSubscribe(n_user.nickname, n_user.ip, n_user.port);
                                remotes.RemoveAt(i);
                                server_name.RemoveAt(i);
                                rtb_Output.Text += (para_mostrar + "has sido eliminado de la sala por el servidor.\r\n");
                                para_mostrar = null;
                            }
                            else
                            {
                                rtb_Output.Text += (para_mostrar + c+"\r\n");
                            }
                        }
                        tiempos[i] = 0;
                    }
                    catch (Exception)
                    {
                        if (tiempos[i] >= 4)
                        {
                            server_name.RemoveAt(i);
                            remotes.RemoveAt(i);
                            tiempos.RemoveAt(i);
                            i--;
                            MessageBox.Show("Se perdio la conexion con el servidor " + para_mostrar);
                        }
                        else
                        {
                            try
                            {
                                remotes[i].IsInstance();
                                if (remotes[i].its_in_tha_room(n_user.nickname))
                                {

                                }
                                else
                                {
                                    remotes[i].Subscribe(n_user.nickname,n_user.ip,n_user.port);
                                }
                             
                            }
                            catch (Exception)
                            {
                                rtb_Output.Text += "fallo la coneccion con: "+server_name[i]+" se esta tratando de reconectar\r\n";
                            }
                            tiempos[i]++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error inesperado.");
            }
        }

        private void chequear_connected()
        {
            listBox1.Items.Clear();
            List<string> users = local.connected_server();
            foreach (string connected in users)
            {
                listBox1.Items.Add(connected);
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
                { resp = resp + Path.GetFileName(direntrie) + ','; }
                foreach (string fileName in fileEntries)
                { resp = resp + Path.GetFileName(fileName) + ','; }
                resp = resp.Substring(0, resp.Length - 1);
            }
            else
            {
                resp = "direccion de ruta invalida";
            }

            return resp;
        }

        #endregion

        #region comandos

        private void Try_Connect(string ip_port, string username)
        {
            try
            {
                if (Channel == null)                                        //verifica si el canal ya fue registrado tanto como server como por el 
                {
                    Channel = new TcpChannel(Convert.ToInt32("tcp://" + tb_client_port.Text));  //registra el canal y el puerto por el cual entramos                            
                    ChannelServices.RegisterChannel(Channel, false);
                }
                if (n_user == null)
                {
                    InstanciaUsuario(username);
                }
                Class1 RemotedObject = (Class1)Activator.GetObject(typeof(Class1), "tcp://" + ip_port + "/chat");
                try { RemotedObject.IsInstance(); }
                catch (Exception ex) { throw new Exception("No se encontro un servidor en la direccion indicada"); }
                if (RemotedObject.its_in_tha_room(n_user.nickname))  //verifica si existo 
                {
                    MessageBox.Show("El Usuario ya esta en esta sala o nickname ya tomado.");
                }
                else
                {
                    RemotedObject.Subscribe(n_user.nickname, n_user.ip, n_user.port);      //me agrega 
                    remotes.Add(RemotedObject);    //invoca servicio remoto
                    server_name.Add("tcp://" + ip_port + "/chat");                                           //agrega direccio de la sala
                    tiempos.Add(0);
                    MessageBox.Show("Te has unido a la sala");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido unir a sala: " + ex.Message);
            }
        }

        private void Disconnect(string ip_port)
        {
            try
            {
                for (int i = 0; i < server_name.Count; i++)
                {
                    if (server_name[i] == "tcp://" + ip_port + "/chat")
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
                            MessageBox.Show("No se encontro al usuario en la sala");
                        }

                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Send_Message(string message)
        {
            try
            {
                for (int i = 0; i < server_name.Count; i++)
                {
                    int a = remotes[i].broadcast(message, n_user.nickname);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ListDirectory(string path)
        {
            try
            {
                for (int j = 0; j < remotes.Count; j++)
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
                    int comp = remotes[j].directories(aux, n_user.nickname);
                    if (comp == 1)
                    {

                    }
                    else MessageBox.Show("error al ejecutar instruccion.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("error al ejecutar instruccion.");
                throw;
            }
        }

        #endregion

        //envia mensajes 
        private void button6_Click(object sender, EventArgs e)
        {
            Send_Message(tbmessage.Text);
        }

        //terminal de comandos tipo usuario
        private void button5_Click(object sender, EventArgs e)
        {
            string[] comando = tbcomando.Text.ToLower().Split(' ');
            if (comando[0] == "connect")
            {
                Try_Connect(comando[1], comando[2]);
            }
            else if (comando[0] == "send")
            {
                Send_Message(comando[1]); //TODO: Concatenar todo el mensage 
            }
            else if (comando[0] == "list" && comando[1] == "sender")
            {
                foreach (string c in server_name)
                {
                    rtb_Output.Text += ("\t" + c);
                }
            }
            else if (comando[0] == "list" && comando[1] == "dir")
            {
                ListDirectory(tbcomando.Text);
            }
            else
            {
                MessageBox.Show("commando no reconocible.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            for (int i = 0; i < remotes.Count; i++)
            {
                remotes[i].UnSubscribe(n_user.nickname, n_user.ip, n_user.port);
            }

        }
    }
}