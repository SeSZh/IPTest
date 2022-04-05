using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IPTest3.Code
{
    public class StoreMovings : StoreAcitonProcessor
    {
        public bool Successful { get; set; }
        public StoreMovings(List<Item> items, string senderId, string receiverId)
        {
           if(MoveItemsToStore(items, receiverId) && MakeMovement(items, senderId, receiverId) && RemoveFromStore(items, senderId))
            {
                Successful = true;
            }
           else
            {
                Successful = false;
            }
        }
        
    }
}
