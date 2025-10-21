### LITERALS

- Literal values are fixed values that are directly written in the code.
- Examples of literals include:
	- Integer literals: `42`, `-7`, `0`
	- Unsigned integer literals: `42U`, `0u`
	- Long integer literals: `1234567890L`, `-9876543210l`
	- Unsigned long integer literals: `1234567890UL`, `0ul`
	- Floating-point literals: `3.14`, `-0.001`, `2.0e10`
	- Double literals: `3.14D`, `-0.001d`
	- Decimal literals: `19.99M`, `-0.01m`
	- Character literals: `'A'`, `'z'`, `'\n'`
	- String literals: `"Hello, World!"`, `"C# is fun!"`
	- Boolean literals: `true`, `false`

### BUILT-IN VALUE DATA TYPES

##### Integral Types

| Data Type | CLR Name | Size (bits) | Signed | Range | Literal Suffix |
|-----------|----------|-------------|--------|-------|---------------|
| byte | System.Byte | 8 | No | 0 to 255 | |
| sbyte | System.SByte | 8 | Yes | −128 to 127 | |
| ushort | System.UInt16 | 16 | No | 0 to 65,535 | |
| short | System.Int16 | 16 | Yes | −32,768 to 32,767 | |	
| uint | System.UInt32 | 32 | No | 0 to 4,294,967,295 | U or u |
| int | System.Int32 | 32 | Yes | −2,147,483,648 to 2,147,483,647 | |
| ulong | System.UInt64 | 64 | No | 0 to 18,446,744,073,709,551,615 | UL or ul |
| long | System.Int64 | 64 | Yes | −9,223,372,036,854,775,808 to 9,223,372,036,854,775,807 | L or l |

- For unsinged types, the range is from 0 to (2<sup>n</sup> - 1), where n is the number of bits.
- For singed types, the range is from -2<sup>n-1</sup> to (2<sup>n-1</sup> - 1), where n is the number of bits.

##### Floating-Point Types

| Data Type | CLR Name | Size (bits) | Precision | Range | Literal Suffix |
|-----------|----------|-------------|-----------|-------|----------------|
| float | System.Single | 32 | 23 bits (~7 decimal digits) | 1.5 × 10<sup>−45</sup> to 3.4 × 10<sup>38</sup> | F or f |
| double | System.Double | 64 | 52 bits (~15 decimal digits) | 5.0 × 10<sup>−324</sup> to 1.8 × 10<sup>308</sup> | D or d |

##### High Precision Floating Point Types
| Data Type | CLR Name | Size (bits) | Precision | Range | Literal Suffix |
|-----------|----------|-------------|-----------|-------|----------------|
| decimal | System.Decimal | 128 | 28-29 digits of precision | 1.0 × 10<sup>-28</sup> to approximately 7.9 × 10<sup>28</sup> | M or m |

##### Character Type

| Data Type | CLR Name | Size (bits) | Description |
|-----------|----------|-------------|-------------|
| char | System.Char | 16 | Single 16-bit Unicode character |

##### Boolean Type
| Data Type | CLR Name | Size (bits) | Description |
|-----------|----------|-------------|-------------|
| bool | System.Boolean | 4 | Boolean value: true or false |

##### Nullable Value Type
| Data Type | CLR Name | Description |
|-----------|----------|-------------|
| nullable | System.Nullable\<T\> | Value type that can also represent null |

### BUILT-IN REFERENCE DATA TYPES
| Data Type | CLR Name | Description |
|-----------|----------|-------------|
| object | System.Object | Base type for all data types |
| dynamic | System.Object | Resolved at runtime |
| string | System.String | Sequence of characters |
| array | System.Array | Collection of elements of the same type |
| nullable | System.Nullable\<T\> | Value type that can also represent null |

### CUSTOM VALUE DATA TYPES
| Data Type | CLR Name | Description |
|-----------|----------|-------------|
| struct | System.ValueType | Value type that can contain data and methods |
| enum | System.Enum | Distinct value type that consists of a set of named constants |
| tuple | System.ValueTuple | Data structure that can hold a fixed number of items of different types |
| record | System.Object | Reference type that provides built-in functionality for encapsulating data |

### CUSTOM REFERENCE DATA TYPES
| Data Type | CLR Name | Description |
|-----------|----------|-------------|
| class | System.Object | Blueprint for creating objects |
| interface | System.Interface | Contract that defines a set of methods and properties |
| delegate | System.Delegate | Reference type that encapsulates a method |

### BUILT-IN TYPES USING LITERALS

###### Interger Literals:
| Literal | TypeName | TypeFullName | BaseTypeFullName | BaseTypeBaseTypeFullName |
|---------|----------|--------------|------------------|--------------------------|
| 1	| Int32 | System.Int32 | System.ValueType | System.Object |
| 1U | UInt32 | System.UInt32 | System.ValueType | System.Object |
| 1L | Int64 | System.Int64 | System.ValueType | System.Object |
| 1UL | UInt64 | System.UInt64 | System.ValueType | System.Object |

###### Floating-Point Literals:
| Literal | TypeName | TypeFullName | BaseTypeFullName | BaseTypeBaseTypeFullName |
|---------|----------|--------------|------------------|--------------------------|
| 1.0F | Single | System.Single | System.ValueType | System.Object |
| 1.0 | Double | System.Double | System.ValueType | System.Object |
| 1.0D | Double | System.Double | System.ValueType | System.Object |
| 1.0M | Decimal | System.Decimal | System.ValueType | System.Object |

###### Character and String Literals:
| Literal | TypeName | TypeFullName | BaseTypeFullName | BaseTypeBaseTypeFullName |
|---------|----------|--------------|------------------|--------------------------|
| 'a' | Char | System.Char | System.ValueType | System.Object |
| "Hello C#!" | String | System.String | System.Object | NONE |

###### Boolean Literals:
| Literal | TypeName | TypeFullName | BaseTypeFullName | BaseTypeBaseTypeFullName |
|---------|----------|--------------|------------------|--------------------------|
| true | Boolean | System.Boolean | System.ValueType | System.Object |
| false | Boolean | System.Boolean | System.ValueType | System.Object |
