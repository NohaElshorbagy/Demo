using Demo.Models;
using Demo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
	public class ItemController : Controller
	{
		IItemRepo itemRepo;
		public ItemController(IItemRepo _itemRepo)
		{
			itemRepo = _itemRepo;
		}
		public IActionResult Index()
		{
			var model = itemRepo.GetAll();
			return View(model);
		}
		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Add(Item item)
		{

			itemRepo.Add(item);
			return RedirectToAction("index");

		}
		public IActionResult Edit(int? id)
		{
			if (!id.HasValue)
				return BadRequest();
			var model = itemRepo.GetById(id.Value);
			if (model == null)
				return BadRequest();
			return View(model);
		}
		[HttpPost]
		public IActionResult Edit(Item item)
		{
			itemRepo.Update(item);
			return RedirectToAction("Index");
		}
		public IActionResult Delete(int? id)
		{
			if (!id.HasValue)
				return BadRequest();
			itemRepo.Delete(id.Value);
			return RedirectToAction("Index");
		}


	}
}
