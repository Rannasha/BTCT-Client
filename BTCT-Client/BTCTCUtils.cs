using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Runtime.Serialization;
using OAuth;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;

namespace BTCTC
{
    public enum OrderType { OT_SELL, OT_BUY, OT_CALL, OT_PUT, OT_TIN, OT_TOUT, OT_UNKNOWN};
    public enum AuthStatusType { AS_NONE, AS_REQRCV, AS_OK };
    public enum SecurityType { ST_BOND, ST_STOCK, ST_FUND };

    public delegate void AuthStatusChangedFunc(AuthStatusType newAS);

    public class AuthStatusChangedEventArgs : EventArgs
    {
        public AuthStatusType AuthStatus { get; set; }

        public AuthStatusChangedEventArgs(AuthStatusType t)
        {
            AuthStatus = t;
        }
    }

    public class BTCTUtils
    {
        public const double SatoshiPerBTC = 100000000.0;

        public static long DoubleToSatoshi(double t)
        {
            return Convert.ToInt64(SatoshiPerBTC * t);
        }

        public static double SatoshiToDouble(long i)
        {
            return ((double)i) / SatoshiPerBTC;
        }

        public static long StringToSatoshi(string s)
        {
            double t;

            try
            {
                t = double.Parse(s, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                t = 0.0;
            }

            return Convert.ToInt64(SatoshiPerBTC * t);
        }

        public static string SatoshiToString(long i)
        {
            double t = ((double)i) / SatoshiPerBTC;
            NumberFormatInfo n = new CultureInfo("en-US", false).NumberFormat;

            return t.ToString(n);
        }

        public static OrderType StringToOrderType(string s)
        {
            if (s == "ask" || s == "sell" || s == "Market Sell")
            {
                return OrderType.OT_SELL;
            }
            if (s == "bid" || s == "buy" || s == "Market Buy")
            {
                return OrderType.OT_BUY;
            }
            if (s == "transfer-in")
            {
                return OrderType.OT_TIN;
            }
            if (s == "transfer-out")
            {
                return OrderType.OT_TOUT;
            }
            if (s == "Call Option")
            {
                return OrderType.OT_CALL;
            }
            if (s == "Put Option")
            {
                return OrderType.OT_PUT;
            }
            return OrderType.OT_UNKNOWN;
        }
    }

    #region Exceptions
    [Serializable]
    public class BTCTException : System.Exception
    {
        public BTCTException() : base() { }
        public BTCTException(string message) : base(message) { }
        public BTCTException(string message, System.Exception inner) : base(message, inner) { }

        protected BTCTException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
    }

    [Serializable]
    public class BTCTOrderException : BTCTException
    { 
        public BTCTOrderException() : base() { }
        public BTCTOrderException(string message) : base(message) { }
        public BTCTOrderException(string message, System.Exception inner) : base(message, inner) { }

        protected BTCTOrderException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
    }

    [Serializable]
    public class BTCTBalanceException : BTCTException
    {
        public BTCTBalanceException() : base() { }
        public BTCTBalanceException(string message) : base(message) { }
        public BTCTBalanceException(string message, System.Exception inner) : base(message, inner) { }

        protected BTCTBalanceException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
    }

    [Serializable]
    public class BTCTAuthException : BTCTException
    {
        public BTCTAuthException() : base() { }
        public BTCTAuthException(string message) : base(message) { }
        public BTCTAuthException(string message, System.Exception inner) : base(message, inner) { }

        protected BTCTAuthException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
    }
    #endregion

    public class BTCTLink
    {
        private string _consumerKey;
        private string _consumerSecret;
        private const string _tradeUrl = "https://btct.co/oauth/trade";
        private const string _csvUrl = "https://btct.co/csv/";
        private OAuthConsumer _oauthConsumer;
        private AuthStatusType _authStatus;

        public AuthStatusType AuthStatus
        {
            get
            {
                return _authStatus;
            }
        }

        public string ApiKey
        {
            get
            {
                return _oauthConsumer.OauthConfig.ApiKey;
            }
            set
            {
                _oauthConsumer.OauthConfig.ApiKey = value;
            }
        }

        public event EventHandler AuthStatusChanged;

        #region Private Methods
        private void ChangeAuthStatus(AuthStatusType t)
        {
            if (_authStatus != t)
            {
                _authStatus = t;
                if (AuthStatusChanged != null)
                {
                    AuthStatusChangedEventArgs a = new AuthStatusChangedEventArgs(t);
                    AuthStatusChanged(this, a);
                }
            }
        }

        private string rawOauthRequest(List<QueryParameter> p)
        {
            string response;

            try
            {
                response = (string)_oauthConsumer.request(_tradeUrl, "POST", p, "PLAIN");
            }
            catch (Exception e)
            {
                // At this stage, this error should occur only if the access token has expired (1 week of inactivity)
                // or has been manually revoked on the API tab of the Account page.
                ChangeAuthStatus(AuthStatusType.AS_NONE);
                if (e.Message.Equals("The remote server returned an error: (401) Unauthorized."))
                {
                    throw (new BTCTAuthException("Unauthorized."));
                }
                else
                {
                    throw (new BTCTException("Unknown error with request. Message: " + e.Message));
                }
            }
            if (response == "Request rate limit exceeded, come back in 60 seconds.\r\n")
            {            
                BTCTException tantrum = new BTCTException("Request Error. Message: " + response);

                throw tantrum; // I WANT MY DATA! I WANT IT NOW!               
            }
            return response;
        }

        private string rawHttpRequest(string uri)
        {
            string c = String.Empty;
            
            try
            {
                System.Net.HttpWebRequest request = System.Net.HttpWebRequest.Create(uri) as System.Net.HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;
                System.Net.HttpWebResponse response = request.GetResponse() as System.Net.HttpWebResponse;
                System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream());
                while (reader.Peek() > 0)
                {
                    c += reader.ReadLine() + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                throw (new BTCTException("Network Error. Message: " + ex.Message));
            }
            if (c == "Request rate limit exceeded, come back in 60 seconds.\r\n")
            {
                BTCTException tantrum = new BTCTException("Request Error. Message: " + c);

                throw tantrum; // I WANT MY DATA! I WANT IT NOW!               
            }
            
            return c;
        }

        private Portfolio parsePortfolio(string json)
        {
            JObject r = JObject.Parse(json);
            Portfolio pf = new Portfolio();

            // Parse simple fields like username & generation time.
            pf.username = (string)r["username"];
            string st = (string)r["generated"];
            string[] formats = { "MM/dd/yyyy HH:mm:ss" };
            pf.lastUpdate = DateTime.ParseExact(st, formats, new CultureInfo("en-US"), DateTimeStyles.None);

            // Parse list of currently held securities.
            List<SecurityOwned> SOList = new List<SecurityOwned>();
            foreach (JProperty c in r["securities"].Children())
            {
                Security s = new Security();
                s.name = c.Name;
                int a = Convert.ToInt32((string)c.First["quantity"]);
                SecurityOwned so = new SecurityOwned(s, a);
                SOList.Add(so);
            }
            pf.securities = SOList;

            // Parse list of active orders
            List<Order> OList = new List<Order>();
            foreach (JProperty c in r["orders"].Children())
            {
                Order o = new Order();
                Security s = new Security();
                o.id = Convert.ToInt32(c.Name);
                JToken c2 = c.First;
                s.name = (string)c2["ticker"];
                o.security = s;
                o.amount = Convert.ToInt32((string)c2["quantity"]);
                o.price = BTCTUtils.StringToSatoshi((string)c2["amount"]);
                o.orderType = BTCTUtils.StringToOrderType((string)c2["type"]);

                OList.Add(o);
            }
            pf.orders = OList;

            return pf;
        }

        private TradeHistory parseTradeHistory(string s)
        {
            List<Order> OList = new List<Order>();
            TradeHistory t = new TradeHistory();

            string[] lines = s.Split(new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);

            // First line contains column headers, which we can ignore
            for (int i = 1; i < lines.Length; i++)
            {
                Order o = new Order();
                Security se = new Security();

                string[] fields = lines[i].Split(new Char[] { ',' });

                se.name = fields[0];
                o.orderType = BTCTUtils.StringToOrderType(fields[1]);
                o.amount = Convert.ToInt32(fields[2]);
                o.price = BTCTUtils.StringToSatoshi(fields[3]);
                // date/time string comes in quotes from BTCT for some reason.
                o.dateTime = DateTime.Parse(fields[4].Substring(1,fields[4].Length-2));
                o.security = se;

                OList.Add(o);
            }
            t.orders = OList;
            t.lastUpdate = DateTime.Now;

            return t;
        }

        private DividendHistory parseDividendHistory(string s)
        {
            DividendHistory dh = new DividendHistory();
            List<Dividend> l = new List<Dividend>();

            string[] lines = s.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 1; i < lines.Length; i++)
            {
                Dividend d = new Dividend();
                Security se = new Security();

                string[] fields = lines[i].Split(new Char[] { ',' });

                se.name = fields[0];
                d.shares = Convert.ToInt32(fields[1]);
                d.dividend = BTCTUtils.StringToSatoshi(fields[2]);
                d.dateTime = DateTime.Parse(fields[4].Substring(1, fields[4].Length - 2));
                d.security = se;

                l.Add(d);
            }

            dh.dividends = l;
            dh.lastUpdate = DateTime.Now;

            return dh;
        }

        private void parseSuccess(string json)
        {
            // THROW ALL THE EXCEPTIONS! |o/

            JObject r;
            try
            {
                r = JObject.Parse(json);
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                if (json.IndexOf("Invalid Ticker") > -1)
                {
                    throw (new BTCTOrderException("Invalid Ticker"));
                }
                else
                {
                    throw (new BTCTOrderException("Unknown Error. Response-message: " + ex.Message));
                }
            }

            if ((string)r["status"] == "error")
            {
                if ((string)r["error_message"] == "Invalid Bid Input.")
                {
                    throw (new BTCTOrderException("Invalid Order. Response-message: " + (string)r["error_message"]));
                }
                else
                {
                    throw (new BTCTOrderException("Unknown Error. Response-message: " + (string)r["error_message"]));
                }
            }
            if ((string)r["status"] == "success")
            {
                if ( ((string)r["response"]).IndexOf("Order failed") > -1)
                {
                    throw (new BTCTBalanceException("Insufficient funds to execute order"));
                }
            }
        }
        #endregion

        public BTCTLink(string consumerKey, string consumerSecret)
        {
            OAuthConfig oc;

            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
            
            oc = new OAuthConfig("");
            oc.SiteUrl = "";
            oc.OauthVersion = "1.0";
            oc.OauthSignatureMethod = "HMAC-SHA1";
            oc.OauthCallback = "oob";
            oc.OauthScope = "all";
            oc.ConsumerKey = _consumerKey;
            oc.ConsumerSecret = _consumerSecret;
            oc.RequestTokenUrl = "https://btct.co/oauth/request_token";
            oc.AccessTokenUrl = "https://btct.co/oauth/access_token";
            oc.UserAuthorizationUrl = "https://btct.co/authorize";

            _oauthConsumer = new OAuthConsumer(oc, "");
            _authStatus = AuthStatusType.AS_NONE;
        }

        #region Access / token management
        public void SerializeConfig(string filename)
        {
            Stream f = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(f, _oauthConsumer.OauthConfig);
            f.Close();
        }

        public void DeserializeConfig(string filename)
        {
            try
            {
                Stream f = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                IFormatter formatter = new BinaryFormatter();
                _oauthConsumer.OauthConfig = (OAuthConfig)formatter.Deserialize(f);
                // There is no guarantee that the deserialized access token is still valid. This should be checked by
                // submitting an auth'ed request and checking the result.
                if (_oauthConsumer.OauthConfig.OauthToken != "")
                {
                    ChangeAuthStatus(AuthStatusType.AS_OK);
                }
                f.Close();
            }
            catch (Exception e)
            {
                throw (new BTCTException("Error loading access token: " + e.Message, e));
            }
        }

        public void GetRequestToken()
        {
            try
            {
                _oauthConsumer.getRequestToken();
                ChangeAuthStatus(AuthStatusType.AS_REQRCV);
            }
            catch (Exception e)
            {
                throw new BTCTAuthException("Unable to get request token: " + e.Message, e);
            }
        }

        public void GetAccessToken(string verifier)
        {
            try
            {
                _oauthConsumer.getAccessToken(verifier);
                ChangeAuthStatus(AuthStatusType.AS_OK);
            }
            catch (Exception e)
            {
                throw new BTCTAuthException("Unable to get access token: " +e.Message, e);
            }
        }
        #endregion

        public Portfolio getPortfolio()
        {
            string response;
            Portfolio pf;
            List<QueryParameter> p = new List<QueryParameter>();
            p.Add(new QueryParameter("act","get_portfolio"));
            try
            {
                response = rawOauthRequest(p);
                pf = parsePortfolio(response);
            }
            catch (BTCTException e)
            {
                throw e;
            }
            
            return pf;
        }

        public void SubmitOrder(string security, int amount, long price, OrderType o, int expire)
        {
            string orderString;

            List<QueryParameter> p = new List<QueryParameter>();
            switch (o)
            {
                case OrderType.OT_BUY:
                    orderString = "bid";
                    break;
                case OrderType.OT_SELL:
                    orderString = "ask";
                    break;
                default:
                    //This shouldn't happen, but we should be careful when submitting orders
                    throw (new BTCTOrderException("Invalid ordertype"));
            }
            p.Add(new QueryParameter("act", orderString + "_submit"));
            p.Add(new QueryParameter("ticker", security));
            p.Add(new QueryParameter(orderString + "_quantity", amount.ToString()));
            // All prices are in Satoshis internally, have to convert to BTC!
            p.Add(new QueryParameter(orderString + "_price", BTCTUtils.SatoshiToString(price)));
            if (expire != 0 && expire != 1 && expire != 7 && expire != 14 && expire != 30 && expire != 90)
            {
                throw (new BTCTOrderException("Invalid expiration time"));
            }
            p.Add(new QueryParameter(orderString + "_expiry_days", expire.ToString()));

            try
            {
                string r = rawOauthRequest(p);
                parseSuccess(r);
            }
            catch (BTCTException e)
            {
                throw (e);
            }
        }

        public TradeHistory GetTradeHistory(string apikey)
        {
            string s = rawHttpRequest(_csvUrl + "trades?key=" + apikey);
            if (s == "Invalid api key.\r\n")
            {
                throw (new BTCTAuthException("Invalid api key."));
            }

            _oauthConsumer.OauthConfig.ApiKey = apikey;
            return parseTradeHistory(s);
        }

        public void CancelOrder(int orderId)
        {
            List<QueryParameter> p = new List<QueryParameter>();

            p.Add(new QueryParameter("order_id", orderId.ToString()));

            try
            {
                string r = rawOauthRequest(p);
                if (r == null)
                {
                    throw (new BTCTException("Invalid order ID"));
                }
                parseSuccess(r);
            }
            catch (BTCTException e)
            {
                throw (e);
            }
        }

        public DividendHistory GetDividendHistory(string apikey)
        {
            string s = rawHttpRequest(_csvUrl + "dividends?key=" + apikey);
            if (s == "Invalid api key.\r\n")
            {
                throw (new BTCTAuthException("Invalid api key."));
            }

            _oauthConsumer.OauthConfig.ApiKey = apikey;
            return parseDividendHistory(s);
        }

        public List<Ticker> GetTickers()
        {
            return null;
        }
    }

    #region Data Storage Classes
    public class Ticker : Security
    {
        public long last { get; set; }
        public int lastQty { get; set; }
        public long lo1d { get; set; }
        public long hi1d { get; set; }
        public long av1d { get; set; }
        public int vol1d { get; set; }
        public long volBTC1d { get; set; }
        public long lo7d { get; set; }
        public long hi7d { get; set; }
        public long av7d { get; set; }
        public int vol7d { get; set; }
        public long volBTC7d { get; set; }
        public long lo30d { get; set; }
        public long hi30d { get; set; }
        public long av30d { get; set; }
        public int vol30d { get; set; }
        public long volBTC30d { get; set; }
        public int totalVol { get; set; }
    }

    public class Dividend
    {
        public Security security { get; set; }
        public int shares { get; set; }
        public long dividend { get; set; }
        public long totalDividend
        {
            get
            {
                return shares * dividend;
            }
        }
        public DateTime dateTime { get; set; }
    }
    
    public class Security
    {
        public string name { get; set; }
        public SecurityType type { get; set; }
    }

    public class Order
    {
        public Security security { get; set; }
        public int id { get; set; }
        public int amount { get; set; }
        public long price { get; set; }
        public long totalPrice
        {
            get
            {
                return amount * price;
            }
        }
        public OrderType orderType { get; set; }
        public bool active { get; set; }
        public DateTime dateTime { get; set; }
    }

    public class SecurityOwned
    {
        public Security security { get; set; }
        public int amount { get; set; }

        public SecurityOwned(Security s, int a)
        {
            security = s;
            amount = a;
        }
    }
    
    public class Portfolio
    {
        public List<SecurityOwned> securities { get; set; }
        public List<Order> orders { get; set; }
        public DateTime lastUpdate { get; set; }
        public long balance { get; set; }
        public string username { get; set; }
    }

    public class TradeHistory
    {
        public List<Order> orders { get; set; }
        public DateTime lastUpdate { get; set; }
    }

    public class DividendHistory
    {
        public List<Dividend> dividends { get; set; }
        public DateTime lastUpdate { get; set; }

        public long TotalDividends
        {
            get
            {
                // sum all div's
                return 0;
            }
        }

        public long DividendPerSecurity(string s)
        {
            // sum all div's for security s
            return 0;
        }
    }
    #endregion

}
