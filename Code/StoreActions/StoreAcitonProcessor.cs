using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IPTest3.Code
{
    public abstract class StoreAcitonProcessor
    {
        public bool Successful;
        public bool MoveItemsToStore(List<Item> items, string receiverId)
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
                if (Store.Attributes.GetNamedItem("Id").Value == receiverId)
                {


                    foreach (Item item in items)
                    {
                        if (item.Amount < 0)
                        {
                            throw new ArgumentException("Item amount less than zero" + " Id:" + item.Id);
                        }
                        bool exists = false;
                        foreach (XmlNode Item in Store)
                        {
                            if (item.Id == Item.Attributes.GetNamedItem("Id").Value)
                            {
                                exists = true;
                                try
                                {
                                    int amount = Int32.Parse(Item.Attributes.GetNamedItem("Количество").Value);
                                    amount += item.Amount;
                                    Item.Attributes.GetNamedItem("Количество").Value = amount.ToString();
                                }
                                catch { return false; }


                            }
                        }
                        if (exists == false)
                        {
                            XmlElement Elem = Doc.CreateElement("Номенклатура");
                            XmlAttribute ElemAttr = Doc.CreateAttribute("Наименование");
                            XmlText ElemText = Doc.CreateTextNode(item.Name);
                            XmlAttribute ElemCode = Doc.CreateAttribute("Id");
                            XmlText ElemCodeText = Doc.CreateTextNode(item.Id);
                            XmlAttribute Amount = Doc.CreateAttribute("Количество");
                            XmlText AmountText = Doc.CreateTextNode(item.Amount.ToString());



                            ElemAttr.AppendChild(ElemText);
                            ElemCode.AppendChild(ElemCodeText);
                            Amount.AppendChild(AmountText);

                            Elem.Attributes.Append(ElemAttr);
                            Elem.Attributes.Append(ElemCode);
                            Elem.Attributes.Append(Amount);

                            Store.AppendChild(Elem);
                        }
                    }
                }
            }
            if (!du.Uploader("main", Doc))
            { return false; }
            return true;
        }
        public bool MakeMovement(List<Item> items, string senderId, string receiverId)
        {
            DownloaderUploader du = new DownloaderUploader();
            Stream responseStream = du.Downloader("movings");
            if (responseStream == null)
            {
                return false;
            }
            XmlDocument Doc = new XmlDocument();
            Doc.Load(responseStream);
            XmlElement Root = Doc.DocumentElement;

            responseStream.Close();





            DateTime myDate = DateTime.Now;
            string Datetime = myDate.Day.ToString() + "." + myDate.Month.ToString() + "." + myDate.Year.ToString();
            Datetime = myDate.ToString();


            {
                XmlElement Admission = Doc.CreateElement("Документ");

                XmlAttribute Date = Doc.CreateAttribute("Дата");
                XmlText DateText = Doc.CreateTextNode(Datetime);




                Date.AppendChild(DateText);
                Admission.Attributes.Append(Date);

                XmlElement Source = Doc.CreateElement("СкладОтправитель");
                XmlAttribute SourceCodeAttr = Doc.CreateAttribute("Id");
                XmlText SourceCodeText = Doc.CreateTextNode(senderId);
                SourceCodeAttr.AppendChild(SourceCodeText);
                Source.Attributes.Append(SourceCodeAttr);

                XmlElement Destination = Doc.CreateElement("СкладПолучатель");
                XmlAttribute DestinationCodeAttr = Doc.CreateAttribute("Id");
                XmlText DestinationCodeText = Doc.CreateTextNode(receiverId);
                DestinationCodeAttr.AppendChild(DestinationCodeText);
                Destination.Attributes.Append(DestinationCodeAttr);

                Admission.AppendChild(Destination);
                Admission.AppendChild(Source);



                foreach (Item item in items)
                {
                    if(item.Amount < 0)
                    {
                        throw new ArgumentException("Item amount less than zero" + " " + item.Id);
                    }
                    XmlElement Elem = Doc.CreateElement("Номенклатура");
                    XmlAttribute ElemAttr = Doc.CreateAttribute("Наименование");
                    XmlText ElemText = Doc.CreateTextNode(item.Name);
                    XmlAttribute ElemCode = Doc.CreateAttribute("Id");
                    XmlText ElemCodeText = Doc.CreateTextNode(item.Id);
                    XmlAttribute ElemAmountAttr = Doc.CreateAttribute("Количество");
                    XmlText ElemAmountText = Doc.CreateTextNode(item.Amount.ToString());


                    ElemAttr.AppendChild(ElemText);
                    ElemCode.AppendChild(ElemCodeText);
                    ElemAmountAttr.AppendChild(ElemAmountText);

                    Elem.Attributes.Append(ElemAttr);
                    Elem.Attributes.Append(ElemCode);
                    Elem.Attributes.Append(ElemAmountAttr);

                    Admission.AppendChild(Elem);


                }
                Root.AppendChild(Admission);
            }
            if (du.Uploader("movings", Doc))
                return true;
            else return false;
        }
        public bool RemoveFromStore(List<Item> items, string senderId)
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





            foreach (XmlNode StoreNode in Root.ChildNodes)
            {
                if (StoreNode.Name == "Склад")
                {
                    XmlNode StoreAttr = StoreNode.Attributes.GetNamedItem("Id");
                    if (StoreAttr != null)
                        if (StoreAttr.Value == senderId)
                        {
                            XmlNodeList nodeList = StoreNode.ChildNodes;
                            for (int k = 0; k < nodeList.Count; k++)
                            {
                                string id = nodeList[k].Attributes["Id"].Value;
                                Item item = items.Find(item => item.Id == id);
                                if (item != null)
                                {
                                    if(item.Amount<0)
                                    {
                                        throw new ArgumentException("Item amount less than zero" + " " + item.Id);
                                    }
                                    int amount = Int32.Parse(nodeList[k].Attributes["Количество"].Value);
                                    if(amount < 0)
                                    {
                                        throw new ArgumentException("DB item amount less than zero" + " " + id + " " + senderId);
                                    }
                                    amount -= item.Amount;
                                    if (amount < 0)
                                        return false;
                                    else if (amount == 0)
                                    { StoreNode.RemoveChild(nodeList[k]); k--; }
                                    else
                                        nodeList[k].Attributes["Количество"].Value = amount.ToString();
                                }
                            }
                        }
                }

            }





            if (du.Uploader("main", Doc))
                return true;
            else return false;
        }
    }
}
