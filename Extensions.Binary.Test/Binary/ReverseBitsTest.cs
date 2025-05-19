using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Binary.Tests
{
    [TestClass]
    public class ReverseBitsTest
    {
        [TestMethod]
        public void ReverseBitsInByte()
        {
            var bitArray = new BitArray(new bool[]
            {
                false, false, false, false,
                true, true, true, true
            });

            bitArray = bitArray.ReverseBitsInByte();
            Assert.AreEqual(15, bitArray.ToByte(), $"BitArray not swapped." );
        }
        [TestMethod]
        public void ReverseBitsInInt()
        {
            var bitArray = new BitArray(new bool[]
            {
                false, false, false, false,
                false, false, false, false,
                false, false, false, false,
                false, false, false, false,
                false, false, false, false,
                false, false, false, false,
                true, true, true, true,
                true, true, true, true
            });
            var reversed = new BitArray(bitArray.Length);
            bitArray = bitArray.ReverseBitsInInt();
            Assert.AreEqual(-16777216, bitArray.ToInt(), $"BitArray not swapped." );
        }
    }
}
