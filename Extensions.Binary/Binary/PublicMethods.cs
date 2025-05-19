using System.Collections;

namespace Extensions.Binary
{
    /// <summary>
    /// Provides specialized extension methods for BitArray operations such as insertion, binary conversion, and appending.
    /// </summary>
    public static class PublicMethodsExtensions
    {
        /// <summary>
        /// Inserts the bits from the specified BitArray into the target BitArray at the given index.
        /// </summary>
        /// <param name="bitArray">The target BitArray to insert bits into.</param>
        /// <param name="insertBitArray">The source BitArray containing bits to insert.</param>
        /// <param name="insertIndex">
        /// The zero-based bit index in the target array at which to begin insertion. Defaults to 0.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when insertIndex is outside the valid range of the target array.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the target array does not have enough remaining bits from insertIndex to accommodate the source bits.
        /// </exception>
        public static void InsertArray( this BitArray bitArray , BitArray insertBitArray , int insertIndex = 0 )
        {
            if( !bitArray.HasValidStartIndex( insertIndex ))
                throw new ArgumentOutOfRangeException( nameof( insertIndex ) , "Insert index is out of range." );

            if( !bitArray.HasEnoughBits( insertIndex , insertBitArray.Count))
                throw new ArgumentException( "Not enough bits remaining in the BitArray to insert data." );

            for( int i = 0 ; i < insertBitArray.Count ; i++ )
                bitArray[ i + insertIndex ] = insertBitArray[ i ];
        }

        /// <summary>
        /// Converts the entire BitArray to its binary string representation of '1's and '0's.
        /// </summary>
        /// <param name="bitArray">The BitArray to convert.</param>
        /// <returns>
        /// A string where each bit in the array is represented as '1' for true and '0' for false, in sequence.
        /// </returns>
        public static string ToBinary( this BitArray bitArray )
        {
            string result = string.Empty;
            foreach( bool bit in bitArray )
                result += bit ? "1" : "0";
            return result;
        }

        /// <summary>
        /// Appends the specified BitArray instances to the end of the current BitArray
        /// </summary>
        /// <param name="bitArray">The original BitArray to which other arrays will be appended.</param>
        /// <param name="arrays">One or more BitArray instances to append.</param>
        /// <returns>
        /// A new BitArray containing the bits of the original array followed by all appended arrays.
        /// </returns>
        /// <remarks>
        /// This method does not modify the original BitArray; instead, it returns a combined copy.
        /// </remarks>
        public static BitArray AppendBitArray( this BitArray bitArray , params BitArray[] arrays )
        {
            if( arrays == null || arrays.Length == 0 )
                return bitArray;

            int totalLength = bitArray.Length + arrays.Sum( a => a.Length );
            BitArray result = new BitArray( totalLength );
            int offset = 0;

            // Copy original bits
            for( int i = 0 ; i < bitArray.Length ; i++ )
                result[ offset++ ] = bitArray[ i ];

            // Copy appended arrays
            foreach( var array in arrays )
            {
                for( int i = 0 ; i < array.Length ; i++ )
                    result[ offset++ ] = array[ i ];
            }

            return result;
        }
    }
}