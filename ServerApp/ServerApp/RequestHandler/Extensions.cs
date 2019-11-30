using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ServerApp.RequestHandler
{
    // These extensions are based on the ASP.net core documentation provided at:
    // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-3.0#session-state

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