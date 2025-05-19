using Extensions.Binary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Binary.Tests
{
    [TestClass]
    public class BitArrayToNumberTest
    {
        [TestMethod]
        public void BitArrayToByte()
        {
            BitArray bitArray = new BitArray(new bool[] { false, true, false, true, false, true, false, true });

            byte expectedLSB = 170; // 10101010 in binary
            byte resultLSB = bitArray.ToByte(0, BitOrder.LSB);

            byte expectedMSB = 85; // 01010101 in binary
            byte resultMSB = bitArray.ToByte(0, BitOrder.MSB);

            Assert.AreEqual(expectedLSB, resultLSB, "(LSB) Failed to convert BitArray to byte.");
            Assert.AreEqual(expectedMSB, resultMSB, "(MSB) Failed to convert BitArray to byte.");
        }

        [TestMethod]
        public void BitArrayToSByte()
        {
            BitArray bitArray = new BitArray(new bool[] { false, true, false, true, false, true, false, true });
            sbyte expectedLSB = -86; // 10101010 in binary
            sbyte resultLSB = bitArray.ToSByte(0, BitOrder.LSB);

            sbyte expectedMSB = 85; // 01010101 in binary
            sbyte resultMSB = bitArray.ToSByte(0, BitOrder.MSB);

            Assert.AreEqual(expectedLSB, resultLSB, "(LSB) Failed to convert BitArray to sbyte.");
            Assert.AreEqual(expectedMSB, resultMSB, "(MSB) Failed to convert BitArray to sbyte.");
        }

        [TestMethod]
        public void BitArrayToShort()
        {
            BitArray bitArray = new BitArray(new bool[] { false, true, false, true, false, true, false, true, true, false, true, false, true, false, true, false });

            short expectedLSBLE = 21930;
            short resultLSBLE = bitArray.ToShort(0, BitOrder.LSB, ByteOrder.LittleEndian);

            short expectedMSBLE = -21931;
            short resultMSBLE = bitArray.ToShort(0, BitOrder.MSB, ByteOrder.LittleEndian);

            short expectedLSBBE = -21931;
            short resultLSBBE = bitArray.ToShort(0, BitOrder.LSB, ByteOrder.BigEndian);

            short expectedMSBBE = 21930;
            short resultMSBBE = bitArray.ToShort(0, BitOrder.MSB, ByteOrder.BigEndian);

            Assert.AreEqual(expectedLSBLE, resultLSBLE, "(LSB & LE) Failed to convert BitArray to short.");
            Assert.AreEqual(expectedMSBLE, resultMSBLE, "(MSB & LE) Failed to convert BitArray to short.");
            Assert.AreEqual(expectedLSBBE, resultLSBBE, "(LSB & BE) Failed to convert BitArray to short.");
            Assert.AreEqual(expectedMSBBE, resultMSBBE, "(MSB & BE) Failed to convert BitArray to short.");
        }

        [TestMethod]
        public void BitArrayToUShort()
        {
            BitArray bitArray = new BitArray(new bool[] { false, true, false, true, false, true, false, true, true, false, true, false, true, false, true, false });

            ushort expectedLSBLE = 21930;
            ushort resultLSBLE = bitArray.ToUShort(0, BitOrder.LSB, ByteOrder.LittleEndian);

            ushort expectedMSBLE = 43605;
            ushort resultMSBLE = bitArray.ToUShort(0, BitOrder.MSB, ByteOrder.LittleEndian);

            ushort expectedLSBBE = 43605;
            ushort resultLSBBE = bitArray.ToUShort(0, BitOrder.LSB, ByteOrder.BigEndian);

            ushort expectedMSBBE = 21930;
            ushort resultMSBBE = bitArray.ToUShort(0, BitOrder.MSB, ByteOrder.BigEndian);

            Assert.AreEqual(expectedLSBLE, resultLSBLE, "(LSB & LE) Failed to convert BitArray to short.");
            Assert.AreEqual(expectedMSBLE, resultMSBLE, "(MSB & LE) Failed to convert BitArray to short.");
            Assert.AreEqual(expectedLSBBE, resultLSBBE, "(LSB & BE) Failed to convert BitArray to short.");
            Assert.AreEqual(expectedMSBBE, resultMSBBE, "(MSB & BE) Failed to convert BitArray to short.");
        }

        [TestMethod]
        public void BitArrayToInt()
        {
            // 32-bit pattern: 01010101 10101010 01010101 10101010 (repeating 0,1 …)
            BitArray bitArray = new BitArray(new[]
            {
                false, true, false, true, false, true, false, true,   // byte 0 → 0xAA
                true, false, true, false, true, false, true, false,   // byte 1 → 0x55
                false, true, false, true, false, true, false, true,   // byte 2 → 0xAA
                true, false, true, false, true, false, true, false    // byte 3 → 0x55
            });

            // 0x55AA55AA is positive; 0xAA55AA55 has the sign bit set, so
            // we wrap it with unchecked(...) to get the intended negative value.
            int expectedLSBLE = 0x55AA55AA;                       // 1437226410
            int expectedMSBLE = unchecked((int)0xAA55AA55);       // -1437226411
            int expectedLSBBE = unchecked((int)0xAA55AA55);       // -1437226411
            int expectedMSBBE = 0x55AA55AA;                       // 1437226410

            int resultLSBLE = bitArray.ToInt(0, BitOrder.LSB, ByteOrder.LittleEndian);
            int resultMSBLE = bitArray.ToInt(0, BitOrder.MSB, ByteOrder.LittleEndian);
            int resultLSBBE = bitArray.ToInt(0, BitOrder.LSB, ByteOrder.BigEndian);
            int resultMSBBE = bitArray.ToInt(0, BitOrder.MSB, ByteOrder.BigEndian);

            Assert.AreEqual(expectedLSBLE, resultLSBLE, "(LSB & LE) Failed to convert BitArray to int.");
            Assert.AreEqual(expectedMSBLE, resultMSBLE, "(MSB & LE) Failed to convert BitArray to int.");
            Assert.AreEqual(expectedLSBBE, resultLSBBE, "(LSB & BE) Failed to convert BitArray to int.");
            Assert.AreEqual(expectedMSBBE, resultMSBBE, "(MSB & BE) Failed to convert BitArray to int.");
        }

        [TestMethod]
        public void BitArrayToUInt()
        {
            // 32-bit pattern: 01010101 10101010 01010101 10101010
            BitArray bitArray = new BitArray(new[]
            {
                false, true, false, true, false, true, false, true,   // byte 0 → 0xAA
                true, false, true, false, true, false, true, false,   // byte 1 → 0x55
                false, true, false, true, false, true, false, true,   // byte 2 → 0xAA
                true, false, true, false, true, false, true, false    // byte 3 → 0x55
            });

            uint expectedLSBLE = 0x55AA55AAu; // 1437226410
            uint expectedMSBLE = 0xAA55AA55u; // 2857740885
            uint expectedLSBBE = 0xAA55AA55u; // 2857740885
            uint expectedMSBBE = 0x55AA55AAu; // 1437226410

            uint resultLSBLE = bitArray.ToUInt(0, BitOrder.LSB, ByteOrder.LittleEndian);
            uint resultMSBLE = bitArray.ToUInt(0, BitOrder.MSB, ByteOrder.LittleEndian);
            uint resultLSBBE = bitArray.ToUInt(0, BitOrder.LSB, ByteOrder.BigEndian);
            uint resultMSBBE = bitArray.ToUInt(0, BitOrder.MSB, ByteOrder.BigEndian);

            Assert.AreEqual(expectedLSBLE, resultLSBLE, "(LSB & LE) Failed to convert BitArray to uint.");
            Assert.AreEqual(expectedMSBLE, resultMSBLE, "(MSB & LE) Failed to convert BitArray to uint.");
            Assert.AreEqual(expectedLSBBE, resultLSBBE, "(LSB & BE) Failed to convert BitArray to uint.");
            Assert.AreEqual(expectedMSBBE, resultMSBBE, "(MSB & BE) Failed to convert BitArray to uint.");
        }

        [TestMethod]
        public void BitArrayToLong()
        {
            // 64-bit pattern: 01010101 10101010 ... repeated (alternating 0,1) for 8 bytes
            BitArray bitArray = new BitArray(new[]
            {
                false, true, false, true, false, true, false, true,   // byte 0 → 0xAA
                true, false, true, false, true, false, true, false,   // byte 1 → 0x55
                false, true, false, true, false, true, false, true,   // byte 2 → 0xAA
                true, false, true, false, true, false, true, false,   // byte 3 → 0x55
                false, true, false, true, false, true, false, true,   // byte 4 → 0xAA
                true, false, true, false, true, false, true, false,   // byte 5 → 0x55
                false, true, false, true, false, true, false, true,   // byte 6 → 0xAA
                true, false, true, false, true, false, true, false    // byte 7 → 0x55
            });

            long expectedLSBLE = 0x55AA55AA55AA55AAL;                       // 6172840429334718890
            long expectedMSBLE = unchecked((long)0xAA55AA55AA55AA55ul);     // -2273883644384832723
            long expectedLSBBE = unchecked((long)0xAA55AA55AA55AA55ul);     // -2273883644384832723
            long expectedMSBBE = 0x55AA55AA55AA55AAL;                       // 6172840429334718890

            long resultLSBLE = bitArray.ToLong(0, BitOrder.LSB, ByteOrder.LittleEndian);
            long resultMSBLE = bitArray.ToLong(0, BitOrder.MSB, ByteOrder.LittleEndian);
            long resultLSBBE = bitArray.ToLong(0, BitOrder.LSB, ByteOrder.BigEndian);
            long resultMSBBE = bitArray.ToLong(0, BitOrder.MSB, ByteOrder.BigEndian);

            Assert.AreEqual(expectedLSBLE, resultLSBLE, "(LSB & LE) Failed to convert BitArray to long.");
            Assert.AreEqual(expectedMSBLE, resultMSBLE, "(MSB & LE) Failed to convert BitArray to long.");
            Assert.AreEqual(expectedLSBBE, resultLSBBE, "(LSB & BE) Failed to convert BitArray to long.");
            Assert.AreEqual(expectedMSBBE, resultMSBBE, "(MSB & BE) Failed to convert BitArray to long.");
        }

        [TestMethod]
        public void BitArrayToULong()
        {
            // 64-bit pattern: 01010101 10101010 ... (alternating bits for 8 bytes)
            BitArray bitArray = new BitArray(new[]
            {
                false, true, false, true, false, true, false, true,   // byte 0 → 0xAA
                true, false, true, false, true, false, true, false,   // byte 1 → 0x55
                false, true, false, true, false, true, false, true,   // byte 2 → 0xAA
                true, false, true, false, true, false, true, false,   // byte 3 → 0x55
                false, true, false, true, false, true, false, true,   // byte 4 → 0xAA
                true, false, true, false, true, false, true, false,   // byte 5 → 0x55
                false, true, false, true, false, true, false, true,   // byte 6 → 0xAA
                true, false, true, false, true, false, true, false    // byte 7 → 0x55
            });

            ulong expectedLSBLE = 0x55AA55AA55AA55AAul; // 6172840429334718890
            ulong expectedMSBLE = 0xAA55AA55AA55AA55ul; // 15673800429374838893
            ulong expectedLSBBE = 0xAA55AA55AA55AA55ul; // 15673800429374838893
            ulong expectedMSBBE = 0x55AA55AA55AA55AAul; // 6172840429334718890

            ulong resultLSBLE = bitArray.ToULong(0, BitOrder.LSB, ByteOrder.LittleEndian);
            ulong resultMSBLE = bitArray.ToULong(0, BitOrder.MSB, ByteOrder.LittleEndian);
            ulong resultLSBBE = bitArray.ToULong(0, BitOrder.LSB, ByteOrder.BigEndian);
            ulong resultMSBBE = bitArray.ToULong(0, BitOrder.MSB, ByteOrder.BigEndian);

            Assert.AreEqual(expectedLSBLE, resultLSBLE, "(LSB & LE) Failed to convert BitArray to ulong.");
            Assert.AreEqual(expectedMSBLE, resultMSBLE, "(MSB & LE) Failed to convert BitArray to ulong.");
            Assert.AreEqual(expectedLSBBE, resultLSBBE, "(LSB & BE) Failed to convert BitArray to ulong.");
            Assert.AreEqual(expectedMSBBE, resultMSBBE, "(MSB & BE) Failed to convert BitArray to ulong.");
        }

        [TestMethod]
        public void BitArrayToInt128()
        {
            // 128-bit pattern: alternating 01010101 10101010... for 16 bytes
            BitArray bitArray = new BitArray(new[]
            {
        // Bytes 0-7: 0xAA, 0x55 alternating
        false, true, false, true, false, true, false, true,   // byte 0 → 0xAA
        true, false, true, false, true, false, true, false,   // byte 1 → 0x55
        false, true, false, true, false, true, false, true,   // byte 2 → 0xAA
        true, false, true, false, true, false, true, false,   // byte 3 → 0x55
        false, true, false, true, false, true, false, true,   // byte 4 → 0xAA
        true, false, true, false, true, false, true, false,   // byte 5 → 0x55
        false, true, false, true, false, true, false, true,   // byte 6 → 0xAA
        true, false, true, false, true, false, true, false,   // byte 7 → 0x55

        // Bytes 8–15: same pattern again
        false, true, false, true, false, true, false, true,   // byte 8 → 0xAA
        true, false, true, false, true, false, true, false,   // byte 9 → 0x55
        false, true, false, true, false, true, false, true,   // byte10 → 0xAA
        true, false, true, false, true, false, true, false,   // byte11 → 0x55
        false, true, false, true, false, true, false, true,   // byte12 → 0xAA
        true, false, true, false, true, false, true, false,   // byte13 → 0x55
        false, true, false, true, false, true, false, true,   // byte14 → 0xAA
        true, false, true, false, true, false, true, false    // byte15 → 0x55
    });

            // 0x55AA55AA55AA55AA55AA55AA55AA55AA
            Int128 expectedLSBLE = Int128.Parse("113868807607784855478016405599735666090");
            // 0xAA55AA55AA55AA55AA55AA55AA55AA55
            Int128 expectedMSBLE = Int128.Parse("-113868807607784855478016405599735666091");
            Int128 expectedLSBBE = Int128.Parse("-113868807607784855478016405599735666091");
            Int128 expectedMSBBE = Int128.Parse("113868807607784855478016405599735666090");

            Int128 resultLSBLE = bitArray.ToInt128(0, BitOrder.LSB, ByteOrder.LittleEndian);
            Int128 resultMSBLE = bitArray.ToInt128(0, BitOrder.MSB, ByteOrder.LittleEndian);
            Int128 resultLSBBE = bitArray.ToInt128(0, BitOrder.LSB, ByteOrder.BigEndian);
            Int128 resultMSBBE = bitArray.ToInt128(0, BitOrder.MSB, ByteOrder.BigEndian);

            Assert.AreEqual(expectedLSBLE, resultLSBLE, "(LSB & LE) Failed to convert BitArray to Int128.");
            Assert.AreEqual(expectedMSBLE, resultMSBLE, "(MSB & LE) Failed to convert BitArray to Int128.");
            Assert.AreEqual(expectedLSBBE, resultLSBBE, "(LSB & BE) Failed to convert BitArray to Int128.");
            Assert.AreEqual(expectedMSBBE, resultMSBBE, "(MSB & BE) Failed to convert BitArray to Int128.");
        }

        [TestMethod]
        public void BitArrayToUInt128()
        {
            // 128-bit pattern: alternating 01010101 10101010... for 16 bytes
            BitArray bitArray = new BitArray(new[]
            {
        // Bytes 0-7: 0xAA, 0x55 alternating
        false, true, false, true, false, true, false, true,   // byte 0 → 0xAA
        true, false, true, false, true, false, true, false,   // byte 1 → 0x55
        false, true, false, true, false, true, false, true,   // byte 2 → 0xAA
        true, false, true, false, true, false, true, false,   // byte 3 → 0x55
        false, true, false, true, false, true, false, true,   // byte 4 → 0xAA
        true, false, true, false, true, false, true, false,   // byte 5 → 0x55
        false, true, false, true, false, true, false, true,   // byte 6 → 0xAA
        true, false, true, false, true, false, true, false,   // byte 7 → 0x55

        // Bytes 8–15: same pattern again
        false, true, false, true, false, true, false, true,   // byte 8 → 0xAA
        true, false, true, false, true, false, true, false,   // byte 9 → 0x55
        false, true, false, true, false, true, false, true,   // byte10 → 0xAA
        true, false, true, false, true, false, true, false,   // byte11 → 0x55
        false, true, false, true, false, true, false, true,   // byte12 → 0xAA
        true, false, true, false, true, false, true, false,   // byte13 → 0x55
        false, true, false, true, false, true, false, true,   // byte14 → 0xAA
        true, false, true, false, true, false, true, false    // byte15 → 0x55
    });

            // 0x55AA55AA55AA55AA55AA55AA55AA55AA
            UInt128 expectedLSBLE = UInt128.Parse("113868807607784855478016405599735666090");
            // 0xAA55AA55AA55AA55AA55AA55AA55AA55
            UInt128 expectedMSBLE = UInt128.Parse("226413559313153607985358201832032545365");
            UInt128 expectedLSBBE = UInt128.Parse("226413559313153607985358201832032545365");
            UInt128 expectedMSBBE = UInt128.Parse("113868807607784855478016405599735666090");

            UInt128 resultLSBLE = bitArray.ToUInt128(0, BitOrder.LSB, ByteOrder.LittleEndian);
            UInt128 resultMSBLE = bitArray.ToUInt128(0, BitOrder.MSB, ByteOrder.LittleEndian);
            UInt128 resultLSBBE = bitArray.ToUInt128(0, BitOrder.LSB, ByteOrder.BigEndian);
            UInt128 resultMSBBE = bitArray.ToUInt128(0, BitOrder.MSB, ByteOrder.BigEndian);

            Assert.AreEqual(expectedLSBLE, resultLSBLE, "(LSB & LE) Failed to convert BitArray to UInt128.");
            Assert.AreEqual(expectedMSBLE, resultMSBLE, "(MSB & LE) Failed to convert BitArray to UInt128.");
            Assert.AreEqual(expectedLSBBE, resultLSBBE, "(LSB & BE) Failed to convert BitArray to UInt128.");
            Assert.AreEqual(expectedMSBBE, resultMSBBE, "(MSB & BE) Failed to convert BitArray to UInt128.");
        }

        [TestMethod]
        public void BitArrayToHalf()
        {
            // Bit pattern: 0 01111 0000000000 = 1.0 in IEEE 754 Half-precision (float16)
            BitArray bitArray = new BitArray(new bool[] {
        false, true, true, true, true,  // Sign + exponent
        false, false, false, false, false, false  // Mantissa
    }.Concat(new bool[5]).ToArray()); // Pad with extra 5 bits to make 16 total

            // IEEE 754 half: 0x3C00 == 1.0f
            Half expectedLSBLE = (Half)1.8E-06;
            Half resultLSBLE = bitArray.ToHalf(0, BitOrder.LSB, ByteOrder.LittleEndian);

            Half expectedMSBLE = (Half)7.15E-06;
            Half resultMSBLE = bitArray.ToHalf(0, BitOrder.MSB, ByteOrder.LittleEndian);

            Half expectedLSBBE = (Half)0.00586;
            Half resultLSBBE = bitArray.ToHalf(0, BitOrder.LSB, ByteOrder.BigEndian);

            Half expectedMSBBE = (Half)32770;
            Half resultMSBBE = bitArray.ToHalf(0, BitOrder.MSB, ByteOrder.BigEndian);

            Assert.AreEqual(expectedLSBLE, resultLSBLE, "(LSB & LE) Failed to convert BitArray to Half.");
            Assert.AreEqual(expectedMSBLE, resultMSBLE, "(MSB & LE) Failed to convert BitArray to Half.");
            Assert.AreEqual(expectedLSBBE, resultLSBBE, "(LSB & BE) Failed to convert BitArray to Half.");
            Assert.AreEqual(expectedMSBBE, resultMSBBE, "(MSB & BE) Failed to convert BitArray to Half.");
        }

        [TestMethod]
        public void BitArrayToFloat()
        {
            // IEEE 754 float (32-bit) for 1.0f = 0x3F800000 = 00111111 10000000 00000000 00000000
            bool[] bits = new bool[]
            {
        false, false, true, true, true, true, true, false,  // Byte 0
        true, false, false, false, false, false, false, false,  // Byte 1
        false, false, false, false, false, false, false, false,  // Byte 2
        false, false, false, false, false, false, false, false   // Byte 3
            };

            BitArray bitArray = new BitArray(bits);

            float resultLSBLE = bitArray.ToFloat(0, BitOrder.LSB, ByteOrder.LittleEndian);
            float resultMSBLE = bitArray.ToFloat(0, BitOrder.MSB, ByteOrder.LittleEndian);
            float resultLSBBE = bitArray.ToFloat(0, BitOrder.LSB, ByteOrder.BigEndian);
            float resultMSBBE = bitArray.ToFloat(0, BitOrder.MSB, ByteOrder.BigEndian);

            Assert.AreEqual((float)5.32E-43, resultLSBLE, "(LSB & LE) Failed to convert BitArray to float.");
            Assert.AreEqual((float)4.6005E-41, resultMSBLE, "(MSB & LE) Failed to convert BitArray to float.");
            Assert.AreEqual((float)2.6792252E+36, resultLSBBE, "(LSB & BE) Failed to convert BitArray to float.");
            Assert.AreEqual((float)0.25, resultMSBBE, "(MSB & BE) Failed to convert BitArray to float.");
        }

        [TestMethod]
        public void BitArrayToDouble()
        {
            // IEEE 754 double (64-bit) for 1.0 = 0x3FF0000000000000
            // Binary: 00111111 11110000 00000000 00000000 00000000 00000000 00000000 00000000
            bool[] bits = new bool[]
            {
        false, false, true, true, true, true, true, true,       // Byte 0: 0x3F
        true, false, false, false, false, false, false, false,  // Byte 1: 0xF0
        false, false, false, false, false, false, false, false, // Byte 2: 0x00
        false, false, false, false, false, false, false, false, // Byte 3: 0x00
        false, false, false, false, false, false, false, false, // Byte 4: 0x00
        false, false, false, false, false, false, false, false, // Byte 5: 0x00
        false, false, false, false, false, false, false, false, // Byte 6: 0x00
        false, false, false, false, false, false, false, false  // Byte 7: 0x00
            };

            BitArray bitArray = new BitArray(bits);

            double resultLSBLE = bitArray.ToDouble(0, BitOrder.LSB, ByteOrder.LittleEndian);
            double resultMSBLE = bitArray.ToDouble(0, BitOrder.MSB, ByteOrder.LittleEndian);
            double resultLSBBE = bitArray.ToDouble(0, BitOrder.LSB, ByteOrder.BigEndian);
            double resultMSBBE = bitArray.ToDouble(0, BitOrder.MSB, ByteOrder.BigEndian);

            Assert.AreEqual((double)2.51E-321 , resultLSBLE, "(LSB & LE) Failed to convert BitArray to double.");
            Assert.AreEqual((double)1.62207E-319, resultMSBLE, "(MSB & LE) Failed to convert BitArray to double.");
            Assert.AreEqual((double)-2.0708792274225E+289, resultLSBBE, "(LSB & BE) Failed to convert BitArray to double.");
            Assert.AreEqual((double)0.0078125, resultMSBBE, "(MSB & BE) Failed to convert BitArray to double.");
        }

        [TestMethod]
        public void BitArrayToDecimal()
        {
            // decimal value: 1.0m
            // Internal representation of decimal(1.0m) is:
            //   - Low 32 bits:   1
            //   - Mid 32 bits:   0
            //   - High 32 bits:  0
            //   - Flags:         0x00010000 (scale=1, positive)
            // Total 128 bits = 16 bytes = 128 bools
        
            byte[] decimalBytes = new byte[]
            {
        // Flags (little-endian): 0x00, 0x00, 0x01, 0x00
        0x00, 0x00, 0x01, 0x00,
        // High
        0x00, 0x00, 0x00, 0x00,
        // Mid
        0x00, 0x00, 0x00, 0x00,
        // Low
        0x01, 0x00, 0x00, 0x00
            };
        
            BitArray bitArray = new BitArray(decimalBytes);
        
            decimal resultLSBLE = bitArray.ToDecimal(0, BitOrder.LSB, ByteOrder.LittleEndian);
            decimal resultMSBLE = bitArray.ToDecimal(0, BitOrder.MSB, ByteOrder.LittleEndian);
            decimal resultLSBBE = bitArray.ToDecimal(0, BitOrder.LSB, ByteOrder.BigEndian);
            decimal resultMSBBE = bitArray.ToDecimal(0, BitOrder.MSB, ByteOrder.BigEndian);
        
            Assert.AreEqual(65536, resultLSBLE, "(LSB & LE) Failed to convert BitArray to decimal.");
            Assert.AreEqual(8388608, resultMSBLE, "(MSB & LE) Failed to convert BitArray to decimal.");
            Assert.AreEqual(16777216, resultLSBBE, "(LSB & BE) Failed to convert BitArray to decimal.");
            Assert.AreEqual(2147483648, resultMSBBE, "(MSB & BE) Failed to convert BitArray to decimal.");
        }
    }
}