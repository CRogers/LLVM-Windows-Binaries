Compiling Windows Binaries
===

Hold on to you hats, we're in for a wild ride. First let's get the necessary tools; we're only going to cover build on Windows (no cross-compiling) using Visual Studio.

1. Install Visual Studio 2012.
2. Install the latest [CMake](http://www.cmake.org/) and make sure `cmake.exe` is on your path.

Now to get the source code

3. Grab the source for 3.3 from [the LLVM download page](http://llvm.org/releases/download.html#3.3) - get the `LLVM source code` ([direct link](http://llvm.org/releases/3.3/llvm-3.3.src.tar.gz)) and put it in a new folder (say `compiling`).
4. Extract the `.tar.gz` to `compiling` - you'll end up with a folder called `llvm-3.3.src` containing the source.
5. In `compiling`, make a new folder called `llvm-3.3.cmake`.

Your folder structure should now look like this:

    compiling/
    |- llvm-3.3.cmake/
    |- llvm-3.3.src/
       |- autoconf/
       |- bindings/
       ....

Fire up `cmd.exe` (or msys, or whatever you prefer) and do the following:

6. `cd llvm-3.3.cmake`
7. `cmake -G "Visual Studio 11" ../llvm-3.3.src` (you can replace the version number fo different visual studios). Wait for it to finish it's work.
8. There should now be a solution and a lot of projects in the folder. Open `LLVM.sln` in Visual Studio.

Choose whether you want to do a Debug or Release build - for Debug, leave as is, for Release: Build menu item > Configuration Manager > Active solution configuration to Release. If you chose Release replace all instances of `Debug` below with `Release`.

9. To build the tools, go to Build > Build Solution.
10. Make dinner, this will take a long time.
11. Your tools will be in `llvm-3.3.cmake/bin/Debug/`.

Compiling Shared Library
===

Here's where it gets fun. Building shared libraries is not supported on Windows. Why not? The developers decided not to have `EXPORT` macros or `declspec(export)`s lying all around their code, which means there are no public symbols. So we can't just link everything together into a DLL. First, we must rebuild the symbols, put them in a `.def` file then link everything back together to a DLL.

1. Build the tools as in the section above.
2. Open a "Developer Command Prompt for VS2012" by going to Start Menu > All Programs > Microsoft Visual Studio 2012 > Visual Studio Tools.
2. cd to `llvm-3.3.cmake/lib/Debug`.
3. `lib /OUT:big.lib LLVM*.lib`. This combines all the individual LLVM libs into one big one called `big.lib`.
4. Download the `LibDefExtractor.exe` tool from [the github page](https://github.com/CRogers/LLVM-Windows-Binaries/tree/v3.3-dev) and place it in `lib/Debug`.
5. `LibDefExtractor big.lib LLVM-3.3.def`. Extracts the non-C++ symbols to a DEF file called `LLVM-3.3.def`

If we try and link now, it will complain about a missing `DllMain` method, so we must make one.

6. Grab the code from [the EmptyDllMain github](https://github.com/CRogers/EmptyDllMain/) and build it in VS2012.
7. Copy the `EmptyDllMain.lib` to `lib/Debug`.
8. `link /DLL /DEF:LLVM-3.3.def /OUT:LLVM-3.3.dll big.lib EmptyDllMain.lib kernel32.lib user32.lib gdi32.lib winspool.lib shell32.lib ole32.lib oleaut32.lib uuid.lib comdlg32.lib advapi32.lib`
9. A DLL ~25mb should be built - if it very small something has gone wrong.

**CONGRATULATIONS**


Make an issues if you have problems, or a pull request if you think this can be improved.