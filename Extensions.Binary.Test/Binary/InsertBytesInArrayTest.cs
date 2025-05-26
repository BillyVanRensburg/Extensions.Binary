using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Binary.Tests
{
    [TestClass]
    public class InsertBytesInArrayTest
    {
        [TestMethod]
        public void InsertBytesInArray()
        {
            BitArray bitArray;
            BitArray result;
            bool[] inputBits;

            bitArray = new BitArray(64);
            result = bitArray.InsertBytesInArray( 0, BitOrder.LSB, 4);
            Assert.AreEqual(Constant.bits8 * 4, result.Length, "Incorrect lenght returned.");

            bitArray = new BitArray(0);
            result = bitArray.InsertBytesInArray(0, BitOrder.LSB , 0);
            Assert.AreEqual(0, result.Length, "Fails when amount of bytes is zero.");

            inputBits = new bool[]
            {
            true, false, true, false, true, false, true, false, // byte 0 (0x55)
            false, true, false, true, false, true, false, true  // byte 1 (0xAA)
            };
            bitArray = new BitArray(inputBits);
            result = bitArray.InsertBytesInArray(0, BitOrder.LSB, 2);
            for (int i = 0; i < inputBits.Length; i++)
            {
                Assert.AreEqual(inputBits[i], result[i], $"Incorrectly copied bits mismatch at bit index {i}");
            }

            try
            {
                bitArray = new BitArray(8);
                bitArray.InsertBytesInArray(100, BitOrder.LSB, 1);
                Assert.Fail("BitArray out of range ArgumentException was not thrown.");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Start index is out of range. (Parameter 'startIndex')", ex.Message);
            }
        }
    }
}
