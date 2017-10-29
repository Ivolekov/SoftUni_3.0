namespace Lab.AdvancedCSharp.Bashsoft.Network
{
    using System;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;

    using Contracts;
    using Exceptions;
    using IO;
    using StaticData;

    public class DownloadManager : IDownloadManager
    {
        #region Constants

        private const ConsoleColor LogColor = ConsoleColor.Yellow;

        #endregion

        #region Private Fields

        private WebClient webClient;

        #endregion

        #region Constructors
        
        public DownloadManager()
        {
            this.webClient = new WebClient();
        }

        #endregion

        #region Public Methods

        public void DownloadAsync(string fileUrl)
        {
            Task.Run(() => this.Download(fileUrl));
        }

        public void Download(string fileUrl)
        {
            try
            {
                OutputWriter.WriteMessageLine("Started downloading: ", LogColor);

                string fileName = this.ExtractFileName(fileUrl);
                string downloadPath = Path.Combine(SessionData.CurrentPath, fileName);

                this.webClient.DownloadFile(fileUrl, downloadPath);

                OutputWriter.WriteMessageLine("Download complete!", LogColor);
            }
            catch (InvalidPathException ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        #endregion

        #region Private Methods

        private string ExtractFileName(string fileUrl)
        {
            int lastBackslashIndex = fileUrl.LastIndexOf('/');

            if (lastBackslashIndex != -1)
            {
                return fileUrl.Substring(lastBackslashIndex + 1);
            }
            else
            {
                throw new InvalidPathException();
            }
        } 

        #endregion
    }
}
