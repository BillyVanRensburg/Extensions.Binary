using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Binary
{
    internal class Constant
    {
        public const int byte0 = 0;                                             // Byte index for 1 byte
        public const int byte1 = 1;                                             // Byte index for 2 bytes
        public const int byte2 = 2;                                             // Byte index for 3 bytes
        public const int byte3 = 3;                                             // Byte index for 4 bytes
        public const int byte4 = 4;                                             // Byte index for 5 bytes
        public const int byte5 = 5;                                             // Byte index for 6 bytes
        public const int byte6 = 6;                                             // Byte index for 7 bytes
        public const int byte7 = 7;                                             // Byte index for 8 bytes
        public const int byte8 = 8;                                             // Byte index for 9 bytes
        public const int byte9 = 9;                                             // Byte index for 10 bytes
        public const int byte10 = 10;                                           // Byte index for 11 bytes
        public const int byte11 = 11;                                           // Byte index for 12 bytes
        public const int byte12 = 12;                                           // Byte index for 13 bytes
        public const int byte13 = 13;                                           // Byte index for 14 bytes
        public const int byte14 = 14;                                           // Byte index for 15 bytes
        public const int byte15 = 15;                                           // Byte index for 16 bytes

        public const int byte1Size = 8;                                         // Size in bits of 1 byte  
        public const int byte2Size = 16;                                        // Size in bits of 2 bytes
        public const int byte4Size = 32;                                        // Size in bits of 4 bytes
        public const int byte8Size = 64;                                        // Size in bits of 8 bytes
        public const int byte12Size = 96;                                       // Size in bits of 12 bytes
        public const int byte16Size = 128;                                      // Size in bits of 16 bytes

        public const int byte1Index = 8;                                        // Starting index of byte 1 in the bit array
        public const int byte2Index = 16;                                       // Starting index of byte 2 in the bit array
        public const int byte3Index = 24;                                       // Starting index of byte 3 in the bit array
        public const int byte4Index = 32;                                       // Starting index of byte 4 in the bit array
        public const int byte5Index = 40;                                       // Starting index of byte 5 in the bit array
        public const int byte6Index = 48;                                       // Starting index of byte 6 in the bit array
        public const int byte7Index = 56;                                       // Starting index of byte 7 in the bit array
        public const int byte8Index = 64;                                       // Starting index of byte 8 in the bit array
        public const int byte9Index = 72;                                       // Starting index of byte 9 in the bit array
        public const int byte10Index = 80;                                      // Starting index of byte 10 in the bit array
        public const int byte11Index = 88;                                      // Starting index of byte 11 in the bit array
        public const int byte12Index = 96;                                      // Starting index of byte 12 in the bit array
        public const int byte13Index = 104;                                     // Starting index of byte 13 in the bit array
        public const int byte14Index = 112;                                     // Starting index of byte 14 in the bit array
        public const int byte15Index = 120;                                     // Starting index of byte 15 in the bit array

        public const int int1Index = 32;                                              // Starting index of int 1 in the bit array
        public const int int2Index = 64;                                              // Starting index of int 2 in the bit array
        public const int int3Index = 96;                                              // Starting index of int 3 in the bit array

        public const int signInt128 = 127;                                      // Sign bit for 128-bit integer

        public const int bits5 = 5;                                             // Size in bits of 5 bits
        public const int bits8 = 8;                                             // Size in bits of 8 bits
        public const int bits16 = 16;                                           // Size in bits of 16 bits
        public const int bits24 = 24;                                           // Size in bits of 24 bits
        public const int bits32 = 32;                                           // Size in bits of 32 bits
        public const int bits40 = 40;                                           // Size in bits of 40 bits
        public const int bits48 = 48;                                           // Size in bits of 48 bits
        public const int bits56 = 56;                                           // Size in bits of 56 bits
        public const int bits64 = 64;                                           // Size in bits of 64 bits
        public const int bits72 = 72;                                           // Size in bits of 72 bits
        public const int bits80 = 80;                                           // Size in bits of 80 bits
        public const int bits88 = 88;                                           // Size in bits of 88 bits
        public const int bits96 = 96;                                           // Size in bits of 96 bits
        public const int bits104 = 104;                                         // Size in bits of 104 bits
        public const int bits112 = 112;                                         // Size in bits of 112 bits
        public const int bits120 = 120;                                         // Size in bits of 120 bits

        public const int mantissaByteSize = 12;                                 // Mantissa byte size for floating-point numbers
        public const int mantissaIntSize = 3;                                   // Mantissa integer size for floating-point numbers

        public const int mantissaBit1Index = 0;                                 // Starting index of mantissa bit 1 in the bit array
        public const int mantissaBit5Index = 4;                                 // Starting index of mantissa bit 5 in the bit array
        public const int mantissaBit9Index = 8;                                 // Starting index of mantissa bit 9 in the bit array

        public const int bytesInSort = 2;                                       // Size in bytes of short
        public const int bytesInInt = 4;                                        // Size in bytes of int
        public const int bytesInLong = 8;                                       // Size in bytes of long
        public const int bytesInInt128 = 16;                                    // Size in bytes of 128-bit integer
        public const int bytesInDecimal = 16;                                   // Size in bytes of decimal

        public const int bitsInByte = 8;                                        // Size in bits of a byte
        public const int bitsInShort = 16;                                      // Size in bits of a short
        public const int bitsInInt = 32;                                        // Size in bits of an int
        public const int bitsInLong = 64;                                       // Size in bits of a long
        public const int bitsInInt128 = 128;                                    // Size in bits of a 128-bit integer
    }
}