using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Binary
{
    /// <summary>
    /// Provides extension methods to reverse bytes.
    /// </summary>
    internal static class ReverseBytesExtensions
    {
        /// <summary>
        /// Reverse the bytes in a BitArray with a length of 16.
        /// </summary>
        /// <param name="bitArray">The BitArray to check.</param>
        /// <returns>Reverse content of BitArray.</returns>
        /// <exception cref="ArgumentException">Thrown if BitArray length is not 16.</exception>
        public static BitArray ReverseBytesInUShort( this BitArray bitArray )
        {
            BitArray result = new( Constant.bitsInShort );

            if( bitArray.Length != Constant.bitsInShort )
                throw new ArgumentException( "Incorrect amount of bits to form a ushort." );

            BitArray SegmentA = bitArray.GetByteFromArray();
            BitArray SegmentB = bitArray.GetByteFromArray( Constant.byte1Index );

            result.InsertArray( SegmentB );
            result.InsertArray( SegmentA , Constant.byte1Index );

            return result;
        }

        /// <summary>
        /// Reverse the bytes in a BitArray with a length of 32.
        /// </summary>
        /// <param name="bitArray">The BitArray to check.</param>
        /// <returns>Reverse content of BitArray.</returns>
        /// <exception cref="ArgumentException">Thrown if BitArray length is not 32.</exception>
        public static BitArray ReverseBytesInUInt( this BitArray bitArray )
        {
            BitArray result = new( Constant.bitsInInt );

            if( bitArray.Length != Constant.bitsInInt )
                throw new ArgumentException( "Incorrect amount of bits to form a uint." );

            BitArray SegmentA = bitArray.GetByteFromArray();
            BitArray SegmentB = bitArray.GetByteFromArray( Constant.byte1Index );
            BitArray SegmentC = bitArray.GetByteFromArray( Constant.byte2Index );
            BitArray SegmentD = bitArray.GetByteFromArray( Constant.byte3Index );

            result.InsertArray( SegmentD );
            result.InsertArray( SegmentC , Constant.byte1Index );
            result.InsertArray( SegmentB , Constant.byte2Index );
            result.InsertArray( SegmentA , Constant.byte3Index );

            return result;
        }

        /// <summary>
        /// Reverse the bytes in a BitArray with a length of 64.
        /// </summary>
        /// <param name="bitArray">The BitArray to check.</param>
        /// <returns>Reverse content of BitArray.</returns>
        /// <exception cref="ArgumentException">Thrown if BitArray length is not 64.</exception>
        public static BitArray ReverseBytesInULong( this BitArray bitArray )
        {
            BitArray result = new( Constant.bitsInLong );

            if( bitArray.Length != Constant.bitsInLong )
                throw new ArgumentException( "Incorrect amount of bits to form a ulong." );

            BitArray SegmentA = bitArray.GetByteFromArray();
            BitArray SegmentB = bitArray.GetByteFromArray( Constant.byte1Index );
            BitArray SegmentC = bitArray.GetByteFromArray( Constant.byte2Index );
            BitArray SegmentD = bitArray.GetByteFromArray( Constant.byte3Index );
            BitArray SegmentE = bitArray.GetByteFromArray( Constant.byte4Index );
            BitArray SegmentF = bitArray.GetByteFromArray( Constant.byte5Index );
            BitArray SegmentG = bitArray.GetByteFromArray( Constant.byte6Index );
            BitArray SegmentH = bitArray.GetByteFromArray( Constant.byte7Index );

            result.InsertArray( SegmentH );
            result.InsertArray( SegmentG , Constant.byte1Index );
            result.InsertArray( SegmentF , Constant.byte2Index );
            result.InsertArray( SegmentE , Constant.byte3Index );
            result.InsertArray( SegmentD , Constant.byte4Index );
            result.InsertArray( SegmentC , Constant.byte5Index );
            result.InsertArray( SegmentB , Constant.byte6Index );
            result.InsertArray( SegmentA , Constant.byte7Index );

            return result;
        }

        /// <summary>
        /// Reverse the bytes in a BitArray with a length of 128.
        /// </summary>
        /// <param name="bitArray">The BitArray to check.</param>
        /// <returns>Reverse content of BitArray.</returns>
        /// <exception cref="ArgumentException">Thrown if BitArray length is not 128.</exception>
        public static BitArray ReverseBytesInUInt128( this BitArray bitArray )
        {
            BitArray result = new( Constant.bitsInInt128 );

            if( bitArray.Length != Constant.bitsInInt128 )
                throw new ArgumentException( "Incorrect amount of bits to form a Int128." );

            BitArray SegmentA = bitArray.GetByteFromArray();
            BitArray SegmentB = bitArray.GetByteFromArray( Constant.byte1Index );
            BitArray SegmentC = bitArray.GetByteFromArray( Constant.byte2Index );
            BitArray SegmentD = bitArray.GetByteFromArray( Constant.byte3Index );
            BitArray SegmentE = bitArray.GetByteFromArray( Constant.byte4Index );
            BitArray SegmentF = bitArray.GetByteFromArray( Constant.byte5Index );
            BitArray SegmentG = bitArray.GetByteFromArray( Constant.byte6Index );
            BitArray SegmentH = bitArray.GetByteFromArray( Constant.byte7Index );
            BitArray SegmentI = bitArray.GetByteFromArray( Constant.byte8Index );
            BitArray SegmentJ = bitArray.GetByteFromArray( Constant.byte9Index );
            BitArray SegmentK = bitArray.GetByteFromArray( Constant.byte10Index );
            BitArray SegmentL = bitArray.GetByteFromArray( Constant.byte11Index );
            BitArray SegmentM = bitArray.GetByteFromArray( Constant.byte12Index );
            BitArray SegmentN = bitArray.GetByteFromArray( Constant.byte13Index );
            BitArray SegmentO = bitArray.GetByteFromArray( Constant.byte14Index );
            BitArray SegmentP = bitArray.GetByteFromArray( Constant.byte15Index );

            result.InsertArray( SegmentP );
            result.InsertArray( SegmentO , Constant.byte1Index );
            result.InsertArray( SegmentN , Constant.byte2Index );
            result.InsertArray( SegmentM , Constant.byte3Index );
            result.InsertArray( SegmentL , Constant.byte4Index );
            result.InsertArray( SegmentK , Constant.byte5Index );
            result.InsertArray( SegmentJ , Constant.byte6Index );
            result.InsertArray( SegmentI , Constant.byte7Index );
            result.InsertArray( SegmentH , Constant.byte8Index );
            result.InsertArray( SegmentG , Constant.byte9Index );
            result.InsertArray( SegmentF , Constant.byte10Index );
            result.InsertArray( SegmentE , Constant.byte11Index );
            result.InsertArray( SegmentD , Constant.byte12Index );
            result.InsertArray( SegmentC , Constant.byte13Index );
            result.InsertArray( SegmentB , Constant.byte14Index );
            result.InsertArray( SegmentA , Constant.byte15Index );

            return result;
        }
    }
}