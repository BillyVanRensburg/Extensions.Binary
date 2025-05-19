using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Binary.Tests
{
    [TestClass]
    public class PublicMethodesTest
    {
        [TestMethod]
        public void InsertArray()
        {
            var target = new BitArray(8); // All false
            var insert = new BitArray(new[] { true, false, true }); // 1 0 1

            target.InsertArray(insert, 0);

            Assert.IsTrue(target[0]);
            Assert.IsFalse(target[1]);
            Assert.IsTrue(target[2]);
            for (int i = 3; i < target.Count; i++)
                Assert.IsFalse(target[i]);
        }

        [TestMethod]
        public void ToBinary()
        {
            var bitArray = new BitArray(4, true); // all true

            string result = bitArray.ToBinary();

            Assert.AreEqual("1111", result);
        }

        [TestMethod]
        public void AppendBitArray()
        {
            var original = new BitArray(new[] { true, false });
            var append = new BitArray(new[] { false, true });

            var result = original.AppendBitArray(append);

            Assert.AreEqual(4, result.Length);
            Assert.AreEqual("1001", result.ToBinary());
        }
    }
}
