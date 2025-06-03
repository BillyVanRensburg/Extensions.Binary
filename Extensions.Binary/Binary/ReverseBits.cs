using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Binary
{
    /// <summary>
    /// Provides extension methods to reverse bits in a byte or integer.
    /// </summary>
    internal static class ReverseBitsExtensions
    {
        /// <summary>
        /// Reverse the bits in a BitArray with a length of 8.
        /// </summary>
        /// <param name="bitArray">The BitArray to check.</param>
        /// <returns>Reverse content of BitArray.</returns>
        /// <exception cref="ArgumentException">Thrown if BitArray length is not 8.</exception>
        public static BitArray ReverseBitsInByte( this BitArray bitArray )
        {
            BitArray result = new( Constant.bitsInByte );

            if( bitArray.Count != Constant.bitsInByte )
                throw new ArgumentException( "Incorrect amount of bits to form a byte." );

            for( int i = 0 ; i < Constant.bitsInByte ; ++i )
                result[ Constant.bitsInByte - 1 - i ] = bitArray[ i ];

            return result;
        }

        /// <summary>
        /// Reverse the bits in a BitArray with a length of 32.
        /// </summary>
        /// <param name="bitArray">The BitArray to check.</param>
        /// <returns>Reverse content of BitArray.</returns>
        /// <exception cref="ArgumentException">Thrown if BitArray length is not 32.</exception>
        public static BitArray ReverseBitsInInt( this BitArray bitArray )
        {
            BitArray result = new( Constant.bitsInInt );

            if( bitArray.Count != Constant.bitsInInt )
                throw new ArgumentException( "Incorrect amount of bits to form a int." );

            BitArray bitArraySegmentA = bitArray.GetByteFromArray().ReverseBitsInByte();
            BitArray bitArraySegmentB = bitArray.GetByteFromArray( Constant.byte1Index ).ReverseBitsInByte();
            BitArray bitArraySegmentC = bitArray.GetByteFromArray( Constant.byte2Index ).ReverseBitsInByte();
            BitArray bitArraySegmentD = bitArray.GetByteFromArray( Constant.byte3Index ).ReverseBitsInByte();

            result.InsertArray( bitArraySegmentA );
            result.InsertArray( bitArraySegmentB , Constant.byte1Index );
            result.InsertArray( bitArraySegmentC , Constant.byte2Index );
            result.InsertArray( bitArraySegmentD , Constant.byte3Index );

            return result;
        }
    }
}