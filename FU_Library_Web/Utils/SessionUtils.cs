using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace FU_Library_Web.Utils
{
    public class SessionUtils
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SessionUtils(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public T GetObjectByName<T>(string sessionName)
        {
            var context = _httpContextAccessor.HttpContext;

            var sessionJson = context.Session.GetString(sessionName);

            if (sessionJson == null)
            {
                return default;
            }

            return JsonSerializer.Deserialize<T>(sessionJson);
        }

        public void SetObjectInSession<T>(string sessionName, T value)
        {
            var context = _httpContextAccessor.HttpContext;

            var sessionJson = JsonSerializer.Serialize(value);

            context.Session.SetString(sessionName, sessionJson);
        }
    }
}
