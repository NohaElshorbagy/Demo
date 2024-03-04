using Demo.Models;

namespace Demo.Repository
{
	public interface IStoreRepo
	{
		List<Store> GetAll();
		Store GetById(int id);
		void Add(Store item);
		void Update(Store item);
		void Delete(int id);
	}
	public class StoreRepo : IStoreRepo
	{
		Context db;
		public StoreRepo(Context _db)
		{
			db = _db;
		}

		public List<Store> GetAll()
		{
			return db.Stores.ToList();
		}
		public Store GetById(int id)
		{
			return db.Stores.FirstOrDefault(a => a.Id == id);
		}
		public void Add(Store store)
		{
			db.Stores.Add(store);
			db.SaveChanges();
		}
		public void Update(Store store)
		{
			db.Stores.Update(store);
			db.SaveChanges();
		}
		public void Delete(int id)
		{
			var store = GetById(id);
			db.Stores.Remove(store);
			db.SaveChanges();
		}
	}
}
