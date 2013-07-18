using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace LibDefExtractor
{
    enum State
    {
        BeforeSymbols,
        DuringSymbols
    }

    class Program
    {
        static void Main(string[] args)
        {
            var infile = args[0];
            var outfile = args[1];

            //var infile = @"C:\Users\Callum\compiling\llvm3.3cmake\lib\Debug\LLVMX86AsmParser.lib";
            //var outfile = "out.def";

            Console.WriteLine("Extracing symbols from {0} to {1}.", infile, outfile);

            var symRegex = new Regex(@"^\s+\w+\s+(.*)$");

            var p = Process.Start(new ProcessStartInfo("dumpbin", "/linkermember:1 " + infile)
                                  {
                                      CreateNoWindow = true,
                                      UseShellExecute = false,
                                      RedirectStandardOutput = true
                                  });

            using (var sr = p.StandardOutput)
            using (var sw = File.CreateText(outfile)) {

                // Write EXPORTS section header
                sw.WriteLine("EXPORTS");

                var state = State.BeforeSymbols;
                var done = false;
                var i = 1;

                while (!sr.EndOfStream && !done) {
                    var l = sr.ReadLine();
                    
                    switch(state) {
                        case State.BeforeSymbols:
                            // Find the "xxxx public symbols" identifier first
                            if (l.Contains("public symbols")) {
                                // Skip the blank line
                                sr.ReadLine();
                                // Set the newer parser state
                                state = State.DuringSymbols;
                            }
                            break;

                        case State.DuringSymbols:
                            var m = symRegex.Match(l);
                            if (!m.Success) {
                                done = true;
                                break;
                            }
                            var sym = m.Groups[1].Value;
                            if (sym.StartsWith("_") && !sym.Contains("@")) {
                                sw.WriteLine("  " + sym.Substring(1));
                            }
                            //sw.WriteLine("  {0}{1}", sym, sym.StartsWith("_") ? "" : "  @" + (i++).ToString());
                            break;
                    }
                }
            }
        }
    }
}
