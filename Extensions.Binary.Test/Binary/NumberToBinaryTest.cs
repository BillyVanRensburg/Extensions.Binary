using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Binary.Tests
{
    [TestClass]
    public class NumberToBinaryTest
    {
        [TestMethod]
        public void ByteToBinary()
        {
            byte value = 5; // 00000101 in binary
            string expectedMSB = "00000101";
            string expectedLSB = "10100000";

            Assert.AreEqual(expectedLSB, value.ToBinary(BitOrder.LSB));
            Assert.AreEqual(expectedMSB, value.ToBinary(BitOrder.MSB));
        }

        [TestMethod]
        public void SByteToBinary()
        {
            sbyte valuePositive = 5;   // 00000101
            sbyte valueNegative = -5;  // 11111011 (two's complement)

            string expectedPositiveMSB = "00000101";
            string expectedPositiveLSB = "10100000";

            string expectedNegativeMSB = "11111011";
            string expectedNegativeLSB = "11011111";

            Assert.AreEqual(expectedPositiveMSB, valuePositive.ToBinary(BitOrder.MSB));
            Assert.AreEqual(expectedPositiveLSB, valuePositive.ToBinary(BitOrder.LSB));

            Assert.AreEqual(expectedNegativeMSB, valueNegative.ToBinary(BitOrder.MSB));
            Assert.AreEqual(expectedNegativeLSB, valueNegative.ToBinary(BitOrder.LSB));
        }

        [TestMethod]
        public void UShortToBinary()
        {
            ushort value = 0x1234; // 4660 in decimal
                                   // In hex:
                                   // High byte: 0x12 = 00010010
                                   // Low byte:  0x34 = 00110100

            // MSB-bit order, Big Endian byte order → high byte first, bits left to right
            string expectedBE_MSB = "0001001000110100"; // 0x12 0x34

            // MSB-bit order, Little Endian byte order → low byte first
            string expectedLE_MSB = "0011010000010010"; // 0x34 0x12

            // LSB-bit order, Big Endian → each byte's bits are reversed, order = 0x12 0x34
            string expectedBE_LSB = "0100100000101100"; // reverse(0x12) + reverse(0x34)

            // LSB-bit order, Little Endian → reverse(0x34) + reverse(0x12)
            string expectedLE_LSB = "0010110001001000";

            Assert.AreEqual(expectedBE_MSB, value.ToBinary(BitOrder.MSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedLE_MSB, value.ToBinary(BitOrder.MSB, ByteOrder.LittleEndian));
            Assert.AreEqual(expectedBE_LSB, value.ToBinary(BitOrder.LSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedLE_LSB, value.ToBinary(BitOrder.LSB, ByteOrder.LittleEndian));
        }

        [TestMethod]
        public void ShortToBinary()
        {
            short valuePositive = 0x1234;  // 4660
            short valueNegative = -0x1234; // -4660 (two's complement: 0xEDCC)

            // Positive: 0x1234 = 00010010 00110100
            string expectedPositiveBE_MSB = "0001001000110100"; // 0x12 0x34
            string expectedPositiveLE_MSB = "0011010000010010"; // 0x34 0x12
            string expectedPositiveBE_LSB = "0100100000101100"; // reverse(0x12) + reverse(0x34)
            string expectedPositiveLE_LSB = "0010110001001000"; // reverse(0x34) + reverse(0x12)

            // Negative: -0x1234 = 0xEDCC = 11101101 11001100
            string expectedNegativeBE_MSB = "1110110111001100"; // 0xED 0xCC
            string expectedNegativeLE_MSB = "1100110011101101"; // 0xCC 0xED
            string expectedNegativeBE_LSB = "1011011100110011"; // reverse(0xED) + reverse(0xCC)
            string expectedNegativeLE_LSB = "0011001110110111"; // reverse(0xCC) + reverse(0xED)

            Assert.AreEqual(expectedPositiveBE_MSB, valuePositive.ToBinary(BitOrder.MSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedPositiveLE_MSB, valuePositive.ToBinary(BitOrder.MSB, ByteOrder.LittleEndian));
            Assert.AreEqual(expectedPositiveBE_LSB, valuePositive.ToBinary(BitOrder.LSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedPositiveLE_LSB, valuePositive.ToBinary(BitOrder.LSB, ByteOrder.LittleEndian));

            Assert.AreEqual(expectedNegativeBE_MSB, valueNegative.ToBinary(BitOrder.MSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedNegativeLE_MSB, valueNegative.ToBinary(BitOrder.MSB, ByteOrder.LittleEndian));
            Assert.AreEqual(expectedNegativeBE_LSB, valueNegative.ToBinary(BitOrder.LSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedNegativeLE_LSB, valueNegative.ToBinary(BitOrder.LSB, ByteOrder.LittleEndian));
        }
        [TestMethod]
        public void UIntToBinary()
        {
            uint value = 0x12345678;

            // Bytes (in hex):
            // 0x12 = 00010010
            // 0x34 = 00110100
            // 0x56 = 01010110
            // 0x78 = 01111000

            // MSB-first, Big Endian (bytes in natural order)
            string expectedBE_MSB = "00010010001101000101011001111000"; // 0x12 0x34 0x56 0x78

            // MSB-first, Little Endian (reverse byte order)
            string expectedLE_MSB = "01111000010101100011010000010010"; // 0x78 0x56 0x34 0x12

            // LSB-first, Big Endian (bit-reversed per byte)
            // reverse(0x12) = 01001000
            // reverse(0x34) = 00101100
            // reverse(0x56) = 01101010
            // reverse(0x78) = 00011110
            string expectedBE_LSB = "01001000001011000110101000011110";

            // LSB-first, Little Endian (reversed bits, reversed byte order)
            string expectedLE_LSB = "00011110011010100010110001001000";

            Assert.AreEqual(expectedBE_MSB, value.ToBinary(BitOrder.MSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedLE_MSB, value.ToBinary(BitOrder.MSB, ByteOrder.LittleEndian));
            Assert.AreEqual(expectedBE_LSB, value.ToBinary(BitOrder.LSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedLE_LSB, value.ToBinary(BitOrder.LSB, ByteOrder.LittleEndian));
        }

        [TestMethod]
        public void IntToBinary()
        {
            int positive = 0x12345678;     // 305419896
            int negative = -0x12345678;    // -305419896 → Two's complement: 0xEDCBA988

            // Positive value: 0x12345678 = [12][34][56][78]
            string expectedPositiveBE_MSB = "00010010001101000101011001111000"; // BigEndian, MSB
            string expectedPositiveLE_MSB = "01111000010101100011010000010010"; // LittleEndian, MSB
            string expectedPositiveBE_LSB = "01001000001011000110101000011110"; // BigEndian, LSB
            string expectedPositiveLE_LSB = "00011110011010100010110001001000"; // LittleEndian, LSB

            // Negative value: -0x12345678 = 0xEDCBA988 = [ED][CB][A9][88]
            string expectedNegativeBE_MSB = "11101101110010111010100110001000";
            string expectedNegativeLE_MSB = "10001000101010011100101111101101";
            string expectedNegativeBE_LSB = "10110111110100111001010100010001";
            string expectedNegativeLE_LSB = "00010001100101011101001110110111";

            Assert.AreEqual(expectedPositiveBE_MSB, positive.ToBinary(BitOrder.MSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedPositiveLE_MSB, positive.ToBinary(BitOrder.MSB, ByteOrder.LittleEndian));
            Assert.AreEqual(expectedPositiveBE_LSB, positive.ToBinary(BitOrder.LSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedPositiveLE_LSB, positive.ToBinary(BitOrder.LSB, ByteOrder.LittleEndian));

            Assert.AreEqual(expectedNegativeBE_MSB, negative.ToBinary(BitOrder.MSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedNegativeLE_MSB, negative.ToBinary(BitOrder.MSB, ByteOrder.LittleEndian));
            Assert.AreEqual(expectedNegativeBE_LSB, negative.ToBinary(BitOrder.LSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedNegativeLE_LSB, negative.ToBinary(BitOrder.LSB, ByteOrder.LittleEndian));
        }

        [TestMethod]
        public void ULongToBinary()
        {
            ulong value = 0x0123456789ABCDEF;

            // Bytes (in hex): 01 23 45 67 89 AB CD EF
            // MSB per byte:
            // 01 = 00000001
            // 23 = 00100011
            // 45 = 01000101
            // 67 = 01100111
            // 89 = 10001001
            // AB = 10101011
            // CD = 11001101
            // EF = 11101111

            string expectedBE_MSB = "0000000100100011010001010110011110001001101010111100110111101111";
            string expectedLE_MSB = "1110111111001101101010111000100101100111010001010010001100000001";

            // LSB per byte (bit-reversed):
            // 01 = 10000000
            // 23 = 11000100
            // 45 = 10100010
            // 67 = 11100110
            // 89 = 10010001
            // AB = 11010101
            // CD = 10110011
            // EF = 11110111

            string expectedBE_LSB = "1000000011000100101000101110011010010001110101011011001111110111";
            string expectedLE_LSB = "1111011110110011110101011001000111100110101000101100010010000000";

            Assert.AreEqual(expectedBE_MSB, value.ToBinary(BitOrder.MSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedLE_MSB, value.ToBinary(BitOrder.MSB, ByteOrder.LittleEndian));
            Assert.AreEqual(expectedBE_LSB, value.ToBinary(BitOrder.LSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedLE_LSB, value.ToBinary(BitOrder.LSB, ByteOrder.LittleEndian));
        }

        [TestMethod]
        public void LongToBinary()
        {
            long positive = 0x0123456789ABCDEF;
            long negative = -0x0123456789ABCDEF; // Two’s complement: 0xFEDCBA9876543211

            // Positive value: 0x0123456789ABCDEF
            string expectedPositiveBE_MSB = "0000000100100011010001010110011110001001101010111100110111101111";
            string expectedPositiveLE_MSB = "1110111111001101101010111000100101100111010001010010001100000001";
            string expectedPositiveBE_LSB = "1000000011000100101000101110011010010001110101011011001111110111";
            string expectedPositiveLE_LSB = "1111011110110011110101011001000111100110101000101100010010000000";

            // Negative value: 0xFEDCBA9876543211
            string expectedNegativeBE_MSB = "1111111011011100101110101001100001110110010101000011001000010001";
            string expectedNegativeLE_MSB = "0001000100110010010101000111011010011000101110101101110011111110";
            string expectedNegativeBE_LSB = "0111111100111011010111010001100101101110001010100100110010001000";
            string expectedNegativeLE_LSB = "1000100001001100001010100110111000011001010111010011101101111111";

            Assert.AreEqual(expectedPositiveBE_MSB, positive.ToBinary(BitOrder.MSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedPositiveLE_MSB, positive.ToBinary(BitOrder.MSB, ByteOrder.LittleEndian));
            Assert.AreEqual(expectedPositiveBE_LSB, positive.ToBinary(BitOrder.LSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedPositiveLE_LSB, positive.ToBinary(BitOrder.LSB, ByteOrder.LittleEndian));

            Assert.AreEqual(expectedNegativeBE_MSB, negative.ToBinary(BitOrder.MSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedNegativeLE_MSB, negative.ToBinary(BitOrder.MSB, ByteOrder.LittleEndian));
            Assert.AreEqual(expectedNegativeBE_LSB, negative.ToBinary(BitOrder.LSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedNegativeLE_LSB, negative.ToBinary(BitOrder.LSB, ByteOrder.LittleEndian));
        }

        [TestMethod]
        public void UInt128ToBinary()
        {
            UInt128 value = UInt128.Parse("24197857200151252728969465429440056815"); // 0x123456789ABCDEF0123456789ABCDEF

            // Bytes (hex) in BigEndian: 01 23 45 67 89 AB CD EF 01 23 45 67 89 AB CD EF
            string expectedBE_MSB = "00010010001101000101011001111000100100001010101111001101111011110001001000110100010101100111100010010000101010111100110111101111";
            string expectedLE_MSB = "11101111110011011010101110010000011110000101011000110100000100101110111111001101101010111001000001111000010101100011010000010010";
            string expectedBE_LSB = "01001000001011000110101000011110000010011101010110110011111101110100100000101100011010100001111000001001110101011011001111110111";
            string expectedLE_LSB = "11110111101100111101010100001001000111100110101000101100010010001111011110110011110101010000100100011110011010100010110001001000";

            Assert.AreEqual(expectedBE_MSB, value.ToBinary(BitOrder.MSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedLE_MSB, value.ToBinary(BitOrder.MSB, ByteOrder.LittleEndian));
            Assert.AreEqual(expectedBE_LSB, value.ToBinary(BitOrder.LSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedLE_LSB, value.ToBinary(BitOrder.LSB, ByteOrder.LittleEndian));
        }

        [TestMethod]
        public void Int128ToBinary()
        {
            // +0x0123456789ABCDEF0123456789ABCDEF
            Int128 positive = Int128.Parse("24197857200151252728969465429440056815");

            // -0x0123456789ABCDEF0123456789ABCDEF (two's complement)
            Int128 negative = -positive;

            string expectedPositiveBE_MSB = "00010010001101000101011001111000100100001010101111001101111011110001001000110100010101100111100010010000101010111100110111101111";
            string expectedPositiveLE_MSB = "11101111110011011010101110010000011110000101011000110100000100101110111111001101101010111001000001111000010101100011010000010010";
            string expectedPositiveBE_LSB = "01001000001011000110101000011110000010011101010110110011111101110100100000101100011010100001111000001001110101011011001111110111";
            string expectedPositiveLE_LSB = "11110111101100111101010100001001000111100110101000101100010010001111011110110011110101010000100100011110011010100010110001001000";

            // Expected results for -0x01234567... 
            string expectedNegativeBE_MSB = "11101101110010111010100110000111011011110101010000110010000100001110110111001011101010011000011101101111010101000011001000010001";
            string expectedNegativeLE_MSB = "00010001001100100101010001101111100001111010100111001011111011010001000000110010010101000110111110000111101010011100101111101101";
            string expectedNegativeBE_LSB = "10110111110100111001010111100001111101100010101001001100000010001011011111010011100101011110000111110110001010100100110010001000";
            string expectedNegativeLE_LSB = "10001000010011000010101011110110111000011001010111010011101101110000100001001100001010101111011011100001100101011101001110110111";

            // POSITIVE TESTS
            Assert.AreEqual(expectedPositiveBE_MSB, positive.ToBinary(BitOrder.MSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedPositiveLE_MSB, positive.ToBinary(BitOrder.MSB, ByteOrder.LittleEndian));
            Assert.AreEqual(expectedPositiveBE_LSB, positive.ToBinary(BitOrder.LSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedPositiveLE_LSB, positive.ToBinary(BitOrder.LSB, ByteOrder.LittleEndian));

            // NEGATIVE TESTS
            Assert.AreEqual(expectedNegativeBE_MSB, negative.ToBinary(BitOrder.MSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedNegativeLE_MSB, negative.ToBinary(BitOrder.MSB, ByteOrder.LittleEndian));
            Assert.AreEqual(expectedNegativeBE_LSB, negative.ToBinary(BitOrder.LSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedNegativeLE_LSB, negative.ToBinary(BitOrder.LSB, ByteOrder.LittleEndian));
        }

        [TestMethod]
        public void HalfToBinary()
        {
            Half value = (Half)1.5f; // IEEE 754: 0x3E00 (sign=0, exp=15, frac=1000000000)

            string expectedBE_MSB = "0011111000000000"; // Big-endian, MSB first
            string expectedLE_MSB = "0000000000111110"; // Little-endian, MSB first

            string expectedBE_LSB = "0111110000000000"; // Big-endian, LSB per byte
            string expectedLE_LSB = "0000000001111100"; // Little-endian, LSB per byte

            Assert.AreEqual(expectedBE_MSB, value.ToBinary(BitOrder.MSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedLE_MSB, value.ToBinary(BitOrder.MSB, ByteOrder.LittleEndian));
            Assert.AreEqual(expectedBE_LSB, value.ToBinary(BitOrder.LSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedLE_LSB, value.ToBinary(BitOrder.LSB, ByteOrder.LittleEndian));
        }

        [TestMethod]
        public void FloatToBinary()
        {
            float value = 1.5f; // IEEE 754: 0x3FC00000 (sign=0, exp=127, frac=10000000000000000000000)

            string expectedBE_MSB = "00111111110000000000000000000000"; // Big-endian, MSB first
            string expectedLE_MSB = "00000000000000001100000000111111"; // Little-endian, MSB first

            string expectedBE_LSB = "11111100000000110000000000000000"; // Big-endian, LSB per byte
            string expectedLE_LSB = "00000000000000000000001111111100"; // Little-endian, LSB per byte

            Assert.AreEqual(expectedBE_MSB, value.ToBinary(BitOrder.MSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedLE_MSB, value.ToBinary(BitOrder.MSB, ByteOrder.LittleEndian));
            Assert.AreEqual(expectedBE_LSB, value.ToBinary(BitOrder.LSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedLE_LSB, value.ToBinary(BitOrder.LSB, ByteOrder.LittleEndian));
        }

        [TestMethod]
        public void DoubleToBinary()
        {
            double value = 1.5; // IEEE 754: 0x3FF8000000000000

            string expectedBE_MSB = "0011111111111000000000000000000000000000000000000000000000000000"; // BE, MSB
            string expectedLE_MSB = "0000000000000000000000000000000000000000000000001111100000111111"; // LE, MSB

            string expectedBE_LSB = "1111110000011111000000000000000000000000000000000000000000000000"; // BE, LSB
            string expectedLE_LSB = "0000000000000000000000000000000000000000000000000001111111111100"; // LE, LSB

            Assert.AreEqual(expectedBE_MSB, value.ToBinary(BitOrder.MSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedLE_MSB, value.ToBinary(BitOrder.MSB, ByteOrder.LittleEndian));
            Assert.AreEqual(expectedBE_LSB, value.ToBinary(BitOrder.LSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedLE_LSB, value.ToBinary(BitOrder.LSB, ByteOrder.LittleEndian));
        }

        [TestMethod]
        public void DecimalToBinary()
        {
            decimal value = 1234.5678m;

            // These strings you get by the steps above, here are placeholders:
            string expectedLE_MSB = "01001110011000011011110000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010000000000";
            string expectedBE_MSB = "00000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000101111000110000101001110";
            string expectedLE_LSB = "01110010100001100011110100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010000000000000";
            string expectedBE_LSB = "00000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001111011000011001110010";

            Assert.AreEqual(expectedLE_MSB, value.ToBinary(BitOrder.MSB, ByteOrder.LittleEndian));
            Assert.AreEqual(expectedBE_MSB, value.ToBinary(BitOrder.MSB, ByteOrder.BigEndian));
            Assert.AreEqual(expectedLE_LSB, value.ToBinary(BitOrder.LSB, ByteOrder.LittleEndian));
            Assert.AreEqual(expectedBE_LSB, value.ToBinary(BitOrder.LSB, ByteOrder.BigEndian));
        }
    }
}
