namespace Extensions.Binary
{
    /// <summary>
    /// Provides extension methods for numeric types to convert their values to binary string representation.
    /// </summary>
    public static class NumberToBinaryExtensions
    {
        /// <summary>
        /// Converts a byte value to its binary string representation.
        /// </summary>
        /// <param name="value">The byte value to convert.</param>
        /// <param name="bitOrder">
        /// The bit order to use for conversion. Defaults to BitOrder.LSB
        /// for least significant bit first.
        /// </param>
        /// <returns>A string representing the binary form of the input value.</returns>
        public static string ToBinary( this byte value , BitOrder bitOrder = BitOrder.LSB )
        {
            return value.ToBitArray( bitOrder ).ToBinary();
        }

        /// <summary>
        /// Converts an sbyte value to its binary string representation.
        /// </summary>
        /// <param name="value">The sbyte value to convert.</param>
        /// <param name="bitOrder">
        /// The bit order to use for conversion. Defaults to BitOrder.LSB
        /// for least significant bit first.
        /// </param>
        /// <returns>A string representing the binary form of the input value.</returns>
        public static string ToBinary( this sbyte value , BitOrder bitOrder = BitOrder.LSB )
        {
            return value.ToBitArray( bitOrder ).ToBinary();
        }

        /// <summary>
        /// Converts a ushort value to its binary string representation.
        /// </summary>
        /// <param name="value">The ushort value to convert.</param>
        /// <param name="bitOrder">
        /// The bit order to use for conversion. Defaults to BitOrder.LSB
        /// for least significant bit first.
        /// </param>
        /// <param name="byteOrder">
        /// The byte order to use for conversion. Defaults to ByteOrder.LittleEndian
        /// for little-endian byte order.
        /// </param>
        /// <returns>A string representing the binary form of the input value.</returns>
        public static string ToBinary( this ushort value , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            return value.ToBitArray( bitOrder , byteOrder ).ToBinary();
        }

        /// <summary>
        /// Converts a short value to its binary string representation.
        /// </summary>
        /// <param name="value">The short value to convert.</param>
        /// <param name="bitOrder">
        /// The bit order to use for conversion. Defaults to BitOrder.LSB
        /// for least significant bit first.
        /// </param>
        /// <param name="byteOrder">
        /// The byte order to use for conversion. Defaults to ByteOrder.LittleEndian
        /// for little-endian byte order.
        /// </param>
        /// <returns>A string representing the binary form of the input value.</returns>
        public static string ToBinary( this short value , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            return value.ToBitArray( bitOrder , byteOrder ).ToBinary();
        }

        /// <summary>
        /// Converts a uint value to its binary string representation.
        /// </summary>
        /// <param name="value">The uint value to convert.</param>
        /// <param name="bitOrder">
        /// The bit order to use for conversion. Defaults to BitOrder.LSB
        /// for least significant bit first.
        /// </param>
        /// <param name="byteOrder">
        /// The byte order to use for conversion. Defaults to ByteOrder.LittleEndian
        /// for little-endian byte order.
        /// </param>
        /// <returns>A string representing the binary form of the input value.</returns>
        public static string ToBinary( this uint value , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            return value.ToBitArray( bitOrder , byteOrder ).ToBinary();
        }

        /// <summary>
        /// Converts an int value to its binary string representation.
        /// </summary>
        /// <param name="value">The int value to convert.</param>
        /// <param name="bitOrder">
        /// The bit order to use for conversion. Defaults to BitOrder.LSB
        /// for least significant bit first.
        /// </param>
        /// <param name="byteOrder">
        /// The byte order to use for conversion. Defaults to ByteOrder.LittleEndian
        /// for little-endian byte order.
        /// </param>
        /// <returns>A string representing the binary form of the input value.</returns>
        public static string ToBinary( this int value , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            return value.ToBitArray( bitOrder , byteOrder ).ToBinary();
        }

        /// <summary>
        /// Converts a ulong value to its binary string representation.
        /// </summary>
        /// <param name="value">The ulong value to convert.</param>
        /// <param name="bitOrder">
        /// The bit order to use for conversion. Defaults to BitOrder.LSB
        /// for least significant bit first.
        /// </param>
        /// <param name="byteOrder">
        /// The byte order to use for conversion. Defaults to ByteOrder.LittleEndian
        /// for little-endian byte order.
        /// </param>
        /// <returns>A string representing the binary form of the input value.</returns>
        public static string ToBinary( this ulong value , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            return value.ToBitArray( bitOrder , byteOrder ).ToBinary();
        }

        /// <summary>
        /// Converts a long value to its binary string representation.
        /// </summary>
        /// <param name="value">The long value to convert.</param>
        /// <param name="bitOrder">
        /// The bit order to use for conversion. Defaults to BitOrder.LSB
        /// for least significant bit first.
        /// </param>
        /// <param name="byteOrder">
        /// The byte order to use for conversion. Defaults to ByteOrder.LittleEndian
        /// for little-endian byte order.
        /// </param>
        /// <returns>A string representing the binary form of the input value.</returns>
        public static string ToBinary( this long value , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            return value.ToBitArray( bitOrder , byteOrder ).ToBinary();
        }

        /// <summary>
        /// Converts a uint128 value to its binary string representation.
        /// </summary>
        /// <param name="value">The long value to convert.</param>
        /// <param name="bitOrder">
        /// The bit order to use for conversion. Defaults to BitOrder.LSB
        /// for least significant bit first.
        /// </param>
        /// <param name="byteOrder">
        /// The byte order to use for conversion. Defaults to ByteOrder.LittleEndian
        /// for little-endian byte order.
        /// </param>
        /// <returns>A string representing the binary form of the input value.</returns>
        public static string ToBinary( this UInt128 value , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            return value.ToBitArray( bitOrder , byteOrder ).ToBinary();
        }

        /// <summary>
        /// Converts a int128 value to its binary string representation.
        /// </summary>
        /// <param name="value">The long value to convert.</param>
        /// <param name="bitOrder">
        /// The bit order to use for conversion. Defaults to BitOrder.LSB
        /// for least significant bit first.
        /// </param>
        /// <param name="byteOrder">
        /// The byte order to use for conversion. Defaults to ByteOrder.LittleEndian
        /// for little-endian byte order.
        /// </param>
        /// <returns>A string representing the binary form of the input value.</returns>
        public static string ToBinary( this Int128 value , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            return value.ToBitArray( bitOrder , byteOrder ).ToBinary();
        }

        /// <summary>
        /// Converts a Half value to its binary string representation.
        /// </summary>
        /// <param name="value">The Half value to convert.</param>
        /// <param name="bitOrder">
        /// The bit order to use for conversion. Defaults to BitOrder.LSB
        /// for least significant bit first.
        /// </param>
        /// <param name="byteOrder">
        /// The byte order to use for conversion. Defaults to ByteOrder.LittleEndian
        /// for little-endian byte order.
        /// </param>
        /// <returns>A string representing the binary form of the input value.</returns>
        public static string ToBinary( this Half value , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            return value.ToBitArray( bitOrder , byteOrder ).ToBinary();
        }

        /// <summary>
        /// Converts a float value to its binary string representation.
        /// </summary>
        /// <param name="value">The float value to convert.</param>
        /// <param name="bitOrder">
        /// The bit order to use for conversion. Defaults to BitOrder.LSB
        /// for least significant bit first.
        /// </param>
        /// <param name="byteOrder">
        /// The byte order to use for conversion. Defaults to ByteOrder.LittleEndian
        /// for little-endian byte order.
        /// </param>
        /// <returns>A string representing the binary form of the input value.</returns>
        public static string ToBinary( this float value , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            return value.ToBitArray( bitOrder , byteOrder ).ToBinary();
        }

        /// <summary>
        /// Converts a double value to its binary string representation.
        /// </summary>
        /// <param name="value">The double value to convert.</param>
        /// <param name="bitOrder">
        /// The bit order to use for conversion. Defaults to BitOrder.LSB
        /// for least significant bit first.
        /// </param>
        /// <param name="byteOrder">
        /// The byte order to use for conversion. Defaults to ByteOrder.LittleEndian
        /// for little-endian byte order.
        /// </param>
        /// <returns>A string representing the binary form of the input value.</returns>
        public static string ToBinary( this double value , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            return value.ToBitArray( bitOrder , byteOrder ).ToBinary();
        }

        /// <summary>
        /// Converts a decimal value to its binary string representation.
        /// </summary>
        /// <param name="value">The decimal value to convert.</param>
        /// <param name="bitOrder">
        /// The bit order to use for conversion. Defaults to BitOrder.LSB
        /// for least significant bit first.
        /// </param>
        /// <param name="byteOrder">
        /// The byte order to use for conversion. Defaults to ByteOrder.LittleEndian
        /// for little-endian byte order.
        /// </param>
        /// <returns>A string representing the binary form of the input value.</returns>
        public static string ToBinary( this decimal value , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
        {
            return value.ToBitArray( bitOrder , byteOrder ).ToBinary();
        }
    }
}