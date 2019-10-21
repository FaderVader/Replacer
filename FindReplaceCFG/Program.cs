using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FindReplaceCFG
{
    class Program
    {

        static void Main(string[] args)
        {
            var handler = new Handler();
            handler.CopyOrig();

            Console.WriteLine("Process complete. Check output (press any key to exit)");
            Console.ReadKey();
        }
    }
}
