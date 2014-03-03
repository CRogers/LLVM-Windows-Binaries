[LLVM 3.4 Windows Binaries](https://github.com/CRogers/LLVM-Windows-Binaries/)
===

Compiling LLVM on Windows is not straightforward. As of writing there is no Windows binary release for 3.4, and the tools does not compile 'out of the box' without some knowledge of CMake and a shared library is even more challenging to build. Luckily, we have done the work for you and packaged them up.

[**Click on releases for easy downloading.**](https://github.com/CRogers/LLVM-Windows-Binaries/releases)

Tools
---

The archive `llvm-3.4-tools-windows.7z` contains all the following tools:

`bugpoint`, `llc`, `lli-child-target`, `lli`, `llvm-ar`, `llvm-as`, `llvm-bcanalyzer`, `llvm-c-test`, `llvm-config`, `llvm-cov`, `llvm-diff`, `llvm-dis`, `llvm-dwarfdump`, `llvm-extract`, `llvm-link`, `llvm-lto`, `llvm-mc`, `llvm-mcmarkup`, `llvm-nm`, `llvm-objdump`, `llvm-ranlib`, `llvm-readobj`, `llvm-rtdyld`, `llvm-size`, `llvm-stress`, `llvm-symbolizer`, `llvm-tblgen`, `macho-dump`, `opt`

Shared Library
---

If you need a single shared library to use with projects that utilise LLVM's C API (such as the excellent [llvm-fs](https://github.com/fsharp/llvm-fs)) grab the file `llvm-3.4-shared-library-windows.7z`. Compiling it is... interesting.

Compiling Windows Binaries
---

Look at [the Compiling document](./compiling.md) for details of how to build the tools and **how to build a shared library**.