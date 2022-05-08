using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace Unit_1842
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sender = new Sender();
            var receiver = new Receiver();
            string url;
            string fileName;

            if (args.Length == 0)
            {
                Console.WriteLine("Введите сслыку на Youtube-видео");
                url = Console.ReadLine();
                Console.WriteLine("Введите название для сохраненного видео");
                fileName = Console.ReadLine();
            }
            else
            {
                url = args[0];
                fileName = args[1];
            }
            sender.AddCommand(new VideoInfoCommand(receiver, url));
            sender.AddCommand(new VideoDownloadCommand(receiver, url, fileName));
            sender.Run();
            Console.ReadKey();
        }
    }
}
