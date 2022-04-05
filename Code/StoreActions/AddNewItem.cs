using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IPTest3.Code
{
    public class AddNewItem : StoreAcitonProcessor
    {
        public new bool Successful;
        public AddNewItem(List<Item> items, string id)
        {
            CheckItemId checkItemId = new CheckItemId(items[0].Id);
            if (!checkItemId.Successful)
            {
                Successful = false;
                return;
            }
            if (MoveItemsToStore(items, id) && MakeMovement(items, "Добавление", id))
            {
                Successful = true;
            }
            else
                Successful = false;
        }
        
    }
}
