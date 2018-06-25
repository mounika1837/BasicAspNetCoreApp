using Microsoft.AspNetCore.Mvc.Filters;
using NLog;


namespace MoviesAppNetCore.Filters
{
    public class LogFilterActionAttribute : IActionFilter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.Info("Before Exceuting" , context.RouteData.ToString());
        }

            public void OnActionExecuted(ActionExecutedContext context)
            {
            logger.Info("After Exceuting", context.RouteData.ToString());
        }
    }
  
}
