using System.Collections;
using Extensions.Binary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Extensions.Binary.Tests
{
    [TestClass]
    public class ReverseBytesTest
    {
        [TestMethod]
        public void ReverseBytesInUShort()
        {
            var bitArray = new BitArray(new bool[]
            {
                false, false, false, false,
                false, false, false, false,
                true, true, true, true,
                true, true, true, true
            });
            var reversed = new BitArray(bitArray.Length);

            bitArray = bitArray.ReverseBytesInUShort();

            BitArray SegmentA = bitArray.GetByteFromArray();
            BitArray SegmentB = bitArray.GetByteFromArray(Constant.byte1Index);

            Assert.AreEqual(255, SegmentA.ToByte(), $"SegmentA not swapped." );
            Assert.AreEqual(0, SegmentB.ToByte(), $"SegmentB not swapped." );
        }

        [TestMethod]
        public void ReverseBytesInUInt()
        {
            var bitArray = new BitArray(new bool[]
            {
                false, false, false, false,
                false, false, false, false,
                true, true, true, true,
                true, true, true, true,
                false, false, false, false,
                false, false, false, false,
                true, true, true, true,
                true, true, true, true
            });
            var reversed = new BitArray(bitArray.Length);

            bitArray = bitArray.ReverseBytesInUInt();

            BitArray SegmentA = bitArray.GetByteFromArray();
            BitArray SegmentB = bitArray.GetByteFromArray(Constant.byte1Index);
            BitArray SegmentC = bitArray.GetByteFromArray(Constant.byte2Index);
            BitArray SegmentD = bitArray.GetByteFromArray(Constant.byte3Index);

            Assert.AreEqual(255, SegmentA.ToByte(), $"SegmentA not swapped." );
            Assert.AreEqual(0, SegmentB.ToByte(), $"SegmentB not swapped." );
            Assert.AreEqual(255, SegmentC.ToByte(), $"SegmentC not swapped." );
            Assert.AreEqual(0, SegmentD.ToByte(), $"SegmentD not swapped." );
        }

        [TestMethod]
        public void ReverseBytesInULong()
        {
            var bitArray = new BitArray(new bool[]
            {
                false, false, false, false,
                false, false, false, false,
                true, true, true, true,
                true, true, true, true,
                false, false, false, false,
                false, false, false, false,
                true, true, true, true,
                true, true, true, true,
                false, false, false, false,
                false, false, false, false,
                true, true, true, true,
                true, true, true, true,
                false, false, false, false,
                false, false, false, false,
                true, true, true, true,
                true, true, true, true
            });
            var reversed = new BitArray(bitArray.Length);

            bitArray = bitArray.ReverseBytesInULong();

            BitArray SegmentA = bitArray.GetByteFromArray();
            BitArray SegmentB = bitArray.GetByteFromArray(Constant.byte1Index);
            BitArray SegmentC = bitArray.GetByteFromArray(Constant.byte2Index);
            BitArray SegmentD = bitArray.GetByteFromArray(Constant.byte3Index);
            BitArray SegmentE = bitArray.GetByteFromArray(Constant.byte4Index);
            BitArray SegmentF = bitArray.GetByteFromArray(Constant.byte5Index);
            BitArray SegmentG = bitArray.GetByteFromArray(Constant.byte6Index);
            BitArray SegmentH = bitArray.GetByteFromArray(Constant.byte7Index);

            Assert.AreEqual(255, SegmentA.ToByte(), $"SegmentA not swapped." );
            Assert.AreEqual(0, SegmentB.ToByte(), $"SegmentB not swapped." );
            Assert.AreEqual(255, SegmentC.ToByte(), $"SegmentC not swapped." );
            Assert.AreEqual(0, SegmentD.ToByte(), $"SegmentD not swapped." );
            Assert.AreEqual(255, SegmentE.ToByte(), $"SegmentE not swapped." );
            Assert.AreEqual(0, SegmentF.ToByte(), $"SegmentF not swapped." );
            Assert.AreEqual(255, SegmentG.ToByte(), $"SegmentG not swapped." );
            Assert.AreEqual(0, SegmentH.ToByte(), $"SegmentH not swapped." );
        }

        [TestMethod]
        public void ReverseBytesInUInt128()
        {
            var bitArray = new BitArray(new bool[]
            {
                false, false, false, false,
                false, false, false, false,
                true, true, true, true,
                true, true, true, true,
                false, false, false, false,
                false, false, false, false,
                true, true, true, true,
                true, true, true, true,
                false, false, false, false,
                false, false, false, false,
                true, true, true, true,
                true, true, true, true,
                false, false, false, false,
                false, false, false, false,
                true, true, true, true,
                true, true, true, true,
                false, false, false, false,
                false, false, false, false,
                true, true, true, true,
                true, true, true, true,
                false, false, false, false,
                false, false, false, false,
                true, true, true, true,
                true, true, true, true,
                false, false, false, false,
                false, false, false, false,
                true, true, true, true,
                true, true, true, true,
                false, false, false, false,
                false, false, false, false,
                true, true, true, true,
                true, true, true, true
            });
            var reversed = new BitArray(bitArray.Length);

            bitArray = bitArray.ReverseBytesInUInt128();

            BitArray SegmentA = bitArray.GetByteFromArray();
            BitArray SegmentB = bitArray.GetByteFromArray(Constant.byte1Index);
            BitArray SegmentC = bitArray.GetByteFromArray(Constant.byte2Index);
            BitArray SegmentD = bitArray.GetByteFromArray(Constant.byte3Index);
            BitArray SegmentE = bitArray.GetByteFromArray(Constant.byte4Index);
            BitArray SegmentF = bitArray.GetByteFromArray(Constant.byte5Index);
            BitArray SegmentG = bitArray.GetByteFromArray(Constant.byte6Index);
            BitArray SegmentH = bitArray.GetByteFromArray(Constant.byte7Index);
            BitArray SegmentI = bitArray.GetByteFromArray(Constant.byte8Index);
            BitArray SegmentJ = bitArray.GetByteFromArray(Constant.byte9Index);
            BitArray SegmentK = bitArray.GetByteFromArray(Constant.byte10Index);
            BitArray SegmentL = bitArray.GetByteFromArray(Constant.byte11Index);
            BitArray SegmentM = bitArray.GetByteFromArray(Constant.byte12Index);
            BitArray SegmentN = bitArray.GetByteFromArray(Constant.byte13Index);
            BitArray SegmentO = bitArray.GetByteFromArray(Constant.byte14Index);
            BitArray SegmentP = bitArray.GetByteFromArray(Constant.byte15Index);
;
            Assert.AreEqual(128, bitArray.Length, $"BitArray length not swapped." );

            Assert.AreEqual(255 , SegmentA.ToByte(), $"SegmentA not swapped." );
            Assert.AreEqual(0 , SegmentB.ToByte(), $"SegmentB not swapped." );
            Assert.AreEqual(255 , SegmentC.ToByte(), $"SegmentC not swapped." );
            Assert.AreEqual(0 , SegmentD.ToByte(), $"SegmentD not swapped." );
            Assert.AreEqual(255 , SegmentE.ToByte(), $"SegmentE not swapped." );
            Assert.AreEqual(0 , SegmentF.ToByte(), $"SegmentF not swapped." );
            Assert.AreEqual(255 , SegmentG.ToByte(), $"SegmentG not swapped." );
            Assert.AreEqual(0 , SegmentH.ToByte(), $"SegmentH not swapped." );
            Assert.AreEqual(255, SegmentI.ToByte(), $"SegmentI not swapped.");
            Assert.AreEqual(0, SegmentJ.ToByte(), $"SegmentJ not swapped.");
            Assert.AreEqual(255, SegmentK.ToByte(), $"SegmentK not swapped.");
            Assert.AreEqual(0, SegmentL.ToByte(), $"SegmentL not swapped.");
            Assert.AreEqual(255, SegmentM.ToByte(), $"SegmentM not swapped.");
            Assert.AreEqual(0, SegmentN.ToByte(), $"SegmentN not swapped.");
            Assert.AreEqual(255, SegmentO.ToByte(), $"SegmentO not swapped.");
            Assert.AreEqual(0, SegmentP.ToByte(), $"SegmentP not swapped.");
        }
    }
}