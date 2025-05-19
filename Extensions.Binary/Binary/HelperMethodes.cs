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

            if (bitArray.Count != Constant.bitsInInt )
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

        /// <summary>
        /// Reverse the bytes in a BitArray with a length of 16.
        /// </summary>
        /// <param name="bitArray">The BitArray to check.</param>
        /// <returns>Reverse content of BitArray.</returns>
        /// <exception cref="ArgumentException">Thrown if BitArray length is not 16.</exception>
        public static BitArray ReverseBytesInUShort( this BitArray bitArray )
        {
            BitArray result = new( Constant.bitsInShort );

            if ( bitArray.Length != Constant.bitsInShort )
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
                if( bitArray[ i ] )
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

            for( int i = 0; i < Constant.bitsInShort ; i++ )
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
                throw new ArgumentException( "Incorrect amount of bits to form a Int128." );

            for( int i = 0 ; i < Constant.bitsInInt128 ; i++ )
                if( bitArray[ i ] )
                    result |= UInt128.One << i;

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

        /// <summary>
        /// Extracts a specified number of bytes from the source starting at a given index,
        /// and inserts them into a new BitArray in the specified bit order.
        /// </summary>
        /// <param name="bitArray">The source from which bytes will be extracted.</param>
        /// <param name="startIndex">The bit index in the source array to begin extraction. Defaults to 0.</param>
        /// <param name="bitOrder">The bit order (LSB or MSB) used when extracting bytes. Defaults to BitOrder.LSB.</param>
        /// <param name="AmountOfBytes">The number of bytes to extract and insert. Defaults to Constant.bytesInSort.</param>
        /// <returns>
        /// A new BitArray containing the inserted bytes in the order specified.
        /// </returns>
        /// <remarks>
        /// This method supports up to 16 bytes. Each byte is inserted into the resulting array at its corresponding position.
        /// </remarks>
        public static BitArray InsertBytesInArray( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB , int AmountOfBytes = Constant.bytesInSort)
        {
            BitArray result = new( AmountOfBytes * Constant.bits8 );

            if( AmountOfBytes > Constant.byte0 ) result.InsertArray( bitArray.GetByteFromArray( startIndex , bitOrder ));
            if( AmountOfBytes > Constant.byte1 ) result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte1Index , bitOrder ) , Constant.byte1Index );
            if( AmountOfBytes > Constant.byte2 ) result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte2Index , bitOrder ) , Constant.byte2Index );
            if( AmountOfBytes > Constant.byte3 ) result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte3Index , bitOrder ) , Constant.byte3Index );
            if( AmountOfBytes > Constant.byte4 ) result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte4Index , bitOrder ) , Constant.byte4Index );
            if( AmountOfBytes > Constant.byte5 ) result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte5Index , bitOrder ) , Constant.byte5Index );
            if( AmountOfBytes > Constant.byte6 ) result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte6Index , bitOrder ) , Constant.byte6Index );
            if( AmountOfBytes > Constant.byte7 ) result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte7Index , bitOrder ) , Constant.byte7Index );
            if( AmountOfBytes > Constant.byte8 ) result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte8Index , bitOrder ) , Constant.byte8Index );
            if( AmountOfBytes > Constant.byte9 ) result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte9Index , bitOrder ) , Constant.byte9Index );
            if( AmountOfBytes > Constant.byte10 ) result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte10Index , bitOrder ) , Constant.byte10Index );
            if( AmountOfBytes > Constant.byte11 ) result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte11Index , bitOrder ) , Constant.byte11Index );
            if( AmountOfBytes > Constant.byte12 ) result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte12Index , bitOrder ) , Constant.byte12Index );
            if( AmountOfBytes > Constant.byte13 ) result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte13Index , bitOrder ) , Constant.byte13Index );
            if( AmountOfBytes > Constant.byte14 ) result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte14Index , bitOrder ) , Constant.byte14Index );
            if( AmountOfBytes > Constant.byte15 ) result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte15Index , bitOrder ) , Constant.byte15Index );

            return result;
        }
    }
}
