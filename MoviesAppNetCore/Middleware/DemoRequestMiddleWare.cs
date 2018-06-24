
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace MoviesAppNetCore.Middleware
{
    public class DemoRequestMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly string _env;
        public DemoRequestMiddleWare(RequestDelegate next,string env)
        {
            _next = next;
            _env = env;
        }

        public Task InvokeAsync(HttpContext context)
        {
            var queryParam = context.Request.Query["param"];
            if (!string.IsNullOrEmpty(queryParam) && queryParam.ToString().Equals("nav"))
            {
                return context.Response.WriteAsync($"Navigation Page!:{_env}");

            }

            return _next(context);
        }
    }


    public static class DemoRequestMiddleWareExtensions
    {
        public static IApplicationBuilder UseDemoMiddleWare(
            this IApplicationBuilder builder,string env)
        {
            return builder.UseMiddleware<DemoRequestMiddleWare>(env);
        }
    }
}
