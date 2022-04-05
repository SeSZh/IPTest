namespace IPTest3.Code
{
    public class Store
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        private Store()
        {
            Id = Guid.NewGuid().ToString();
            Name = "";
        }

        public Store(string id, string name)
        {
            Id = id;
            Name = name;
        }
        public Store(Store store)
        {
            Id = store.Id;
            Name = store.Name;
        }
    }
}
