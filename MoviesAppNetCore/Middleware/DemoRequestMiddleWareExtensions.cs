using Microsoft.AspNetCore.Builder;

namespace MoviesAppNetCore.Middleware
{
    public static class DemoRequestMiddleWareExtensions
    {
        public static IApplicationBuilder UseDemoMiddleWare(
            this IApplicationBuilder builder,string env)
        {
            return builder.UseMiddleware<DemoRequestMiddleWare>(env);
        }
    }
}