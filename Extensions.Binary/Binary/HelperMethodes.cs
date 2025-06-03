using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Binary
{
    internal static class HelperMethodsExtensions
    {
        /// <summary>
        /// Calculate if BitArray has sufficient amount of bits from start index to form a byte.
        /// </summary>
        /// <param name="bitArray">The BitArray to check.</param>
        /// <param name="startIndex">The starting index in the BitArray. Defaults to 0.</param>
        /// <param name="requiredBytes">The required amount of bytes required to be valid. Defaults to 1.</param>
        /// <returns>True if BitArray has valid amount of bits, false if not.</returns>
        public static bool HasEnoughBits( this BitArray bitArray , int startIndex = 0 , int requiredBits = 8 )
        {
            bool result = true;

            if( bitArray.Count < requiredBits + startIndex )
                result = false;

            return result;
        }

        /// <summary>
        /// Gets 8 bits(byte) from a BitArray
        /// </summary>
        /// <param name="bitArray">The BitArray extract bits from.</param>
        /// <param name="startIndex">The starting index in the BitArray. Defaults to 0.</param>
        /// <param name="bitOrder">The bit order of the BitArray. Defaults to LSB.</param>
        /// <returns>8 Bits(byte) from a BitArray</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws when an invalid index has been provided.</exception>
        /// <exception cref="ArgumentException">Thrown if there are not enough bits remaining in the BitArray to form a byte.</exception>
        public static BitArray GetByteFromArray( this BitArray bitArray, int startIndex = 0, BitOrder bitOrder = BitOrder.LSB )
        {
            BitArray result = new( Constant.bitsInByte );

            if( !bitArray.HasValidStartIndex( startIndex ))
                throw new ArgumentOutOfRangeException( nameof( startIndex ) , "Start index is out of range." );

            if( !bitArray.HasEnoughBits( startIndex ))
                throw new ArgumentException( "Not enough bits remaining in the BitArray to retrieve data." );

            for( int i = 0 ; i < Constant.bitsInByte ; i++ )
                result[ i ] = bitArray[ startIndex + i ];

            if( bitOrder == BitOrder.MSB )
                result = result.ReverseBitsInByte();

            return result;
        }

        /// <summary>
        /// Calculate if start index is valid for BitArray
        /// </summary>
        /// <param name="bitArray">The BitArray to check.</param>
        /// <param name="startIndex">The starting index in the BitArray. Defaults to 0.</param>
        /// <returns>True if start index is valid, false if not.</returns>
        public static bool HasValidStartIndex( this BitArray bitArray , int startIndex = 0 )
        {
            bool result = true;

            if( startIndex < 0 || startIndex > ( bitArray.Count - 1 ))
                result = false;

            return result;
        }
    }
}
