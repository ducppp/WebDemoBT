﻿using DatabaseFirstDemo.Models;
using DatabaseFirstDemo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace WebDemoBT.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class NewsCategoryController : BaseController
	{

		INewsCategoryRepository newsCategoryRepository = null;
		public NewsCategoryController()
		{
			newsCategoryRepository = new NewsCategoryRepository();
		}
		public IActionResult Index()
		{
			var result = newsCategoryRepository.GetAll();
			return View(result);
		}
		public IActionResult Craete()
		{
			return View();
		}
		[HttpPost]
		public JsonResult Create(NewsCategory newCategory)
		{
			try
			{
			
				newsCategoryRepository.Insert(newCategory);
				SetAlert("Insert Data is success!", "success");
				return Json(new { success = true });
				
			}
			catch (Exception ex)
			{
				return Json(new { success = false, message = ex.Message });
			}
			return Json(new { success = false });
		}
		[HttpGet]
		public IActionResult Edit(int id)
		{
			NewsCategory newCategory = newsCategoryRepository.GetById(id);
			var data = new
			{
				Id = newCategory.Id,
				Name = newCategory.CategoryName
				// Các trường khác
			};

			return new JsonResult(new { success = true, data = data });
		}

		[HttpPost]
		public JsonResult Edit(NewsCategory newCategory)
		{
			try
			{
				/*  if (ModelState.IsValid)
				  {*/
				newsCategoryRepository.Update(newCategory);
				SetAlert("Update Data is success!", "success");
				/*}*/
			}
			catch (Exception ex)
			{
				return Json(new { success = false, message = ex.Message });
			}
			return Json(new { success = true });
		}

		[HttpPost]
		public JsonResult Delete(NewsCategory newCategory)
		{
			try
			{
				newsCategoryRepository.Delete(newCategory);
				SetAlert("Delete Data is success!", "success");

			}
			catch (Exception ex)
			{
				return Json(new { success = false, message = ex.Message });
			}
			return Json(new { success = true });
		}
	}
}
