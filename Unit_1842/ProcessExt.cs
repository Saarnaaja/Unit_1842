using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_1842
{
    internal static class ProcessExt
    {
        internal static void Run(string processName, string arguments, Encoding encoding = null)
        {
            string res;
            if (!File.Exists(processName))
            {
                Console.WriteLine($"Файл {processName} не найден");
                return;
            }
            try
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.FileName = processName;
                p.StartInfo.CreateNoWindow = false;
                p.StartInfo.RedirectStandardOutput = true;

                if (encoding != null) p.StartInfo.StandardOutputEncoding = encoding;
                p.StartInfo.Arguments = arguments;
                p.Start();

                while (!p.StandardOutput.EndOfStream)
                {
                    res = p.StandardOutput.ReadLine();
                    Console.WriteLine(res);
                }
                p.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
