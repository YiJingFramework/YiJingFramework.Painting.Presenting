using System;
using System.Collections.Generic;
using System.Linq;
using YiJingFramework.References.Zhouyi;

namespace HexagramTableGenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var zy = new Zhouyi("translation.json");
            List<ZhouyiHexagram> hexagrams = new List<ZhouyiHexagram>();
            for (int i = 0; i <= 0b111111; i++)
            {
                var str = Convert.ToString(i, 2).PadLeft(6, '0');
                _ = YiJingFramework.Core.Painting.TryParse(str, out var result);
                hexagrams.Add(zy.GetHexagram(result));
            }
            var linq = from hexagram in hexagrams
                       orderby hexagram.Index
                       select hexagram;
            foreach (var q in linq)
            {
                Console.Write(q.GetPainting().ToBytes()[0]);
                Console.Write(',');
            }
        }
    }
}
