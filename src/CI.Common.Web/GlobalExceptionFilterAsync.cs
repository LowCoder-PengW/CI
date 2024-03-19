using CI.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace CI.Common.Web
{
    public class GlobalExceptionFilterAsync : IAsyncExceptionFilter, IFilterMetadata
    {
        private readonly IConfiguration configuration;
        public GlobalExceptionFilterAsync(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            FuncResult funcResult = new FuncResult
            {
                Code = "0500",
                Message = "系统访问人太多了，请稍后再试！"
            };
            Type type = context.Exception.GetType();
            bool flag = typeof(CIException).IsAssignableFrom(type);
            if (Utils.IsDevelopment || flag)
            {
                funcResult.Message = context.Exception.Message;
            }

            ///处理异常
            context.ExceptionHandled = true;
            if (!flag)
            {
                context.HttpContext.Response.Headers.Add("x-exception", "true");
                context.HttpContext.Features.Set(new HttpStatusCodeWrapperFeature(HttpStatusCode.InternalServerError));
            }

            if (context.Exception is SpecificStatusCodeException ex)
            {
                context.Result = new StatusCodeObjectResult(ex.StatusCode, funcResult);
                int statusCode = (int)ex.StatusCode;
                if (statusCode != 0)
                {
                    funcResult.Code = statusCode.ToString().PadLeft(4, '0');
                }
            }
            else if (type.FullName == "Refit.ApiException")
            {
                int num = (int)type.GetProperty("StatusCode").GetValue(context.Exception);
                funcResult.Code = ((num == 0) ? "0500" : num.ToString().PadLeft(4, '0'));
                if (num == 401)
                {
                    funcResult.Message = "token已失效，请重新登录";
                }

                context.Result = new StatusCodeObjectResult((HttpStatusCode)num, funcResult);
            }
            else
            {
                ObjectResult objectResult = new ObjectResult(funcResult);
                if ("true".Equals(configuration["RestfulExceptionFilter"], StringComparison.OrdinalIgnoreCase))
                {
                    objectResult.StatusCode = 500;
                }

                context.Result = objectResult;
            }

            // Log<GlobalExceptionFilter>.Error("GlobalExceptionFilter:" + context.Exception.Message, context.Exception);
            if (context.Exception.InnerException != null)
            {
                // Log<GlobalExceptionFilter>.Error("GlobalInnerExceptionFilter:" + context.Exception.InnerException.Message, context.Exception.InnerException);
            }

            // FailureLogFilterAttribute.LogFailure(funcResult, context.HttpContext);
            await Task.CompletedTask;
        }
    }
}
