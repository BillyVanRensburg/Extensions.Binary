using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extensions.Binary;

namespace Extensions.Binary.Tests
{
    [TestClass]
    public class RandomNumberTest
    {
        public Random random = new Random();
        public int testAmount = 100;

        [TestMethod]
        public void ByteToBitArrayToByte()
        {
            for (int i = 0; i < testAmount; i++)
            {
                Byte randomValue = (byte)random.Next(byte.MinValue, byte.MaxValue);
                BitArray testValue = randomValue.ToBitArray();

                Assert.AreEqual(testValue.ToByte(), randomValue, "Failed to convert byte to BitArray and back to byte.");
            }
        }

        [TestMethod]
        public void SByteToBitArrayToSByte()
        {
            for (int i = 0; i < testAmount; i++)
            {
                sbyte randomValue = (sbyte)random.Next(byte.MinValue, byte.MaxValue);
                BitArray testValue = randomValue.ToBitArray();

                Assert.AreEqual(testValue.ToSByte(), randomValue, "Failed to convert sbyte to BitArray and back to sbyte.");
            }
        }

        [TestMethod]
        public void ShortToBitArrayToShort()
        {
            for (int i = 0; i < testAmount; i++)
            {
                short randomValue = (short)random.Next(short.MinValue, short.MaxValue);
                BitArray testValue = randomValue.ToBitArray();
                Assert.AreEqual(testValue.ToShort(), randomValue, "Failed to convert short to BitArray and back to short.");
            }
        }

        [TestMethod]
        public void UShortToBitArrayToUShort()
        {
            for (int i = 0; i < testAmount; i++)
            {
                ushort randomValue = (ushort)random.Next(ushort.MinValue, ushort.MaxValue);
                BitArray testValue = randomValue.ToBitArray();
                Assert.AreEqual(testValue.ToUShort(), randomValue, "Failed to convert ushort to BitArray and back to ushort.");
            }
        }

        [TestMethod]
        public void IntToBitArrayToInt()
        {
            for (int i = 0; i < testAmount; i++)
            {
                int randomValue = random.Next(int.MinValue, int.MaxValue);
                BitArray testValue = randomValue.ToBitArray();
                Assert.AreEqual(testValue.ToInt(), randomValue, "Failed to convert int to BitArray and back to int.");
            }
        }

        [TestMethod]
        public void UIntToBitArrayToUInt()
        {
            for (int i = 0; i < testAmount; i++)
            {
                uint randomValue = (uint)random.Next(int.MinValue, int.MaxValue);
                BitArray testValue = randomValue.ToBitArray();
                Assert.AreEqual(testValue.ToUInt(), randomValue, "Failed to convert uint to BitArray and back to uint.");
            }
        }

        [TestMethod]
        public void LongToBitArrayToLong()
        {
            for (int i = 0; i < testAmount; i++)
            {
                long randomValue = (long)random.Next(int.MinValue, int.MaxValue);
                BitArray testValue = randomValue.ToBitArray();
                Assert.AreEqual(testValue.ToLong(), randomValue, "Failed to convert long to BitArray and back to long.");
            }
        }

        [TestMethod]
        public void ULongToBitArrayToULong()
        {
            for (int i = 0; i < testAmount; i++)
            {
                ulong randomValue = (ulong)random.Next(int.MinValue, int.MaxValue);
                BitArray testValue = randomValue.ToBitArray();
                Assert.AreEqual(testValue.ToULong(), randomValue, "Failed to convert ulong to BitArray and back to ulong.");
            }
        }

        [TestMethod]
        public void Int128ToBitArrayToInt128()
        {
            for (int i = 0; i < testAmount; i++)
            {
                Int128 randomValue = (Int128)random.Next(int.MinValue, int.MaxValue);
                BitArray testValue = randomValue.ToBitArray();
                Assert.AreEqual(testValue.ToInt128(), randomValue, "Failed to convert ulong to BitArray and back to ulong.");
            }
        }

        [TestMethod]
        public void UInt128ToBitArrayToUInt128()
        {
            for (int i = 0; i < testAmount; i++)
            {
                UInt128 randomValue = (UInt128)random.Next(int.MinValue, int.MaxValue);
                BitArray testValue = randomValue.ToBitArray();
                Assert.AreEqual(testValue.ToUInt128(), randomValue, "Failed to convert ulong to BitArray and back to ulong.");
            }
        }

        [TestMethod]
        public void HalfToBitArrayHalf()
        {
            for (int i = 0; i < testAmount; i++)
            {
                Half randomValue = (Half)random.Next(int.MinValue, int.MaxValue);
                BitArray testValue = randomValue.ToBitArray();
                Assert.AreEqual(testValue.ToHalf(), randomValue, "Failed to convert ulong to BitArray and back to ulong.");
            }
        }

        [TestMethod]
        public void FloatToBitArrayToFloat()
        {
            for (int i = 0; i < testAmount; i++)
            {
                float randomValue = (float)random.Next(int.MinValue, int.MaxValue);
                BitArray testValue = randomValue.ToBitArray();
                Assert.AreEqual(testValue.ToFloat(), randomValue, "Failed to convert float to BitArray and back to float.");
            }
        }

        [TestMethod]
        public void DoubleToBitArrayToDouble()
        {
            for (int i = 0; i < testAmount; i++)
            {
                double randomValue = (double)random.Next(int.MinValue, int.MaxValue);
                BitArray testValue = randomValue.ToBitArray();
                Assert.AreEqual(testValue.ToDouble(), randomValue, "Failed to convert double to BitArray and back to double.");
            }
        }

        [TestMethod]
        public void DecimalToBitArrayToDecimal()
        {
            for (int i = 0; i < testAmount; i++)
            {
                decimal randomValue = (decimal)((Single)random.NextSingle() * (sbyte)random.Next(-128, 128));
                BitArray testValue = randomValue.ToBitArray();
                Assert.AreEqual(testValue.ToDecimal(), randomValue, "Failed to convert decimal to BitArray and back to decimal.");
            }
        }
    }
}
