namespace IPTest3.Code
{
    public class Item
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public int Amount { get; set; }
        public bool IsSelected { get; set; }
        
        private Item()
        {
            Id = "";
            Name = "";
            Amount = 0;
            IsSelected = false;
        }

        public Item(string id, string name, int amount, bool isSelected)
        {
            Id = id;
            Name = name;
            Amount = amount;
            IsSelected = isSelected;
        }
        public Item(Item item)
        { 
            Id=item.Id;
            Name = item.Name;
            Amount = item.Amount;
            IsSelected = item.IsSelected;
        }

    }
}
