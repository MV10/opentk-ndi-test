
# opentk-ndi-test

Wires up the basics of [NDI](https://ndi.video/) send / receive of OpenGL textures.

The project accepts a `sender` or `receiver` command line argument to run either mode. An optional second argument specifies the device name. If not provided, the default name is "test". If your name contains spaces, wrap it in quotes. If a name is provided, an optional third argument can specify a comma-delimited list of NDI group names (in quotes if there are spaces).

> NOTE: Only the sender mode is working, receiver mode is a work in progress.

Send mode runs a simple plasma-color shader. Receive mode applies a ripple effect shader to the incoming texture. 

Uses Elias Puurunen's [NdiLibDotNetCoreBase](https://github.com/eliaspuurunen/NdiLibDotNetCoreBase) NDI v6.2 bindings. The NDI [tools](https://ndi.video/tools/) may be useful for working with this test. This project will redistribute the core NDI 6.2.1 DLL which gets deployed into the build directory. See the csproj for details.

Note this isn't a great reference for using Elias' NDI wrapper. I use the raw C++ API calls, but his package provides a C#-friendly wrapper around those calls.

Note that my [eyecandy](https://github.com/MV10/eyecandy) library is used as a convenience. It provides some basic functionality from the [OpenTK](https://github.com/opentk/opentk) windowing support, shader compilation, and uniform handling, but it's entirely incidental to the NDI processing. OpenTK itself is a thin wrapper around OpenGL and GLFW windowing APIs.

<img width="991" height="1284" alt="image" src="https://github.com/user-attachments/assets/6ea25d59-3331-4f9e-83a9-6f0065edd982" />
