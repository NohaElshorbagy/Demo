using Demo.Models;
using Demo.Repository;
using Demo.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Controllers
{
	public class StoreItemController : Controller
	{
		Context db = new Context();
		IItemRepo itemRepo;
		IStoreRepo storeRepo;
		IItemStoreRepo itemStoreRepo;

		public StoreItemController(IItemRepo _itemRepo, IStoreRepo _storeRepo, IItemStoreRepo _itemStoreRepo)
		{
			itemRepo = _itemRepo;
			storeRepo = _storeRepo;
			itemStoreRepo = _itemStoreRepo;

		}
		public IActionResult IncreaseStock()
		{
			var model = itemStoreRepo.Show();
			return View(model);
		}
		public IActionResult GetQuantity(int? StoreId, int? ItemId)
		{
			var totalQuantity = db.ItemStore
				.Where(a => a.Store_Id == StoreId && a.Item_Id == ItemId)
				.Sum(a => a.Quantity);

			return Ok(totalQuantity);
		}
		[HttpPost]

		public IActionResult IncreaseStock(ItemViewModel? viewmodel)
		{

			var storeId = viewmodel.StoreId;
			var itemId = viewmodel.ItemId;
			var addQuantity = viewmodel.Quantity;

			StoreItem storeitem = new StoreItem
			{
				Store_Id = storeId,
				Item_Id = itemId,
				Quantity = addQuantity
			};
			itemStoreRepo.Add(storeitem);
			var store = storeRepo.GetAll();
			var item = itemRepo.GetAll();
			var model = new ItemViewModel
			{
				stores = store,
				items = item,
				Quantity = addQuantity
			};

			return View(model);
		}



	}
}
