using System;
using System.Text;
using YiJingFramework.Core;
using YiJingFramework.Painting.Presenting;

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
            Console.Write($"{yang}-{shaoYin}-{li}-{qian} ");
            var characterConverter = new CharacterConverter();
            char characterOfQian = characterConverter.ConvertTo(qian);
            Console.Write($"{characterConverter.ConvertTo(yang)}-" +
                $"{characterConverter.ConvertTo(shaoYin)}-" +
                $"{characterConverter.ConvertTo(li)}-" +
                $"{characterOfQian} ");
            _ = characterConverter.TryConvertFrom(characterOfQian, out Painting result);
            Console.WriteLine(result);
            Console.WriteLine();
            // Output: 1-10-101-001000 ⚊-⚍-☲-䷎ 001000
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
