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
    public enum OrderType { OT_SELL, OT_BUY, OT_TIN, OT_TOUT, OT_UNKNOWN };
    public enum AuthStatusType { AS_NONE, AS_REQRCV, AS_OK };

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
            if (s == "ask" || s == "sell")
            {
                return OrderType.OT_SELL;
            }
            if (s == "bid" || s == "buy")
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

        #region Private Methods
        private string rawOauthRequest(List<QueryParameter> p)
        {
            string response = (string)_oauthConsumer.request(_tradeUrl, "POST", p, "PLAIN");

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
            oc.ConsumerKey = _consumerKey;
            oc.ConsumerSecret = _consumerSecret;
            oc.RequestTokenUrl = "https://btct.co/oauth/request_token";
            oc.AccessTokenUrl = "https://btct.co/oauth/access_token";
            oc.UserAuthorizationUrl = "https://btct.co/authorize";

            _oauthConsumer = new OAuthConsumer(oc, "");
            _authStatus = AuthStatusType.AS_NONE;
        }

        public void SerializeConfig(string filename)
        {
            Stream f = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(f, _oauthConsumer.OauthConfig);
        }

        public void DeserializeConfig(string filename)
        {
            try
            {
                Stream f = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                IFormatter formatter = new BinaryFormatter();
                _oauthConsumer.OauthConfig = (OAuthConfig)formatter.Deserialize(f);
                _authStatus = AuthStatusType.AS_OK;
            }
            catch (Exception ex)
            {
                throw (new BTCTException("Error loading access token: " + ex.Message));
            }
        }

        public void GetRequestToken()
        {
            try
            {
                _oauthConsumer.getRequestToken();
                _authStatus = AuthStatusType.AS_REQRCV;
            }
            catch (Exception e)
            {
                throw new BTCTAuthException("Unable to get request token.",e);
            }
        }

        public void GetAccessToken(string verifier)
        {
            try
            {
                _oauthConsumer.getAccessToken(verifier);
                _authStatus = AuthStatusType.AS_OK;
            }
            catch (Exception e)
            {
                throw new BTCTAuthException("Unable to get access token.",e);
            }
        }

        public Portfolio getPortfolio()
        {
            List<QueryParameter> p = new List<QueryParameter>();
            p.Add(new QueryParameter("act","get_portfolio"));
            string response = rawOauthRequest(p);

            Portfolio pf = parsePortfolio(response);

            return pf;
        }

        public string SubmitOrder(string security, int amount, long price, OrderType o, int expire)
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


            string r = rawOauthRequest(p);

            try
            {
                parseSuccess(r);
            }
            catch (BTCTException e)
            {
                throw (e);
            }
            return r;
        }

        public TradeHistory GetTradeHistory(string apikey)
        {
            string s = rawHttpRequest(_csvUrl + "trades?key=" + apikey);

            return parseTradeHistory(s);
        }
    }

    #region Data Storage Classes
    public class Security
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Order
    {
        public int id { get; set; }
        public Security security { get; set; }
        public int amount { get; set; }
        public long price { get; set; }
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
    #endregion

}
