using System;
using System.Diagnostics.CodeAnalysis;
using YiJingFramework.Painting.Presenting.Exceptions;

namespace YiJingFramework.Painting.Presenting
{
    /// <summary>
    /// 将卦画转变到字符。
    /// 仅支持一爻、二爻、三爻和六爻卦。
    /// Convert the paintings to characters.
    /// Only paintings with 1, 2, 3 and 6 lines can be converted.
    /// </summary>
    public sealed class CharacterConverter : IConverterFrom<char>, IConverterTo<char>
    {
        private static readonly byte[] hexagramTable =
            new byte[] { 127, 64, 81, 98, 87, 122, 66, 80, 119, 123, 71, 120, 125, 111, 68, 72, 89, 102, 67, 112, 105, 101, 96, 65, 121, 103, 97, 94, 82, 109, 92, 78, 124, 79, 104, 69, 117, 107, 84, 74, 99, 113, 95, 126, 88, 70, 90, 86, 93, 110, 73, 100, 116, 75, 77, 108, 118, 91, 114, 83, 115, 76, 85, 106 };

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
        /// <paramref name="painting"/> 不是一爻、二爻、三爻或六爻卦。
        /// <paramref name="painting"/> isn't a painting with 1, 2, 3 or 6 lines.
        /// </exception>
        public char ConvertTo(Core.Painting painting)
        {
            if (painting.Count == 1)
                return painting[0] == Core.LineAttribute.Yang ? '\u268A' : '\u268B';

            if (painting.Count == 2)
            {
                if (painting[0] == Core.LineAttribute.Yang)
                    return painting[1] == Core.LineAttribute.Yang ? '\u268C' : '\u268D';
                return painting[1] == Core.LineAttribute.Yang ? '\u268E' : '\u268F';
            }

            if (painting.Count == 3)
            {
                int value = '\u2630';
                int d = 4;
                foreach (var line in painting)
                {
                    if (line == Core.LineAttribute.Yin)
                        value += d;
                    d = d / 2;
                }
                return (char)value;
            }

            if (painting.Count == 6)
            {
                int value = '\u4DC0';
                return (char)(value + Array.IndexOf(hexagramTable, painting.ToBytes()[0]));
            }

            throw new PaintingConversionException("The painting should have 1, 2, 3 or 6 lines.");
        }

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
        public bool TryConvertFrom(char value, [MaybeNullWhen(false)] out Core.Painting result)
        {
            switch (value)
            {
                case '\u268A':
                    result = new Core.Painting(Core.LineAttribute.Yang);
                    return true;
                case '\u268B':
                    result = new Core.Painting(Core.LineAttribute.Yin);
                    return true;
                case '\u268C':
                    result = new Core.Painting(Core.LineAttribute.Yang, Core.LineAttribute.Yang);
                    return true;
                case '\u268D':
                    result = new Core.Painting(Core.LineAttribute.Yang, Core.LineAttribute.Yin);
                    return true;
                case '\u268E':
                    result = new Core.Painting(Core.LineAttribute.Yin, Core.LineAttribute.Yang);
                    return true;
                case '\u268F':
                    result = new Core.Painting(Core.LineAttribute.Yin, Core.LineAttribute.Yin);
                    return true;
                default:
                    break;
            }

            {
                var difference = value - '\u2630';
                if (difference is >= 0 and < 8)
                {
                    var first = Core.LineAttribute.Yang;
                    if (difference > 4)
                    {
                        first = Core.LineAttribute.Yin;
                        difference -= 4;
                    }

                    var second = Core.LineAttribute.Yang;
                    if (difference > 2)
                    {
                        second = Core.LineAttribute.Yin;
                        difference -= 2;
                    }

                    var third = Core.LineAttribute.Yang;
                    if (difference > 1)
                        third = Core.LineAttribute.Yin;

                    result = new Core.Painting(first, second, third);
                    return true;
                }
            }

            {
                var difference = value - '\u4DC0';
                if (difference is >= 0 and < 64)
                {
                    result = Core.Painting.FromBytes(hexagramTable[difference]);
                    return true;
                }
            }

            result = null;
            return false;
        }
    }
}
