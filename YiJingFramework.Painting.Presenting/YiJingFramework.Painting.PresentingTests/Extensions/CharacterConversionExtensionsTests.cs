using Microsoft.VisualStudio.TestTools.UnitTesting;
using YiJingFramework.Painting.Presenting.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiJingFramework.Painting.Presenting.Converters;

namespace YiJingFramework.Painting.Presenting.Extensions.Tests
{
    [TestClass()]
    public class CharacterConversionExtensionsTests
    {
        [TestMethod()]
        public void ToUnicodeCharacterTest()
        {
            var yang = new Core.Painting(Core.YinYang.Yang)
                .ToUnicodeCharacter();
            Assert.AreEqual('⚊', yang);
            var yangyang = new Core.Painting(Core.YinYang.Yang, Core.YinYang.Yang)
                .ToUnicodeCharacter();
            Assert.AreEqual('⚌', yangyang);
            var xun = new Core.Painting(Core.YinYang.Yin, Core.YinYang.Yang, Core.YinYang.Yang)
                .ToUnicodeCharacter();
            Assert.AreEqual('☴', xun);
            var qian = new Core.Painting(
                Core.YinYang.Yang, Core.YinYang.Yang, Core.YinYang.Yang,
                Core.YinYang.Yang, Core.YinYang.Yang, Core.YinYang.Yang)
                .ToUnicodeCharacter();
            Assert.AreEqual('䷀', qian);
        }
    }
}