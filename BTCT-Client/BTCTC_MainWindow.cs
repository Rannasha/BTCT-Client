using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Web;
using OAuth;

namespace BTCTC
{
    public partial class BTCTC_MainWindow : Form
    {
        private const string _consumerKey = "20bd6751441ff12b98117f4be1c09a9371de4cf7";
        private const string _consumerSecret = "0949565dac0d493501a84cbab79a0f9eb6c936a9";
        private BTCTLink b;

        public BTCTC_MainWindow()
        {
            InitializeComponent();
            cbOrderType.SelectedIndex = 0;
            cbExpiry.SelectedIndex = 0;
            OnAuthStatusChanged(null, EventArgs.Empty);
            b = new BTCTLink(_consumerKey, _consumerSecret, DebugToTextBox);
            b.AuthStatusChanged += OnAuthStatusChanged;
        }

        private void Log(string s, bool toFile)
        {
            if (toFile)
            {
                using (StreamWriter sw = new StreamWriter("log.txt", true))
                {
                    sw.Write(s);
                }
            }

            tbOutput.Text += s;
        }

        private void DebugToTextBox(string msg)
        {
          //  Log(msg + Environment.NewLine, false);
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
                    button1.Enabled = true;
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
            MessageBox.Show("After authorizing BTCT-Client in the browser window that just opened, copy/paste the \"oauth_verifier\" into the \"Verifier\" textbox and click \"Authorize\"", "BTCT-Client: Authorization in progress", MessageBoxButtons.OK);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            b.GetAccessToken(textBox3.Text);
            Portfolio p = b.GetPortfolio();
            b.ApiKey = p.apiKey;
            textBox1.Text = b.ApiKey;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Portfolio p;
            try
            {
                p = b.GetPortfolio();
            }
            catch (BTCTException ex)
            {
               Log("Error getting portfolio. Error-message: " + ex.Message, false);
                return;
            }

            Log("User: " + p.username + Environment.NewLine, false);
            Log("Generated: " + p.lastUpdate.ToString() + Environment.NewLine, false);
            foreach (SecurityOwned so in p.securities)
            {
                Log(so.security.name + " (" + Convert.ToString(so.amount) + ")" + Environment.NewLine, false);
            }
            foreach (Order o in p.orders)
            {
                switch (o.orderType)
                {
                    case OrderType.OT_BUY:
                        Log("BUY: ", false);
                        break;
                    case OrderType.OT_SELL:
                        Log("SELL: ", false);
                        break;
                    case OrderType.OT_UNKNOWN:
                        Log("UNKNOWN: ", false);
                        break;
                }
                Log(o.security.name + " x " + Convert.ToString(o.amount) + Environment.NewLine, false);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            b.DeserializeConfig("btct-client.dat");
            textBox1.Text = b.ApiKey;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            b.ApiKey = textBox1.Text;
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
                Log("Error obtaining trade history: " + ex.Message + Environment.NewLine, false);
                return;
            }

            for (int i = 0; i < t.orders.Count; i++)
            {
                Log("[" + t.orders[i].dateTime.ToString() + "] ", false);
                switch (t.orders[i].orderType)
                {
                    case OrderType.OT_BUY:
                        Log("buy ", false);
                        break;
                    case OrderType.OT_SELL:
                        Log("sell ", false);
                        break;
                    case OrderType.OT_TIN:
                        Log("tr-in ", false);
                        Log("(" + t.orders[i].transferUser + ") ", false);
                        break;
                    case OrderType.OT_TOUT:
                        Log("tr-out ", false);
                        Log("(" + t.orders[i].transferUser + ") ", false);
                        break;
                    default:
                        Log("unknown ", false);
                        break;
                }
                Log(t.orders[i].amount.ToString() + " x " + t.orders[i].security.name + " @ " + BTCTUtils.SatoshiToString(t.orders[i].price), false);
                Log(Environment.NewLine, false);
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
                Log("Order ID field not a valid number." + Environment.NewLine, false);
                return;
            }
            try
            {
                b.CancelOrder(id);
            }
            catch (BTCTException ex)
            {
                Log("Error cancelling order: " + ex.Message + Environment.NewLine, false);
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
                Log("Invalid input for field 'amount'" + Environment.NewLine, false);
                amount = -1;
            }
            try
            {
                price = Convert.ToDouble(tbPrice.Text);
            }
            catch (Exception ex)
            {
                Log("Invalid input for field 'price'" + Environment.NewLine, false);
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
                    Log("Order submitted." + Environment.NewLine, false);
                }
                catch (BTCTException ex)
                {
                    Log(ex.Message + Environment.NewLine, false);
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
                Log("Error obtaining dividend history: " + ex.Message + Environment.NewLine, false);
                return;
            }

            foreach (Dividend d in dh.dividends)
            {
                Log("[" + d.dateTime.ToString() + "] " + d.security.name + ": " + d.shares.ToString() + " x "
                        + BTCTUtils.SatoshiToString(d.dividend) + " = " + BTCTUtils.SatoshiToString(d.dividend * d.shares) + Environment.NewLine, false);
            }
        }

        private void getAllTickers()
        {
            List<Ticker> lt = b.GetTickers();

            foreach (Ticker t in lt)
            {
                Log(t.name + " -- " + t.lastQty.ToString() + "@" + t.last.ToString() + Environment.NewLine, false);
            }
        }

        private void getTradeHistory()
        {
            TradeHistory t = null;

            try
            {
                t = b.GetPublicTradeHistory();
            }
            catch (Exception ex)
            {
                Log("Error obtaining trade history: " + ex.Message + Environment.NewLine, false);
                return;
            }

            for (int i = 0; i < t.orders.Count; i++)
            {
                Log("[" + t.orders[i].dateTime.ToString() + "] ", false);
                switch (t.orders[i].orderType)
                {
                    case OrderType.OT_BUY:
                        Log("buy ", false);
                        break;
                    case OrderType.OT_SELL:
                        Log("sell ", false);
                        break;
                    case OrderType.OT_TIN:
                        Log("tr-in ", false);
                        break;
                    case OrderType.OT_TOUT:
                        Log("tr-out ", false);
                        break;
                    default:
                        Log("unknown ", false);
                        break;
                }
                Log(t.orders[i].amount.ToString() + " x " + t.orders[i].security.name + " @ " + BTCTUtils.SatoshiToString(t.orders[i].price), false);
                Log(Environment.NewLine, false);
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {

        }

        #region DMS Auto-Transfer functions
        System.Timers.Timer updateTimer;
        int interval;
        bool readOnly, singleUser;
        string singleUserName;
        DateTime lastUpdate;

        private void cbReadOnly_CheckedChanged(object sender, EventArgs e)
        {
            bool ro = cbReadOnly.Checked;
            bool su = cbSingleUser.Checked;

            cbSingleUser.Enabled = !ro;
            tbSingleUserName.Enabled = !ro && su;
            lbSingleUserName.Enabled = !ro && su;
        }

        private void cbSingleUser_CheckedChanged(object sender, EventArgs e)
        {
            bool su = cbSingleUser.Checked;

            tbSingleUserName.Enabled = su;
            lbSingleUserName.Enabled = su;
        }

        private void btnAutoTransferStart_Click(object sender, EventArgs e)
        {
            if (b.AuthStatus != AuthStatusType.AS_OK)
            {
                Log("Not yet authorized." + Environment.NewLine, false);
                return;
            }
            try
            {
                interval = Convert.ToInt32(tbInterval.Text) * 1000 *60;
            }
            catch (Exception ex)
            {
                Log("Invalid number-format in interval-input" + Environment.NewLine, false);
                return;
            }
            if (interval < 2)
            {
                Log("Interval too short, needs to be at least 2 minutes" + Environment.NewLine, false);
                return;
            }

            updateTimer = new System.Timers.Timer(interval);
            updateTimer.SynchronizingObject = this;
            updateTimer.Elapsed += new ElapsedEventHandler(doUpdate);
            updateTimer.Enabled = true;

            readOnly = cbReadOnly.Checked;
            singleUser = cbSingleUser.Checked;
            if (singleUser)
                singleUserName = tbSingleUserName.Text;
            
            lbInterval.Enabled = false;
            tbInterval.Enabled = false;
            cbReadOnly.Enabled = false;
            cbSingleUser.Enabled = false;
            lbSingleUserName.Enabled = false;
            tbSingleUserName.Enabled = false;

            btnAutoTransferStart.Enabled = false;
            btnAutoTransferStop.Enabled = true;

            TradeHistory t;

            try
            {
                t = b.GetTradeHistory();
            }
            catch (BTCTException ex)
            {
                Log("Error obtaining initial trade history - Timer aborted. Message: " + ex.Message, false);
                btnAutoTransferStop_Click(sender, e);
                return;
            }
            
            lastUpdate = t.orders[t.orders.Count - 1].dateTime;
        }

        private void btnAutoTransferStop_Click(object sender, EventArgs e)
        {
            updateTimer.Enabled = false;

            lbInterval.Enabled = true;
            tbInterval.Enabled = true;
            cbReadOnly.Enabled = true;
            cbSingleUser.Enabled = !readOnly;
            lbSingleUserName.Enabled = !readOnly && singleUser;
            tbSingleUserName.Enabled = !readOnly && singleUser;

            btnAutoTransferStart.Enabled = true;
            btnAutoTransferStop.Enabled = false;
        }

        private void doUpdate(object sender, ElapsedEventArgs e)
        {
            string input = "DMS.PURCHASE";
            string[] output = { "DMS.MINING", "DMS.SELLING" };
            
            Log("Update started at " + DateTime.Now.ToString() + Environment.NewLine, true);

            TradeHistory t;
            try
            {
                t = b.GetTradeHistory();
            }
            catch (BTCTException ex)
            {
                Log("Error obtaining trade history. Message: " + ex.Message, true);
                return;
            }

            foreach (Order o in t.orders)
            {
                if (o.dateTime.CompareTo(lastUpdate) > 0
                    && o.orderType == OrderType.OT_TIN
                    && o.security.name == input)
                {
                    int num = o.amount;
                    string username = o.transferUser;
                    Log("TX-IN: " + num.ToString() + " x " + o.security.name + " <- " + username + Environment.NewLine, true);
                    foreach (string s in output)
                    {
                        try
                        {
                            if (!readOnly)
                            {
                                if (!singleUser || singleUserName == username)
                                {
                                    b.TransferAsset(s, num, username, 0);
                                }
                            }
                            if (readOnly || (singleUser && singleUserName == username))
                            {
                                Log("(not executed) ", true);
                            }
                            Log("TX-OUT: " + num.ToString() + " x " + s + " -> " + username + Environment.NewLine, true);
                        }
                        catch (BTCTException ex)
                        {
                            Log("ERROR: " + ex.Message + Environment.NewLine, true);
                        }
                    }
                }
            }
            lastUpdate = t.orders[t.orders.Count - 1].dateTime;

        }
        #endregion




    }
}
