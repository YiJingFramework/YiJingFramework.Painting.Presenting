using System;
using System.Diagnostics.CodeAnalysis;
using YiJingFramework.Painting.Presenting.Converters;
using YiJingFramework.Painting.Presenting.Exceptions;

namespace YiJingFramework.Painting.Presenting.Extensions
{
    /// <summary>
    /// 使字符转变体验更佳。
    /// Make the experience of character conversion better.
    /// </summary>
    public static class CharacterConversionExtensions
    {
        private static readonly CharacterConverter converter = new CharacterConverter();

        /// <summary>
        /// 把卦画转换为字符。
        /// Convert a painting to a character.
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
        /// <paramref name="painting"/> 不是一爻、二爻、三爻或六爻卦。
        /// <paramref name="painting"/> isn't a painting with 1, 2, 3 or 6 lines.
        /// </exception>
        public static char ToUnicodeCharacter(this Core.Painting painting)
        {
            return converter.ConvertTo(painting);
        }
    }
}
