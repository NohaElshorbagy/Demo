namespace Demo.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation Property

        public List<StoreItem> storeItems { get; set; }
    }
}
