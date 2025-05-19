# Extensions.Binary
[![.NET C#](https://img.shields.io/badge/.NET-C%23-blue)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![License: MIT](https://img.shields.io/badge/license-MIT-blue.svg)](https://opensource.org/licenses/MIT)
[![NuGet](https://img.shields.io/nuget/v/Extensions.Binary.svg)](https://www.nuget.org/packages/Extensions.Binary)

A C# extension library for enhancing `System.Collections.BitArray` functionality to add binary support to the `BitArray` class. This library provides methods to convert `BitArray` instances to binary strings, append multiple `BitArray` instances, and insert bits into an existing `BitArray`.

## Features

- `ToBitArray()` - Convert variables to binary bits stored in a BitArray.
- `ToBinary()` – Converts a `BitArray` to a string of `'1'`s and `'0'`s.
- `AppendBitArray()` – Appends one or more `BitArray` instances together.
- `InsertArray()` – Inserts bits into an existing `BitArray` at a specific index.
- `BitArray to values` - Converts a `BitArray` to a variable values.
- `LSB/MSB support` - Support for both Least Significant Bit (LSB) and Most Significant Bit (MSB) ordering.
- `LE/BE support` - Support for both Little Endian (LE) and Big Endian (BE) byte ordering.

## Supported variables types

- `byte`
- `sbyte`
- `short`
- `ushort`
- `int`
- `uint`
- `long`
- `ulong`
- `int128`
- `uint128`
- `half`
- `float`
- `double`
- `decimal`

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- Visual Studio or any C#-compatible IDE

### Installation
To start using the Extension.Binary library from scratch, you first need to install the main [NuGet package](https://www.nuget.org/packages/Extensions.Binary/) in the project you want to use the library and its components.
You can use the NuGet package manager in your IDE or use the following command when using a CLI:

```shell
dotnet add package Extensions.Binary
```

The following using directives are required to use the methods in this library:

```csharp
using System.Collections;
using Extensions.Binary;
```

### General Methods

#### InsertArray

Inserts the bits from one BitArray into another at a specified index.

__Parameters:__

*bitArray* – The target array to insert into.
*insertBitArray* – The source array to insert.
*insertIndex* – Zero-based index in bitArray where insertion begins. Defaults to 0.

__Exceptions:__

*ArgumentOutOfRangeException* – If insertIndex is outside the valid range
*ArgumentException* – If there's not enough space to insert all bits.

__Example:__

```csharp
var target = new BitArray(8); // all false
var insert = new BitArray(new[] { true, false, true });

target.InsertArray(insert, 2);

// Result: 00101000
```

#### ToBinary

Converts a BitArray to a binary string of '1's and '0's.

__Returns:__

A string with each bit represented as '1' (true) or '0' (false).

__Example:__

```csharp
var bits = new BitArray(new[] { true, false, true });
string binary = bits.ToBinary(); // "101"
```

#### AppendBitArray

Appends one or more BitArray instances to the end of another, producing a new combined array.

__Parameters:__

*bitArray* – The base array.
*arrays* – One or more arrays to append.

__Returns:__
A new BitArray combining the original and appended arrays.

__Notes:__
This method does not modify the original array.

__Example:__

```csharp
var a = new BitArray(new[] { true, false });
var b = new BitArray(new[] { false, true });

var result = a.AppendBitArray(b);
// result.ToBinary() => "1001"
```

### Numbers to BitArray

#### Supported Types

__Integral Types:__ byte, sbyte, short, ushort, int, uint, long, ulong, Int128, UInt128

__Floating-Point Types:__ Half, float, double, decimal

#### Parameters

| Parameter	Type | Description | Default |
|----------------|-------------|---------|
| bitOrder	BitOrder | Order of bits within each byte (LSB or MSB) | BitOrder.LSB |
| byteOrder	ByteOrder |	Order of bytes in the array (LittleEndian or BigEndian)	| ByteOrder.LittleEndian |

Both BitOrder and ByteOrder are enums used to control binary representation order.

#### Usage

```csharp
int number = 42;
BitArray bits = number.ToBitArray(BitOrder.MSB, ByteOrder.BigEndian);
```

#### Method List

```csharp
BitArray ToBitArray(this byte value, BitOrder bitOrder = LSB)
BitArray ToBitArray(this sbyte value, BitOrder bitOrder = LSB)
BitArray ToBitArray(this short value, BitOrder bitOrder = LSB, ByteOrder byteOrder = LittleEndian)
BitArray ToBitArray(this ushort value, BitOrder bitOrder = LSB, ByteOrder byteOrder = LittleEndian)
BitArray ToBitArray(this int value, BitOrder bitOrder = LSB, ByteOrder byteOrder = LittleEndian)
BitArray ToBitArray(this uint value, BitOrder bitOrder = LSB, ByteOrder byteOrder = LittleEndian)
BitArray ToBitArray(this long value, BitOrder bitOrder = LSB, ByteOrder byteOrder = LittleEndian)
BitArray ToBitArray(this ulong value, BitOrder bitOrder = LSB, ByteOrder byteOrder = LittleEndian)
BitArray ToBitArray(this Int128 value, BitOrder bitOrder = LSB, ByteOrder byteOrder = LittleEndian)
BitArray ToBitArray(this UInt128 value, BitOrder bitOrder = LSB, ByteOrder byteOrder = LittleEndian)
BitArray ToBitArray(this Half value, BitOrder bitOrder = LSB, ByteOrder byteOrder = LittleEndian)
BitArray ToBitArray(this float value, BitOrder bitOrder = LSB, ByteOrder byteOrder = LittleEndian)
BitArray ToBitArray(this double value, BitOrder bitOrder = LSB, ByteOrder byteOrder = LittleEndian)
BitArray ToBitArray(this decimal value, BitOrder bitOrder = LSB, ByteOrder byteOrder = LittleEndian)
```

#### Notes

BitOrder.MSB means bits are arranged from most significant bit to least within a byte.

ByteOrder.BigEndian arranges bytes from most significant byte to least.

Floating point types use their raw IEEE 754 bit layout.

decimal uses the internal .NET 128-bit structure: [flags, high, mid, low].

### BitArray to Numbers

#### Supported Types

__Integral Types:__ byte, sbyte, short, ushort, int, uint, long, ulong, Int128, UInt128

__Floating-Point Types:__ Half, float, double, decimal

#### Parameters

| Parameter	Type | Description | Default |
|----------------|-------------|---------|
| startIndex int | Starting index in the BitArray | 0 |
| bitOrder	BitOrder | Order of bits within each byte (LSB or MSB) | BitOrder.LSB |
| byteOrder	ByteOrder |	Order of bytes in the array (LittleEndian or BigEndian)	| ByteOrder.LittleEndian |

Both BitOrder and ByteOrder are enums used to control binary representation order.

#### Usage

```csharp
bool[] bits = new bool[]
{
    false, false, true, false,
    false, true, true, false,
    false, false, false, true,
    false, false, false, false
};

BitArray bitArray = new BitArray(bits);

int result = bitArray.ToShort(0, BitOrder.LSB, ByteOrder.LittleEndian);
```

#### Method List

```csharp
byte ToByte( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB )
sbyte ToSByte( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB )
ushort ToUShort( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
short ToShort( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
uint ToUInt( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
int ToInt( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
ulong ToULong( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
long ToLong( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
Int128 ToInt128( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
UInt128 ToUInt128( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
Half ToHalf( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
float ToFloat( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
double ToDouble( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
decimal ToDecimal( this BitArray bitArray , int startIndex = 0 , BitOrder bitOrder = BitOrder.LSB , ByteOrder byteOrder = ByteOrder.LittleEndian )
```

#### Notes

BitOrder.MSB means bits are arranged from most significant bit to least within a byte.

ByteOrder.BigEndian arranges bytes from most significant byte to least.

Floating point types use their raw IEEE 754 bit layout.

decimal uses the internal .NET 128-bit structure: [flags, high, mid, low].
