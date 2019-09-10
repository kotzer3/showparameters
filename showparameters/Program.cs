using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace showparameters
{
    using System.Diagnostics;
    using System.Diagnostics.Eventing.Reader;
    using System.IO;
    using System.Threading;

    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                using (StreamWriter w = File.AppendText("log.txt"))
                {
                Log("#Started.",w);
                if (args != null && args.Length > 0)
                {
                    foreach (var arg in args)
                    {
                        Log(arg, w);
                    }
                    Log("#End.", w);
                }
                else
                {
                    Log("#No parameters provided :(", w);
                }
                }

            }
            catch (Exception ex)
            {
                using (StreamWriter w = File.AppendText("log.txt")){
                Log("#Exception: " + ex,w);
                                }

            }
            //Console.ReadLine();
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (true)
            {
                //some other processing to do STILL POSSIBLE
                if (stopwatch.ElapsedMilliseconds >= 10*1000*60)
                {
                    break;
                }
                Thread.Sleep(1); //so processor can rest for a while
            }

        }
     public static void Log(string logMessage, TextWriter w)
    {
        w.Write("\r\nLog Entry : ");
        w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
            DateTime.Now.ToLongDateString());
        w.WriteLine("  :");
        w.WriteLine("  :{0}", logMessage);
        w.WriteLine ("-------------------------------");
    }

    }
}
