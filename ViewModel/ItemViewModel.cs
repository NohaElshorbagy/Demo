using Demo.Models;

namespace Demo.ViewModel
{
	public class ItemViewModel
	{
		public int StoreId { get; set; }
		public IEnumerable<Store>? stores { get; set; }
		public int ItemId { get; set; }
		public IEnumerable<Item>? items { get; set; }

		public int Quantity { get; set; }
		public List<int>? Quantities { get; set; }
	}
}
