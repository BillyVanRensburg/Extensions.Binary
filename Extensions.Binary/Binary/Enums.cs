namespace Extensions.Binary
{
    /// <summary>
    /// Specifies the bit order to use when converting a BitArray.
    /// </summary>
    public enum BitOrder
    {
        /// <summary>
        /// Most significant bit first (leftmost bit).
        /// </summary>
        MSB,
        /// <summary>
        /// Least significant bit first (rightmost bit).
        /// </summary>
        LSB
    }

    /// <summary>
    /// Specifies the byte order to use when converting a BitArray
    /// </summary>
    public enum ByteOrder
    {
        /// <summary>
        /// Little-endian byte order (rightmost byte first).
        /// </summary>
        LittleEndian,
        /// <summary>
        /// Big-endian byte order (leftmost byte first).
        /// </summary>
        BigEndian,
    }

    /// <summary>
    /// Specifies the Unicode Encoding to use
    /// </summary>
    public enum UnicodeEncoding
    {
        /// <summary>
        /// UTF-8 encoding
        /// </summary>
        UTF8,
        /// <summary>
        /// UTF-16 encoding (system's native endianness).
        /// </summary>
        UTF16,
        /// <summary>
        /// UTF-32 encoding (system's native endianness).
        /// </summary>
        UTF32
    }
}