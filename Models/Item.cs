namespace Demo.Models
{
	public class Item
	{
		public int Id { get; set; }
		public String Name { get; set; }

		//Navigaton Property
		public List<StoreItem> Itemstores { get; set; }

	}
}
