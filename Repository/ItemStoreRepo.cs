using Demo.Models;
using Demo.ViewModel;

namespace Demo.Repository
{
	public interface IItemStoreRepo
	{
		public ItemViewModel Show();
		public StoreItem GetById(int storeId, int itemId);
		public void Add(StoreItem storeItem);
	}
	public class ItemStoreRepo : IItemStoreRepo
	{
		Context db ;
		
		IItemRepo itemRepo;
		IStoreRepo storeRepo;

		public ItemStoreRepo(IItemRepo _itemRepo, IStoreRepo _storeRepo , Context _db)
		{
			itemRepo = _itemRepo;
			storeRepo = _storeRepo;
			db = _db;	
		}

		public ItemViewModel Show()
		{
			
			var store = storeRepo.GetAll();
			var item = itemRepo.GetAll();
			var model = new ItemViewModel
			{
				stores = store,
				items = item,

			};
			return model;
		}
		public StoreItem GetById(int storeId, int itemId)
		{
			return db.ItemStore
				.Where(a => a.Store_Id == storeId && a.Item_Id == itemId)
				.FirstOrDefault();
		}

		public void Add(StoreItem storeItem)
		{
			db.ItemStore.Add(storeItem);
			db.SaveChanges();
		}
	}
}
