
# opentk-ndi-test

Wires up the basics of [NDI](https://ndi.video/) send / receive of OpenGL textures.

The project accepts a `sender` or `receiver` command line argument to run either mode. An optional second argument specifies the device name. If not provided, the default name is "test". If your name contains spaces, wrap it in quotes.

> NOTE: Work-in-progress, neither mode is working yet.

Send mode runs a simple plasma-color shader. Receive mode applies a ripple effect shader to the incoming texture. 

Uses Elias Puurunen's [NdiLibDotNetCoreBase](https://github.com/eliaspuurunen/NdiLibDotNetCoreBase) NDI v6.2 bindings. The NDI [tools](https://ndi.video/tools/) may be useful for working with this test.

Note that my [eyecandy](https://github.com/MV10/eyecandy) library is used as a convenience. It provides some basic functionality from the [OpenTK](https://github.com/opentk/opentk) windowing support, shader compilation, and uniform handling, but it's entirely incidental to the NDI processing. OpenTK itself is a thin wrapper around OpenGL and GLFW windowing APIs.

