using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Binary
{
    internal static class InsertBytesInArrayExtensions
    {
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
        public static BitArray InsertBytesInArray( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB , int AmountOfBytes = Constant.bytesInSort )
        {
            BitArray result = new( AmountOfBytes * Constant.bits8 );

            if( AmountOfBytes > Constant.byte0 ) 
                result.InsertArray( bitArray.GetByteFromArray( startIndex , bitOrder ) );

            if( AmountOfBytes > Constant.byte1 ) 
                result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte1Index , bitOrder ) , Constant.byte1Index );

            if( AmountOfBytes > Constant.byte2 ) 
                result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte2Index , bitOrder ) , Constant.byte2Index );

            if( AmountOfBytes > Constant.byte3 ) 
                result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte3Index , bitOrder ) , Constant.byte3Index );

            if( AmountOfBytes > Constant.byte4 ) 
                result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte4Index , bitOrder ) , Constant.byte4Index );
            
            if( AmountOfBytes > Constant.byte5 ) 
                result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte5Index , bitOrder ) , Constant.byte5Index );

            if( AmountOfBytes > Constant.byte6 ) 
                result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte6Index , bitOrder ) , Constant.byte6Index );
            
            if( AmountOfBytes > Constant.byte7 ) 
                result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte7Index , bitOrder ) , Constant.byte7Index );

            if( AmountOfBytes > Constant.byte8 ) 
                result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte8Index , bitOrder ) , Constant.byte8Index );

            if( AmountOfBytes > Constant.byte9 ) 
                result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte9Index , bitOrder ) , Constant.byte9Index );

            if( AmountOfBytes > Constant.byte10 ) 
                result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte10Index , bitOrder ) , Constant.byte10Index );

            if( AmountOfBytes > Constant.byte11 ) 
                result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte11Index , bitOrder ) , Constant.byte11Index );
            
            if( AmountOfBytes > Constant.byte12 ) 
                result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte12Index , bitOrder ) , Constant.byte12Index );
            
            if( AmountOfBytes > Constant.byte13 ) 
                result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte13Index , bitOrder ) , Constant.byte13Index );

            if( AmountOfBytes > Constant.byte14 ) 
                result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte14Index , bitOrder ) , Constant.byte14Index );

            if( AmountOfBytes > Constant.byte15 ) 
                result.InsertArray( bitArray.GetByteFromArray( startIndex + Constant.byte15Index , bitOrder ) , Constant.byte15Index );

            return result;
        }
    }
}