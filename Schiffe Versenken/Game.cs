using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schiffe_Versenken
{
    public partial class Game : Form
    {
        Thread client_thread;
        Thread server_thread;
        string send_msg;
        string receive_msg;
        bool send_ack = false;
        bool send_Y = false;
        bool send_N = false;

        bool thread_restart = false;

        int clicked_x;
        int clicked_y;

        Socket listener;
        Socket client;

        bool is_host;
        Form1 original_window;
        IPAddress local; //own IP
        IPAddress dest; // destination IP
        IPEndPoint ipReEndPoint;
        IPEndPoint ipSeEndPoint;
        int own_port;
        int dest_port;
        bool is_your_turn;
        bool in_hiding = true;
        bool fin_hiding_own = false;
        bool fin_hiding_att = false;

        Label[,] own = new Label[10, 10];
        Label[,] att = new Label[10, 10];
        Felder[,] own_f = new Felder[10, 10];
        Felder[,] att_f = new Felder[10, 10];
        public Game(bool is_host, Form1 original_window, IPAddress local, IPAddress dest, int own_port, int dest_port)
        {
            InitializeComponent();
            this.is_host = is_host;
            this.original_window = original_window;
            this.local = local;
            this.dest = dest;
            this.own_port = own_port;
            this.dest_port = dest_port;
        }

        private void Game_Load(object sender, EventArgs e)
        {


            ipReEndPoint = new IPEndPoint(local, own_port); //own IP EndPoint
            ipSeEndPoint = new IPEndPoint(dest, dest_port); //destination IP EndPoint

            if (is_host) //host starts
            { 
                is_your_turn = true;
            } else
            {
                is_your_turn = false;
            }

            //att[i,j] --> i = x; j = y

            for (int i = 0; i < 10; i++) 
            {
                for (int j = 0; j < 10; j++) 
                {
                    own_f[i, j] = new Felder(true);
                    att_f[i, j] = new Felder(true);

                    own[i, j] = new Label { BackColor = Color.DarkGreen, Size = new Size(50, 50), Location = new Point(i*52 + 50, j*52 +50) }; //adding fields
                    att[i, j] = new Label { BackColor = Color.Green, Size = new Size(50, 50), Location = new Point(i * 52 + 600, j * 52 + 50) };

                    own[i, j].Click += own_clicked;
                    att[i, j].Click += att_clicked;

                    Controls.Add(own[i, j]);
                    Controls.Add(att[i, j]);
                }
            }

            label_do.Text = "Place your ships!";


            if(!is_your_turn)
            {
                //server_thread.Start();
                Controls.Remove(button_placed);
            }
            server_thread = new Thread(host);
            client_thread = new Thread(join);
            if (is_host) //decides if person is host or client
            {
                server_thread.Start();
            } else
            {
                client_thread.Start();
            }
        }

        public async void host() 
        {
            listener = new Socket(ipReEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(ipReEndPoint);
            listener.Listen(100);

            receive_msg = null;

            var handler = await listener.AcceptAsync(); //waiting for connection
            while (true)
            {
                if (is_your_turn) //decides if sending or reciving based on if it is your turn
                {
                    //send
                    var message = send_msg;
                    if (message != null)
                    {
                        var messageBytes = Encoding.UTF8.GetBytes(message);
                        handler.Send(messageBytes, SocketFlags.None);

                        var buffer = new byte[1024];
                        var received = handler.Receive(buffer, SocketFlags.None);

                        var response = Encoding.UTF8.GetString(buffer, 0, received);

                        if (response != null && (response == "<|ACK|>" || response == "<|Y|>" || response == "<|N|>")) //check for acknowledge/response
                        {
                            send_msg = null;

                            if(response == "<|Y|>")
                            {
                                send_Y = true;
                            } else if(response == "<|N|>")
                            {
                                send_N = true;
                            }

                            send_ack = true;
                            listener.Close();
                            thread_restart = true;
                            break; //breaking while loop if acknowledge received

                        }
                    }
                }
                else
                {
                    //receive
                    var buffer = new byte[1024];
                    var received = handler.Receive(buffer, SocketFlags.None);

                    var response = Encoding.UTF8.GetString(buffer, 0, received);

                    if (response != null && !(response == "<|ACK|>" || response == "<|Y|>" || response == "<|N|>"))
                    {
                        receive_msg = response;

                        string[] tmp = response.Split(';'); //parsing received string

                        var ackMessage = "<|ACK|>";
                        if (!in_hiding && own_f[Convert.ToInt32(tmp[0]), Convert.ToInt32(tmp[1])].is_ship) //checks if ship is on received location
                        {
                            ackMessage = "<|Y|>";
                        } else if(!in_hiding)
                        {
                            ackMessage = "<|N|>";
                        }

                        
                        var echoBytes = Encoding.UTF8.GetBytes(ackMessage);
                        handler.Send(echoBytes, 0);

                        response = null;
                        listener.Close();
                        thread_restart = true;
                        break;
                    }
                }
            }
        }
        public async void join() //same logic as above
        {
            send_ack = false;
            client = new Socket(ipSeEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            await client.ConnectAsync(ipSeEndPoint); //connecting to server

            while (true)
            {
                if (is_your_turn)
                {
                    //send
                    var message = send_msg;
                    if (message != null)
                    {
                        var messageBytes = Encoding.UTF8.GetBytes(message);
                        client.Send(messageBytes, SocketFlags.None);

                        var buffer = new byte[1024];
                        var received = client.Receive(buffer, SocketFlags.None);
                        var response = Encoding.UTF8.GetString(buffer, 0, received);

                        if (response != null && (response == "<|ACK|>" || response == "<|Y|>" || response == "<|N|>"))
                        {
                            send_msg = null;
                            if (response == "<|Y|>")
                            {
                                send_Y = true;
                            }
                            else if (response == "<|N|>")
                            {
                                send_N = true;
                            }
                            send_ack = true;
                            client.Close();
                            thread_restart = true;
                            break;

                        }
                    }
                }
                else
                {


                    // Receive message.
                    var buffer = new byte[1024];
                    var received = client.Receive(buffer, SocketFlags.None);
                    var response = Encoding.UTF8.GetString(buffer, 0, received);
                    if (response != null && !(response == "<|ACK|>" || response == "<|Y|>" || response == "<|N|>"))
                    {
                        receive_msg = response;

                        string[] tmp = response.Split(';');

                        var ackMessage = "<|ACK|>";
                        if (!in_hiding && own_f[Convert.ToInt32(tmp[0]), Convert.ToInt32(tmp[1])].is_ship)
                        {
                            ackMessage = "<|Y|>";
                        }
                        else if (!in_hiding)
                        {
                            ackMessage = "<|N|>";
                        }

                        var echoBytes = Encoding.UTF8.GetBytes(ackMessage);
                        client.Send(echoBytes, 0);

                        response = null;
                        client.Close();
                        thread_restart = true;
                        break;
                    }
                }
            }
        }


        public void own_clicked(object sender, EventArgs e)
        {
            if(in_hiding) //was passiert, wenn man das schiff verseteckt
            {
                for(int i = 0;i < 10;i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if(own[i, j] == sender)
                        {
                            own_f[i,j].is_ship = !own_f[i, j].is_ship;
                            if(own_f[i, j].is_ship) //changes color
                            {
                                own[i, j].BackColor = Color.Salmon;
                            } else
                            {
                                own[i, j].BackColor = Color.DarkGreen;
                            }
                            
                        }
                        
                    }
                }
            }
        }
        public void att_clicked(object sender, EventArgs e)
        {
            if(!in_hiding && is_your_turn) //was passiert, wenn man beim angriff auf das Feld clickt
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if(att[i, j] == sender)
                        {
                            string SendStr = i + ";" + j; //koordinaten werden gesendet
                            send_msg = SendStr;
                            clicked_x = i; clicked_y = j; //speichert die Koordinaten des geclickten Felds
                        }
                    }
                }
            }
        }

        private void button_placed_Click(object sender, EventArgs e)
        {
            fin_hiding_own = true; //was passiert, wenn man ferig mit dem versetecken ist
            Controls.Remove(button_placed);

            send_msg = "fin";
            
        }

        private void general_Tick(object sender, EventArgs e)
        { //thread restarters and received message parsers
            if (thread_restart && is_host)
            {
                server_thread = new Thread(host);
                server_thread.Start();
                thread_restart = false;
            }
            else if (thread_restart && !is_host)
            {
                client_thread = new Thread(join);
                client_thread.Start();
                thread_restart = false;
            }
            if (send_ack)
            {
                send_ack = false;
                is_your_turn = !is_your_turn;
            }
            if(send_Y)
            {
                send_Y = false;
                att_f[clicked_x, clicked_y].is_ship = true;
                att[clicked_x, clicked_y].BackColor = Color.Red;
                clicked_x = -1;
                clicked_y = -1;
            }
            if (send_N)
            {
                send_N = false;
                att[clicked_x, clicked_y].BackColor = Color.Aqua;
                clicked_x = -1;
                clicked_y = -1;
            }


            if (receive_msg != null)
            {
                is_your_turn = !is_your_turn;
                if (receive_msg == "fin" && in_hiding)
                {
                    fin_hiding_att = true;
                    label_do.Text = "Place your ships! \n Opponent has finished hiding!";
                    Controls.Add(button_placed);
                    receive_msg = null;
                    //receive_thread.Abort();
                }
                else
                {
                    string[] tmp = receive_msg.Split(';');
                    int x = Convert.ToInt32(tmp[0]);
                    int y = Convert.ToInt32(tmp[1]);

                    if (own_f[x, y].is_ship)
                    {
                        own[x, y].BackColor = Color.Red;
                    }
                    else
                    {
                        own[x, y].BackColor = Color.Aqua;
                    }
                    receive_msg = null;

                }
            }


            if (in_hiding && fin_hiding_own && fin_hiding_att) 
            { 
                in_hiding = false;
                Controls.Remove(button_placed);
                //MessageBox.Show("s");
            }


            if(!in_hiding && is_your_turn)
            {
                label_do.Text = "Your turn";
                label_do.ForeColor = Color.Green;
            } else if(!in_hiding)
            {
                label_do.Text = "Your opponent's turn";
                label_do.ForeColor = Color.Red;
            }

        }

        private void button_exit_Click(object sender, EventArgs e)
        { //schließt das Spiel
            original_window.Close();
        }
    }
}
