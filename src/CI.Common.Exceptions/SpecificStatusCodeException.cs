using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CI.Common.Exceptions
{
    public class SpecificStatusCodeException : CIException
    {
        /// <summary>
        /// HTTP状态码
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
        /// <summary>
        /// 指定http响应码抛出异常
        /// </summary>
        /// <param name="message"></param>
        public SpecificStatusCodeException(string message) : this(message, HttpStatusCode.OK, null)
        {
        }

        /// <summary>
        /// 指定http响应码抛出异常
        /// </summary>
        /// <param name="message"></param>
        /// <param name="statusCode"></param>
        public SpecificStatusCodeException(string message, HttpStatusCode statusCode) : this(message, statusCode, null)
        {
        }

        /// <summary>
        /// 指定http响应码抛出异常
        /// </summary>
        /// <param name="message"></param>
        /// <param name="statusCode"></param>
        /// <param name="inner"></param>
        public SpecificStatusCodeException(string message, HttpStatusCode statusCode, Exception inner) : base(message, inner)
        {
            StatusCode = statusCode;
        }
    }
}
