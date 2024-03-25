using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Net;

namespace CI.Common.Web
{
    /// <summary>
    /// configure 扩展方法
    /// </summary>
    public static class ProgramConfigureExtensionFunctions
    {
        /// <summary>
        /// 配置model 无效时的响应参数
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureInvalidModelState(this IServiceCollection services)
        {
            services.Configure(delegate (ApiBehaviorOptions behavior)
            {
                behavior.InvalidModelStateResponseFactory = delegate (ActionContext actionContext)
                {
                    var list = actionContext.ModelState.Select((KeyValuePair<string, ModelStateEntry> e) => new
                    {
                        Field = e.Key,
                        ErrorMessage = e.Value.Errors?.FirstOrDefault()?.ErrorMessage
                    }).ToList();
                    list.RemoveAll(s => s == null || string.IsNullOrEmpty(s.ErrorMessage));
                    //格式定义
                    FuncResult value = new FuncResult
                    {
                        Code = "0400",
                        Message = string.Join(";", list.Select(e => e.ErrorMessage.Replace("$FIELD$", e.Field)).Distinct())
                    };

                    actionContext.HttpContext.Features.Set(new HttpStatusCodeWrapperFeature(HttpStatusCode.BadRequest));

                    return new ObjectResult(value)
                    {
                        StatusCode = 200
                    };
                };
            });
        }

    }
}
