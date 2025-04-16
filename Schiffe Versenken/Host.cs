using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Schiffe_Versenken
{
    public partial class Host : Form
    {
        Socket host;
        int port;
        int dest_port;
        int ip_index;
        Random rnd = new Random();
        Thread t;
        IPEndPoint ipEndPoint;
        IPAddress origin_ip;
        IPAddress localIpAddress;
        Form1 original_form;
        bool connected = false;
        public Host(Form1 orig)
        {
            InitializeComponent();
            original_form = orig;
        }

        private void Host_Load(object sender, EventArgs e)
        {
            port = rnd.Next(5000, 6000); //Generiert einen Zufälligen port
            port_label.Text = "" + port;

            string hostName = Dns.GetHostName();
            //Ruft den Hostnamen des lokalen Computers auf


            SelectIP selectIP = new SelectIP(this, Dns.GetHostByName(hostName).AddressList); 
            //öffnet das Auswahlfenster für die IP-Adresse

            selectIP.Show();
            this.Hide();

        }
        public void selectFinished(int index) //wird ausgeführt, wenn die IP auswahl Fertig ist
        {
            ip_index = index;

            var hostName = Dns.GetHostName(); // Die IP des lokalen Computers

            ip_label.Text = Dns.GetHostByName(hostName).AddressList[ip_index].ToString(); 
            //schreibe die IP auf das Label


            localIpAddress = Dns.GetHostByName(hostName).AddressList[ip_index]; 
            //die Richtige IP wird ausgewählt anhand des Auswahlfensters

            ipEndPoint = new IPEndPoint(localIpAddress, port);


            host = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp); 
            //erstellen von Socket

            Thread t = new Thread(WaitForJoin); //ausführen der Funktion des Sockets
            t.Start();

        }

        public async void WaitForJoin()
        {
            host.Bind(ipEndPoint); 
            //der server wird auf die EndPoint gebindet

            host.Listen(100); 
            //der Socket wird auf den Wartemodus gestellt

            var handler = await host.AcceptAsync(); 
            //es wird auf eine Verbindung gewartet

            while (true)
            {
                // Receive message.
                var buffer = new byte[1024];
                var received = handler.Receive(buffer, SocketFlags.None); 
                //die erhaltene Nachricht wird abgespeichert

                var response = Encoding.UTF8.GetString(buffer, 0, received); 
                //die erhaltene Nachricht wird dekodiert

                if(response != null)
                {
                    var response_arr = response.Split(';'); //die Erhaltene Nachricht wird geparsed

                    origin_ip = System.Net.IPAddress.Parse(response_arr[0]);
                    dest_port = Convert.ToInt32(response_arr[1]);
                    connected = true;

                    var ackMessage = "<|ACK|>"; //eine Bestätigung wird zurückgesendet
                    var echoBytes = Encoding.UTF8.GetBytes(ackMessage);
                    handler.Send(echoBytes, 0);

                    host.Close();
                    break;
                }
            }
        }

        public void startMainGame() //das Spiel starten
        {
            Game maingame = new Game(true, original_form, localIpAddress, origin_ip, port, dest_port);
            maingame.Show();
            this.Hide();
        }

        private void button_join_Click(object sender, EventArgs e)
        {

            startMainGame();
        }

        private void general_Tick(object sender, EventArgs e)
        {
            if(connected) //wenn verbunden, dann den Start button aktivieren
            {
                button_start.Enabled = true;
                button_start.BackColor = Color.YellowGreen;
                general.Enabled = false;
            }
            
        }
    }
}
