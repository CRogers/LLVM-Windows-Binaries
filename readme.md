[LLVM 3.3 Windows Binaries](https://github.com/CRogers/LLVM-Windows-Binaries/)
===

Compiling LLVM on Windows is a hellish task; it is bad enough trying to build the tools, let alone a shared library (which involves much hackery and is officially unsupported). It seems the devs are scared too, since (as of writing) there is no Windows binary release for 3.3 and 3.2 is still unusably slow. Luckily, I have done the work for you and packaged them up.

[**Click on releases for easy donwloading.**](https://github.com/CRogers/LLVM-Windows-Binaries/releases)

Tools
---

The archive `llvm-3.3-tools-windows.7z` contains all the following tools:

`FileCheck`, `count`, `llvm-bcanalyzer`, `llvm-extract`, `llvm-objdump`, `llvm-size`, `not`, `yaml2obj`, `FileUpdate`, `llc`, `llvm-cov`, `llvm-link`, `llvm-prof`, `llvm-stress`, `obj2yaml`, `KillTheDoctor`, `lli`, `llvm-diff`, `llvm-mc`, `llvm-ranlib`, `llvm-symbolizer`, `opt`, `ModuleMaker`, `llvm-ar`, `llvm-dis`, `llvm-mcmarkup`, `llvm-readobj`, `llvm-tblgen`, `bugpoint`, `llvm-as`, `llvm-dwarfdump`, `llvm-nm`, `llvm-rtdyld`, `macho-dump`, `yaml-bench`

Shared Library
---

If you need a single shared library to use with projects that utilise LLVM's C API (such as the excellent [llvm-fs](https://github.com/fsharp/llvm-fs)) grab the file `llvm-3.3-shared-library-windows.7z`. Compiling it is... interesting.

Compiling Windows Binaries
---

Look at [the Compiling document](./compiling.md) for details of how to build the tools and **how to build a shared library**.