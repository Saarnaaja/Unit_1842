using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_1842.Navigator;

namespace Unit_1842
{
    class VideoDownloadCommand : Command
    {
        private string _url;
        private string _fileName;
        private Receiver _reciever;
        public VideoDownloadCommand(Receiver reciever, string url, string fileName)
        {
            _reciever = reciever;
            _url = url;
            _fileName = fileName;
        }
        public override void Cancel()
        {
            throw new NotImplementedException();
        }

        public override void Run()
        {
            try
            {
                //т.к. при скачивании необходимо указать в каком формате необходимо скачивать видео
                //делаем такую конструкцию
                var manifest = _reciever.GetVideoManifests(_url).Result;
                if (manifest == null) return;

                var navigator = new ManifestNavigator(manifest.Streams);
                navigator.Run();
                var stream = navigator.GetCurrentSelected() as YoutubeExplode.Videos.Streams.IStreamInfo;

                //После чего передаем имя файла и формат на скачивание
                _reciever.DownloadVideo(_fileName, stream);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
