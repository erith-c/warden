3283111108105116117100101

<<//Stream//>>
<<//...		<! Opening Stream
...//>>		<! Closing Stream

<<//Stream[FILE]//>>
<<//[FILE]...	<! Opening Stream
...[FILE]//>>	<! Closing Stream

<<//...
<<--Notes made here-->>

<<Query
Prompt>>

Root.Parent.Child{{ <Code goes here> }}

<<--Scope Identifiers-->>
global  <! document/program scope
local   <! local scope
public  <! public access, anything
guard   <! protected access, only children
private <! private access, only itself
@param  <! operation-specific scope & access

<<--Modification Identifiers-->>
const   <! constant value. Cannot be modified.
mut     <! mutable value. Can be modified.
static  <! static value. Can be modified, but persists beyond the enclosing scope's lifetime

<<--Type Identifiers-->>
<<--  Scalar  -->>
Bit      <! On/Off value represented as a 1 or a 0
Tri      <! Two bits. Some/None/Other value represented as the values 00, 0x1, and 11
Byte     <! Eight bits. Can represent any ASCII letter or any number between the values of 0 and 255 (unsigned) or -128 and 127 (signed)
Int/UInt <! 32-bit number. Can represent any number between the values of 0 and 4,294,967,295 (unsigned) or -2,147,483,648 and 2,147,483,647 (signed)
Double   <! 64-bit number. Has double precision.
Utf      <! 4-byte symbol representing a Unicode scalar value between U+0000 to U+D7FF, and U+E000 to U+10FFFF
<<--  Complex -->>
Abstract <! Warden equivalent of an enumeration. Abstractly represents another piece of data not represented by a scalar type.
Array    <! A contiguous collection of values of the same type, such as [1/2/3] or [["apple"/"banana"/"orange"]]
Tuple    <! A non-contiguous collection of values of variable types, such as (1, true) or (0, 196, 196)


<<--Operation Identifiers-->>
Oper[T]	<! Oper takes the place of "func" or "function" in other languages, returning a result of type T. Unlike in C-based and other programming languages, parameters are not declared in parentheses.>
Void	<! Void is a function that returns null. >
Option	<! A special type of function that returns a trit.>