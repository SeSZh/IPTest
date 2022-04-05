using System.Text.RegularExpressions;
using System.Xml;


namespace IPTest3.Code
{
    public class ItemsPage
    {
        public List<Item> items = new();
        public ItemsPage(string id)
        {
            Start(id);
        }
        private void Start(string id)
        {
            items = GetItems(id);
        }
        public ItemsPage(string id, DateTime time, List<Item> Items)
        {
            Start(id, time, Items);
        }
        private void Start(string id, DateTime time, List<Item> Items)
        {
            items = GetItems(id, time, Items);
        }

        private List<Item> GetItems(string id)
        {
            List<Item> items = new();

            XmlDocument Doc = new XmlDocument();
            DownloaderUploader du = new DownloaderUploader();
            Stream stream = du.Downloader("main");
            if (stream == null)
            {
                return items;
            }
            Doc.Load(stream);
            if (Doc == null)
            {
                return items;
            }
            XmlElement Root = Doc.DocumentElement;
            foreach (XmlNode StoreNode in Root.ChildNodes)
            {
                if (StoreNode.Name == "Склад")
                {
                    
                    XmlNode storeIdAttr = StoreNode.Attributes.GetNamedItem("Id");
                    if (storeIdAttr != null)
                    {
                        if(storeIdAttr.Value == id)
                        {
                            foreach(XmlNode Item in StoreNode.ChildNodes)
                            {
                                try
                                {
                                    XmlAttribute itemIdAttr = Item.Attributes["Id"];
                                    XmlAttribute itemNameAttr = Item.Attributes["Наименование"];
                                    XmlAttribute itemAmountAttr = Item.Attributes["Количество"];
                                    if (itemIdAttr != null && itemNameAttr != null && itemAmountAttr != null)
                                        items.Add(new Code.Item(itemIdAttr.Value, itemNameAttr.Value, Int32.Parse(itemAmountAttr.Value), false));
                                }
                                catch (Exception ex)
                                {
                                    return items;
                                }
                            }
                        }
                       
                    }
                }
            }
            


            return items;
        }
        private List<Item> GetItems(string id, DateTime time, List<Item> Items)
        {
            List<Item> items = new();

            XmlDocument Doc = new XmlDocument();
            DownloaderUploader du = new DownloaderUploader();
            Stream stream = du.Downloader("movings");
            if (stream == null)
            {
                return items;
            }
            Doc.Load(stream);
            if (Doc == null)
            {
                return items;
            }
            XmlElement Root = Doc.DocumentElement;
            foreach (XmlNode MovNode in Root.ChildNodes)
            {

                string movTimeString = MovNode.Attributes["Дата"].Value;
                if (movTimeString.Length == 18)
                    movTimeString = movTimeString.Insert(11, "0");
                try
                {
                    DateTime movTime = DateTime.ParseExact(movTimeString, "dd.MM.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    var comp = movTime.CompareTo(time);
                    if (comp == 1)
                    {
                        //List<Item> movItems = new List<Item>();
                        bool isStore = false;
                        bool addOrDelete = false;
                        foreach (XmlNode movNodeChild in MovNode.ChildNodes)
                        {
                            
                            
                            if(movNodeChild.Name == "СкладПолучатель" && movNodeChild.Attributes["Id"].Value == id)
                            {
                                addOrDelete = false;
                                isStore = true;
                            }
                            if (movNodeChild.Name == "СкладОтправитель" && movNodeChild.Attributes["Id"].Value == id)
                            {
                                addOrDelete = true;
                                isStore = true;
                            }
                            if(movNodeChild.Name == "Номенклатура")
                            {
                                if(isStore)
                                items.Add(new Item(movNodeChild.Attributes["Id"].Value, movNodeChild.Attributes["Наименование"].Value, Int32.Parse(movNodeChild.Attributes["Количество"].Value), addOrDelete));
                            }

                        }
                    }


                }
                catch
                {
                    throw new ArgumentException();
                }

            }
            List<Item> ChangedItems = new(items);
            foreach (Item item in ChangedItems)
            {
                int index = Items.FindIndex(it => it.Id == item.Id);
                if (index < 0)
                {
                    Items.Add(item);
                }
                else
                {
                    if (item.IsSelected == false)
                    {
                        Items[index].Amount -= item.Amount;
                        if (Items[index].Amount == 0)
                            Items.RemoveAt(index);
                        if (Items[index].Amount < 0)
                            throw new ArgumentException();
                    }
                    else
                    {
                        Items[index].Amount += item.Amount;
                    }
                }
            }


            return items;
        }
    }

}
