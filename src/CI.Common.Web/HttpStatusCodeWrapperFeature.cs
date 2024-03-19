using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CI.Common.Web
{
    /// <summary>
    /// http状态码封装功能
    /// </summary>
    internal class HttpStatusCodeWrapperFeature
    {
        public HttpStatusCode OriStatusCode { get; set; }

        public HttpStatusCodeWrapperFeature(HttpStatusCode statusCode)
        {
            OriStatusCode = statusCode;
        }
    }
}
