using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Binary
{
    /// <summary>
    /// Methodes to calculate values from a bit array
    /// </summary>
    internal static class CalculateFromBitArrayExtensions
    {
        /// <summary>
        /// Calculates the byte value form a BitArray with a length of 8.
        /// </summary>
        /// <param name="bitArray">The BitArray to be used for calculations.</param>
        /// <returns>Byte value of the BitArray.</returns>
        /// <exception cref="ArgumentException">Thrown if BitArray length is not 8.</exception>
        public static byte CalculateByteFromArray( this BitArray bitArray )
        {
            byte result = 0;

            if( bitArray.Count != Constant.bitsInByte )
                throw new ArgumentException( "Incorrect amount of bits to form a byte." );

            for( int i = 0 ; i < Constant.bitsInByte ; i++ )
                if ( bitArray[ i ] )
                    result |= ( byte )( 1 << i );

            return result;
        }

        /// <summary>
        /// Calculates the ushort value form a BitArray with a length of 16.
        /// </summary>
        /// <param name="bitArray">The BitArray to be used for calculations.</param>
        /// <returns>UShort value of the BitArray.</returns>
        /// <exception cref="ArgumentException">Thrown if BitArray length is not 16.</exception>
        public static ushort CalculateUShortFromArray( this BitArray bitArray )
        {
            ushort result = 0;

            if( bitArray.Count != Constant.bitsInShort )
                throw new ArgumentException( "Incorrect amount of bits to form a ushort." );

            for( int i = 0 ; i < Constant.bitsInShort ; i++ )
                if( bitArray[ i ] )
                    result |= ( ushort )( 1 << i );

            return result;
        }

        /// <summary>
        /// Calculates the uint value form a BitArray with a length of 32.
        /// </summary>
        /// <param name="bitArray">The BitArray to be used for calculations.</param>
        /// <returns>UInt value of the BitArray.</returns>
        /// <exception cref="ArgumentException">Thrown if BitArray length is not 32.</exception>
        public static uint CalculateUIntFromArray( this BitArray bitArray )
        {
            uint result = 0;

            if( bitArray.Count != Constant.bitsInInt )
                throw new ArgumentException( "Incorrect amount of bits to form a uint." );

            for( int i = 0 ; i < Constant.bitsInInt ; i++ )
                if( bitArray[ i ] )
                    result |= ( uint )( 1 << i );

            return result;
        }

        /// <summary>
        /// Calculates the ulong value form a BitArray with a length of 64.
        /// </summary>
        /// <param name="bitArray">The BitArray to be used for calculations.</param>
        /// <returns>Ulong value of the BitArray.</returns>
        /// <exception cref="ArgumentException">Thrown if BitArray length is not 64.</exception>
        public static ulong CalculateULongFromArray( this BitArray bitArray )
        {
            ulong result = 0;

            if( bitArray.Count != Constant.bitsInLong )
                throw new ArgumentException( "Incorrect amount of bits to form a ulong." );

            for( int i = 0 ; i < Constant.bitsInLong ; i++ )
                if( bitArray[ i ] )
                    result |= ( ulong )1 << i;

            return result;
        }

        /// <summary>
        /// Calculates the int128 value form a BitArray with a length of 128.
        /// </summary>
        /// <param name="bitArray">The BitArray to be used for calculations.</param>
        /// <returns>Int128 value of the BitArray.</returns>
        /// <exception cref="ArgumentException">Thrown if BitArray length is not 128.</exception>
        public static UInt128 CalculateUInt128FromArray( this BitArray bitArray )
        {
            UInt128 result = 0;

            if( bitArray.Count != Constant.bitsInInt128 )
                throw new ArgumentException( "Incorrect amount of bits to form a uint128." );

            for( int i = 0 ; i < Constant.bitsInInt128 ; i++ )
                if( bitArray[ i ] )
                    result |= UInt128.One << i;

            return result;
        }
    }
}