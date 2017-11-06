using System;
using System.Diagnostics;
using System.Net;
using System.Web.Mvc;

using Calculator.Definition.Entities;
using Calculator.Definition.Resources;
using Calculator.Engine.CommonManager;

namespace Calculator.Web.Helpers.Filters
{
    public class HandleExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            var exception = filterContext.Exception;

            var traceLevel = TraceLevel.Error;

            var exceptionMessage = ErrorMessages.SomethingWentWrong;

            if (filterContext.Exception.GetType() == typeof(BusinessException))
            {
                filterContext.ExceptionHandled = true;

                var businessEx = (BusinessException)filterContext.Exception;

                traceLevel = businessEx.TraceLevel;

                exceptionMessage = businessEx.Message;
            }

            //log only critical exceptions
            if (!(traceLevel == TraceLevel.Info || traceLevel == TraceLevel.Verbose))
            {
                ExceptionLogManager.Log(exception);
            }

            if (!filterContext.HttpContext.Request.IsAjaxRequest()) { return; }
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.StatusCode = 200;
            filterContext.Result = new JsonResult
            {
                Data = new BaseResponse { IsSuccess = false, ErrorMessage = exceptionMessage },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}