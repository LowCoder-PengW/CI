namespace CI.Common.Exceptions
{
    /// <summary>
    /// 异常基类，自定义异常应从此类派生。try时只需catch本类型异常就可以抓住自定义异常
    /// </summary>
    public class CIException : Exception
    {
        /// <summary>
        /// 异常基类
        /// </summary>
        public CIException()
        {
        }

        /// <summary>
        /// 异常基类
        /// </summary>
        /// <param name="msg"></param>
        public CIException(string msg) : base(msg)
        {
        }

        /// <summary>
        /// 异常基类
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        public CIException(string msg, Exception ex) : base(msg, ex)
        {
        }

    }
}
