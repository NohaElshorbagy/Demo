using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
	public class StoreItem
	{
		[Key] public int Id { get; set; }

		[ForeignKey("Store")]
		[Display(Name = "Choose Store")]
		public int Store_Id { get; set; }

		[ForeignKey("Item")]
		[Display(Name = "Choose Item")]
		public int Item_Id { get; set; }
		public int Quantity { get; set; }

		//Navigation Property
		public Store Store { get; set; }
		public Item Item { get; set; }
	}
}
