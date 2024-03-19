using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI.Common
{
    /// <summary>
    /// 方法返回实体
    /// </summary>
    [DebuggerDisplay("Code={Code},Message={Message}")]
    public class FuncResult
    {
        /// <summary>
        /// 失败的编码
        /// </summary>
        public const string _FAIL_CODE = "0500";
        /// <summary>
        /// 成功的编码
        /// </summary>
        public const string _SUCCESS_CODE = "0000";
        /// <summary>
        /// 成功的默认信息
        /// </summary>
        public const string _SUCCESS_MESSAGE = "操作成功";
        /// <summary>
        /// 状态码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回一个成功的，带有数据的FuncResult<T>对象
        /// </summary>
        /// <typeparam name="T">返回内容的类型</typeparam>
        /// <param name="content">返回内容</param>
        /// <param name="message">返回信息</param>
        /// <returns></returns>
        public static FuncResult<T> Success<T>(T content, string message = null)
        {
            return new FuncResult<T>
            {
                Data = content,
                Code = "0000",
                Message = (message ?? "操作成功")
            };
        }

        /// <summary>
        /// 返回一个成功的FuncResult对象
        /// </summary>
        /// <param name="message"></param>
        /// <returns>返回一个成功的FuncResult对象</returns>
        public static FuncResult Success(string message = null)
        {
            return new FuncResult
            {
                Code = "0000",
                Message = (message ?? "操作成功")
            };
        }

        /// <summary>
        /// 返回失败
        /// </summary>
        /// <typeparam name="T">返回内容的类型</typeparam>
        /// <param name="data">返回内容</param>
        /// <param name="message">错误信息</param>
        /// <param name="code">返回码</param>
        /// <returns>返回一个失败的FuncResult<T>对象</returns>
        public static FuncResult<T> Fail<T>(T data, string message, string code = "0500")
        {
            return new FuncResult<T>
            {
                Data = data,
                Message = message,
                Code = code
            };
        }

        /// <summary>
        /// 返回失败
        /// </summary>
        /// <typeparam name="T">返回内容的类型</typeparam>
        /// <param name="message">错误信息</param>
        /// <param name="code">返回码</param>
        /// <returns>返回一个失败的FuncResult<T>对象</returns>
        public static FuncResult<T> Fail<T>(string message, string code = "0500")
        {
            return Fail(default(T), message, code);
        }

        /// <summary>
        /// 返回失败
        /// </summary>
        /// <param name="message">错误信息</param>
        /// <param name="code">返回码</param>
        /// <returns>返回一个失败的FuncResult对象</returns>
        public static FuncResult Fail(string message, string code = "0500")
        {
            return new FuncResult
            {
                Message = message,
                Code = code
            };
        }

        /// <summary>
        /// 返回result的Success
        /// </summary>
        /// <param name="result"></param>
        public static implicit operator bool(FuncResult result)
        {
            if (result != null)
            {
                return result.Code == "0000";
            }

            return false;
        }



        /// <summary>
        /// 分页成功返回
        /// </summary>
        /// <typeparam name="T">返回内容类型</typeparam>
        /// <param name="array"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public static FuncResultPagination<T> Success<T>(IEnumerable<T> array, int total)
        {
            return new FuncResultPagination<T>
            {
                Code = "0000",
                Message = "操作成功",
                Data = new PaginationResult<T>
                {
                    Total = total,
                    Array = (array ?? new List<T>())
                }
            };
        }

        /// <summary>
        /// 分页失败返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static FuncResultPagination<T> FailList<T>(string message, string code = "0500")
        {
            return new FuncResultPagination<T>
            {
                Code = code,
                Message = message
            };
        }

    }
}
