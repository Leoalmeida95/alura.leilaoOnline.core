using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Alura.LeilaoOnline.WebApp.Extensions
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            var json = JsonConvert.SerializeObject(value);
            session.SetString(key, json);
        }

        public static T Get<T>(this ISession session, string key) where T:class
        {
            var json = session.GetString(key);
            if (string.IsNullOrEmpty(json))
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
