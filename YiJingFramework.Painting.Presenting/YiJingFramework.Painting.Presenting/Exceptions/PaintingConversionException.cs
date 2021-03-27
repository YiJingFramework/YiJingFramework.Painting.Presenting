using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiJingFramework.Painting.Presenting.Exceptions
{
    /// <summary>
    /// 卦画转换失败。
    /// Paintings' conversion failed.
    /// </summary>
    [Serializable]
    public class PaintingConversionException : Exception
    {
        /// <summary>
        /// 初始化一个新实例。
        /// Initialize a new instance.
        /// </summary>
        /// <param name="message">
        /// 异常消息。
        /// The message.
        /// </param>
        /// <param name="inner">
        /// 内部异常。
        /// The inner exception.
        /// </param>
        public PaintingConversionException(string? message = null, Exception? inner = null)
            : base(message, inner) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected PaintingConversionException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
