using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BTCTC
{
    class DMSArb
    {
        private int _maxUnits = 100;
        private int _miningBidUnitsMult = 2;
        private double _minProfit = 0.005;
        private BTCTLink _link;
        private System.Timers.Timer _timer;
        private int _interval;
        private bool _active;
        private System.ComponentModel.ISynchronizeInvoke _syncObj;
        private int _incomingTransfers = 0;

        public bool Active
        {
            get
            {
                return _active;
            }
        }

        public bool ReadOnly { get; set; }

        public int Interval
        {
            get
            {
                return _interval;
            }
            set
            {
                if (Active)
                {
                    StopTimer();
                    _interval = value;
                    StartTimer(_syncObj);
                }
                else
                {
                    _interval = value;
                }
            }
        }

        public BTCTLink InLink
        {
            get
            {
                return _link;
            }
        }

        public DebugHandler Logger { get; set; }

        public DMSArb(BTCTLink inLink, int interval, int maxUnits, double minProfit)
        {
            _link = inLink;
            _interval = interval;

            _timer = new System.Timers.Timer();
            _timer.Interval = interval;

            _active = false;

            _maxUnits = maxUnits;
            _minProfit = minProfit;
        }

        public void Log(string msg)
        {
            if (Logger != null)
            {
                Logger(msg);
            }
        }

        public static long decreaseSellPrice(long price)
        {
            string priceString = price.ToString();

            int firstDigit = (from c in priceString
                              where c != '0'
                              select priceString.IndexOf(c)).First();

            char[] temp = priceString.ToCharArray();
            int num = (int)Char.GetNumericValue(temp[firstDigit + 3]) + 10 * (int)Char.GetNumericValue(temp[firstDigit + 2]) 
                      + 100 * (int)Char.GetNumericValue(temp[firstDigit + 1]) + 1000 * (int)Char.GetNumericValue(temp[firstDigit]) - 1;
            char[] temp2 = num.ToString().ToCharArray();
            temp[firstDigit] = temp2[0];
            temp[firstDigit + 1] = temp2[1];
            temp[firstDigit + 2] = temp2[2];
            temp[firstDigit + 3] = temp2[3];

            return Convert.ToInt64(new String(temp));
        }
                   
        public static int findMaxBidIndex(TradeHistory orderBook)
        {
            int i;

            for (i = 0; i < orderBook.orders.Count; i++)
            {
                if (orderBook.orders[i].orderType == OrderType.OT_SELL)
                {
                    return i - 1;
                }
            }

            return -1;
        }

        public long getMiningSellPrice(TradeHistory orderBook, int minUnits)
        {
            int i = findMaxBidIndex(orderBook);
            if (i < 0) return -1;

            long currPrice = 0;
            long totalUnits = 0;
            bool found = false;

            while (!found && i >= -1)
            {
                totalUnits += orderBook.orders[i].amount;
                currPrice = orderBook.orders[i].price;
                
                if (totalUnits >= minUnits)
                {
                    found = true;
                }

                i--;
            }

            if (found)
            {
                return currPrice;
            }
            else
            {
                return -1;
            }
        }

        public long getSellingSellPrice(TradeHistory orderBook)
        {
            int i = findMaxBidIndex(orderBook) + 1;

            return orderBook.orders[i].price;
        }

        public long getPurchaseBuyPrice(TradeHistory orderBook)
        {
            int i = findMaxBidIndex(orderBook) + 1;

            while (orderBook.orders[i].amount < 1000)
            {
                i++;
                if (i == orderBook.orders.Count) return 1000000000;
            }

            return orderBook.orders[i].price;
        }

        public int getSellingDeficit(Portfolio p)
        {
            int num;

            if (p.securities.Count(s => s.security.name == "DMS.SELLING") > 0)
            {
                num = (from s in p.securities
                        where s.security.name == "DMS.SELLING"
                        select s.amount).First();
            }
            else
            {
                num = 0;
            }

            return _maxUnits - num;
        }

        public int getPurchaseCount(Portfolio p)
        {
            if (p.securities.Count(s => s.security.name == "DMS.PURCHASE") > 0)
            {
                return (from s in p.securities
                        where s.security.name == "DMS.PURCHASE"
                        select s.amount).First();
            }
            else
            {
                return -1;
            }
        }

        public int getMiningCount(Portfolio p)
        {
            if (p.securities.Count(s => s.security.name == "DMS.MINING") > 0)
            {
                return (from s in p.securities
                        where s.security.name == "DMS.MINING"
                        select s.amount).First();
            }
            else
            {
                return -1;
            }

        }

        public int getSellingOrderId(Portfolio p)
        {
            if (p.orders.Count(o => o.security.name == "DMS.SELLING") > 0)
            {
                return (from o in p.orders
                        where o.security.name == "DMS.SELLING" && o.orderType == OrderType.OT_SELL
                        select o.id).First();
            }
            else
            {
                return -1;
            }
        }

        public static long arbProfit(long sAsk, long mBid, long pAsk)
        {
            return (998 * (sAsk + mBid) - 1002 * pAsk) / 1000;
        }

        private void DoUpdate(object sender, ElapsedEventArgs e)
        {
            Portfolio p = null;
            TradeHistory oMining = null;
            TradeHistory oSelling = null;
            TradeHistory oPurchase = null;
            try
            {
                p = _link.GetPortfolio();
                oMining = _link.GetOrderBook("DMS.MINING");
                oSelling = _link.GetOrderBook("DMS.SELLING");
                oPurchase = _link.GetOrderBook("DMS.PURCHASE");
            }
            catch (Exception ex)
            {
                Log("Error obtaining portfolio/orderbooks: " + ex.Message + Environment.NewLine);
            }

            long profit = DMSArb.arbProfit(getSellingSellPrice(oSelling), getMiningSellPrice(oMining, _maxUnits * _miningBidUnitsMult), getPurchaseBuyPrice(oPurchase));
            int orderId = getSellingOrderId(p);
            int numSelling = _maxUnits - getSellingDeficit(p);

            Log("M = " + getMiningSellPrice(oMining, _maxUnits * _miningBidUnitsMult) + " - S = " + getSellingSellPrice(oSelling) + " - profit = " + profit.ToString() + " - orderId = " + orderId.ToString() + Environment.NewLine);

            // If we have any MINING, sell them immediately into the bid.
            if (getMiningCount(p) > 0)
            {
                int mc = getMiningCount(p);
                long price = getMiningSellPrice(oMining, 2 * getMiningCount(p));
                Log("MINING-count = " + mc.ToString() + " - MINING-price = " + price.ToString() + Environment.NewLine);
                _incomingTransfers -= mc;

                try
                {
                    _link.SubmitOrder("DMS.MINING", getMiningCount(p), price, OrderType.OT_SELL, 0);
                }
                catch (Exception ex)
                {
                    Log("Error selling MINING: " + ex.Message + Environment.NewLine);
                }
            }

            // Cancel an existing SELLING order. We will remake the order later if circumstances are still okay.
            if (orderId > 0)
            {
                try
                {
                    _link.CancelOrder(orderId);
                    oSelling = _link.GetOrderBook("DMS.SELLING");
                }
                catch (Exception ex)
                {
                    Log("Error with order cancel: " + ex.Message + Environment.NewLine);
                }
            }
            long targetSellingPrice = DMSArb.decreaseSellPrice(getSellingSellPrice(oSelling));
            Log("targetSellingPrice = " + targetSellingPrice.ToString() + " - numSelling = " + numSelling.ToString() + Environment.NewLine);

            // If we don't have enough SELLING units (including transfers that are still incoming), buy more PURCHASE.
            // After the order, wait 1 second and transfer the PURCHASE units.
            if (numSelling + _incomingTransfers < _maxUnits)
            {
                Log("incomingTransfers = " + _incomingTransfers.ToString() + Environment.NewLine);
                try
                {
                    int pc = _maxUnits - numSelling - _incomingTransfers;
                    _link.SubmitOrder("DMS.PURCHASE", pc, getPurchaseBuyPrice(oPurchase), OrderType.OT_BUY, 0);
                    System.Threading.Thread.Sleep(1000);
                    _link.TransferAsset("DMS.PURCHASE", pc, "DeprivedMining", 0);
                    _incomingTransfers += pc;
                    Log("Bought & tx'ed " + pc.ToString() + " units. New _incomingTransfers = " + _incomingTransfers.ToString() + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    Log("Error with PURCHASE: " + ex.Message + Environment.NewLine);
                }
            }

            // Finally, if the potential arbitrage profit is large enough, submit a new SELLING order.
            if (profit > _minProfit * targetSellingPrice && numSelling > 0)
            {
                try
                {
                    _link.SubmitOrder("DMS.SELLING", numSelling, targetSellingPrice, OrderType.OT_SELL, 0);
                }
                catch (Exception ex)
                {
                    Log("Error selling SELLING (pun intended!): " + ex.Message + Environment.NewLine);
                }
            }
        }

        public void StartTimer(System.ComponentModel.ISynchronizeInvoke s)
        {
            if (_active)
            {
                Log("Attempt to start timer that is already running." + Environment.NewLine);
                return;
            }
            if (_link.AuthStatus != AuthStatusType.AS_OK)
            {
                Log("Not yet authorized." + Environment.NewLine);
                return;
            }

            if (_interval < 120000)
            {
                Log("Interval too short, needs to be at least 2 minutes" + Environment.NewLine);
                return;
            }

            _timer.Interval = _interval;
            _timer.SynchronizingObject = s;
            _syncObj = s;
            _timer.Elapsed += new ElapsedEventHandler(DoUpdate);
            _timer.Enabled = true;
            _active = true;

            DoUpdate(this, null);
        }

        public void StopTimer()
        {
            if (_active)
            {
                Log("Arbitrage bot stopped at " + DateTime.Now.ToString() + Environment.NewLine);
                _timer.Enabled = false;
                _active = false;
            }
        }
    }
}
