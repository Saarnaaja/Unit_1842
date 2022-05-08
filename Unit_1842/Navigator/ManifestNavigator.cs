using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode.Videos.Streams;

namespace Unit_1842.Navigator
{
    /// <summary>
    /// Класс для удобной навигации по форматам скачиваемого файла с YouTube
    /// </summary>
    class ManifestNavigator : AbstractNavigator<IReadOnlyList<IStreamInfo>, IStreamInfo>
    {
        public ManifestNavigator(IReadOnlyList<IStreamInfo> streams)
        {
            Collection = streams ?? throw new ArgumentNullException("streams");
        }

        protected override void ShowCollection()
        {
            foreach (var c in Collection)
                Console.WriteLine($"\t{c} Bitrate:{c.Bitrate} Size:{c.Size}");
        }

        protected override void ExecuteCommand()
        {
            var input = Console.ReadKey(true).Key;
            var command = Commands.Where(x => x.GetKey() == input)
                                  .FirstOrDefault();

            Console.CursorVisible = false;

            if (command != null) 
                command.Execute();
        }
    }
}
