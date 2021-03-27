using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiJingFramework.Painting.Presenting.Exceptions;

namespace YiJingFramework.Painting.Presenting
{
    /// <summary>
    /// 将卦画转为其他值的转换器。
    /// A converter that convert paintings to other values.
    /// </summary>
    /// <typeparam name="T">
    /// 支持转换到的值的类型。
    /// The values' type.
    /// </typeparam>
    public interface IConverterTo<T>
    {
        /// <summary>
        /// 进行转换。
        /// Convert a painting.
        /// </summary>
        /// <param name="painting">
        /// 要转换的卦画。
        /// The painting to convert.
        /// </param>
        /// <returns>
        /// 转换结果。
        /// The result.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="painting"/> 是 <c>null</c> 。
        /// <paramref name="painting"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="PaintingConversionException">
        /// 转换失败。这通常表示此转换器不适用于指定的卦画。
        /// Conversion failed. This often means that the converter doesn't fit the given painting.
        /// </exception>
        T ConvertTo(Core.Painting painting);
    }
}
