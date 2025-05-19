using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Binary.Tests
{
    [TestClass]
    public class InsertInArrayTest
    {

        [TestMethod]
        public void InsertBytesInArray_ReturnsCorrectLength()
        {
            var bitArray = new BitArray(64); // Enough for 8 bytes
            var result = bitArray.InsertBytesInArray(startIndex: 0, bitOrder: BitOrder.LSB, AmountOfBytes: 4);
            Assert.AreEqual(Constant.bits8 * 4, result.Length);
        }

        [TestMethod]
        public void InsertBytesInArray_ReturnsEmptyArray_WhenAmountOfBytesIsZero()
        {
            var bitArray = new BitArray(0);
            var result = bitArray.InsertBytesInArray(startIndex: 0, AmountOfBytes: 0);
            Assert.AreEqual(0, result.Length);
        }

        [TestMethod]
        public void InsertBytesInArray_CorrectlyCopiesBits()
        {
            // Input byte pattern: 0b10101010 = 0xAA
            var inputBits = new bool[]
            {
            true, false, true, false, true, false, true, false, // byte 0 (0x55)
            false, true, false, true, false, true, false, true  // byte 1 (0xAA)
            };
            var bitArray = new BitArray(inputBits);

            var result = bitArray.InsertBytesInArray(startIndex: 0, AmountOfBytes: 2, bitOrder: BitOrder.LSB);

            // Expected pattern: should be same as inputBits
            for (int i = 0; i < inputBits.Length; i++)
            {
                Assert.AreEqual(inputBits[i], result[i], $"Mismatch at bit index {i}");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertBytesInArray_ThrowsIfStartIndexIsInvalid()
        {
            var bitArray = new BitArray(8); // Only 1 byte
            _ = bitArray.InsertBytesInArray(startIndex: 100, AmountOfBytes: 1);
        }
    }
}
