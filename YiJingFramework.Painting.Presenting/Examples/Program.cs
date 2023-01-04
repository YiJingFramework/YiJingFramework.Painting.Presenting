using System;
using System.Text;
using YiJingFramework.Core;
using YiJingFramework.Painting.Presenting.Converters;
using YiJingFramework.Painting.Presenting.Extensions;

namespace Examples
{
    class Program
    {
        static void Main()
        {
            #region to convert to characters and back
            Console.OutputEncoding = Encoding.Unicode;
            Painting yang = new Painting(
                YinYang.Yang); // 阳
            Painting shaoYin = new Painting(
                YinYang.Yang, YinYang.Yin); // 少阴
            Painting li = new Painting(
                YinYang.Yang, YinYang.Yin, YinYang.Yang); // 离
            Painting qian = new Painting(
                YinYang.Yin, YinYang.Yin, YinYang.Yang,
                YinYang.Yin, YinYang.Yin, YinYang.Yin); // 谦
            Console.WriteLine($"{yang}-{shaoYin}-{li}-{qian} ");
            Console.WriteLine();
            // Output: 1-10-101-001000

            var characterConverter = new CharacterConverter();
            char characterOfQian = characterConverter.ConvertTo(qian);
            Console.WriteLine(
                $"{characterConverter.ConvertTo(yang)}-" +
                $"{shaoYin.ToUnicodeCharacter()}-" +
                $"{li.ToUnicodeCharacter()}-" +
                $"{characterOfQian} ");
            Console.WriteLine();
            // Output: ⚊-⚍-☲-䷎

            _ = characterConverter.TryConvertFrom(characterOfQian, out Painting result);
            Console.WriteLine(result);
            Console.WriteLine();
            // Output: 001000
            #endregion

            #region to convert to string
            StringConverter stringConverter = new StringConverter(
                "-----", "-- --", Environment.NewLine);
            Console.WriteLine(stringConverter.ConvertTo(qian));
            Console.WriteLine();
            /*
             * Outputs:
             * -- --
             * -- --
             * -- --
             * -----
             * -- --
             * -- --
             */
            #endregion
        }
    }
}
