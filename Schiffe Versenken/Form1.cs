using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schiffe_Versenken
{
    public partial class Form1 : Form
    {
        Game maingame;
        public Join joinform;
        public Host hostform;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_host_Click(object sender, EventArgs e)
        {
            hostform = new Host(this);
            hostform.Show();
            this.Hide();
        }

        private void button_join_Click(object sender, EventArgs e)
        {
            joinform = new Join(this);
            joinform.Show();
            this.Hide();
        }
    }
}
