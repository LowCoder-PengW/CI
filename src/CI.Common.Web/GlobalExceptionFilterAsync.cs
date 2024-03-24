using CI.Common.Exceptions;
using CI.Common.Logger;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace CI.Common.Web
{
    /// <summary>
    /// 全局异常过滤器
    /// </summary>
    public class GlobalExceptionFilterAsync : IAsyncExceptionFilter
    {
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            FuncResult funcResult = new FuncResult
            {
                Code = "0500",
                Message = "网络出小差，请稍后再试！"
            };
            if (Utils.IsDevelopment)
            {
                funcResult.Message = context.Exception.Message;
            }

            ///处理异常
            context.ExceptionHandled = true;

            //暂时只考虑 exception 情况 
            context.Result = new StatusCodeObjectResult(HttpStatusCode.OK, funcResult);
             

            ////记录堆栈信息
            //Log<GlobalExceptionFilterAsync>.Error("GlobalExceptionFilterAsync:" + context.Exception.Message, context.Exception);
            ////异常传递
            //if (context.Exception.InnerException != null)
            //{
            //    Log<GlobalExceptionFilterAsync>.Error("GlobalInnerExceptionFilter:" + context.Exception.InnerException.Message, context.Exception.InnerException);
            //}

            await Task.CompletedTask;
        }
    }
}
