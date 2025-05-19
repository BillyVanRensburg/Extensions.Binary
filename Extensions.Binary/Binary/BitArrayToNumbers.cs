using System.Collections;

namespace Extensions.Binary
{
    /// <summary>
    /// Methods to convert BitArray to numbers
    /// </summary>
    public static class BitArrayToNumbersExtensions
    {
        /// <summary>
        /// Converts a BitArray to a byte value.
        /// </summary>
        /// <param name="bitArray">The BitArray to convert.</param>
        /// <param name="startIndex">The starting index in the BitArray. Defaults to 0.</param>
        /// <param name="bitOrder">The bit order of the BitArray. Defaults to LSB.</param>
        /// <returns>The byte value represented by the BitArray.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the start Index is out of range.</exception>
        /// <exception cref="ArgumentException">Thrown if there are not enough bits remaining in the BitArray to form a byte.</exception>
        /// <exception cref="Exception">Thrown if an unexpected error occurs during conversion.</exception>
        public static byte ToByte( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB )
        {
            BitArray result = new( Constant.byte1Size );

            try 
            {
                result.InsertArray( bitArray.GetByteFromArray( startIndex , bitOrder )); 
            }

            catch( ArgumentOutOfRangeException ex ) 
            {
                throw new ArgumentOutOfRangeException( nameof( startIndex ) , ex.Message );
            }

            catch( ArgumentException ex )
            {
                throw new ArgumentException( ex.Message );
            }

            catch( Exception ex )
            {
                throw new Exception( "An unexpected error occurred while converting BitArray to byte." , ex );
            }

            return result.CalculateByteFromArray();
        }

        /// <summary>
        /// Converts a BitArray to a sbyte value.
        /// </summary>
        /// <param name="bitArray">The BitArray to convert</param>
        /// <param name="startIndex">The starting index in the BitArray. Defaults to 0.</param>
        /// <param name="bitOrder">The bit order of the BitArray. Defaults to LSB</param>
        /// <returns>The sbyte value represented by the BitArray.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the start Index is out of range.</exception>
        /// <exception cref="ArgumentException">Thrown if there are not enough bits remaining in the BitArray to form a sbyte.</exception>
        /// <exception cref="Exception">Thrown if an unexpected error occurs during conversion.</exception>
        public static sbyte ToSByte( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB )
        {
            sbyte result;

            try
            {
                result = ( sbyte )bitArray.ToByte( startIndex , bitOrder );
            }

            catch( ArgumentOutOfRangeException ex )
            {
                throw new ArgumentOutOfRangeException( nameof( startIndex ) , ex.Message );
            }

            catch( ArgumentException ex )
            {
                throw new ArgumentException( ex.Message );
            }

            catch( Exception ex )
            {
                throw new Exception( "An unexpected error occurred while converting BitArray to sbyte." , ex );
            }

            return result;
        }

        /// <summary>
        /// Converts a BitArray to a ushort value.
        /// </summary>
        /// <param name="bitArray">The BitArray to convert</param>
        /// <param name="startIndex">The starting index in the BitArray. Defaults to 0.</param>
        /// <param name="bitOrder">The bit order of the BitArray. Defaults to LSB</param>
        /// <param name="byteOrder">The byte order of the BitArray. Defaults to LittleEndian</param>
        /// <returns>The ushort value represented by the BitArray.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the start Index is out of range.</exception>
        /// <exception cref="ArgumentException">Thrown if there are not enough bits remaining in the BitArray to form a ushort.</exception>
        /// <exception cref="Exception">Thrown if an unexpected error occurs during conversion.</exception>
        public static ushort ToUShort( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            BitArray result = new( Constant.byte2Size );

            try
            {
                result = bitArray.InsertBytesInArray(startIndex, bitOrder);

                if( byteOrder == ByteOrder.BigEndian )
                {
                    result = result.ReverseBytesInUShort();
                }
            }

            catch( ArgumentOutOfRangeException ex )
            {
                throw new ArgumentOutOfRangeException( nameof( startIndex ) , ex.Message );
            }

            catch( ArgumentException ex )
            {
                throw new ArgumentException( ex.Message );
            }

            catch( Exception ex )
            {
                throw new Exception( "An unexpected error occurred while converting BitArray to ushort." , ex );
            }

            return result.CalculateUShortFromArray();
        }

        /// <summary>
        /// Converts a BitArray to a short value.
        /// </summary>
        /// <param name="bitArray">The BitArray to convert</param>
        /// <param name="startIndex">The starting index in the BitArray. Defaults to 0.</param>
        /// <param name="bitOrder">The bit order of the BitArray. Defaults to LSB</param>
        /// <param name="byteOrder">The byte order of the BitArray. Defaults to LittleEndian</param>
        /// <returns>The short value represented by the BitArray.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the start Index is out of range.</exception>
        /// <exception cref="ArgumentException">Thrown if there are not enough bits remaining in the BitArray to form a short.</exception>
        /// <exception cref="Exception">Thrown if an unexpected error occurs during conversion.</exception>
        public static short ToShort( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            ushort result;

            try
            {
                result = bitArray.ToUShort( startIndex , bitOrder , byteOrder );
            }

            catch( ArgumentOutOfRangeException ex )
            {
                throw new ArgumentOutOfRangeException( nameof( startIndex ) , ex.Message );
            }

            catch( ArgumentException ex )
            {
                throw new ArgumentException( ex.Message );
            }

            catch( Exception ex )
            {
                throw new Exception( "An unexpected error occurred while converting BitArray to ushort." , ex );
            }

            return ( short )result;
        }

        /// <summary>
        /// Converts a BitArray to a uint value.
        /// </summary>
        /// <param name="bitArray">The BitArray to convert</param>
        /// <param name="startIndex">The starting index in the BitArray. Defaults to 0.</param>
        /// <param name="bitOrder">The bit order of the BitArray. Defaults to LSB</param>
        /// <param name="byteOrder">The byte order of the BitArray. Defaults to LittleEndian</param>
        /// <returns>The uint value represented by the BitArray.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the start Index is out of range.</exception>
        /// <exception cref="ArgumentException">Thrown if there are not enough bits remaining in the BitArray to form a uint.</exception>
        /// <exception cref="Exception">Thrown if an unexpected error occurs during conversion.</exception>
        public static uint ToUInt( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            BitArray result = new( Constant.byte4Size );

            try
            {
                result = bitArray.InsertBytesInArray(startIndex, bitOrder, Constant.bytesInInt);

                if ( byteOrder == ByteOrder.BigEndian )
                {
                    result = result.ReverseBytesInUInt();
                }
            }

            catch( ArgumentOutOfRangeException ex )
            {
                throw new ArgumentOutOfRangeException( nameof( startIndex ) , ex.Message );
            }

            catch( ArgumentException ex )
            {
                throw new ArgumentException( ex.Message );
            }

            catch( Exception ex )
            {
                throw new Exception( "An unexpected error occurred while converting BitArray to uint." , ex );
            }

            return result.CalculateUIntFromArray();
        }

        /// <summary>
        /// Converts a BitArray to a int value.
        /// </summary>
        /// <param name="bitArray">The BitArray to convert</param>
        /// <param name="startIndex">The starting index in the BitArray. Defaults to 0.</param>
        /// <param name="bitOrder">The bit order of the BitArray. Defaults to LSB</param>
        /// <param name="byteOrder">The byte order of the BitArray. Defaults to LittleEndian</param>
        /// <returns>The int value represented by the BitArray.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the start Index is out of range.</exception>
        /// <exception cref="ArgumentException">Thrown if there are not enough bits remaining in the BitArray to form a int.</exception>
        /// <exception cref="Exception">Thrown if an unexpected error occurs during conversion.</exception>
        public static int ToInt( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            uint result;

            try
            {
                result = bitArray.ToUInt( startIndex , bitOrder , byteOrder );
            }

            catch( ArgumentOutOfRangeException ex )
            {
                throw new ArgumentOutOfRangeException( nameof( startIndex ) , ex.Message );
            }

            catch( ArgumentException ex )
            {
                throw new ArgumentException( ex.Message );
            }

            catch( Exception ex )
            {
                throw new Exception( "An unexpected error occurred while converting BitArray to int." , ex );
            }

            return ( int )result;
        }

        /// <summary>
        /// Converts a BitArray to a ulong value.
        /// </summary>
        /// <param name="bitArray">The BitArray to convert</param>
        /// <param name="startIndex">The starting index in the BitArray. Defaults to 0.</param>
        /// <param name="bitOrder">The bit order of the BitArray. Defaults to LSB</param>
        /// <param name="byteOrder">The byte order of the BitArray. Defaults to LittleEndian</param>
        /// <returns>The ulong value represented by the BitArray.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the start Index is out of range.</exception>
        /// <exception cref="ArgumentException">Thrown if there are not enough bits remaining in the BitArray to form a ulong.</exception>
        /// <exception cref="Exception">Thrown if an unexpected error occurs during conversion.</exception>
        public static ulong ToULong( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            BitArray result = new( Constant.byte8Size );

            try
            {
                result = bitArray.InsertBytesInArray(startIndex, bitOrder, Constant.bytesInLong);

                if( byteOrder == ByteOrder.BigEndian )
                {
                    result = result.ReverseBytesInULong();
                }
            }

            catch( ArgumentOutOfRangeException ex )
            {
                throw new ArgumentOutOfRangeException( nameof( startIndex ) , ex.Message );
            }

            catch( ArgumentException ex )
            {
                throw new ArgumentException( ex.Message );
            }

            catch( Exception ex )
            {
                throw new Exception( "An unexpected error occurred while converting BitArray to ulong." , ex );
            }

            return result.CalculateULongFromArray();
        }

        /// <summary>
        /// Converts a BitArray to a long value.
        /// </summary>
        /// <param name="bitArray">The BitArray to convert</param>
        /// <param name="startIndex">The starting index in the BitArray. Defaults to 0.</param>
        /// <param name="bitOrder">The bit order of the BitArray. Defaults to LSB</param>
        /// <param name="byteOrder">The byte order of the BitArray. Defaults to LittleEndian</param>
        /// <returns>The long value represented by the BitArray.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the start Index is out of range.</exception>
        /// <exception cref="ArgumentException">Thrown if there are not enough bits remaining in the BitArray to form a long.</exception>
        /// <exception cref="Exception">Thrown if an unexpected error occurs during conversion.</exception>
        public static long ToLong( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            ulong result;

            try
            {
                result = bitArray.ToULong( startIndex , bitOrder , byteOrder );
            }

            catch( ArgumentOutOfRangeException ex )
            {
                throw new ArgumentOutOfRangeException( nameof( startIndex ) , ex.Message );
            }

            catch( ArgumentException ex )
            {
                throw new ArgumentException( ex.Message );
            }

            catch( Exception ex )
            {
                throw new Exception( "An unexpected error occurred while converting BitArray to long." , ex );
            }

            return ( long )result;
        }

        /// <summary>
        /// Converts a BitArray to a uint128 value.
        /// </summary>
        /// <param name="bitArray">The BitArray to convert</param>
        /// <param name="startIndex">The starting index in the BitArray. Defaults to 0.</param>
        /// <param name="bitOrder">The bit order of the BitArray. Defaults to LSB</param>
        /// <param name="byteOrder">The byte order of the BitArray. Defaults to LittleEndian</param>
        /// <returns>The uint128 value represented by the BitArray.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the start Index is out of range.</exception>
        /// <exception cref="ArgumentException">Thrown if there are not enough bits remaining in the BitArray to form a uint128.</exception>
        /// <exception cref="Exception">Thrown if an unexpected error occurs during conversion.</exception>
        public static UInt128 ToUInt128( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            BitArray result = new( Constant.bitsInInt128 );

            try
            {
                result = bitArray.InsertBytesInArray( startIndex , bitOrder , Constant.bytesInInt128 );

                if ( byteOrder == ByteOrder.BigEndian )
                {
                    result = result.ReverseBytesInUInt128();
                }
            }

            catch ( ArgumentOutOfRangeException ex )
            {
                throw new ArgumentOutOfRangeException( nameof( startIndex ) , ex.Message );
            }

            catch ( ArgumentException ex )
            {
                throw new ArgumentException( ex.Message );
            }

            catch ( Exception ex )
            {
                throw new Exception( "An unexpected error occurred while converting BitArray to uint128." , ex );
            }

            return result.CalculateUInt128FromArray();
        }

        /// <summary>
        /// Converts a BitArray to a int128 value.
        /// </summary>
        /// <param name="bitArray">The BitArray to convert</param>
        /// <param name="startIndex">The starting index in the BitArray. Defaults to 0.</param>
        /// <param name="bitOrder">The bit order of the BitArray. Defaults to LSB</param>
        /// <param name="byteOrder">The byte order of the BitArray. Defaults to LittleEndian</param>
        /// <returns>The int128 value represented by the BitArray.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the start Index is out of range.</exception>
        /// <exception cref="ArgumentException">Thrown if there are not enough bits remaining in the BitArray to form a int128.</exception>
        /// <exception cref="Exception">Thrown if an unexpected error occurs during conversion.</exception>
        public static Int128 ToInt128( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            UInt128 result;

            try
            {
                result = bitArray.ToUInt128(startIndex, bitOrder, byteOrder);
            }

            catch( ArgumentOutOfRangeException ex )
            {
                throw new ArgumentOutOfRangeException( nameof( startIndex ) , ex.Message );
            }

            catch( ArgumentException ex )
            {
                throw new ArgumentException( ex.Message );
            }

            catch( Exception ex )
            {
                throw new Exception( "An unexpected error occurred while converting BitArray to int128." , ex );
            }

            return ( Int128 )result;
        }

        /// <summary>
        /// Converts a BitArray to a Half value.
        /// </summary>
        /// <param name="bitArray">The BitArray to convert</param>
        /// <param name="startIndex">The starting index in the BitArray. Defaults to 0.</param>
        /// <param name="byteOrder">The byte order of the BitArray. Defaults to LittleEndian</param>
        /// <returns>The Half value represented by the BitArray.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the startIndex is out of range.</exception>
        /// <exception cref="ArgumentException">Thrown if there are not enough bits remaining in the BitArray to form a Half.</exception>
        /// <exception cref="Exception">Thrown if an unexpected error occurs during conversion.</exception>
        public static Half ToHalf( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            short result;

            try
            {
                result = bitArray.ToShort( startIndex , bitOrder , byteOrder );
            }

            catch( ArgumentOutOfRangeException )
            {
                throw new ArgumentOutOfRangeException( nameof( startIndex ) , "Start index is out of range." );
            }

            catch( ArgumentException )
            {
                throw new ArgumentException( "Not enough bits remaining in the BitArray to form a Half." );
            }

            catch( Exception ex )
            {
                throw new Exception("An unexpected error occurred while converting BitArray to Half.", ex );
            }

            return BitConverter.ToHalf( BitConverter.GetBytes( result ));
        }

        /// <summary>
        /// Converts a BitArray to a float value.
        /// </summary>
        /// <param name="bitArray">The BitArray to convert</param>
        /// <param name="startIndex">The starting index in the BitArray. Defaults to 0.</param>
        /// <param name="byteOrder">The byte order of the BitArray. Defaults to LittleEndian</param>
        /// <returns>The float value represented by the BitArray.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the startIndex is out of range.</exception>
        /// <exception cref="ArgumentException">Thrown if there are not enough bits remaining in the BitArray to form a float.</exception>
        /// <exception cref="Exception">Thrown if an unexpected error occurs during conversion.</exception>
        public static float ToFloat( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            int result;

            try
            {
                result = bitArray.ToInt( startIndex , bitOrder , byteOrder );
            }

            catch( ArgumentOutOfRangeException )
            {
                throw new ArgumentOutOfRangeException( nameof( startIndex ) , "Start index is out of range." );
            }

            catch( ArgumentException )
            {
                throw new ArgumentException( "Not enough bits remaining in the BitArray to form a float." );
            }

            catch( Exception ex )
            {
                throw new Exception( "An unexpected error occurred while converting BitArray to float." , ex );
            }

            return BitConverter.ToSingle( BitConverter.GetBytes( result ));
        }

        /// <summary>
        /// Converts a BitArray to a double value.
        /// </summary>
        /// <param name="bitArray">The BitArray to convert</param>
        /// <param name="startIndex">The starting index in the BitArray. Defaults to 0.</param>
        /// <param name="byteOrder">The byte order of the BitArray. Defaults to LittleEndian</param>
        /// <returns>The double value represented by the BitArray.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the startIndex is out of range.</exception>
        /// <exception cref="ArgumentException">Thrown if there are not enough bits remaining in the BitArray to form a double.</exception>
        /// <exception cref="Exception">Thrown if an unexpected error occurs during conversion.</exception>
        public static double ToDouble( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            long result;

            try
            {
                result = bitArray.ToLong( startIndex , bitOrder , byteOrder );
            }

            catch( ArgumentOutOfRangeException )
            {
                throw new ArgumentOutOfRangeException( nameof( startIndex ) , "Start index is out of range." );
            }

            catch( ArgumentException )
            {
                throw new ArgumentException( "Not enough bits remaining in the BitArray to form a double." );
            }

            catch( Exception ex )
            {
                throw new Exception( "An unexpected error occurred while converting BitArray to double." , ex );
            }

            return BitConverter.ToDouble( BitConverter.GetBytes( result ));
        }

        /// <summary>
        /// Converts a BitArray to a decimal value.
        /// </summary>
        /// <param name="bitArray">The BitArray to convert</param>
        /// <param name="startIndex">The starting index in the BitArray. Defaults to 0.</param>
        /// <param name="byteOrder">The byte order of the BitArray. Defaults to LittleEndian</param>
        /// <returns>The decimal value represented by the BitArray.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the startIndex is out of range.</exception>
        /// <exception cref="ArgumentException">Thrown if there are not enough bits remaining in the BitArray to form a decimal.</exception>
        /// <exception cref="Exception">Thrown if an unexpected error occurs during conversion.</exception>
        public static decimal ToDecimal( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            decimal result;
        
            try
            {
                BitArray buildBitArray = new( Constant.byte16Size );
        
                buildBitArray = bitArray.InsertBytesInArray( startIndex , bitOrder , Constant.bytesInDecimal );

                if( byteOrder == ByteOrder.BigEndian )
                {
                    buildBitArray = buildBitArray.ReverseBytesInUInt128();
                }
        
                bitArray = buildBitArray;
        
                bool sign = bitArray[ Constant.signInt128 ];
        
                int exponent = 0;
                for( int i = 0 ; i < Constant.bits5 ; i++ )
                {
                    if( bitArray[ Constant.byte14Index + i ] )
                    {
                        exponent |= 1 << i;
                    }
                }
        
                byte scale = ( byte )(( exponent ));
        
                BitArray mantissaBits = new BitArray( Constant.byte12Size );
                for( int i = 0 ; i < Constant.byte12Size ; i++ )
                {
                    mantissaBits[ i ] = bitArray[ i ];
                }
        
                byte[] mantissaBytes = new byte[ Constant.mantissaByteSize ];
                mantissaBits.CopyTo( mantissaBytes , 0 );
        
                int[] mantissaInts = new int[ Constant.mantissaIntSize ];
                mantissaInts[0] = BitConverter.ToInt32(mantissaBytes, Constant.mantissaBit1Index );
                mantissaInts[1] = BitConverter.ToInt32(mantissaBytes, Constant.mantissaBit5Index );
                mantissaInts[2] = BitConverter.ToInt32(mantissaBytes, Constant.mantissaBit9Index );
        
                result = new decimal( mantissaInts[ 0 ] , mantissaInts[ 1 ] , mantissaInts[ 2 ] , sign , scale );
            }
        
            catch( ArgumentOutOfRangeException )
            {
                throw new ArgumentOutOfRangeException( nameof( startIndex ) , "Start index is out of range." );
            }
        
            catch( ArgumentException )
            {
                throw new ArgumentException( "Not enough bits remaining in the BitArray to form a decimal." );
            }
        
            catch( Exception ex )
            {
                throw new Exception( "An unexpected error occurred while converting BitArray to decimal." , ex );
            }
        
            return result;
        }
    }
}