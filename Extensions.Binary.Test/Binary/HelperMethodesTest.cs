using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Binary.Tests
{
    [TestClass]
    public class HelperMethodesTest
    {
        [TestMethod]
        public void HasEnoughBits()
        {
            var bitArray = new BitArray(16); // 16 bits
            Assert.IsTrue(bitArray.HasEnoughBits());
            Assert.IsTrue(bitArray.HasEnoughBits(8));
            Assert.IsFalse(bitArray.HasEnoughBits(9));
            Assert.IsTrue(bitArray.HasEnoughBits(2,8));
            Assert.IsFalse(bitArray.HasEnoughBits(2,16));
        }

        [TestMethod]
        public void HasValidStartIndex()
        {
            var bitArray = new BitArray(16);
            Assert.IsTrue(bitArray.HasValidStartIndex(0));
            Assert.IsTrue(bitArray.HasValidStartIndex(15));
            Assert.IsFalse(bitArray.HasValidStartIndex(16));
        }
    }
}
