using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTest3.Code
{
    public class Movement
    {
        public string Date = ""; 
        public string Sender = "";
        public string Receiver = "";
        public List<Item> Items = new List<Item>();

        public Movement()
        {
            
        }
        public Movement(string date, string sender, string receiver, List<Item> items)
        {
            Date = date;
            Sender = sender;
            Receiver = receiver;
            Items = items;
        }

    }
}
