using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace IPTest3.Code
{
    public class DeleteFromStore : StoreAcitonProcessor
    {
        public new bool Successful { get; set; }
        public DeleteFromStore(List<Item> items, string senderId)
        {
            if (MakeMovement(items, senderId, "Удаление") && RemoveFromStore(items, senderId))
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
