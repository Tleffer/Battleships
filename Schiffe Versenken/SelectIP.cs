using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schiffe_Versenken
{
    public partial class SelectIP : Form
    {
        Host host;
        Join join;
        IPAddress[] addr;
        int index;
        public SelectIP(Host host, IPAddress[] ips)
        {
            InitializeComponent();
            this.host = host;
            this.addr = ips;
        }

        public SelectIP(Join join, IPAddress[] ips)
        {
            InitializeComponent();
            this.join = join;
            this.addr = ips;
        }

        private void SelectIP_Load(object sender, EventArgs e)
        {
            IPs.Items.Clear(); //löschen der ListView
            for (int i = 0; i < addr.Length; i++) //anzeigen der IPs in der ListView
            {
                string[] row = { i.ToString(), addr[i].ToString() };
                ListViewItem item = new ListViewItem(row);
                IPs.Items.Add(item);
            }
        }

        private void IPs_DoubleClick(object sender, EventArgs e)
        {
            index = Convert.ToInt32(IPs.SelectedItems[0].Text); //auswählen der IP durch Doppelclick
            if(host != null)
            {
                host.selectFinished(index);
                host.Show();
            } 
            else if(join != null)
            {
                join.selectFinished(index);
                join.Show();
            } 
            this.Close();
        }
    }
}
