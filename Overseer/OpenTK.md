# OpenTK #

## Chapter 1 ##

### Handles ###
A handle is an integer representing where the object lives on the graphics card. It's akin to a pointer--it can't be utilized directly, but it can be sent to OpenGL functions that need them.

Vertex Buffer Object (VBO) - Allows data to be delivered in bulk.

Vertex Array Object - 

### Normalized Device Coordinates ###
In Normalized Device Coordinates (NDC), (x:0, y:0) represents the point at the center of the screen.
- Negative X moves the point to the left, while positive X moves it to the right.
- Negative Y moves the point down, while positive Y moves it up.
- OpenGL only supports 3D rendering, so 2D positioning requires setting the Z point to 0.

### Normalized Colors ###
Under Normalized Colors, a color is a range between 0.0 to 1.0, with 0.0 representing black,
and 1.0 representing the largest possible value for the given channel. For example:

```
(0.2f, 0.3f, 0.3f, 1.0f)
----- ----- ----- -----
  R     G     B     A
```

The above color is a deep green.

