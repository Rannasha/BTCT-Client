using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using OAuth;
using Newtonsoft.Json.Linq;

namespace BTCTC
{
    public enum OrderType { OT_SELL, OT_BUY, OT_TIN, OT_TOUT };

    [Serializable]
    public class BTCTException : System.Exception
    {
        public BTCTException() : base() { }
        public BTCTException(string message) : base(message) { }
        public BTCTException(string message, System.Exception inner) : base(message, inner) { }

        protected BTCTException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
    }

    public class BTCTLink
    {
        private string _consumerKey;
        private string _consumerSecret;
        private const string _tradeUrl = "https://btct.co/oauth/trade";

        private OAuthConfig _oauthConfig;
        private OAuthConsumer _oauthConsumer;

        public BTCTLink(string consumerKey, string consumerSecret)
        {
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
            
            _oauthConfig = new OAuthConfig("");
            _oauthConfig.SiteUrl = "";
            _oauthConfig.OauthVersion = "1.0";
            _oauthConfig.OauthSignatureMethod = "HMAC-SHA1";
            _oauthConfig.ConsumerKey = _consumerKey;
            _oauthConfig.ConsumerSecret = _consumerSecret;
            _oauthConfig.RequestTokenUrl = "https://btct.co/oauth/request_token";
            _oauthConfig.AccessTokenUrl = "https://btct.co/oauth/access_token";
            _oauthConfig.UserAuthorizationUrl = "https://btct.co/authorize";

            _oauthConsumer = new OAuthConsumer(_oauthConfig, "");
        }

        public void getRequestToken()
        {
            try
            {
                _oauthConsumer.getRequestToken();
            }
            catch (Exception e)
            {
                throw new BTCTException("Unable to get request token.");
            }
        }

        public void getAccessToken(string verifier)
        {
            try
            {
                _oauthConsumer.getAccessToken(verifier);
            }
            catch (Exception e)
            {
                throw new BTCTException("Unable to get access token.");
            }
        }

        private string rawRequest(List<QueryParameter> p)
        {
            string response = (string)_oauthConsumer.request(_tradeUrl, "POST", p, "PLAIN");

            return response;
        }

        public Portfolio parsePortfolio(string json)
        {
            JObject r = JObject.Parse(json);
            Portfolio pf = new Portfolio();

            pf.username = (string)r["username"];
            string st = (string)r["generated"];
            string[] formats = { "MM/dd/yyyy HH:mm:ss" };
            pf.lastUpdate = DateTime.ParseExact(st, formats, new CultureInfo("en-US"), DateTimeStyles.None);

            List<SecurityOwned> SOList = new List<SecurityOwned>();
            foreach (JProperty c in r["securities"].Children())
            {
                Security s = new Security();
                s.name = (string)c.Name;
                int a = Convert.ToInt32((string)c.First["quantity"]);
                SecurityOwned so = new SecurityOwned(s, a);
                SOList.Add(so);
            }

            pf.securities = SOList;

            return pf;
        }

        public Portfolio getPortfolio()
        {
            List<QueryParameter> p = new List<QueryParameter>();
            p.Add(new QueryParameter("act","get_portfolio"));
            string response = rawRequest(p);

            Portfolio pf = parsePortfolio(response);

            return pf;
        }
    }

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
    }

}
