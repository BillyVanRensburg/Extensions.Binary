using System.Collections;

namespace Extensions.Binary
{
    /// <summary>
    /// Methods to convert numbers to BitArrays
    /// </summary>
    public static class NumberToBitArrayExtensions
    {
        /// <summary>
        /// Converts a byte value to a BitArray, using the specified bit order.
        /// </summary>
        /// <param name="value">The byte value to convert.</param>
        /// <param name="bitOrder"> The bit order to use for the conversion. 
        /// Use BitOrder.LSB for least significant bit first (default), 
        /// or BitOrder.MSB for most significant bit first.
        /// </param>
        /// <returns>
        /// A BitArray representing the bits of the input byte in the specified order.
        /// </returns>
        public static BitArray ToBitArray( this byte value , BitOrder bitOrder = BitOrder.LSB )
        {
            BitArray bitArray = new( new[] { value } );

            if( bitOrder == BitOrder.MSB )
                bitArray = bitArray.ReverseBitsInByte();

            return bitArray;
        }

        /// <summary>
        /// Converts a sbyte value to a BitArray, using the specified bit order.
        /// </summary>
        /// <param name="value">The sbyte value to convert.</param>
        /// <param name="bitOrder"> The bit order to use for the conversion. 
        /// Use BitOrder.LSB for least significant bit first (default), 
        /// or BitOrder.MSB for most significant bit first.
        /// </param>
        /// <returns>
        /// A BitArray representing the bits of the input byte in the specified order.
        /// </returns>
        public static BitArray ToBitArray( this sbyte value , BitOrder bitOrder = BitOrder.LSB )
        {
            BitArray bitArray = new ( new[] { ( byte )value } );

            if( bitOrder == BitOrder.MSB )
                bitArray = bitArray.ReverseBitsInByte();
            
            return bitArray;
        }

        /// <summary>
        /// Converts a ushort value to a BitArray, using the specified bit order.
        /// </summary>
        /// <param name="value">The ushort value to convert.</param>
        /// <param name="bitOrder"> The bit order to use for the conversion. 
        /// Use BitOrder.LSB for least significant bit first (default), 
        /// or BitOrder.MSB for most significant bit first.
        /// </param>
        /// <returns>
        /// A BitArray representing the bits of the input ushort in the specified order.
        /// </returns>
        public static BitArray ToBitArray( this ushort value , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            BitArray bitArray = new( Constant.bitsInByte );
            byte SegmentA = ( byte )( value );
            byte SegmentB = ( byte )( value >> Constant.bits8 );

            bitArray = SegmentA.ToBitArray( bitOrder )
                .AppendBitArray( SegmentB.ToBitArray( bitOrder ));


            if( byteOrder == ByteOrder.BigEndian )
                bitArray = bitArray.ReverseBytesInUShort();
                    
            return bitArray;
        }

        /// <summary>
        /// Converts a short value to a BitArray, using the specified bit order.
        /// </summary>
        /// <param name="value">The short value to convert.</param>
        /// <param name="bitOrder"> The bit order to use for the conversion. 
        /// Use BitOrder.LSB for least significant bit first (default), 
        /// or BitOrder.MSB for most significant bit first.
        /// </param>
        /// <returns>
        /// A BitArray representing the bits of the input short in the specified order.
        /// </returns>
        public static BitArray ToBitArray( this short value , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            ushort result = ( ushort )value;
            return result.ToBitArray( bitOrder , byteOrder );
        }

        /// <summary>
        /// Converts a uint value to a BitArray, using the specified bit order.
        /// </summary>
        /// <param name="value">The uint value to convert.</param>
        /// <param name="bitOrder"> The bit order to use for the conversion. 
        /// Use BitOrder.LSB for least significant bit first (default), 
        /// or BitOrder.MSB for most significant bit first.
        /// </param>
        /// <returns>
        /// A BitArray representing the bits of the input uint in the specified order.
        /// </returns>
        public static BitArray ToBitArray( this uint value , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            BitArray bitArray = new( Constant.byte4Size );

            byte SegmentA = ( byte )( value );
            byte SegmentB = ( byte )( value >> Constant.bits8 );
            byte SegmentC = ( byte )( value >> Constant.bits16 );
            byte SegmentD = ( byte )( value >> Constant.bits24 );

            bitArray = SegmentA.ToBitArray( bitOrder )
                .AppendBitArray( SegmentB.ToBitArray( bitOrder ))
                .AppendBitArray( SegmentC.ToBitArray( bitOrder ))
                .AppendBitArray( SegmentD.ToBitArray( bitOrder ));

            if( byteOrder == ByteOrder.BigEndian )
                bitArray = bitArray.ReverseBytesInUInt();

            return bitArray;
        }

        /// <summary>
        /// Converts a int value to a BitArray, using the specified bit order.
        /// </summary>
        /// <param name="value">The int value to convert.</param>
        /// <param name="bitOrder"> The bit order to use for the conversion. 
        /// Use BitOrder.LSB for least significant bit first (default), 
        /// or BitOrder.MSB for most significant bit first.
        /// </param>
        /// <returns>
        /// A BitArray representing the bits of the input int in the specified order.
        /// </returns>
        public static BitArray ToBitArray( this int value , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            uint result = ( uint )value;
            return result.ToBitArray( bitOrder , byteOrder );
        }

        /// <summary>
        /// Converts a ulong value to a BitArray, using the specified bit order.
        /// </summary>
        /// <param name="value">The ulong value to convert.</param>
        /// <param name="bitOrder"> The bit order to use for the conversion. 
        /// Use BitOrder.LSB for least significant bit first (default), 
        /// or BitOrder.MSB for most significant bit first.
        /// </param>
        /// <returns>
        /// A BitArray representing the bits of the input ulong in the specified order.
        /// </returns>
        public static BitArray ToBitArray( this ulong value , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            BitArray bitArray = new( Constant.bitsInLong );
            byte SegmentA = ( byte )( value );
            byte SegmentB = ( byte )( value >> Constant.bits8 );
            byte SegmentC = ( byte )( value >> Constant.bits16 );
            byte SegmentD = ( byte )( value >> Constant.bits24 );
            byte SegmentE = ( byte )( value >> Constant.bits32 );
            byte SegmentF = ( byte )( value >> Constant.bits40 );
            byte SegmentG = ( byte )( value >> Constant.bits48 );
            byte SegmentH = ( byte )( value >> Constant.bits56 );

            bitArray = SegmentA.ToBitArray( bitOrder )
                .AppendBitArray( SegmentB.ToBitArray( bitOrder ))
                .AppendBitArray( SegmentC.ToBitArray( bitOrder ))
                .AppendBitArray( SegmentD.ToBitArray( bitOrder ))
                .AppendBitArray( SegmentE.ToBitArray( bitOrder ))
                .AppendBitArray( SegmentF.ToBitArray( bitOrder ))
                .AppendBitArray( SegmentG.ToBitArray( bitOrder ))
                .AppendBitArray( SegmentH.ToBitArray( bitOrder ));

            if( byteOrder == ByteOrder.BigEndian )
                bitArray = bitArray.ReverseBytesInULong();

            return bitArray;
        }

        /// <summary>
        /// Converts a long value to a BitArray, using the specified bit order.
        /// </summary>
        /// <param name="value">The long value to convert.</param>
        /// <param name="bitOrder"> The bit order to use for the conversion. 
        /// Use BitOrder.LSB for least significant bit first (default), 
        /// or BitOrder.MSB for most significant bit first.
        /// </param>
        /// <returns>
        /// A BitArray representing the bits of the input long in the specified order.
        /// </returns>
        public static BitArray ToBitArray( this long value , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            ulong result = ( ulong )value;
            return result.ToBitArray( bitOrder , byteOrder );
        }

        /// <summary>
        /// Converts a UInt128 value to a BitArray, using the specified bit and byte order.
        /// </summary>
        /// <param name="value">The UInt128 value to convert.</param>
        /// <param name="bitOrder">
        /// The bit order to use for the conversion. 
        /// Use BitOrder.LSB for least significant bit first (default),
        /// or BitOrder.MSB for most significant bit first.
        /// </param>
        /// <param name="byteOrder">
        /// The byte order to use for the conversion. 
        /// Use ByteOrder.LittleEndian (default) or ByteOrder.BigEndian.
        /// </param>
        /// <returns>
        /// A BitArray representing the bits of the input UInt128 in the specified order.
        /// </returns>
        public static BitArray ToBitArray( this UInt128 value , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            BitArray bitArray = new( Constant.bitsInInt128 );

            byte SegmentA = ( byte )( value );
            byte SegmentB = ( byte )( value >> Constant.bits8 );
            byte SegmentC = ( byte )( value >> Constant.bits16 );
            byte SegmentD = ( byte )( value >> Constant.bits24 );
            byte SegmentE = ( byte )( value >> Constant.bits32 );
            byte SegmentF = ( byte )( value >> Constant.bits40 );
            byte SegmentG = ( byte )( value >> Constant.bits48 );
            byte SegmentH = ( byte )( value >> Constant.bits56 );
            byte SegmentI = ( byte )( value >> Constant.bits64 );
            byte SegmentJ = ( byte )( value >> Constant.bits72 );
            byte SegmentK = ( byte )( value >> Constant.bits80 );
            byte SegmentL = ( byte )( value >> Constant.bits88 );
            byte SegmentM = ( byte )( value >> Constant.bits96 );
            byte SegmentN = ( byte )( value >> Constant.bits104 );
            byte SegmentO = ( byte )( value >> Constant.bits112 );
            byte SegmentP = ( byte )( value >> Constant.bits120 );

            bitArray = SegmentA.ToBitArray( bitOrder )
                .AppendBitArray( SegmentB.ToBitArray( bitOrder ))
                .AppendBitArray( SegmentC.ToBitArray( bitOrder ))
                .AppendBitArray( SegmentD.ToBitArray( bitOrder ))
                .AppendBitArray( SegmentE.ToBitArray( bitOrder ))
                .AppendBitArray( SegmentF.ToBitArray( bitOrder ))
                .AppendBitArray( SegmentG.ToBitArray( bitOrder ))
                .AppendBitArray( SegmentH.ToBitArray( bitOrder ))
                .AppendBitArray( SegmentI.ToBitArray( bitOrder ))
                .AppendBitArray( SegmentJ.ToBitArray( bitOrder ))
                .AppendBitArray( SegmentK.ToBitArray( bitOrder ))
                .AppendBitArray( SegmentL.ToBitArray( bitOrder ))
                .AppendBitArray( SegmentM.ToBitArray( bitOrder ))
                .AppendBitArray( SegmentN.ToBitArray( bitOrder ))
                .AppendBitArray( SegmentO.ToBitArray( bitOrder ))
                .AppendBitArray( SegmentP.ToBitArray( bitOrder ));

            if( byteOrder == ByteOrder.BigEndian )
                bitArray = bitArray.ReverseBytesInUInt128();

            return bitArray;
        }

        /// <summary>
        /// Converts a int128 value to a BitArray, using the specified bit order.
        /// </summary>
        /// <param name="value">The int128 value to convert.</param>
        /// <param name="bitOrder"> The bit order to use for the conversion. 
        /// Use BitOrder.LSB for least significant bit first (default), 
        /// or BitOrder.MSB for most significant bit first.
        /// </param>
        /// <returns>
        /// A BitArray representing the bits of the input int128 in the specified order.
        /// </returns>
        public static BitArray ToBitArray( this Int128 value , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            UInt128 result = (UInt128)value;
            return result.ToBitArray(bitOrder, byteOrder);
        }

        /// <summary>
        /// Converts a Half value to a BitArray, using the specified bit order.
        /// </summary>
        /// <param name="value">The Half value to convert.</param>
        /// <param name="bitOrder"> The bit order to use for the conversion. 
        /// Use BitOrder.LSB for least significant bit first (default), 
        /// or BitOrder.MSB for most significant bit first.
        /// </param>
        /// <returns>
        /// A BitArray representing the bits of the input Half in the specified order.
        /// </returns>
        public static BitArray ToBitArray( this Half value , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            short result;

            result = BitConverter.HalfToInt16Bits( value );
            return result.ToBitArray( bitOrder , byteOrder );
        }

        /// <summary>
        /// Converts a float value to a BitArray, using the specified bit order.
        /// </summary>
        /// <param name="value">The float value to convert.</param>
        /// <param name="bitOrder"> The bit order to use for the conversion. 
        /// Use BitOrder.LSB for least significant bit first (default), 
        /// or BitOrder.MSB for most significant bit first.
        /// </param>
        /// <returns>
        /// A BitArray representing the bits of the input float in the specified order.
        /// </returns>
        public static BitArray ToBitArray( this float value , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            int result;

            result = BitConverter.SingleToInt32Bits( value );
            return result.ToBitArray( bitOrder , byteOrder );
        }

        /// <summary>
        /// Converts a double value to a BitArray, using the specified bit order.
        /// </summary>
        /// <param name="value">The double value to convert.</param>
        /// <param name="bitOrder"> The bit order to use for the conversion. 
        /// Use BitOrder.LSB for least significant bit first (default), 
        /// or BitOrder.MSB for most significant bit first.
        /// </param>
        /// <returns>
        /// A BitArray representing the bits of the input double in the specified order.
        /// </returns>
        public static BitArray ToBitArray( this double value , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            long result;

            result = BitConverter.DoubleToInt64Bits( value );
            return result.ToBitArray( bitOrder , byteOrder );
        }

        /// <summary>
        /// Converts a decimal value to a BitArray, using the specified bit order.
        /// </summary>
        /// <param name="value">The decimal value to convert.</param>
        /// <param name="bitOrder"> The bit order to use for the conversion. 
        /// Use BitOrder.LSB for least significant bit first (default), 
        /// or BitOrder.MSB for most significant bit first.
        /// </param>
        /// <returns>
        /// A BitArray representing the bits of the input decimal in the specified order.
        /// </returns>
        public static BitArray ToBitArray( this decimal value , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            BitArray bitArray = new( Constant.bitsInInt128 );
            
            BitArray intArraySegmentA = new( Constant.bitsInInt );
            BitArray intArraySegmentB = new( Constant.bitsInInt );
            BitArray intArraySegmentC = new( Constant.bitsInInt );
            BitArray intArraySegmentD = new( Constant.bitsInInt );
            
            int[] bits = decimal.GetBits( value );
            
            intArraySegmentA = bits[ 0 ].ToBitArray();
            intArraySegmentB = bits[ 1 ].ToBitArray();
            intArraySegmentC = bits[ 2 ].ToBitArray();
            intArraySegmentD = bits[ 3 ].ToBitArray();
            
            if( bitOrder == BitOrder.MSB )
            {
                intArraySegmentA = intArraySegmentA.ReverseBitsInInt();
                intArraySegmentB = intArraySegmentB.ReverseBitsInInt();
                intArraySegmentC = intArraySegmentC.ReverseBitsInInt();
                intArraySegmentD = intArraySegmentD.ReverseBitsInInt();
            }
            
            bitArray.InsertArray( intArraySegmentA );
            bitArray.InsertArray( intArraySegmentB , Constant.int1Index );
            bitArray.InsertArray( intArraySegmentC , Constant.int2Index );
            bitArray.InsertArray( intArraySegmentD , Constant.int3Index );
            
            if( byteOrder == ByteOrder.BigEndian )
                bitArray = bitArray.ReverseBytesInUInt128();
            
            return bitArray;
        }
    }
}