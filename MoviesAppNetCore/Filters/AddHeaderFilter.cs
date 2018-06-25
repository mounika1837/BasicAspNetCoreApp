
using Microsoft.AspNetCore.Mvc.Filters;

namespace MoviesAppNetCore.Filters
{
    //Adds Header to Response : Result Filters are run after the action method is executed successfully.
    public class AddHeaderFilter: ResultFilterAttribute
    {
        private readonly string _name;
        private readonly string _value;

      public AddHeaderFilter(string name, string value)
      {
          _name = name;
          _value = value;
      }

     public override void OnResultExecuting(ResultExecutingContext context)
     {
         context.HttpContext.Response.Headers.Add(
               _name, new string[] { _value });
             base.OnResultExecuting(context);
     }
    }
    
}
