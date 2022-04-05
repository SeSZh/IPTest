using System.Xml;


namespace IPTest3.Code.Interfaces
{
    public interface IDownloaderUploader
    {
        Stream Downloader(string FileName);
        bool Uploader(string FileName, XmlDocument Doc);

    }
}
