namespace Executor.Network.Contract
{
    public interface IAsynchDownloader
    {
        void DownloadAsync(string fileURL);
    }
}
