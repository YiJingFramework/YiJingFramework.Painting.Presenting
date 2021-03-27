using Microsoft.VisualStudio.TestTools.UnitTesting;
using YiJingFramework.Painting.Presenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiJingFramework.Painting.Presenting.Tests
{
    [TestClass()]
    public class CharacterConverterTests
    {
        [TestMethod()]
        public void ConvertToTest()
        {
            IConverterTo<char> c = new CharacterConverter();
            var yang = c.ConvertTo(new Core.Painting(Core.LineAttribute.Yang));
            Assert.AreEqual('⚊', yang);
            var yin = c.ConvertTo(new Core.Painting(Core.LineAttribute.Yin));
            Assert.AreEqual('⚋', yin);
            var yangyang = c.ConvertTo(new Core.Painting(Core.LineAttribute.Yang, Core.LineAttribute.Yang));
            Assert.AreEqual('⚌', yangyang);
            var yangyin = c.ConvertTo(new Core.Painting(Core.LineAttribute.Yang, Core.LineAttribute.Yin));
            Assert.AreEqual('⚍', yangyin);
            var yinyang = c.ConvertTo(new Core.Painting(Core.LineAttribute.Yin, Core.LineAttribute.Yang));
            Assert.AreEqual('⚎', yinyang);
            var yinyin = c.ConvertTo(new Core.Painting(Core.LineAttribute.Yin, Core.LineAttribute.Yin));
            Assert.AreEqual('⚏', yinyin);
            var xun = c.ConvertTo(new Core.Painting(
                Core.LineAttribute.Yin, Core.LineAttribute.Yang, Core.LineAttribute.Yang));
            Assert.AreEqual('☴', xun);
            var qian = c.ConvertTo(new Core.Painting(
                Core.LineAttribute.Yang, Core.LineAttribute.Yang, Core.LineAttribute.Yang));
            Assert.AreEqual('☰', qian);
            var kun = c.ConvertTo(new Core.Painting(
                Core.LineAttribute.Yin, Core.LineAttribute.Yin, Core.LineAttribute.Yin));
            Assert.AreEqual('☷', kun);
            var dui = c.ConvertTo(new Core.Painting(
                Core.LineAttribute.Yang, Core.LineAttribute.Yang, Core.LineAttribute.Yin));
            Assert.AreEqual('☱', dui);
            var ze = c.ConvertTo(new Core.Painting(
                Core.LineAttribute.Yin, Core.LineAttribute.Yang, Core.LineAttribute.Yin));
            Assert.AreEqual('☵', ze);

            var qian6 = c.ConvertTo(new Core.Painting(
                Core.LineAttribute.Yang, Core.LineAttribute.Yang, Core.LineAttribute.Yang,
                Core.LineAttribute.Yang, Core.LineAttribute.Yang, Core.LineAttribute.Yang));
            Assert.AreEqual('䷀', qian6);
            var weiji = c.ConvertTo(new Core.Painting(
                Core.LineAttribute.Yin, Core.LineAttribute.Yang, Core.LineAttribute.Yin,
                Core.LineAttribute.Yang, Core.LineAttribute.Yin, Core.LineAttribute.Yang));
            Assert.AreEqual('䷿', weiji);
            var r = c.ConvertTo(new Core.Painting(
                Core.LineAttribute.Yin, Core.LineAttribute.Yang, Core.LineAttribute.Yang,
                Core.LineAttribute.Yin, Core.LineAttribute.Yin, Core.LineAttribute.Yin));
            Assert.AreEqual('䷭', r);
        }

        readonly Random random = new Random();
        private Core.Painting GetRandomPainting(int lineCount)
        {
            List<Core.LineAttribute> lines = new List<Core.LineAttribute>(lineCount);
            for(int i =0;i < lineCount;i++)
            {
                lines.Add(random.Next(0, 2) == 0 ? Core.LineAttribute.Yang : Core.LineAttribute.Yin);
            }
            return new Core.Painting(lines);
        }
        [TestMethod()]
        public void TryConvertFromTest()
        {
            IConverterTo<char> c = new CharacterConverter();
            IConverterFrom<char> cb = new CharacterConverter();

            for (int i = 0; i < 10000; i++)
            {
                var painting = this.GetRandomPainting(random.Next(0, 4) switch {
                    0 => 1,
                    1 => 2,
                    2 => 3,
                    _ => 6
                });
                var cdd = c.ConvertTo(painting);
                var bl = cb.TryConvertFrom(cdd, out var cddd);
                Assert.IsTrue(bl);
                Assert.AreEqual(painting, cddd);
            }
        }
    }
}