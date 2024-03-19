using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CI.Common.Web
{
    /// <summary>
    /// 状态码对象返回结果封装
    /// </summary>
    internal class StatusCodeObjectResult : ObjectResult
    {
        public StatusCodeObjectResult(HttpStatusCode statusCode, object data) : base(data)
        {
            base.StatusCode = (int)statusCode;
        }
    }
}
