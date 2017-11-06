using System.Web.Mvc;

using Calculator.Web.Helpers.Filters;

namespace Calculator.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleExceptionFilter());
        }
    }
}