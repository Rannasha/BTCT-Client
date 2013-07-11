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
            cbOrderType.SelectedIndex = 0;
            cbExpiry.SelectedIndex = 0;
            OnAuthStatusChanged(null, EventArgs.Empty);
            b = new BTCTLink(_consumerKey, _consumerSecret);
            b.AuthStatusChanged += OnAuthStatusChanged;
        }

        private void OnAuthStatusChanged(object sender, EventArgs e)
        {
            AuthStatusChangedEventArgs ea;

            if (e.Equals(EventArgs.Empty))
            {
                ea = new AuthStatusChangedEventArgs(AuthStatusType.AS_NONE);
            }
            else
            {
                ea = (AuthStatusChangedEventArgs)e;
            }

            switch (ea.AuthStatus)
            {
                case AuthStatusType.AS_NONE:
                    button1.Enabled = true;
                    button2.Enabled = false;
                    textBox3.ReadOnly = true;
                    textBox2.Text = "None";
                    break;
                case AuthStatusType.AS_REQRCV:
                    button1.Enabled = false;
                    button2.Enabled = true;
                    textBox3.ReadOnly = false;
                    textBox2.Text = "Req-rcv";
                    break;
                case AuthStatusType.AS_OK:
                    button1.Enabled = false;
                    button2.Enabled = false;
                    textBox3.ReadOnly = true;
                    textBox2.Text = "Authorized";
                    break;

            }
        
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
            Portfolio p;
            try
            {
                p = b.getPortfolio();
            }
            catch (BTCTException ex)
            {
                textBox4.Text += "Error getting portfolio. Error-message: " + ex.Message;
                return;
            }
    
            textBox4.Text += "User: " + p.username + Environment.NewLine;
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
            textBox1.Text = b.ApiKey;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            b.SerializeConfig("btct-client.dat");
        }

        private void button6_Click(object sender, EventArgs e)
        {

            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TradeHistory t = null;

            try
            {
                t = b.GetTradeHistory(textBox1.Text);
            }
            catch (Exception ex)
            {
                textBox4.Text += "Error obtaining trade history: " + ex.Message + Environment.NewLine;
                return;
            }

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

        private void button8_Click(object sender, EventArgs e)
        {
            int id;

            try
            {
                id = Convert.ToInt32(tbCancelOrderId.Text);
            }
            catch (Exception ex)
            {
                textBox4.Text += "Order ID field not a valid number." + Environment.NewLine;
                return;
            }
            try
            {
                b.CancelOrder(id);
            }
            catch (BTCTException ex)
            {
                textBox4.Text += "Error cancelling order: " + ex.Message + Environment.NewLine;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string security = tbSecurity.Text;
            int amount = 0;
            double price = 0;
            try
            {
                amount = Convert.ToInt32(tbAmount.Text);
            }
            catch (Exception ex)
            {
                textBox4.Text += "Invalid input for field 'amount'" + Environment.NewLine;
                amount = -1;
            }
            try
            {
                price = Convert.ToDouble(tbPrice.Text);
            }
            catch (Exception ex)
            {
                textBox4.Text += "Invalid input for field 'price'" + Environment.NewLine;
                amount = -1;
            }
            OrderType ot;
            switch (cbOrderType.SelectedIndex)
            {
                case 0:
                    ot = OrderType.OT_BUY;
                    break;
                case 1:
                    ot = OrderType.OT_SELL;
                    break;
                default:
                    ot = OrderType.OT_UNKNOWN;
                    break;
            }
            int expiry = Convert.ToInt32(cbExpiry.Text);
            if (amount > 0)
            {
                try
                {
                    b.SubmitOrder(security, amount, BTCTUtils.DoubleToSatoshi(price), ot, expiry);
                    textBox4.Text += "Order submitted.";
                }
                catch (BTCTException ex)
                {
                    textBox4.Text += ex.Message + Environment.NewLine;
                }
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            DividendHistory dh;
            try
            {
                dh = b.GetDividendHistory(textBox1.Text);
            }
            catch (BTCTException ex)
            {
                textBox4.Text += "Error obtaining dividend history: " + ex.Message + Environment.NewLine;
                return;
            }

            foreach (Dividend d in dh.dividends)
            {
                textBox4.Text += "[" + d.dateTime.ToString() + "] " + d.security.name + ": " + d.shares.ToString() + " x " 
                        + BTCTUtils.SatoshiToString(d.dividend) + " = " + BTCTUtils.SatoshiToString(d.dividend * d.shares) + Environment.NewLine;
            }
        }


    }
}
