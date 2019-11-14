using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ServerApp.RequestHandler
{
    public static class SessionExtensions
    {
        private static JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.All
        };

        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value, settings));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) :
                JsonConvert.DeserializeObject<T>(value, settings);
        }
    }
}