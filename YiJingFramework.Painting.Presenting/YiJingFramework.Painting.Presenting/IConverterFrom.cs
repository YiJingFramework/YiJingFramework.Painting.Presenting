using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiJingFramework.Painting.Presenting
{
    /// <summary>
    /// 将其他值转为卦画的转换器。
    /// A converter that convert other values to paintings.
    /// </summary>
    /// <typeparam name="T">
    /// 支持转换的值的类型。
    /// The values' type.
    /// </typeparam>
    public interface IConverterFrom<T>
    {
        /// <summary>
        /// 尝试从某个值进行转换。
        /// Try converting from.
        /// </summary>
        /// <param name="value">
        /// 要转换的值。
        /// The value to convert from.
        /// </param>
        /// <param name="result">
        /// 转换结果。
        /// The result.
        /// </param>
        /// <returns>
        /// 指示转换是否成功的值。
        /// A value indicates whether the conversion succeeded or not.
        /// </returns>
        bool TryConvertFrom(T value, [MaybeNullWhen(false)] out Core.Painting result);
    }
}
