using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IPTest3.Code
{
    public class MovingsHistory
    {
        public List<Movement> movements = new List<Movement>();
        public MovingsHistory()
        {
            movements = GetHistory();
        }
        private List<Movement> GetHistory()
        {
            List<Movement> movements = new List<Movement>();
            DownloaderUploader du = new DownloaderUploader();
            Stream responseStream = du.Downloader("movings");
            if (responseStream == null)
            {
                return movements;
            }
            XmlDocument Doc = new XmlDocument();
            Doc.Load(responseStream);
            XmlElement Root = Doc.DocumentElement;

            responseStream.Close();


            foreach (XmlNode moving in Root.ChildNodes)
            {
                string date = moving.Attributes["Дата"].Value;
                string sender = "";
                string receiver = "";
                List<Item> items = new List<Item>();
                foreach(XmlNode node in moving.ChildNodes)
                {
                    if(node.Name == "СкладПолучатель")
                    {
                        receiver = node.Attributes["Id"].Value;
                    }
                    if(node.Name == "СкладОтправитель")
                    {
                        sender = node.Attributes["Id"].Value;
                    }
                    if(node.Name == "Номенклатура")
                    {
                        string name = node.Attributes["Наименование"].Value;
                        string id = node.Attributes["Id"].Value;
                        int amount = Int32.Parse(node.Attributes["Количество"].Value);
                        items.Add(new Item(id, name, amount, false));
                    }
                }
                movements.Add(new Movement(date, sender, receiver, items));

            }

            return movements;
        }
    }
}
