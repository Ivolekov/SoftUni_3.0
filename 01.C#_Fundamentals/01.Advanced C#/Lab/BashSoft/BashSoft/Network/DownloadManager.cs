using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.Network
{
    public static class DownloadManager
    {
        public static void Download(string fileURL)
        {
            WebClient webClient = new WebClient();

            try
            {
                OutputWriter.WriteMessageOnNewLine("Started downloading: ");

                string nameOfFile = ExtractNameOfFile(fileURL);
                string pathToDownload = SessionData.currentPath + "/" + nameOfFile;

                webClient.DownloadFile(fileURL, pathToDownload);

                OutputWriter.WriteMessageOnNewLine("Download complete");
            }
            catch (WebException ex)
            {
                OutputWriter.DisplayExeption(ex.Message);
            }
        }

        public static void DownloadAsynch(string fileURL)
        {
            Task.Run(() => Download(fileURL));
        }

        private static string ExtractNameOfFile(string fileURL)
        {
            int indexOfLastBackSlash = fileURL.LastIndexOf('/');

            if (indexOfLastBackSlash != -1)
            {

            }
            else
            {
                throw new WebException(ExceptionMessages.InvalidPath);
            }

            return fileURL.Substring(indexOfLastBackSlash + 1);
        }
    }
}
