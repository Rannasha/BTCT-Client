using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using OAuth;

namespace BTCTC
{
    public partial class Form1 : Form
    {
        private const string _consumerKey = "20bd6751441ff12b98117f4be1c09a9371de4cf7";
        private const string _consumerSecret = "0949565dac0d493501a84cbab79a0f9eb6c936a9";
        private BTCTLink b;
 
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b = new BTCTLink(_consumerKey, _consumerSecret);
//            b.getRequestToken();
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            b.getAccessToken(textBox3.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
        //    Portfolio p = b.getPortfolio();
            Portfolio p = b.parsePortfolio(textBox1.Text);

            textBox4.Text = "User: " + p.username + Environment.NewLine;
            textBox4.Text += "Generated: " + p.lastUpdate.ToString() + Environment.NewLine;
            foreach (SecurityOwned so in p.securities)
            {
                textBox4.Text += so.security.name + "(" + Convert.ToString(so.amount) + ")" + Environment.NewLine;
            }
        }


    }
}
