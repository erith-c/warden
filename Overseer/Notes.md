<<//...  
OPENING FILE

OVERSEER AUTHORIZATION PASSKEY ALS2020OS

BEGIN FILE [NOTES_MD]

Medi is a strongly typed language.  
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
By convention, these braces should be separated from the contents of the comment by at least one newline, though this is not required. All of the following comments are parsed the same way.  
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
son   - A SON is a Medi-unique trinary value, represented by two bits.
  These are often represented as 00, 0x1, and 11, and can be used to represent values where binary is inappropriate or inefficient, such 
  as in the case of SOME, OTHER, and NONE (from which its name is derived).  
byte  - A byte is a collection of eight bits, capable of representing the numbers 0 - 255.  
utf   - A utf is the Medi equivalent of a char.
A four-byte (32-bit) value representing a single UTF8 character of the range U+0000 to U+D2FF, and U+E000 to U+FF0000.  

### Scalar Types ###
Medi Language specifies the following scalar data types:

u8    - A single byte of data, representing an unsigned integer between 0 and 255, inclusive.  
int   - Four bytes, representing the values of -2,147,483,648 to 2,147,483,647. Integers are signed by default, though they can be 
  declared as unsigned using the `unsigned` modifier.  
float - An eight byte value representing a floating-point decimal value of double precision.  

### Compound Types ###
Medi Languages specifies the following compound data types:

abstract - An abstract type is the medi equivalent of an enumeration, struct or class.  
array    - An array is a collection of values that are all of the same type. Arrays are represented using array notation, which is a 
  value enclosed in square braces, and separated from other values by a slash. Medi defines an array as a homogenous collection of data 
  of the same type that is contiguous in memory, such as [1/2/3] or ["apples"/"lemons"/"oranges"].  
tuple    - A tuple is a collection of values that are of varying types. Tuples are represented using tuple notation, which is a value
  enclosed by parenthetical braces, and separated from other values by a comma, such as (0, 255, 255) or ('a', "name", 127f).  

Identifiers
-----------
### Identifying Labels ###
Labels in medi are strongly typed, and must be declared before being used. A label can start with any letter or an underscore, and can 
  contain any combination of letters, numbers, underscores, or spaces. Uppercase and lowercase letters are parsed the same. This is a 
  major difference between medi and most other programming languages--the label My Operation is valid and distinct from MyOperation, but 
  MyOperation and Myoperation are parsed the same.

Labels are terminated with a colon, after which a value can be declared and assigned to the label.

Example:
```
<! Declares a u8 value of 5. >
My U8: var[u8] 5
<! Declares an int value of 1,000. >
My_Int: var[int] 1000
<<--
Declares an Option of type bit (0 or 1). Operations and Options are explained later.
    Note that the `?` operator is a unary operator identifying a conditional. Conditionals will be explained later.
	Also note that the `=>` is the return operator, signifies a value to be returned by the operation.
	The statements are separated by commas. For the sake of brevity, the entire option is put on one line,
	but a multi-line example will be provided later.
-->>
MyOption: Opt[bit] <<( Bool: @param[bit] ) Bool = 1? => (Some, Bool), Bool = 0? => (Other, Bool), => None >>
```

### Identifying Declarations ###
res[T]	- Reserves the size of the type provided as T. Used in the same cases as sizeof() in other languages.  
var[T]	- Assigns a value of type provided as T to an Identifying Label.  
Oper[T]	- Declares an Operation, the medi equivalent of a function. 
  Operations are defined utilizing the stream opening and closing operators (<< & >>), 
  with optional an optional set of parameters listed at the beginning of the Operation stream using parentheses.
  If an Operation must contain more than one statement, it can either be combined with other statements on the same line
  separated by commas, or set on different lines utilizing the block opening & closing operators (</ & />).  
Opt[T]	- Declares an Option of the type provided as T. Inspired by Rust Language's Option<T>, Opt[T] is a special Operation that 
  returns either a tuple containing a 0x1 or 11 value and some value of type T, or a 00 value.  
Void	- A function that returns null would use a Void Identifying Declaration.

Example:
```
<! Declares an Operation that takes two int values, adds them, and returns the result. >
Sum: Oper[int] <<( x: @param[int], y: @param[int] ) => x + y >>

Sum(3, 2)
<! Returns 5 >

<<--
Declares a Void Operation that sorts a provided List of type Int.
This example utilizes the blocker opening operator `</` and block closing operator `/>`
-->>
Sort: Void <<( numbers: @param[List[int]] )
for loop( _index = 0, numbers.Length )
</  if _index > 0?
    </  foreach (number in numbers)
        </  if numbers.at(_index) > number?
            </  swap(number, numbers.at(_index))  />
        />
    />
else next
/> >>
```

### Modifiers ###
#### Scope ####
global  
local  
public  
guard  
private  
@param  

#### Lifetime ####
const  
mut  
static  

END [NOTES_MD]  
...//>>
