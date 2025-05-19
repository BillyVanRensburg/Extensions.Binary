using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Binary.Tests
{
    [TestClass]
    public class CalculateFromBitArrayTest
    {
        [TestMethod]
        public void CalculateByteFromArray()
        {
            var bitArray = new BitArray(new bool[8] { true, false, true, false, true, false, true, false }); // 0b01010101
            byte result = bitArray.CalculateByteFromArray();
            Assert.AreEqual((byte)0x55, result); // 85 decimal
        }

        [TestMethod]
        public void CalculateUShortFromArray()
        {
            // Arrange: 16 bits (LSB-first): 0b1010101010101010 → decimal 43690 (0xAAAA)
            var bitArray = new BitArray(new bool[]
            {
                false, true, false, true, false, true, false, true,   // byte 0 (LSB first)
                false, true, false, true, false, true, false, true    // byte 1
            });

            ushort expected = 0b1010101010101010; // 43690

            // Act
            var result = bitArray.CalculateUShortFromArray();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CalculateUIntFromArray()
        {
            // Arrange: 32 bits in LSB-first order → 0b10101010... = 0xAAAAAAAA = 2863311530
            var bitArray = new BitArray(new bool[]
            {
                false, true, false, true, false, true, false, true,   // byte 0
                false, true, false, true, false, true, false, true,   // byte 1
                false, true, false, true, false, true, false, true,   // byte 2
                false, true, false, true, false, true, false, true    // byte 3
            });

            uint expected = 0xAAAAAAAA; // 2863311530

            // Act
            var result = bitArray.CalculateUIntFromArray();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CalculateULongFromArray()
        {
            // Arrange: 64-bit pattern LSB-first → 0xAAAAAAAAAAAAAAAA = 12297829382473034410
            var bitArray = new BitArray(new bool[]
            {
                false, true, false, true, false, true, false, true,  // byte 0
                false, true, false, true, false, true, false, true,  // byte 1
                false, true, false, true, false, true, false, true,  // byte 2
                false, true, false, true, false, true, false, true,  // byte 3
                false, true, false, true, false, true, false, true,  // byte 4
                false, true, false, true, false, true, false, true,  // byte 5
                false, true, false, true, false, true, false, true,  // byte 6
                false, true, false, true, false, true, false, true   // byte 7
            });

            ulong expected = 0xAAAAAAAAAAAAAAAA; // 12297829382473034410

            // Act
            var result = bitArray.CalculateULongFromArray();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CalculateUInt128FromArray()
        {
            // Arrange: 128-bit pattern: 0xAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA (LSB-first)
            var bits = new bool[128];
            for (int i = 0; i < 128; i++)
                bits[i] = (i % 2 == 1); // 01010101...

            var bitArray = new BitArray(bits);

            // Expected: 0xAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
            var expected = UInt128.Parse("226854911280625642308916404954512140970");

            // Act
            var result = bitArray.CalculateUInt128FromArray();

            // Assert
            Assert.AreEqual(expected, result);
        }

    }
}
