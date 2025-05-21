using Extensions.Binary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Binary.Tests
{
    /// <summary>
    /// Test convertion of BitArray to numbers
    /// </summary>
    [TestClass]
    public class BitArrayToNumberTest
    {
        /// <summary>
        /// BitArray to Byte test
        /// </summary>
        /// <remarks>
        /// * Tests least significant bit order
        /// * Tests most significant bit order
        /// * Tests from diffferent start indexes
        /// * Tests start index is out of range exception
        /// * Tests invalid amount of bits exception
        /// </remarks>
        [TestMethod]
        public void BitArrayToByte()
        {
            BitArray bitArray = new BitArray(new bool[] 
            { 
                false, true, false, true, false, true, false, true, 
                false, true 
            });

            Assert.AreEqual
            (
                170, 
                bitArray.ToByte(0, BitOrder.LSB), 
                "(LSB) Failed to convert BitArray to byte from index 0."
            );

            Assert.AreEqual
            (
                85, 
                bitArray.ToByte(0, BitOrder.MSB), 
                "(MSB) Failed to convert BitArray to byte from index 0."
            );

            Assert.AreEqual
            (
                85, 
                bitArray.ToByte(1, BitOrder.LSB), 
                "(LSB) Failed to convert BitArray to byte from index 1."
            );

            Assert.AreEqual
            (
                170, 
                bitArray.ToByte(1, BitOrder.MSB), 
                "(MSB) Failed to convert BitArray to byte from index 1."
            );

            Assert.AreEqual
            (
                170, 
                bitArray.ToByte(2, BitOrder.LSB), 
                "(LSB) Failed to convert BitArray to byte from index 2."
            );

            Assert.AreEqual
            (
                85, 
                bitArray.ToByte(2, BitOrder.MSB), 
                "(MSB) Failed to convert BitArray to byte from index 2."
            );

            try
            {
                bitArray.ToByte(300);
                Assert.Fail("Start index out of range exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Start index is out of range. (Parameter 'startIndex') (Parameter 'startIndex')", ex.Message);
            }

            try
            {
                bitArray.ToByte(3);
                Assert.Fail("Invalid amount of bits left over exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Not enough bits remaining in the BitArray to retrieve data.", ex.Message);
            }
        }

        /// <summary>
        /// BitArray to SByte test
        /// </summary>
        /// <remarks>
        /// * Tests least significant bit order
        /// * Tests most significant bit order
        /// * Tests from diffferent start indexes
        /// * Tests start index is out of range exception
        /// * Tests invalid amount of bits exception
        /// </remarks>
        [TestMethod]
        public void BitArrayToSByte()
        {
            BitArray bitArray = new BitArray(new bool[] 
            { 
                false, true, false, true, false, true, false, true ,
                false, true 
            });

            Assert.AreEqual
            (
                -86, 
                bitArray.ToSByte(0, BitOrder.LSB), 
                "(LSB) Failed to convert BitArray to sbyte from index 0."
            );

            Assert.AreEqual
            (
                85, 
                bitArray.ToSByte(0, BitOrder.MSB), 
                "(MSB) Failed to convert BitArray to sbyte from index 0."
            );

            Assert.AreEqual
            (
                85, 
                bitArray.ToSByte(1, BitOrder.LSB), 
                "(LSB) Failed to convert BitArray to sbyte from index 1."
            );

            Assert.AreEqual
            (
                -86, 
                bitArray.ToSByte(1, BitOrder.MSB), 
                "(MSB) Failed to convert BitArray to sbyte from index 1."
            );

            Assert.AreEqual
            (
                -86, 
                bitArray.ToSByte(2, BitOrder.LSB), 
                "(LSB) Failed to convert BitArray to sbyte from index 2."
            );

            Assert.AreEqual
            (
                85, 
                bitArray.ToSByte(2, BitOrder.MSB), 
                "(MSB) Failed to convert BitArray to sbyte from index 2."
            );

            try
            {
                bitArray.ToSByte(300);
                Assert.Fail("Start index out of range exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Start index is out of range. (Parameter 'startIndex') (Parameter 'startIndex') (Parameter 'startIndex')", ex.Message);
            }

            try
            {
                bitArray.ToSByte(3);
                Assert.Fail("Invalid amount of bits left over exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Not enough bits remaining in the BitArray to retrieve data.", ex.Message);
            }
        }

        /// <summary>
        /// BitArray to Short test
        /// </summary>
        /// <remarks>
        /// * Tests least significant bit order
        /// * Tests most significant bit order
        /// * Tests little endian byte order
        /// * Tests big endian byte order
        /// * Tests from diffferent start indexes
        /// * Tests start index is out of range exception
        /// * Tests invalid amount of bits exception
        /// </remarks>
        [TestMethod]
        public void BitArrayToShort()
        {
            BitArray bitArray = new BitArray(new bool[] 
            { 
                false, true, false, true, false, true, false, true, 
                true, false, true, false, true, false, true, false, 
                true, false 
            });

            Assert.AreEqual
            (
                21930, 
                bitArray.ToShort(0, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to short from index 0."
            );

            Assert.AreEqual
            (
                -21931, 
                bitArray.ToShort(0, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to short from index 0."
            );

            Assert.AreEqual
            (
                -21931, 
                bitArray.ToShort(0, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to short from index 0."
            );

            Assert.AreEqual
            (
                21930, 
                bitArray.ToShort(0, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to short from index 0."
            );

            Assert.AreEqual
            (
                -21803, 
                bitArray.ToShort(1, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to short from index 1."
            );

            Assert.AreEqual
            (
                21931, 
                bitArray.ToShort(1, BitOrder.MSB, 
                ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to short from index 1."
            );

            Assert.AreEqual
            (
                -10838, 
                bitArray.ToShort(1, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to short from index 1."
            );

            Assert.AreEqual
            (
                -21675, 
                bitArray.ToShort(1, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to short from index 1."
            );

            Assert.AreEqual
            (
                21866, 
                bitArray.ToShort(2, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to short from index 2."
            );

            Assert.AreEqual
            (
                -21930, 
                bitArray.ToShort(2, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to short from index 2."
            );

            Assert.AreEqual
            (
                27221, 
                bitArray.ToShort(2, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to short from index 2."
            );

            Assert.AreEqual
            (
                22186, 
                bitArray.ToShort(2, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to short from index 2."
            );

            try
            {
                bitArray.ToShort(300);
                Assert.Fail("Start index out of range exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Start index is out of range. (Parameter 'startIndex') (Parameter 'startIndex') (Parameter 'startIndex')", ex.Message);
            }

            try
            {
                bitArray.ToShort(3);
                Assert.Fail("Invalid amount of bits left over exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Not enough bits remaining in the BitArray to retrieve data.", ex.Message);
            }
        }

        /// <summary>
        /// BitArray to UShort test
        /// </summary>
        /// <remarks>
        /// * Tests least significant bit order
        /// * Tests most significant bit order
        /// * Tests little endian byte order
        /// * Tests big endian byte order
        /// * Tests from diffferent start indexes
        /// * Tests start index is out of range exception
        /// * Tests invalid amount of bits exception
        /// </remarks>
        [TestMethod]
        public void BitArrayToUShort()
        {
            BitArray bitArray = new BitArray(new bool[] 
            { 
                false, true, false, true, false, true, false, true, 
                true, false, true, false, true, false, true, false,
                true, false 
            });

            Assert.AreEqual
            (
                21930, 
                bitArray.ToUShort(0, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to short from index 0."
            );

            Assert.AreEqual
            (
                43605, 
                bitArray.ToUShort(0, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to short from index 0."
            );

            Assert.AreEqual
            (
                43605, 
                bitArray.ToUShort(0, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to short from index 0."
            );

            Assert.AreEqual
            (
                21930, 
                bitArray.ToUShort(0, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to short from index 0."
            );

            Assert.AreEqual
            (
                43733, 
                bitArray.ToUShort(1, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to short from index 1."
            );
            
            Assert.AreEqual
            (
                21931, 
                bitArray.ToUShort(1, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to short from index 1."
            );
            
            Assert.AreEqual
            (
                54698, 
                bitArray.ToUShort(1, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to short from index 1."
            );
            
            Assert.AreEqual
            (
                43861, 
                bitArray.ToUShort(1, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to short from index 1."
            );

            Assert.AreEqual
            (
                21866, 
                bitArray.ToUShort(2, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to short from index 2."
            );
            
            Assert.AreEqual
            (
                43606, 
                bitArray.ToUShort(2, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to short from index 2."
            );
            
            Assert.AreEqual
            (
                27221, 
                bitArray.ToUShort(2, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to short from index 2."
            );
            
            Assert.AreEqual
            (
                22186, 
                bitArray.ToUShort(2, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to short from index 2."
            );

            try
            {
                bitArray.ToUShort(300);
                Assert.Fail("Start index out of range exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Start index is out of range. (Parameter 'startIndex') (Parameter 'startIndex')", ex.Message);
            }

            try
            {
                bitArray.ToUShort(3);
                Assert.Fail("Invalid amount of bits left over exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Not enough bits remaining in the BitArray to retrieve data.", ex.Message);
            }
        }

        /// <summary>
        /// BitArray to Int test
        /// </summary>
        /// <remarks>
        /// * Tests least significant bit order
        /// * Tests most significant bit order
        /// * Tests little endian byte order
        /// * Tests big endian byte order
        /// * Tests from diffferent start indexes
        /// * Tests start index is out of range exception
        /// * Tests invalid amount of bits exception
        /// </remarks>
        [TestMethod]
        public void BitArrayToInt()
        {
            BitArray bitArray = new BitArray(new[]
            {
                false, true, false, true, false, true, false, true,
                true, false, true, false, true, false, true, false,
                false, true, false, true, false, true, false, true,
                true, false, true, false, true, false, true, false,
                true, false
            });

            Assert.AreEqual
            (
                1437226410, 
                bitArray.ToInt(0, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to int from index 0."
            );
            
            Assert.AreEqual
            (
                -1437226411, 
                bitArray.ToInt(0, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to int from index 0."
            );
            
            Assert.AreEqual
            (
                -1437226411, 
                bitArray.ToInt(0, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to int from index 0."
            );
            
            Assert.AreEqual
            (
                1437226410, 
                bitArray.ToInt(0, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to int from index 0."
            );

            Assert.AreEqual
            (
                -1428870443, 
                bitArray.ToInt(1, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to int from index 1."
            );
            
            Assert.AreEqual
            (
                1437291691, 
                bitArray.ToInt(1, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to int from index 1."
            );
            
            Assert.AreEqual
            (
                -718613078, 
                bitArray.ToInt(1, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to int from index 1."
            );
            
            Assert.AreEqual
            (
                -1420514475, 
                bitArray.ToInt(1, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to int from index 1."
            );

            Assert.AreEqual
            (
                1433048426, 
                bitArray.ToInt(2, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to int from index 2."
            );
            
            Assert.AreEqual
            (
                -1437161130, 
                bitArray.ToInt(2, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to int from index 2."
            );
            
            Assert.AreEqual
            (
                1788176981, 
                bitArray.ToInt(2, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to int from index 2."
            );
            
            Assert.AreEqual
            (
                1453938346, 
                bitArray.ToInt(2, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to int from index 2."
            );

            try
            {
                bitArray.ToInt(300);
                Assert.Fail("Start index out of range exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Start index is out of range. (Parameter 'startIndex') (Parameter 'startIndex') (Parameter 'startIndex')", ex.Message);
            }

            try
            {
                bitArray.ToInt(3);
                Assert.Fail("Invalid amount of bits left over exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Not enough bits remaining in the BitArray to retrieve data.", ex.Message);
            }
        }

        /// <summary>
        /// BitArray to UInt test
        /// </summary>
        /// <remarks>
        /// * Tests least significant bit order
        /// * Tests most significant bit order
        /// * Tests little endian byte order
        /// * Tests big endian byte order
        /// * Tests from diffferent start indexes
        /// * Tests start index is out of range exception
        /// * Tests invalid amount of bits exception
        /// </remarks>
        [TestMethod]
        public void BitArrayToUInt()
        {
            BitArray bitArray = new BitArray(new[]
            {
                false, true, false, true, false, true, false, true,
                true, false, true, false, true, false, true, false,
                false, true, false, true, false, true, false, true,
                true, false, true, false, true, false, true, false,
                true, false
            });

            Assert.AreEqual
            (
                1437226410U, 
                bitArray.ToUInt(0, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to uint from index 0."
            );
            
            Assert.AreEqual
            (
                2857740885U, 
                bitArray.ToUInt(0, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to uint from index 0."
            );
            
            Assert.AreEqual
            (
                2857740885U, 
                bitArray.ToUInt(0, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to uint from index 0."
            );
            
            Assert.AreEqual
            (
                1437226410U, 
                bitArray.ToUInt(0, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to uint from index 0."
            );

            Assert.AreEqual
            (
                2866096853U, 
                bitArray.ToUInt(1, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to uint from index 1."
            );
            
            Assert.AreEqual
            (
                1437291691U, 
                bitArray.ToUInt(1, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to uint from index 1."
            );
            
            Assert.AreEqual
            (
                3576354218U, 
                bitArray.ToUInt(1, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to uint from index 1."
            );
            
            Assert.AreEqual
            (
                2874452821U, 
                bitArray.ToUInt(1, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to uint from index 1."
            );

            Assert.AreEqual
            (
                1433048426U, 
                bitArray.ToUInt(2, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to uint from index 2."
            );
            
            Assert.AreEqual
            (
                2857806166U, 
                bitArray.ToUInt(2, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to uint from index 2."
            );
            
            Assert.AreEqual
            (
                1788176981U, 
                bitArray.ToUInt(2, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to uint from index 2."
            );
            
            Assert.AreEqual
            (
                1453938346U, 
                bitArray.ToUInt(2, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to uint from index 2."
            );

            try
            {
                bitArray.ToUInt(300);
                Assert.Fail("Start index out of range exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Start index is out of range. (Parameter 'startIndex') (Parameter 'startIndex')", ex.Message);
            }

            try
            {
                bitArray.ToUInt(3);
                Assert.Fail("Invalid amount of bits left over exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Not enough bits remaining in the BitArray to retrieve data.", ex.Message);
            }
        }

        /// <summary>
        /// BitArray to Long test
        /// </summary>
        /// <remarks>
        /// * Tests least significant bit order
        /// * Tests most significant bit order
        /// * Tests little endian byte order
        /// * Tests big endian byte order
        /// * Tests from diffferent start indexes
        /// * Tests start index is out of range exception
        /// * Tests invalid amount of bits exception
        /// </remarks>
        [TestMethod]
        public void BitArrayToLong()
        {
            BitArray bitArray = new BitArray(new[]
            {
                false, true, false, true, false, true, false, true,
                true, false, true, false, true, false, true, false,
                false, true, false, true, false, true, false, true,
                true, false, true, false, true, false, true, false,
                false, true, false, true, false, true, false, true,
                true, false, true, false, true, false, true, false,
                false, true, false, true, false, true, false, true,
                true, false, true, false, true, false, true, false,
                true, false
            });

            Assert.AreEqual
            (
                6172840429334713770, 
                bitArray.ToLong(0, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to long from index 0."
            );
            
            Assert.AreEqual
            (
                -6172840429334713771, 
                bitArray.ToLong(0, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to long from index 0."
            );
            
            Assert.AreEqual
            (
                -6172840429334713771, 
                bitArray.ToLong(0, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to long from index 0."
            );
            
            Assert.AreEqual
            (
                6172840429334713770, 
                bitArray.ToLong(0, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to long from index 0."
            );

            Assert.AreEqual
            (
                -6136951822187418923, 
                bitArray.ToLong(1, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to long from index 1."
            );
            
            Assert.AreEqual
            (
                6173120809078052011, 
                bitArray.ToLong(1, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to long from index 1."
            );
            
            Assert.AreEqual
            (
                -3086420214667356758, 
                bitArray.ToLong(1, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to long from index 1."
            );
            
            Assert.AreEqual
            (
                -6101063215040124075, 
                bitArray.ToLong(1, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to long from index 1."
            );

            Assert.AreEqual
            (
                6154896125761066346, 
                bitArray.ToLong(2, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to long from index 2."
            );
            
            Assert.AreEqual
            (
                -6172560049591375530, 
                bitArray.ToLong(2, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to long from index 2."
            );
            
            Assert.AreEqual
            (
                7680161929521097301, 
                bitArray.ToLong(2, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to long from index 2."
            );
            
            Assert.AreEqual
            (
                6244617643629303466, 
                bitArray.ToLong(2, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to long from index 2."
            );

            try
            {
                bitArray.ToLong(300);
                Assert.Fail("Start index out of range exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Start index is out of range. (Parameter 'startIndex') (Parameter 'startIndex') (Parameter 'startIndex')", ex.Message);
            }

            try
            {
                bitArray.ToLong(3);
                Assert.Fail("Invalid amount of bits left over exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Not enough bits remaining in the BitArray to retrieve data.", ex.Message);
            }
        }

        /// <summary>
        /// BitArray to ULong test
        /// </summary>
        /// <remarks>
        /// * Tests least significant bit order
        /// * Tests most significant bit order
        /// * Tests little endian byte order
        /// * Tests big endian byte order
        /// * Tests from diffferent start indexes
        /// * Tests start index is out of range exception
        /// * Tests invalid amount of bits exception
        /// </remarks>
        [TestMethod]
        public void BitArrayToULong()
        {
            BitArray bitArray = new BitArray(new[]
            {
                false, true, false, true, false, true, false, true,
                true, false, true, false, true, false, true, false,
                false, true, false, true, false, true, false, true,
                true, false, true, false, true, false, true, false,
                false, true, false, true, false, true, false, true,
                true, false, true, false, true, false, true, false,
                false, true, false, true, false, true, false, true,
                true, false, true, false, true, false, true, false,
                true, false
            });

            Assert.AreEqual
            (
                6172840429334713770UL, 
                bitArray.ToULong(0, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to ulong from index 0."
            );
            
            Assert.AreEqual
            (
                12273903644374837845UL, 
                bitArray.ToULong(0, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to ulong from index 0."
            );
            
            Assert.AreEqual
            (
                12273903644374837845UL, 
                bitArray.ToULong(0, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to ulong from index 0."
            );
            
            Assert.AreEqual
            (
                6172840429334713770UL, 
                bitArray.ToULong(0, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to ulong from index 0."
            );

            Assert.AreEqual
            (
                12309792251522132693UL, 
                bitArray.ToULong(1, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to ulong from index 1."
            );
            
            Assert.AreEqual
            (
                6173120809078052011UL, 
                bitArray.ToULong(1, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to ulong from index 1."
            );
            
            Assert.AreEqual
            (
                15360323859042194858UL, 
                bitArray.ToULong(1, BitOrder.LSB, ByteOrder.BigEndian),
                "(LSB & BE) Failed to convert BitArray to ulong from index 1."
            );
            
            Assert.AreEqual
            (
                12345680858669427541UL, 
                bitArray.ToULong(1, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to ulong from index 1."
            );

            Assert.AreEqual
            (
                6154896125761066346UL, 
                bitArray.ToULong(2, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to ulong from index 2."
            );
            
            Assert.AreEqual
            (
                12274184024118176086UL, 
                bitArray.ToULong(2, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to ulong from index 2."
            );
            
            Assert.AreEqual
            (
                7680161929521097301UL, 
                bitArray.ToULong(2, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to ulong from index 2."
            );
            
            Assert.AreEqual
            (
                6244617643629303466UL, 
                bitArray.ToULong(2, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to ulong from index 2."
            );

            try
            {
                bitArray.ToULong(300);
                Assert.Fail("Start index out of range exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Start index is out of range. (Parameter 'startIndex') (Parameter 'startIndex')", ex.Message);
            }

            try
            {
                bitArray.ToULong(3);
                Assert.Fail("Invalid amount of bits left over exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Not enough bits remaining in the BitArray to retrieve data.", ex.Message);
            }
        }

        /// <summary>
        /// BitArray to Int128 test
        /// </summary>
        /// <remarks>
        /// * Tests least significant bit order
        /// * Tests most significant bit order
        /// * Tests little endian byte order
        /// * Tests big endian byte order
        /// * Tests from diffferent start indexes
        /// * Tests start index is out of range exception
        /// * Tests invalid amount of bits exception
        /// </remarks>
        [TestMethod]
        public void BitArrayToInt128()
        {
            BitArray bitArray = new BitArray(new[]
            {
                false, true, false, true, false, true, false, true,
                true, false, true, false, true, false, true, false,
                false, true, false, true, false, true, false, true,
                true, false, true, false, true, false, true, false,
                false, true, false, true, false, true, false, true,
                true, false, true, false, true, false, true, false,
                false, true, false, true, false, true, false, true,
                true, false, true, false, true, false, true, false,
                false, true, false, true, false, true, false, true,
                true, false, true, false, true, false, true, false,
                false, true, false, true, false, true, false, true,
                true, false, true, false, true, false, true, false,
                false, true, false, true, false, true, false, true,
                true, false, true, false, true, false, true, false,
                false, true, false, true, false, true, false, true,
                true, false, true, false, true, false, true, false,
                true, false
            });

            Assert.AreEqual
            (
                Int128.Parse("113868807607784855478016405599735666090"), 
                bitArray.ToInt128(0, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to Int128 from index 0."
            );
            
            Assert.AreEqual
            (
                Int128.Parse("-113868807607784855478016405599735666091"), 
                bitArray.ToInt128(0, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to Int128 from index 0."
            );
            
            Assert.AreEqual
            (
                Int128.Parse("-113868807607784855478016405599735666091"), 
                bitArray.ToInt128(0, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to Int128 from index 0."
            );
            
            Assert.AreEqual
            (
                Int128.Parse("113868807607784855478016405599735666090"), 
                bitArray.ToInt128(0, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to Int128 from index 0."
            );

            Assert.AreEqual
            (
                Int128.Parse("-113206779656576803992679100916016272683"), 
                bitArray.ToInt128(1, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to Int128 from index 1."
            );
            
            Assert.AreEqual
            (
                Int128.Parse("113873979701153668380245603292577223851"), 
                bitArray.ToInt128(1, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to Int128 from index 1."
            );
            
            Assert.AreEqual
            (
                Int128.Parse("-56934403803892427739008202799867832918"), 
                bitArray.ToInt128(1, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to Int128 from index 1."
            );
            
            Assert.AreEqual
            (
                Int128.Parse("-112544751705368752507341796232296879275"), 
                bitArray.ToInt128(1, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to Int128 from index 1."
            );

            Assert.AreEqual
            (
                Int128.Parse("113537793632180829735347753257875969386"), 
                bitArray.ToInt128(2, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to Int128 from index 2."
            );
            
            Assert.AreEqual
            (
                Int128.Parse("-113863635514416042575787207906894108330"), 
                bitArray.ToInt128(2, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to Int128 from index 2."
            );
            
            Assert.AreEqual
            (
                Int128.Parse("141673981558523017862183202315950189141"), 
                bitArray.ToInt128(2, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to Int128 from index 2."
            );
            
            Assert.AreEqual
            (
                Int128.Parse("115192863510200958448691014967174452906"), 
                bitArray.ToInt128(2, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to Int128 from index 2."
            );

            try
            {
                bitArray.ToInt128(300);
                Assert.Fail("Start index out of range exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Start index is out of range. (Parameter 'startIndex') (Parameter 'startIndex') (Parameter 'startIndex')", ex.Message);
            }

            try
            {
                bitArray.ToInt128(9);
                Assert.Fail("Invalid amount of bits left over exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Not enough bits remaining in the BitArray to retrieve data.", ex.Message);
            }
        }

        /// <summary>
        /// BitArray to UInt128 test
        /// </summary>
        /// <remarks>
        /// * Tests least significant bit order
        /// * Tests most significant bit order
        /// * Tests little endian byte order
        /// * Tests big endian byte order
        /// * Tests from diffferent start indexes
        /// * Tests start index is out of range exception
        /// * Tests invalid amount of bits exception
        /// </remarks>
        [TestMethod]
        public void BitArrayToUInt128()
        {
            BitArray bitArray = new BitArray(new[]
            {
                false, true, false, true, false, true, false, true,
                true, false, true, false, true, false, true, false,
                false, true, false, true, false, true, false, true,
                true, false, true, false, true, false, true, false,
                false, true, false, true, false, true, false, true,
                true, false, true, false, true, false, true, false,
                false, true, false, true, false, true, false, true,
                true, false, true, false, true, false, true, false,
                false, true, false, true, false, true, false, true,
                true, false, true, false, true, false, true, false,
                false, true, false, true, false, true, false, true,
                true, false, true, false, true, false, true, false,
                false, true, false, true, false, true, false, true,
                true, false, true, false, true, false, true, false,
                false, true, false, true, false, true, false, true,
                true, false, true, false, true, false, true, false,
                true, false
            });

            Assert.AreEqual
            (
                UInt128.Parse("113868807607784855478016405599735666090"), 
                bitArray.ToUInt128(0, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to UInt128 from index 0."
            );
            
            Assert.AreEqual
            (
                UInt128.Parse("226413559313153607985358201832032545365"), 
                bitArray.ToUInt128(0, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to UInt128 from index 0."
            );
            
            Assert.AreEqual
            (
                UInt128.Parse("226413559313153607985358201832032545365"), 
                bitArray.ToUInt128(0, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to UInt128 from index 0."
            );
            
            Assert.AreEqual
            (
                UInt128.Parse("113868807607784855478016405599735666090"), 
                bitArray.ToUInt128(0, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to UInt128 from index 0."
            );

            Assert.AreEqual
            (
                UInt128.Parse("227075587264361659470695506515751938773"), 
                bitArray.ToUInt128(1, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to UInt128 from index 1."
            );
            
            Assert.AreEqual
            (
                UInt128.Parse("113873979701153668380245603292577223851"), 
                bitArray.ToUInt128(1, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to UInt128 from index 1."
            );
            
            Assert.AreEqual
            (
                UInt128.Parse("283347963117046035724366404631900378538"), 
                bitArray.ToUInt128(1, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to UInt128 from index 1."
            );
            
            Assert.AreEqual
            (
                UInt128.Parse("227737615215569710956032811199471332181"), 
                bitArray.ToUInt128(1, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to UInt128 from index 1."
            );

            Assert.AreEqual
            (
                UInt128.Parse("113537793632180829735347753257875969386"), 
                bitArray.ToUInt128(2, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to UInt128 from index 2."
            );
            
            Assert.AreEqual
            (
                UInt128.Parse("226418731406522420887587399524874103126"), 
                bitArray.ToUInt128(2, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to UInt128 from index 2."
            );
            
            Assert.AreEqual
            (
                UInt128.Parse("141673981558523017862183202315950189141"), 
                bitArray.ToUInt128(2, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to UInt128 from index 2."
            );
            
            Assert.AreEqual
            (
                UInt128.Parse("115192863510200958448691014967174452906"), 
                bitArray.ToUInt128(2, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to UInt128 from index 2."
            );

            try
            {
                bitArray.ToUInt128(300);
                Assert.Fail("Start index out of range exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Start index is out of range. (Parameter 'startIndex') (Parameter 'startIndex')", ex.Message);
            }

            try
            {
                bitArray.ToUInt128(9);
                Assert.Fail("Invalid amount of bits left over exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Not enough bits remaining in the BitArray to retrieve data.", ex.Message);
            }
        }

        /// <summary>
        /// BitArray to half test
        /// </summary>
        /// <remarks>
        /// * Tests least significant bit order
        /// * Tests most significant bit order
        /// * Tests little endian byte order
        /// * Tests big endian byte order
        /// * Tests from diffferent start indexes
        /// * Tests start index is out of range exception
        /// * Tests invalid amount of bits exception
        /// </remarks>
        [TestMethod]
        public void BitArrayToHalf()
        {
            BitArray bitArray = new BitArray(new bool[]
            {
                false, true, true, true, true, false, false, false,
                false, false, false, false, false, false, false, false,
                true, false
            });

            Assert.AreEqual
            (
                (Half)1.8E-06, 
                bitArray.ToHalf(0, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to Half from index 0."
            );
            
            Assert.AreEqual
            (
                (Half)7.15E-06, 
                bitArray.ToHalf(0, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to Half from index 0."
            );
            
            Assert.AreEqual
            (
                (Half)0.00586, 
                bitArray.ToHalf(0, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to Half from index 0."
            );
            
            Assert.AreEqual
            (
                (Half)32770, 
                bitArray.ToHalf(0, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to Half from index 0."
            );

            Assert.AreEqual
            (
                (Half)(-9E-07), 
                bitArray.ToHalf(1, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to Half from index 1."
            );
            
            Assert.AreEqual
            (
                (Half)2.956E-05, 
                bitArray.ToHalf(1, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to Half from index 1."
            );
            
            Assert.AreEqual
            (
                (Half)0.0004578, 
                bitArray.ToHalf(1, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to Half from index 1."
            );
            
            Assert.AreEqual
            (
                (Half)(-8200), 
                bitArray.ToHalf(1, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to Half from index 1."
            );

            Assert.AreEqual
            (
                (Half)2.014, 
                bitArray.ToHalf(2, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to Half from index 2."
            );
            
            Assert.AreEqual
            (
                (Half)4.387E-05, 
                bitArray.ToHalf(2, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to Half from index 2."
            );
            
            Assert.AreEqual
            (
                (Half)0.0001106, 
                bitArray.ToHalf(2, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to Half from index 2."
            );
            
            Assert.AreEqual
            (
                (Half)(-513), 
                bitArray.ToHalf(2, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to Half from index 2."
            );

            try
            {
                bitArray.ToHalf(300);
                Assert.Fail("Start index out of range exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Start index is out of range. (Parameter 'startIndex')", ex.Message);
            }

            try
            {
                bitArray.ToHalf(3);
                Assert.Fail("Invalid amount of bits left over exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Not enough bits remaining in the BitArray to form a Half.", ex.Message);
            }
        }

        /// <summary>
        /// BitArray to float test
        /// </summary>
        /// <remarks>
        /// * Tests least significant bit order
        /// * Tests most significant bit order
        /// * Tests little endian byte order
        /// * Tests big endian byte order
        /// * Tests from diffferent start indexes
        /// * Tests start index is out of range exception
        /// * Tests invalid amount of bits exception
        /// </remarks>
        [TestMethod]
        public void BitArrayToFloat()
        {
            bool[] bits = new bool[]
            {
                false, false, true, true, true, true, true, false,
                true, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false,
                true, false
            };

            BitArray bitArray = new BitArray(bits);

            float resultLSBLE = bitArray.ToFloat(0, BitOrder.LSB, ByteOrder.LittleEndian);
            float resultMSBLE = bitArray.ToFloat(0, BitOrder.MSB, ByteOrder.LittleEndian);
            float resultLSBBE = bitArray.ToFloat(0, BitOrder.LSB, ByteOrder.BigEndian);
            float resultMSBBE = bitArray.ToFloat(0, BitOrder.MSB, ByteOrder.BigEndian);

            Assert.AreEqual
            (
                (float)5.32E-43, 
                bitArray.ToFloat(0, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to float from index 0."
            );
            
            Assert.AreEqual
            (
                (float)4.6005E-41, 
                bitArray.ToFloat(0, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to float from index 0."
            );
            
            Assert.AreEqual
            (
                (float)2.6792252E+36, 
                bitArray.ToFloat(0, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to float from index 0."
            );
            
            Assert.AreEqual
            (
                (float)0.25, 
                bitArray.ToFloat(0, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to float from index 0."
            );

            Assert.AreEqual
            (
                (float)(-2.66E-43), 
                bitArray.ToFloat(1, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to float from index 1."
            );
            
            Assert.AreEqual
            (
                (float)2.3510237E-38, 
                bitArray.ToFloat(1, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to float from index 1."
            );
            
            Assert.AreEqual
            (
                (float)(-0.1250019), 
                bitArray.ToFloat(1, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to float from index 1."
            );
            
            Assert.AreEqual
            (
                (float)1.0633825E+37, 
                bitArray.ToFloat(1, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to float from index 1."
            );

            Assert.AreEqual
            (
                (float)2.0000226, 
                bitArray.ToFloat(2, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to float from index 2."
            );
            
            Assert.AreEqual
            (
                (float)9.404235E-38, 
                bitArray.ToFloat(2, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to float from index 2."
            );
            
            Assert.AreEqual
            (
                (float)9.223442E+18, 
                bitArray.ToFloat(2, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to float from index 2."
            );
            
            Assert.AreEqual
            (
                (float)(-1.6615354E+35), 
                bitArray.ToFloat(2, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to float from index 2."
            );

            try
            {
                bitArray.ToFloat(300);
                Assert.Fail("Start index out of range exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Start index is out of range. (Parameter 'startIndex')", ex.Message);
            }

            try
            {
                bitArray.ToFloat(3);
                Assert.Fail("Invalid amount of bits left over exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Not enough bits remaining in the BitArray to form a float.", ex.Message);
            }
        }

        /// <summary>
        /// BitArray to double test
        /// </summary>
        /// <remarks>
        /// * Tests least significant bit order
        /// * Tests most significant bit order
        /// * Tests little endian byte order
        /// * Tests big endian byte order
        /// * Tests from diffferent start indexes
        /// * Tests start index is out of range exception
        /// * Tests invalid amount of bits exception
        /// </remarks>
        [TestMethod]
        public void BitArrayToDouble()
        {
            bool[] bits = new bool[]
            {
                false, false, true, true, true, true, true, true,       
                true, false, false, false, false, false, false, false,  
                false, false, false, false, false, false, false, false, 
                false, false, false, false, false, false, false, false, 
                false, false, false, false, false, false, false, false, 
                false, false, false, false, false, false, false, false, 
                false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false,
                true, false
            };

            BitArray bitArray = new BitArray(bits);

            Assert.AreEqual
            (
                (double)2.51E-321, 
                bitArray.ToDouble(0, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to double from index 0."
            );
            
            Assert.AreEqual
            (
                (double)1.62207E-319, 
                bitArray.ToDouble(0, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to double from index 0."
            );
            
            Assert.AreEqual
            (
                (double)-2.0708792274225E+289, 
                bitArray.ToDouble(0, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to double from index 0."
            );
            
            Assert.AreEqual
            (
                (double)0.0078125, 
                bitArray.ToDouble(0, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to double from index 0."
            );

            Assert.AreEqual
            (
                (double)(-1.255E-321), 
                bitArray.ToDouble(1, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to double from index 1."
            );
            
            Assert.AreEqual
            (
                (double)7.291122019556603E-304, 
                bitArray.ToDouble(1, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to double from index 1."
            );
            
            Assert.AreEqual
            (
                (double)(-8.371160993642951E+298), 
                bitArray.ToDouble(1, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to double from index 1."
            );
            
            Assert.AreEqual
            (
                (double)5.48612406879369E+303, 
                bitArray.ToDouble(1, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to double from index 1."
            );

            Assert.AreEqual
            (
                (double)2.0000000000000564, 
                bitArray.ToDouble(2, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to double from index 2."
            );
            
            Assert.AreEqual
            (
                (double)4.77830972673675E-299, 
                bitArray.ToDouble(2, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to double from index 2."
            );
            
            Assert.AreEqual
            (
                (double)5.486124068793767E+303, 
                bitArray.ToDouble(2, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to double from index 2."
            );
            
            Assert.AreEqual
            (
                (double)(-8.371160993642717E+298), 
                bitArray.ToDouble(2, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to double from index 2."
            );

            try
            {
                bitArray.ToDouble(300);
                Assert.Fail("Start index out of range exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Start index is out of range. (Parameter 'startIndex')", ex.Message);
            }

            try
            {
                bitArray.ToDouble(3);
                Assert.Fail("Invalid amount of bits left over exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Not enough bits remaining in the BitArray to form a double.", ex.Message);
            }
        }

        /// <summary>
        /// BitArray to decimal test
        /// </summary>
        /// <remarks>
        /// * Tests least significant bit order
        /// * Tests most significant bit order
        /// * Tests little endian byte order
        /// * Tests big endian byte order
        /// * Tests from diffferent start indexes
        /// * Tests start index is out of range exception
        /// * Tests invalid amount of bits exception
        /// </remarks>
        [TestMethod]
        public void BitArrayToDecimal()
        {
            byte[] decimalBytes = new byte[]
            {
                0x00, 0x00, 0x01, 0x00,
                0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00,
                0x01, 0x00, 0x00, 0x00,
                0x99
            };
        
            BitArray bitArray = new BitArray(decimalBytes);
        
            Assert.AreEqual
            (
                65536, 
                bitArray.ToDecimal(0, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to decimal from index 0."
            );
            
            Assert.AreEqual
            (
                8388608, 
                bitArray.ToDecimal(0, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to decimal from index 0."
            );
            
            Assert.AreEqual
            (
                16777216, 
                bitArray.ToDecimal(0, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to decimal from index 0."
            );
            
            Assert.AreEqual
            (
                2147483648, 
                bitArray.ToDecimal(0, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to decimal from index 0."
            );

            Assert.AreEqual
            (
                decimal.Parse("-39614081257132168796772007936"), 
                bitArray.ToDecimal(1, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to decimal from index 1."
            );
            
            Assert.AreEqual
            (
                decimal.Parse("309485009821345068724781312"), 
                bitArray.ToDecimal(1, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to decimal from index 1."
            );
            
            Assert.AreEqual
            (
                decimal.Parse("549755814016"), 
                bitArray.ToDecimal(1, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to decimal from index 1."
            );
            
            Assert.AreEqual
            (
                decimal.Parse("429496729,7"), 
                bitArray.ToDecimal(1, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to decimal from index 1."
            );

            Assert.AreEqual
            (
                decimal.Parse("19807040628566084398386003968"), 
                bitArray.ToDecimal(2, BitOrder.LSB, ByteOrder.LittleEndian), 
                "(LSB & LE) Failed to convert BitArray to decimal from index 2."
            );
            
            Assert.AreEqual
            (
                decimal.Parse("618970019642690137449562624"), 
                bitArray.ToDecimal(2, BitOrder.MSB, ByteOrder.LittleEndian), 
                "(MSB & LE) Failed to convert BitArray to decimal from index 2."
            );
            
            Assert.AreEqual
            (
                decimal.Parse("274877907008"), 
                bitArray.ToDecimal(2, BitOrder.LSB, ByteOrder.BigEndian), 
                "(LSB & BE) Failed to convert BitArray to decimal from index 2."
            );
            
            Assert.AreEqual
            (
                decimal.Parse("85899345,94"), 
                bitArray.ToDecimal(2, BitOrder.MSB, ByteOrder.BigEndian), 
                "(MSB & BE) Failed to convert BitArray to decimal from index 2."
            );

            try
            {
                bitArray.ToDecimal(300);
                Assert.Fail("Start index out of range exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Start index is out of range. (Parameter 'startIndex')", ex.Message);
            }

            try
            {
                bitArray.ToDecimal(9);
                Assert.Fail("Invalid amount of bits left over exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Not enough bits remaining in the BitArray to form a decimal.", ex.Message);
            }
        }
    }
}