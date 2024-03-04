using Demo.Models;
using Demo.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;

namespace Demo.Controllers
{
	public class StoreController : Controller
	{
		IStoreRepo storeRepo;
		public StoreController(IStoreRepo _storeRepo)
		{
			storeRepo = _storeRepo;
		}
		public IActionResult Index()
		{
			var model = storeRepo.GetAll();
			return View(model);
		}

		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Add(Store s)
		{
			storeRepo.Add(s);
			return RedirectToAction("index");

		}
		public IActionResult Edit(int? id)
		{
			if (!id.HasValue)
				return BadRequest();
			var model = storeRepo.GetById(id.Value);
			if (model == null)
				return BadRequest();
			return View(model);
		}
		[HttpPost]
		public IActionResult Edit(Store s)
		{
			storeRepo.Update(s);
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int? id)
		{
			if (!id.HasValue)
				return BadRequest();
			storeRepo.Delete(id.Value);
			return RedirectToAction("Index");
		}
	}
}
