using Microsoft.AspNetCore.Http;

namespace Template_MS.Helper
{
    public static class HttpContextHelper
    {
        public static IHttpContextAccessor HttpContextAccessor { get; set; }
        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }
        public static HttpContext Current => HttpContextAccessor?.HttpContext;
    }

}
