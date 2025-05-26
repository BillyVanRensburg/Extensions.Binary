using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Binary.Tests
{
    /// <summary>
    /// Tests methodes to calculate values from a bit array
    /// </summary>
    [TestClass]
    public class CalculateFromBitArrayTest
    {
        /// <summary>
        /// Calculate byte from BitArray test
        /// </summary>
        /// <remarks>
        /// * Tests calculations from BitArray
        /// * Tests invalid amount of bits exception
        /// </remarks>
        [TestMethod]
        public void CalculateByteFromArray()
        {
            var bitArray = new BitArray
            ([
                true , false , true , false , true , false , true , false
            ]);

            Assert.AreEqual
            ( 
                ( byte ) 85 , 
                bitArray.CalculateByteFromArray() ,
                "Calculate from byte from BitArray failed."
            );

            try
            {
                bitArray = new BitArray( bitArray.Length + 1 );
                bitArray.CalculateByteFromArray();
                Assert.Fail( "BitArray out of range ArgumentException was not thrown." );
            }
            catch( ArgumentException ex )
            {
                Assert.AreEqual( "Incorrect amount of bits to form a byte." , ex.Message );
            }
        }

        /// <summary>
        /// Calculate ushort from BitArray test
        /// </summary>
        /// <remarks>
        /// * Tests calculations from BitArray
        /// * Tests invalid amount of bits exception
        /// </remarks>
        [TestMethod]
        public void CalculateUShortFromArray()
        {
            var bitArray = new BitArray
             ([
                false , true , false , true , false , true , false , true ,
                false , true , false , true , false , true , false , true
             ]);

            Assert.AreEqual
            ( 
                43690 , 
                bitArray.CalculateUShortFromArray() ,
                "Calculate from byte from BitArray failed."
            );

            try
            {
                bitArray = new BitArray( bitArray.Length + 1 );
                bitArray.CalculateUShortFromArray();
                Assert.Fail( "BitArray out of range ArgumentException was not thrown." );
            }
            catch( ArgumentException ex )
            {
                Assert.AreEqual( "Incorrect amount of bits to form a ushort." , ex.Message );
            }
        }

        /// <summary>
        /// Calculate uint from BitArray test
        /// </summary>
        /// <remarks>
        /// * Tests calculations from BitArray
        /// * Tests invalid amount of bits exception
        /// </remarks>
        [TestMethod]
        public void CalculateUIntFromArray()
        {
            var bitArray = new BitArray
            ([
                false , true , false , true , false , true , false , true ,
                false , true , false , true , false , true , false , true ,
                false , true , false , true , false , true , false , true ,
                false , true , false , true , false , true , false , true
            ]);

            Assert.AreEqual
            ( 
                2863311530 , 
                bitArray.CalculateUIntFromArray() ,
                "Calculate from uint from BitArray failed."
            );

            try
            {
                bitArray = new BitArray( bitArray.Length + 1 );
                bitArray.CalculateUIntFromArray();
                Assert.Fail( "BitArray out of range ArgumentException was not thrown." );
            }
            catch( ArgumentException ex )
            {
                Assert.AreEqual( "Incorrect amount of bits to form a uint." , ex.Message );
            }
        }

        /// <summary>
        /// Calculate ulong from BitArray test
        /// </summary>
        /// <remarks>
        /// * Tests calculations from BitArray
        /// * Tests invalid amount of bits exception
        /// </remarks>
        [TestMethod]
        public void CalculateULongFromArray()
        {
            var bitArray = new BitArray
            ([
                false , true , false , true , false , true , false , true ,
                false , true , false , true , false , true , false , true ,
                false , true , false , true , false , true , false , true ,
                false , true , false , true , false , true , false , true ,
                false , true , false , true , false , true , false , true ,
                false , true , false , true , false , true , false , true ,
                false , true , false , true , false , true , false , true ,
                false , true , false , true , false , true , false , true
            ]);

            Assert.AreEqual
            ( 
                12297829382473034410 , 
                bitArray.CalculateULongFromArray() ,
                "Calculate from ulong from BitArray failed."
            );

            try
            {
                bitArray = new BitArray( bitArray.Length + 1 );
                bitArray.CalculateULongFromArray();
                Assert.Fail( "BitArray out of range ArgumentException was not thrown." );
            }
            catch( ArgumentException ex )
            {
                Assert.AreEqual( "Incorrect amount of bits to form a ulong." , ex.Message );
            }
        }

        /// <summary>
        /// Calculate uint128 from BitArray test
        /// </summary>
        /// <remarks>
        /// * Tests calculations from BitArray
        /// * Tests invalid amount of bits exception
        /// </remarks>
        [TestMethod]
        public void CalculateUInt128FromArray()
        {
            var bitArray = new BitArray
            ([
                false , true , false , true , false , true , false , true ,
                false , true , false , true , false , true , false , true ,
                false , true , false , true , false , true , false , true ,
                false , true , false , true , false , true , false , true ,
                false , true , false , true , false , true , false , true ,
                false , true , false , true , false , true , false , true ,
                false , true , false , true , false , true , false , true ,
                false , true , false , true , false , true , false , true ,
                false , true , false , true , false , true , false , true ,
                false , true , false , true , false , true , false , true ,
                false , true , false , true , false , true , false , true ,
                false , true , false , true , false , true , false , true ,
                false , true , false , true , false , true , false , true ,
                false , true , false , true , false , true , false , true ,
                false , true , false , true , false , true , false , true ,
                false , true , false , true , false , true , false , true
            ]);

            Assert.AreEqual
            ( 
                UInt128.Parse( "226854911280625642308916404954512140970" ) , 
                bitArray.CalculateUInt128FromArray() , 
                "Calculate from uint128 from BitArray failed."
            );

            try
            {
                bitArray = new BitArray( bitArray.Length + 1 );
                bitArray.CalculateUInt128FromArray();
                Assert.Fail( "BitArray out of range ArgumentException was not thrown." );
            }
            catch( ArgumentException ex )
            {
                Assert.AreEqual( "Incorrect amount of bits to form a uint128." , ex.Message );
            }
        }
    }
}
