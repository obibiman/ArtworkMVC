using System.Collections.Specialized;
using System.Web;
using System.Web.Routing;

namespace Artist.UI.HelperClasses
{
    public static class RouteValueDictionaryExtensions
    {
        public static RouteValueDictionary AddQueryStringParameters(this RouteValueDictionary dict)
        {
            NameValueCollection querystring = HttpContext.Current.Request.QueryString;

            foreach (string key in querystring.AllKeys)
                if (!dict.ContainsKey(key))
                    dict.Add(key, querystring.GetValues(key)[0]);

            return dict;
        }

        public static RouteValueDictionary ExceptFor(this RouteValueDictionary dict, params string[] keysToRemove)
        {
            foreach (string key in keysToRemove)
                if (dict.ContainsKey(key))
                    dict.Remove(key);

            return dict;
        }
    }
}