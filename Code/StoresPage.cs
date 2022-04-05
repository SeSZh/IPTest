using System.Text.RegularExpressions;
using System.Xml;

namespace IPTest3.Code
{
    public class StoresPage
    {
        public List<Store> stores = new List<Store>();
        public StoresPage()
        {
            Start();
        }
        public StoresPage(string id)
        {
            Start(id);
        }
        private void Start()
        {
            stores = GetStores(); 
        }
        private void Start(string id)
        {
            stores = GetStores(id);
        }
        
        private List<Store>? GetStores()
        {
            List<Store> stores = new List<Store>();

            XmlDocument Doc = new XmlDocument();
            DownloaderUploader du = new DownloaderUploader();
            Stream stream = du.Downloader("main");
            if (stream == null)
            {
                return stores;
            }
            Doc.Load(stream);
            if(Doc==null)
            {
                return stores;
            }
            XmlElement Root = Doc.DocumentElement;
            
            foreach (XmlNode StoreNode in Root.ChildNodes)
            {
                if (StoreNode.Name == "Склад")
                {
                    XmlNode StoreNameAttr = StoreNode.Attributes.GetNamedItem("Наименование");
                    XmlNode StoreIdAttr = StoreNode.Attributes.GetNamedItem("Id");
                    if (StoreNameAttr != null && StoreIdAttr != null)
                    {
                        stores.Add(new Store(StoreIdAttr.Value, StoreNameAttr.Value));
                    }
                }
            }         
            return stores;
        }

        private List<Store>? GetStores(string exStore)
        {
            List<Store> stores = new List<Store>();

            XmlDocument Doc = new XmlDocument();
            DownloaderUploader du = new DownloaderUploader();
            Stream stream = du.Downloader("main");
            if (stream == null)
            {
                return stores;
            }
            Doc.Load(stream);
            if (Doc == null)
            {
                return stores;
            }
            XmlElement Root = Doc.DocumentElement;

            foreach (XmlNode StoreNode in Root.ChildNodes)
            {
                if (StoreNode.Name == "Склад")
                {
                    XmlNode StoreNameAttr = StoreNode.Attributes.GetNamedItem("Наименование");
                    XmlNode StoreIdAttr = StoreNode.Attributes.GetNamedItem("Id");
                    if (StoreNameAttr != null && StoreIdAttr != null)
                    {
                        if(StoreIdAttr.Value != exStore)
                        stores.Add(new Store(StoreIdAttr.Value, StoreNameAttr.Value));
                    }
                }
            }
            return stores;
        }

    }

}
