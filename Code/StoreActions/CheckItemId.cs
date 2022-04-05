using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IPTest3.Code
{
    public class CheckItemId
    {
        public bool Successful { get; set; }
        public CheckItemId(string id)
        {
            if(CheckId(id))
                Successful = true;
            else
                Successful = false;
        }
        private bool CheckId(string id)
        {
            DownloaderUploader du = new DownloaderUploader();
            Stream responseStream = du.Downloader("main");
            if (responseStream == null)
            {
                return false;
            }
            XmlDocument Doc = new XmlDocument();
            Doc.Load(responseStream);
            XmlElement Root = Doc.DocumentElement;


            responseStream.Close();


            foreach (XmlNode Store in Root.ChildNodes)
            {
                foreach (XmlNode Item in Store)
                {
                    if (Item.Attributes["Id"].Value == id)
                        return false;


                }
            }
            return true;
        }
    }
}
