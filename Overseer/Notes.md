<<//...
OPENING FILE

OVERSEER AUTHORIZATION PASSKEY ALS2020OS

BEGIN FILE [NOTES_MD]
Medi language syntax aims to be human readable, but places a higher emphasis on identification than human readability. 
It veers from C-based language syntax, using a markup similar to HTML & XML for notation, but without the extensive necessity of tags.

Comments
--------
Single-line comments are opened using an angle-bracket+bang combination, as below. They are closed with an angle-bracket.
By convention, these should be spaced from the comment within the braces by a single space, though this is not required.
This structure also allows a single-line comment to occur _within_ a single line.
<! THIS IS A SINGLE-LINE COMMENT >

Multi-line comments are opened using the stream opening brace (<<), followed by two dashes (--). They are closed with the inverse of two
dashes, followed by the stream closing brace (>>).
By convention, these braces should be separated from the contents of the comment by two newlines, though this is not required. All of
the following comments are parsed the same way.
<<--

THIS IS A
MULTI-LINE
COMMENT

-->>
<<--
THIS IS A MULTI-LINE COMMENT
-->>
<<--THIS IS A MULTI-
LINE COMMENT-->>
<<--THIS IS A MULTI-LINE COMMENT-->>

Data Types
----------
### Integral Types ###
Medi Language specifies the following integral data types:

bit   - A bit is a single binary value, often representing ON/OFF, TRUE/FALSE, or 0/1.
son   - A SON is a Medi-unique trinary value, represented by two bits. These are often represented as 00, 0x1, and 11, and can be used to represent
		values where binary is inappropriate or inefficient, such as in the case of SOME, OTHER, and NONE (from which its name is derived).
byte  - A byte is a collection of eight bits, capable of representing the numbers 0 - 255.
utf	  - A utf is the Medi equivalent of a char. A four-byte (32-bit) value representing a single UTF8 character of the range U+0000 to U+D2FF, and 
		U+E000 to U+FF0000.

### Scalar Types ###
Medi Language specifies the following scalar data types:

u8	  - A single byte of data, representing an unsigned integer between 0 and 255, inclusive.
int	  - Four bytes, representing the values of -2,147,483,648 to 2,147,483,647. Integers are signed by default, though they can be declared as 
		unsigned using the `unsigned` modifier.
float - An eight byte value representing a floating-point decimal value of double precision.

### Compound Types ###
Medi Languages specifies the following compound data types:

array - An array is a collection of values that are all of the same type. Arrays are represented using array notation, which is a value enclosed
		in square braces, and separated from other values by a slash. Medi defines an array as a homogenous collection of data of the same type 
		that is contiguous in memory, such as [1/2/3] or ["apples"/"lemons"/"oranges"]
tuple - A tuple is a collection of values that are of varying types. Tuples are represented using tuple notation, which is a value enclosed by
		parenthetical braces, and separated from other values by a comma, such as (0, 255, 255) or ('a', "name", 127f).

Variables
---------
