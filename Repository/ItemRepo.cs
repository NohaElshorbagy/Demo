using Demo.Models;

namespace Demo.Repository
{
	public interface IItemRepo
	{
		List<Item> GetAll();
		Item GetById(int id);
		void Add(Item item);
		void Update(Item item);
		void Delete(int id);
	}
	public class ItemRepo : IItemRepo
	{
		Context db;
		public ItemRepo(Context _db)
		{
			db = _db;
		}

		public List<Item> GetAll()
		{
			return db.Items.ToList();
		}
		public Item GetById(int id)
		{
			return db.Items.FirstOrDefault(a => a.Id == id);
		}
		public void Add(Item item)
		{
			db.Items.Add(item);
			db.SaveChanges();
		}
		public void Update(Item item)
		{
			db.Items.Update(item);
			db.SaveChanges();
		}
		public void Delete(int id)
		{
			var item = GetById(id);
			db.Items.Remove(item);
			db.SaveChanges();
		}
	}
}
