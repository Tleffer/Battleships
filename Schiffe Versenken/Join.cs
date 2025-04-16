using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schiffe_Versenken
{
    public partial class Join : Form
    {
        Socket client;
        string ip;
        int port;
        Thread t;
        int ip_index;
        IPEndPoint ipEndPoint;
        IPAddress localIpAddress;
        IPAddress destination_ip;
        Form1 original_form;
        bool connected = false;
        int own_port;
        Random rnd = new Random();
        public Join(Form1 original_form)
        {
            InitializeComponent();
            this.original_form = original_form;
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            port = Convert.ToInt32(port_box.Text); //liest den port aus, an welchen gesendet wird
            ip = ip_box.Text; //liest die IP aus, an welchen gesendet wird
            own_port = rnd.Next(7000, 8000); //generiert einen zufälligen port
            string hostName = Dns.GetHostName();


            SelectIP selectIP = new SelectIP(this, Dns.GetHostByName(hostName).AddressList); //führt die IP Auswahl aus
            selectIP.Show();
        }

        public void selectFinished(int index)
        {
            ip_index = index;


            var hostName = Dns.GetHostName();
            // This is the IP address of the local machine
            localIpAddress = Dns.GetHostByName(hostName).AddressList[ip_index]; //wählt die lokale IP aus

            destination_ip = System.Net.IPAddress.Parse(ip); 
            //erstellt aus der eingegebenen IP Adresse (String) eine IP Adresse als Zahl

            ipEndPoint = new IPEndPoint(destination_ip, port); //erstellt einen IPEndpoint

            //MessageBox.Show("" + localIpAddress);

            client = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp); //erstellt den Socket

            t = new Thread(SendMsg); //startet die Funktion des Sockets als Thread
            t.Start();

        }

        public async void SendMsg()
        {
            await client.ConnectAsync(ipEndPoint); //verbinden mit Server

            while (true)
            {
                //send message.
                var message = ip + ";" + own_port; //erstellen der zu sendenden Nachricht

                var messageBytes = Encoding.UTF8.GetBytes(message); //kodieren der Nachricht
                client.Send(messageBytes, SocketFlags.None); //senden der Nachricht

                var buffer = new byte[1024];
                var received = client.Receive(buffer, SocketFlags.None);
                var response = Encoding.UTF8.GetString(buffer, 0, received);
                if (response == "<|ACK|>") //erhalten der Bestätigung
                {
                    connected = true;
                    client.Close();
                    break;

                }
            }
        }

        public void startMainGame() //startet das Hauptspiel
        {
            Game maingame = new Game(false, original_form, localIpAddress, destination_ip, own_port, port);
            maingame.Show();
            this.Hide();
        }

        private void tick_Tick(object sender, EventArgs e)
        {
            if (connected) //wenn verbunden, dann den Start button aktivieren
            { 
                button_start.Enabled = true;
                button_start.BackColor = Color.YellowGreen;
                tick.Enabled = false;
            }
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            startMainGame();
        }
    }
}
