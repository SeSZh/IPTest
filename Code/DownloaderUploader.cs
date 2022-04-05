using System.Net;
using System.Xml;

namespace IPTest3.Code
{
    public class DownloaderUploader : Interfaces.IDownloaderUploader
    {
        public Stream Downloader(string FileName)
        {

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://93.189.46.164/" + FileName + ".xml");
            
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential("localusage", "gX5qM8iA0niC2m");

            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                // получаем поток ответа
                Stream responseStream = response.GetResponseStream();
                //response.Close();
                //responseStream.Close();
                return responseStream;
            }
            catch
            {
                return null;
            }


        }
        public bool Uploader(string FileName, XmlDocument Doc)
        {
            try
            {
                // загрузка файла на сервер
                FtpWebRequest secrequest = (FtpWebRequest)WebRequest.Create("ftp://93.189.46.164/" + FileName + ".xml");

                secrequest.Method = WebRequestMethods.Ftp.UploadFile;
                secrequest.Credentials = new NetworkCredential("localusage", "gX5qM8iA0niC2m");

                Stream secrequestStream = secrequest.GetRequestStream();
                Doc.Save(secrequestStream);
                secrequestStream.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
