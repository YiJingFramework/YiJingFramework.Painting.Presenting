using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using YiJingFramework.Painting.Presenting.Exceptions;

namespace YiJingFramework.Painting.Presenting.Converters
{
    /// <summary>
    /// 将卦画以指定的分割符和阴阳表示方式转换成字符串。
    /// Convert the paintings to strings by the given yin-yang representations and separators.
    /// </summary>
    public sealed class StringConverter : IConverterTo<string>
    {
        private readonly string yang;
        private readonly string yin;
        private readonly string separator;

        /// <summary>
        /// 创建一个新实例。
        /// Initialize a new instance.
        /// </summary>
        /// <param name="yang">
        /// 阳爻表示方法。
        /// The representation of yang lines.
        /// </param>
        /// <param name="yin">
        /// 阴爻表示方法。
        /// The representation of yin lines.
        /// </param>
        /// <param name="separator">
        /// 分割符。
        /// The separator.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="separator"/> 、 <paramref name="yang"/> 或 <paramref name="yin"/> 是 <c>null</c> 。
        /// <paramref name="separator"/>, <paramref name="yang"/> or <paramref name="yin"/> is <c>null</c>.
        /// </exception>
        public StringConverter(string yang = "-----", string yin = "-- --", string separator = "\n")
        {
            if (yang is null)
                throw new ArgumentNullException(nameof(yang));
            if (yin is null)
                throw new ArgumentNullException(nameof(yin));
            if (separator is null)
                throw new ArgumentNullException(nameof(separator));
            this.yang = yang;
            this.yin = yin;
            this.separator = separator;
        }

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
        public string ConvertTo(Core.Painting painting)
        {
            if (painting is null)
                throw new ArgumentNullException(nameof(painting));
            var linq = from line in painting.Reverse()
                       select line.IsYang ? this.yang : this.yin;
            return string.Join(this.separator, linq);
        }
    }
}
