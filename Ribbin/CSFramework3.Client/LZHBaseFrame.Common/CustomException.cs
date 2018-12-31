using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace LZHBaseFrame.Common
{
    /// <summary>
    /// 用户自定义异常
    /// </summary>
    public class CustomException : Exception
    {
        public CustomException(string message)
            : base(message)
        { }
    }

}
