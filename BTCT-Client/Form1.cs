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
            b = new BTCTLink(_consumerKey, _consumerSecret);
        }

        private void button1_Click(object sender, EventArgs e)
        {
             b.GetRequestToken();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            b.GetAccessToken(textBox3.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Portfolio p = b.getPortfolio();
    
            textBox4.Text = "User: " + p.username + Environment.NewLine;
            textBox4.Text += "Generated: " + p.lastUpdate.ToString() + Environment.NewLine;
            foreach (SecurityOwned so in p.securities)
            {
                textBox4.Text += so.security.name + " (" + Convert.ToString(so.amount) + ")" + Environment.NewLine;
            }
            foreach (Order o in p.orders)
            {
                switch (o.orderType)
                {
                    case OrderType.OT_BUY:
                        textBox4.Text += "BUY: ";
                        break;
                    case OrderType.OT_SELL:
                        textBox4.Text += "SELL: ";
                        break;
                    case OrderType.OT_UNKNOWN:
                        textBox4.Text += "UNKNOWN: ";
                        break;
                }
                textBox4.Text += o.security.name + " x " + Convert.ToString(o.amount) + Environment.NewLine;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            b.DeserializeConfig("btct-client.dat");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            b.SerializeConfig("btct-client.dat");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string r = b.SubmitOrder("TAMINER", 1000, BTCTUtils.StringToSatoshi("0,01"), OrderType.OT_BUY, 0);
                textBox4.Text += r + Environment.NewLine;
            }
            catch (BTCTException ex)
            {
                textBox4.Text += ex.Message + Environment.NewLine;
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TradeHistory t = b.GetTradeHistory(textBox1.Text);

            for (int i = 0; i < t.orders.Count; i++)
            {
                textBox4.Text += "[" + t.orders[i].dateTime.ToString() + "] ";
                switch (t.orders[i].orderType)
                {
                    case OrderType.OT_BUY:
                        textBox4.Text += "buy ";
                        break;
                    case OrderType.OT_SELL:
                        textBox4.Text += "sell ";
                        break;
                    case OrderType.OT_TIN:
                        textBox4.Text += "tr-in ";
                        break;
                    case OrderType.OT_TOUT:
                        textBox4.Text += "tr-out ";
                        break;
                    default:
                        textBox4.Text += "unknown ";
                        break;
                }
                textBox4.Text += t.orders[i].amount.ToString() + " x " + t.orders[i].security.name + " @ " + BTCTUtils.SatoshiToString(t.orders[i].price);
                textBox4.Text += Environment.NewLine;
            }

        }


    }
}
