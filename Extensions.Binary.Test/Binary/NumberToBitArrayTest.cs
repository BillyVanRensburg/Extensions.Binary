using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Binary.Tests
{
    [TestClass]
    public class NumberToBitArrayTest
    {
        [TestMethod]
        public void ByteToBitArray()
        {
            byte value = 0b_10110010; // 178

            // Expected: LSB first (default .NET BitArray behavior)
            bool[] expectedLSB = new bool[]
            {
        false, true, false, false, true, true, false, true // bit 0 to bit 7
            };

            // Expected: MSB first
            bool[] expectedMSB = new bool[]
            {
        true, false, true, true, false, false, true, false // bit 7 to bit 0
            };

            BitArray lsbBitArray = value.ToBitArray(BitOrder.LSB);
            BitArray msbBitArray = value.ToBitArray(BitOrder.MSB);

            // Compare LSB
            for (int i = 0; i < 8; i++)
                Assert.AreEqual(expectedLSB[i], lsbBitArray[i], $"LSB Bit mismatch at position {i}");

            // Compare MSB
            for (int i = 0; i < 8; i++)
                Assert.AreEqual(expectedMSB[i], msbBitArray[i], $"MSB Bit mismatch at position {i}");
        }

        [TestMethod]
        public void SByteToBitArray()
        {
            sbyte value = -86; // 0b10101010 in 2's complement = 170 (unsigned)

            // Expected: LSB first (Bit 0 to Bit 7)
            bool[] expectedLSB = new bool[]
            {
        false, true, false, true, false, true, false, true // bits of 0b10101010 reversed
            };

            // Expected: MSB first (Bit 7 to Bit 0)
            bool[] expectedMSB = new bool[]
            {
        true, false, true, false, true, false, true, false // 0b10101010 as-is
            };

            BitArray bitArrayLSB = value.ToBitArray(BitOrder.LSB);
            BitArray bitArrayMSB = value.ToBitArray(BitOrder.MSB);

            for (int i = 0; i < 8; i++)
            {
                Assert.AreEqual(expectedLSB[i], bitArrayLSB[i], $"LSB mismatch at bit {i}");
                Assert.AreEqual(expectedMSB[i], bitArrayMSB[i], $"MSB mismatch at bit {i}");
            }
        }

        [TestMethod]
        public void UShortToBitArray()
        {
            ushort value = 0x12AB; // 0001 0010 1010 1011
                                   // Bytes:
                                   // Little Endian: [0xAB, 0x12]
                                   // Big Endian:    [0x12, 0xAB]

            // Helper method to extract bits
            bool[] Bits(byte b, BitOrder order)
            {
                bool[] bits = new bool[8];
                for (int i = 0; i < 8; i++)
                    bits[i] = ((b >> (order == BitOrder.LSB ? i : (7 - i))) & 1) == 1;
                return bits;
            }

            // Expected arrays
            bool[] expectedLSBLE = Bits(0xAB, BitOrder.LSB).Concat(Bits(0x12, BitOrder.LSB)).ToArray();
            bool[] expectedMSBLE = Bits(0xAB, BitOrder.MSB).Concat(Bits(0x12, BitOrder.MSB)).ToArray();
            bool[] expectedLSBBE = Bits(0x12, BitOrder.LSB).Concat(Bits(0xAB, BitOrder.LSB)).ToArray();
            bool[] expectedMSBBE = Bits(0x12, BitOrder.MSB).Concat(Bits(0xAB, BitOrder.MSB)).ToArray();

            BitArray resultLSBLE = value.ToBitArray(BitOrder.LSB, ByteOrder.LittleEndian);
            BitArray resultMSBLE = value.ToBitArray(BitOrder.MSB, ByteOrder.LittleEndian);
            BitArray resultLSBBE = value.ToBitArray(BitOrder.LSB, ByteOrder.BigEndian);
            BitArray resultMSBBE = value.ToBitArray(BitOrder.MSB, ByteOrder.BigEndian);

            for (int i = 0; i < 16; i++)
            {
                Assert.AreEqual(expectedLSBLE[i], resultLSBLE[i], $"LSB & LE mismatch at bit {i}");
                Assert.AreEqual(expectedMSBLE[i], resultMSBLE[i], $"MSB & LE mismatch at bit {i}");
                Assert.AreEqual(expectedLSBBE[i], resultLSBBE[i], $"LSB & BE mismatch at bit {i}");
                Assert.AreEqual(expectedMSBBE[i], resultMSBBE[i], $"MSB & BE mismatch at bit {i}");
            }
        }

        [TestMethod]
        public void ShortToBitArray()
        {
            short value = -21930; // 0xAAAA in 2's complement = 0b1010101010101010
            ushort unsigned = unchecked((ushort)value); // 0xAAAA = 43690

            // Helper method to extract bits
            bool[] Bits(byte b, BitOrder order)
            {
                bool[] bits = new bool[8];
                for (int i = 0; i < 8; i++)
                    bits[i] = ((b >> (order == BitOrder.LSB ? i : (7 - i))) & 1) == 1;
                return bits;
            }

            // Extract segments
            byte low = (byte)(unsigned & 0xFF);        // 0xAA
            byte high = (byte)((unsigned >> 8) & 0xFF); // 0xAA

            // Build expected bit arrays for each combination
            bool[] expectedLSBLE = Bits(low, BitOrder.LSB).Concat(Bits(high, BitOrder.LSB)).ToArray();
            bool[] expectedMSBLE = Bits(low, BitOrder.MSB).Concat(Bits(high, BitOrder.MSB)).ToArray();
            bool[] expectedLSBBE = Bits(high, BitOrder.LSB).Concat(Bits(low, BitOrder.LSB)).ToArray();
            bool[] expectedMSBBE = Bits(high, BitOrder.MSB).Concat(Bits(low, BitOrder.MSB)).ToArray();

            // Invoke method
            BitArray resultLSBLE = value.ToBitArray(BitOrder.LSB, ByteOrder.LittleEndian);
            BitArray resultMSBLE = value.ToBitArray(BitOrder.MSB, ByteOrder.LittleEndian);
            BitArray resultLSBBE = value.ToBitArray(BitOrder.LSB, ByteOrder.BigEndian);
            BitArray resultMSBBE = value.ToBitArray(BitOrder.MSB, ByteOrder.BigEndian);

            // Assert all 16 bits
            for (int i = 0; i < 16; i++)
            {
                Assert.AreEqual(expectedLSBLE[i], resultLSBLE[i], $"LSB & LE mismatch at bit {i}");
                Assert.AreEqual(expectedMSBLE[i], resultMSBLE[i], $"MSB & LE mismatch at bit {i}");
                Assert.AreEqual(expectedLSBBE[i], resultLSBBE[i], $"LSB & BE mismatch at bit {i}");
                Assert.AreEqual(expectedMSBBE[i], resultMSBBE[i], $"MSB & BE mismatch at bit {i}");
            }
        }

        [TestMethod]
        public void UIntToBitArray()
        {
            uint value = 0x12345678; // Bytes: 0x78 0x56 0x34 0x12 (LE)

            // Helper to extract bits from a byte based on bit order
            bool[] Bits(byte b, BitOrder order)
            {
                bool[] bits = new bool[8];
                for (int i = 0; i < 8; i++)
                    bits[i] = ((b >> (order == BitOrder.LSB ? i : 7 - i)) & 1) == 1;
                return bits;
            }

            // Break into bytes
            byte a = (byte)(value);             // 0x78
            byte b = (byte)(value >> 8);        // 0x56
            byte c = (byte)(value >> 16);       // 0x34
            byte d = (byte)(value >> 24);       // 0x12

            // Create expected outputs
            bool[] expectedLSBLE = Bits(a, BitOrder.LSB)
                .Concat(Bits(b, BitOrder.LSB))
                .Concat(Bits(c, BitOrder.LSB))
                .Concat(Bits(d, BitOrder.LSB))
                .ToArray();

            bool[] expectedMSBLE = Bits(a, BitOrder.MSB)
                .Concat(Bits(b, BitOrder.MSB))
                .Concat(Bits(c, BitOrder.MSB))
                .Concat(Bits(d, BitOrder.MSB))
                .ToArray();

            bool[] expectedLSBBE = Bits(d, BitOrder.LSB)
                .Concat(Bits(c, BitOrder.LSB))
                .Concat(Bits(b, BitOrder.LSB))
                .Concat(Bits(a, BitOrder.LSB))
                .ToArray();

            bool[] expectedMSBBE = Bits(d, BitOrder.MSB)
                .Concat(Bits(c, BitOrder.MSB))
                .Concat(Bits(b, BitOrder.MSB))
                .Concat(Bits(a, BitOrder.MSB))
                .ToArray();

            // Call your method
            BitArray resultLSBLE = value.ToBitArray(BitOrder.LSB, ByteOrder.LittleEndian);
            BitArray resultMSBLE = value.ToBitArray(BitOrder.MSB, ByteOrder.LittleEndian);
            BitArray resultLSBBE = value.ToBitArray(BitOrder.LSB, ByteOrder.BigEndian);
            BitArray resultMSBBE = value.ToBitArray(BitOrder.MSB, ByteOrder.BigEndian);

            // Validate all 32 bits
            for (int i = 0; i < 32; i++)
            {
                Assert.AreEqual(expectedLSBLE[i], resultLSBLE[i], $"LSB & LE mismatch at bit {i}");
                Assert.AreEqual(expectedMSBLE[i], resultMSBLE[i], $"MSB & LE mismatch at bit {i}");
                Assert.AreEqual(expectedLSBBE[i], resultLSBBE[i], $"LSB & BE mismatch at bit {i}");
                Assert.AreEqual(expectedMSBBE[i], resultMSBBE[i], $"MSB & BE mismatch at bit {i}");
            }
        }

        [TestMethod]
        public void IntToBitArray()
        {
            int value = -559038737; // 0xDEADBEEF in 2's complement
            uint unsigned = unchecked((uint)value); // Treat as 0xDEADBEEF

            // Helper to extract bits from byte
            bool[] Bits(byte b, BitOrder order)
            {
                bool[] bits = new bool[8];
                for (int i = 0; i < 8; i++)
                    bits[i] = ((b >> (order == BitOrder.LSB ? i : 7 - i)) & 1) == 1;
                return bits;
            }

            // Extract bytes
            byte a = (byte)(unsigned);         // 0xEF
            byte b = (byte)(unsigned >> 8);    // 0xBE
            byte c = (byte)(unsigned >> 16);   // 0xAD
            byte d = (byte)(unsigned >> 24);   // 0xDE

            // Expected results for each combo
            bool[] expectedLSBLE = Bits(a, BitOrder.LSB)
                .Concat(Bits(b, BitOrder.LSB))
                .Concat(Bits(c, BitOrder.LSB))
                .Concat(Bits(d, BitOrder.LSB))
                .ToArray();

            bool[] expectedMSBLE = Bits(a, BitOrder.MSB)
                .Concat(Bits(b, BitOrder.MSB))
                .Concat(Bits(c, BitOrder.MSB))
                .Concat(Bits(d, BitOrder.MSB))
                .ToArray();

            bool[] expectedLSBBE = Bits(d, BitOrder.LSB)
                .Concat(Bits(c, BitOrder.LSB))
                .Concat(Bits(b, BitOrder.LSB))
                .Concat(Bits(a, BitOrder.LSB))
                .ToArray();

            bool[] expectedMSBBE = Bits(d, BitOrder.MSB)
                .Concat(Bits(c, BitOrder.MSB))
                .Concat(Bits(b, BitOrder.MSB))
                .Concat(Bits(a, BitOrder.MSB))
                .ToArray();

            // Call the method
            BitArray resultLSBLE = value.ToBitArray(BitOrder.LSB, ByteOrder.LittleEndian);
            BitArray resultMSBLE = value.ToBitArray(BitOrder.MSB, ByteOrder.LittleEndian);
            BitArray resultLSBBE = value.ToBitArray(BitOrder.LSB, ByteOrder.BigEndian);
            BitArray resultMSBBE = value.ToBitArray(BitOrder.MSB, ByteOrder.BigEndian);

            // Validate all 32 bits
            for (int i = 0; i < 32; i++)
            {
                Assert.AreEqual(expectedLSBLE[i], resultLSBLE[i], $"LSB & LE mismatch at bit {i}");
                Assert.AreEqual(expectedMSBLE[i], resultMSBLE[i], $"MSB & LE mismatch at bit {i}");
                Assert.AreEqual(expectedLSBBE[i], resultLSBBE[i], $"LSB & BE mismatch at bit {i}");
                Assert.AreEqual(expectedMSBBE[i], resultMSBBE[i], $"MSB & BE mismatch at bit {i}");
            }
        }

        [TestMethod]
        public void ULongToBitArray()
        {
            ulong value = 0x0123456789ABCDEF; // 8 bytes

            // Helper to get bits from a byte in a specified bit order
            bool[] Bits(byte b, BitOrder order)
            {
                bool[] bits = new bool[8];
                for (int i = 0; i < 8; i++)
                    bits[i] = ((b >> (order == BitOrder.LSB ? i : 7 - i)) & 1) == 1;
                return bits;
            }

            // Split into 8 bytes
            byte[] bytes = new byte[8];
            for (int i = 0; i < 8; i++)
                bytes[i] = (byte)(value >> (8 * i));

            // Little Endian
            bool[] expectedLSBLE = bytes.SelectMany(b => Bits(b, BitOrder.LSB)).ToArray();
            bool[] expectedMSBLE = bytes.SelectMany(b => Bits(b, BitOrder.MSB)).ToArray();

            // Big Endian (reverse byte order)
            bool[] expectedLSBBE = bytes.Reverse().SelectMany(b => Bits(b, BitOrder.LSB)).ToArray();
            bool[] expectedMSBBE = bytes.Reverse().SelectMany(b => Bits(b, BitOrder.MSB)).ToArray();

            // Call your method
            BitArray resultLSBLE = value.ToBitArray(BitOrder.LSB, ByteOrder.LittleEndian);
            BitArray resultMSBLE = value.ToBitArray(BitOrder.MSB, ByteOrder.LittleEndian);
            BitArray resultLSBBE = value.ToBitArray(BitOrder.LSB, ByteOrder.BigEndian);
            BitArray resultMSBBE = value.ToBitArray(BitOrder.MSB, ByteOrder.BigEndian);

            // Assert all 64 bits
            for (int i = 0; i < 64; i++)
            {
                Assert.AreEqual(expectedLSBLE[i], resultLSBLE[i], $"LSB & LE mismatch at bit {i}");
                Assert.AreEqual(expectedMSBLE[i], resultMSBLE[i], $"MSB & LE mismatch at bit {i}");
                Assert.AreEqual(expectedLSBBE[i], resultLSBBE[i], $"LSB & BE mismatch at bit {i}");
                Assert.AreEqual(expectedMSBBE[i], resultMSBBE[i], $"MSB & BE mismatch at bit {i}");
            }
        }

        [TestMethod]
        public void LongToBitArray()
        {
            long value = -81985529216486895; // In hex: 0xFEDCBA9876543211
            ulong unsigned = unchecked((ulong)value); // Reinterpret the bits

            // Helper: get bits from byte in given order
            bool[] Bits(byte b, BitOrder order)
            {
                bool[] bits = new bool[8];
                for (int i = 0; i < 8; i++)
                    bits[i] = ((b >> (order == BitOrder.LSB ? i : 7 - i)) & 1) == 1;
                return bits;
            }

            // Split into 8 bytes
            byte[] bytes = new byte[8];
            for (int i = 0; i < 8; i++)
                bytes[i] = (byte)(unsigned >> (8 * i));

            // Expected bits
            bool[] expectedLSBLE = bytes.SelectMany(b => Bits(b, BitOrder.LSB)).ToArray();
            bool[] expectedMSBLE = bytes.SelectMany(b => Bits(b, BitOrder.MSB)).ToArray();
            bool[] expectedLSBBE = bytes.Reverse().SelectMany(b => Bits(b, BitOrder.LSB)).ToArray();
            bool[] expectedMSBBE = bytes.Reverse().SelectMany(b => Bits(b, BitOrder.MSB)).ToArray();

            // Actual results from method
            BitArray resultLSBLE = value.ToBitArray(BitOrder.LSB, ByteOrder.LittleEndian);
            BitArray resultMSBLE = value.ToBitArray(BitOrder.MSB, ByteOrder.LittleEndian);
            BitArray resultLSBBE = value.ToBitArray(BitOrder.LSB, ByteOrder.BigEndian);
            BitArray resultMSBBE = value.ToBitArray(BitOrder.MSB, ByteOrder.BigEndian);

            // Compare all 64 bits
            for (int i = 0; i < 64; i++)
            {
                Assert.AreEqual(expectedLSBLE[i], resultLSBLE[i], $"LSB & LE mismatch at bit {i}");
                Assert.AreEqual(expectedMSBLE[i], resultMSBLE[i], $"MSB & LE mismatch at bit {i}");
                Assert.AreEqual(expectedLSBBE[i], resultLSBBE[i], $"LSB & BE mismatch at bit {i}");
                Assert.AreEqual(expectedMSBBE[i], resultMSBBE[i], $"MSB & BE mismatch at bit {i}");
            }
        }

        [TestMethod]
        public void UInt128ToBitArray()
        {
            // Example value: 0x0123456789ABCDEF_FEDCBA9876543210 (16 bytes)
            UInt128 value = UInt128.Parse("2419785720015125272896946542944005680");

            // Split into 16 bytes (little endian)
            byte[] bytesLE = new byte[16];
            UInt128 temp = value;
            for (int i = 0; i < 16; i++)
            {
                bytesLE[i] = (byte)(temp & 0xFF);
                temp >>= 8;
            }

            // Helper: Convert byte to bits
            bool[] Bits(byte b, BitOrder order)
            {
                bool[] bits = new bool[8];
                for (int i = 0; i < 8; i++)
                {
                    int bitIndex = (order == BitOrder.LSB) ? i : 7 - i;
                    bits[i] = ((b >> bitIndex) & 1) == 1;
                }
                return bits;
            }

            // Construct expected arrays
            bool[] expectedLSBLE = bytesLE.SelectMany(b => Bits(b, BitOrder.LSB)).ToArray();
            bool[] expectedMSBLE = bytesLE.SelectMany(b => Bits(b, BitOrder.MSB)).ToArray();
            bool[] expectedLSBBE = bytesLE.Reverse().SelectMany(b => Bits(b, BitOrder.LSB)).ToArray();
            bool[] expectedMSBBE = bytesLE.Reverse().SelectMany(b => Bits(b, BitOrder.MSB)).ToArray();

            // Actual results
            BitArray resultLSBLE = value.ToBitArray(BitOrder.LSB, ByteOrder.LittleEndian);
            BitArray resultMSBLE = value.ToBitArray(BitOrder.MSB, ByteOrder.LittleEndian);
            BitArray resultLSBBE = value.ToBitArray(BitOrder.LSB, ByteOrder.BigEndian);
            BitArray resultMSBBE = value.ToBitArray(BitOrder.MSB, ByteOrder.BigEndian);

            // Verify all bits
            for (int i = 0; i < 128; i++)
            {
                Assert.AreEqual(expectedLSBLE[i], resultLSBLE[i], $"LSB & LE mismatch at bit {i}");
                Assert.AreEqual(expectedMSBLE[i], resultMSBLE[i], $"MSB & LE mismatch at bit {i}");
                Assert.AreEqual(expectedLSBBE[i], resultLSBBE[i], $"LSB & BE mismatch at bit {i}");
                Assert.AreEqual(expectedMSBBE[i], resultMSBBE[i], $"MSB & BE mismatch at bit {i}");
            }
        }

        [TestMethod]
        public void Int128ToBitArray()
        {
            // Example signed 128-bit value: -0x0123456789ABCDEF_FEDCBA9876543210
            // Decimal: -2419785720015125272896946542944005680
            Int128 value = Int128.Parse("-2419785720015125272896946542944005680");

            // Convert to bytes (little endian 16 bytes)
            byte[] bytesLE = new byte[16];
            Int128 temp = value;
            for (int i = 0; i < 16; i++)
            {
                bytesLE[i] = (byte)(temp & 0xFF);
                temp >>= 8;
            }

            // Helper: Convert byte to bits
            bool[] Bits(byte b, BitOrder order)
            {
                bool[] bits = new bool[8];
                for (int i = 0; i < 8; i++)
                {
                    int bitIndex = (order == BitOrder.LSB) ? i : 7 - i;
                    bits[i] = ((b >> bitIndex) & 1) == 1;
                }
                return bits;
            }

            // Construct expected arrays
            bool[] expectedLSBLE = bytesLE.SelectMany(b => Bits(b, BitOrder.LSB)).ToArray();
            bool[] expectedMSBLE = bytesLE.SelectMany(b => Bits(b, BitOrder.MSB)).ToArray();
            bool[] expectedLSBBE = bytesLE.Reverse().SelectMany(b => Bits(b, BitOrder.LSB)).ToArray();
            bool[] expectedMSBBE = bytesLE.Reverse().SelectMany(b => Bits(b, BitOrder.MSB)).ToArray();

            // Actual results
            BitArray resultLSBLE = value.ToBitArray(BitOrder.LSB, ByteOrder.LittleEndian);
            BitArray resultMSBLE = value.ToBitArray(BitOrder.MSB, ByteOrder.LittleEndian);
            BitArray resultLSBBE = value.ToBitArray(BitOrder.LSB, ByteOrder.BigEndian);
            BitArray resultMSBBE = value.ToBitArray(BitOrder.MSB, ByteOrder.BigEndian);

            // Verify all bits
            for (int i = 0; i < 128; i++)
            {
                Assert.AreEqual(expectedLSBLE[i], resultLSBLE[i], $"LSB & LE mismatch at bit {i}");
                Assert.AreEqual(expectedMSBLE[i], resultMSBLE[i], $"MSB & LE mismatch at bit {i}");
                Assert.AreEqual(expectedLSBBE[i], resultLSBBE[i], $"LSB & BE mismatch at bit {i}");
                Assert.AreEqual(expectedMSBBE[i], resultMSBBE[i], $"MSB & BE mismatch at bit {i}");
            }
        }

        [TestMethod]
        public void HalfToBitArray()
        {
            // Half precision float value: 1.5
            Half value = (Half)1.5;

            ushort rawBits = BitConverter.HalfToUInt16Bits(value);
            byte lowByte = (byte)(rawBits & 0xFF);
            byte highByte = (byte)(rawBits >> 8);

            // Helper to convert byte to bool[]
            bool[] Bits(byte b, BitOrder order)
            {
                bool[] bits = new bool[8];
                for (int i = 0; i < 8; i++)
                {
                    int bitIndex = (order == BitOrder.LSB) ? i : 7 - i;
                    bits[i] = ((b >> bitIndex) & 1) == 1;
                }
                return bits;
            }

            // Expected bits in all formats
            bool[] expectedLSBLE = Bits(lowByte, BitOrder.LSB).Concat(Bits(highByte, BitOrder.LSB)).ToArray();
            bool[] expectedMSBLE = Bits(lowByte, BitOrder.MSB).Concat(Bits(highByte, BitOrder.MSB)).ToArray();
            bool[] expectedLSBBE = Bits(highByte, BitOrder.LSB).Concat(Bits(lowByte, BitOrder.LSB)).ToArray();
            bool[] expectedMSBBE = Bits(highByte, BitOrder.MSB).Concat(Bits(lowByte, BitOrder.MSB)).ToArray();

            // Actual conversions
            BitArray resultLSBLE = value.ToBitArray(BitOrder.LSB, ByteOrder.LittleEndian);
            BitArray resultMSBLE = value.ToBitArray(BitOrder.MSB, ByteOrder.LittleEndian);
            BitArray resultLSBBE = value.ToBitArray(BitOrder.LSB, ByteOrder.BigEndian);
            BitArray resultMSBBE = value.ToBitArray(BitOrder.MSB, ByteOrder.BigEndian);

            // Assertions
            for (int i = 0; i < 16; i++)
            {
                Assert.AreEqual(expectedLSBLE[i], resultLSBLE[i], $"LSB & LE mismatch at bit {i}");
                Assert.AreEqual(expectedMSBLE[i], resultMSBLE[i], $"MSB & LE mismatch at bit {i}");
                Assert.AreEqual(expectedLSBBE[i], resultLSBBE[i], $"LSB & BE mismatch at bit {i}");
                Assert.AreEqual(expectedMSBBE[i], resultMSBBE[i], $"MSB & BE mismatch at bit {i}");
            }
        }

        [TestMethod]
        public void FloatToBitArray()
        {
            float value = 123.625f;

            byte[] bytesLE = BitConverter.GetBytes(value);  // Little-endian system
            byte[] bytesBE = (byte[])bytesLE.Clone();
            Array.Reverse(bytesBE);

            // Helper to extract bits from byte
            bool[] Bits(byte b, BitOrder order)
            {
                bool[] bits = new bool[8];
                for (int i = 0; i < 8; i++)
                {
                    int bitIndex = order == BitOrder.LSB ? i : 7 - i;
                    bits[i] = ((b >> bitIndex) & 1) == 1;
                }
                return bits;
            }

            // Expected bit sequences
            bool[] expectedLSBLE = bytesLE.SelectMany(b => Bits(b, BitOrder.LSB)).ToArray();
            bool[] expectedMSBLE = bytesLE.SelectMany(b => Bits(b, BitOrder.MSB)).ToArray();
            bool[] expectedLSBBE = bytesBE.SelectMany(b => Bits(b, BitOrder.LSB)).ToArray();
            bool[] expectedMSBBE = bytesBE.SelectMany(b => Bits(b, BitOrder.MSB)).ToArray();

            // Actual results
            BitArray resultLSBLE = value.ToBitArray(BitOrder.LSB, ByteOrder.LittleEndian);
            BitArray resultMSBLE = value.ToBitArray(BitOrder.MSB, ByteOrder.LittleEndian);
            BitArray resultLSBBE = value.ToBitArray(BitOrder.LSB, ByteOrder.BigEndian);
            BitArray resultMSBBE = value.ToBitArray(BitOrder.MSB, ByteOrder.BigEndian);

            // Verify all 32 bits
            for (int i = 0; i < 32; i++)
            {
                Assert.AreEqual(expectedLSBLE[i], resultLSBLE[i], $"LSB & LE mismatch at bit {i}");
                Assert.AreEqual(expectedMSBLE[i], resultMSBLE[i], $"MSB & LE mismatch at bit {i}");
                Assert.AreEqual(expectedLSBBE[i], resultLSBBE[i], $"LSB & BE mismatch at bit {i}");
                Assert.AreEqual(expectedMSBBE[i], resultMSBBE[i], $"MSB & BE mismatch at bit {i}");
            }
        }

        [TestMethod]
        public void DoubleToBitArray()
        {
            double value = 12345.6789;

            byte[] bytesLE = BitConverter.GetBytes(value);  // Usually little-endian
            byte[] bytesBE = (byte[])bytesLE.Clone();
            Array.Reverse(bytesBE);

            // Helper to convert a byte to bool[] in given bit order
            bool[] Bits(byte b, BitOrder order)
            {
                bool[] bits = new bool[8];
                for (int i = 0; i < 8; i++)
                {
                    int bitIndex = order == BitOrder.LSB ? i : 7 - i;
                    bits[i] = ((b >> bitIndex) & 1) == 1;
                }
                return bits;
            }

            // Expected 64 bits
            bool[] expectedLSBLE = bytesLE.SelectMany(b => Bits(b, BitOrder.LSB)).ToArray();
            bool[] expectedMSBLE = bytesLE.SelectMany(b => Bits(b, BitOrder.MSB)).ToArray();
            bool[] expectedLSBBE = bytesBE.SelectMany(b => Bits(b, BitOrder.LSB)).ToArray();
            bool[] expectedMSBBE = bytesBE.SelectMany(b => Bits(b, BitOrder.MSB)).ToArray();

            // Actual results
            BitArray resultLSBLE = value.ToBitArray(BitOrder.LSB, ByteOrder.LittleEndian);
            BitArray resultMSBLE = value.ToBitArray(BitOrder.MSB, ByteOrder.LittleEndian);
            BitArray resultLSBBE = value.ToBitArray(BitOrder.LSB, ByteOrder.BigEndian);
            BitArray resultMSBBE = value.ToBitArray(BitOrder.MSB, ByteOrder.BigEndian);

            for (int i = 0; i < 64; i++)
            {
                Assert.AreEqual(expectedLSBLE[i], resultLSBLE[i], $"LSB & LE mismatch at bit {i}");
                Assert.AreEqual(expectedMSBLE[i], resultMSBLE[i], $"MSB & LE mismatch at bit {i}");
                Assert.AreEqual(expectedLSBBE[i], resultLSBBE[i], $"LSB & BE mismatch at bit {i}");
                Assert.AreEqual(expectedMSBBE[i], resultMSBBE[i], $"MSB & BE mismatch at bit {i}");
            }
        }

        [TestMethod]
        public void DecimalToBitArray()
        {
            decimal value = 123456.789m;

            // Expected bit arrays 
            BitArray expectedLSBLE = new BitArray(new bool[] { 
                true, false, true, false, true, false, false, false, 
                true, false, true, true, false, false, true, true,
                true, true, false, true, true, false, true, false,
                true, true, true, false, false, false,false,false,
                false, false, false, false, false, false,false,false,
                false, false, false, false, false, false,false,false,
                false, false, false, false, false, false,false,false,
                false, false, false, false, false, false,false,false,
                false, false, false, false, false, false,false,false,
                false, false, false, false, false, false,false,false,
                false, false, false, false, false, false,false,false,
                false, false, false, false, false, false,false,false,
                false, false, false, false, false, false,false,false,
                false, false, false, false, false, false,false,false,
                true, true, false, false, false, false,false,false,
                false, false, false, false, false, false,false,false });

            BitArray expectedMSBLE = new BitArray(new bool[] {
                false, false, false, true, false, true, false, true,
                true, true, false, false, true, true, false, true,
                false, true, false, true, true, false, true, true,
                false, false, false, false, false, true, true, true,
                false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, true, true,
                false, false, false, false, false, false, false, false });

            BitArray expectedLSBBE = new BitArray(new bool[] {
                false, false, false, false, false, false,false,false,
                true, true, false, false, false, false,false,false,
                false, false, false, false, false, false,false,false,
                false, false, false, false, false, false,false,false,
                false, false, false, false, false, false,false,false,
                false, false, false, false, false, false,false,false,
                false, false, false, false, false, false,false,false,
                false, false, false, false, false, false,false,false,
                false, false, false, false, false, false,false,false,
                false, false, false, false, false, false,false,false,
                false, false, false, false, false, false,false,false,
                false, false, false, false, false, false,false,false,
                true, true, true, false, false, false,false,false,
                true, true, false, true, true, false, true, false,
                true, false, true, true, false, false, true, true,
                true, false, true, false, true, false, false, false });

            BitArray expectedMSBBE = new BitArray(new bool[] {
                false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, true, true,
                false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false,
                false, false, false, false, false, true, true, true,
                false, true, false, true, true, false, true, true,
                true, true, false, false, true, true, false, true,
                false, false, false, true, false, true, false, true,
            });

            // Actual results
            BitArray resultLSBLE = value.ToBitArray(BitOrder.LSB, ByteOrder.LittleEndian);
            BitArray resultMSBLE = value.ToBitArray(BitOrder.MSB, ByteOrder.LittleEndian);
            BitArray resultLSBBE = value.ToBitArray(BitOrder.LSB, ByteOrder.BigEndian);
            BitArray resultMSBBE = value.ToBitArray(BitOrder.MSB, ByteOrder.BigEndian);
        
            for (int i = 0; i < 128; i++)
            {
                Assert.AreEqual(expectedLSBLE[i], resultLSBLE[i], $"LSB & LE mismatch at bit {i}");
                Assert.AreEqual(expectedMSBLE[i], resultMSBLE[i], $"MSB & LE mismatch at bit {i}");
                Assert.AreEqual(expectedLSBBE[i], resultLSBBE[i], $"LSB & BE mismatch at bit {i}");
                Assert.AreEqual(expectedMSBBE[i], resultMSBBE[i], $"MSB & BE mismatch at bit {i}");
            }
        }

    }
}
