using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI.Common
{
    /// <summary>
    /// 方法返回值
    /// </summary>
    /// <typeparam name="T">返回内容数据类型</typeparam>
    [DebuggerDisplay("Code={Code},Message={Message},Data={Data}")]
    public class FuncResult<T> : FuncResult
    {
        /// <summary>
        /// 返回的内容
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// T data 隐式转换 FuncResult<T>.SuccessResult(data)
        /// </summary>
        /// <param name="data"></param>
        public static implicit operator FuncResult<T>(T data)
        {
            return FuncResult.Success(data);
        }
    }
}
