using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstDemo.Models;
using DatabaseFirstDemo.Repository;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Data;

namespace WebDemoBT.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class RolesController : BaseController
	{
		private readonly ProductMagementDemoContext _context;

		IRolesRepository rolesRepository = null;
		public RolesController()
		{
			rolesRepository = new RolesRepository();
		}
		//public RolesController(ProductMagementDemoContext context)
		//{
		//    _context = context;
		//}

		// GET: Admin/Roles
		public async Task<IActionResult> Index()
		{
			var result = rolesRepository.GetAll();
			return View(result);
			//      return _context.Roles != null ? 
			//                  View(await _context.Roles.ToListAsync()) :
			//                  Problem("Entity set 'ProductMagementDemoContext.Roles'  is null.");
			//
		}

		// GET: Admin/Roles/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Roles == null)
			{
				return NotFound();
			}

			var role = await _context.Roles
				.FirstOrDefaultAsync(m => m.Id == id);
			if (role == null)
			{
				return NotFound();
			}

			return View(role);
		}

		// GET: Admin/Roles/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Admin/Roles/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name")] Role role)
		{
			try
			{
				if (ModelState.IsValid)
				{
					rolesRepository.Insert(role);
					SetAlert("Insert Data is success!", "success"); ;
					//_context.Add(role);
					//await _context.SaveChangesAsync();
					return RedirectToAction(nameof(Index));
				}
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("Error", ex.Message);
			}

			return View(role);
		}

		// GET: Admin/Roles/Edit/5
		public async Task<IActionResult> Edit(int id)
		{
			Role role = rolesRepository.GetById(id);
			if (id == null || role == null)
			{
				return NotFound();
			}

			//var role = await _context.Roles.FindAsync(id);
			//if (role == null)
			//{
			//	return NotFound();
			//}
			return View(role);
		}

		// POST: Admin/Roles/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Role role)
		{
			try
			{
				if (id != role.Id)
				{
					return NotFound();
				}

				if (ModelState.IsValid)
				{
					try
					{
						rolesRepository.Update(role);
						SetAlert("Update data is success!", "success");
					}
					catch (DbUpdateConcurrencyException)
					{
						if (!RoleExists(role.Id))
						{
							return NotFound();
						}
						else
						{
							throw;
						}
					}
					return RedirectToAction(nameof(Index));
				}
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("Error", ex.Message);
			}
			return View(role);
		}

		// GET: Admin/Roles/Delete/5
		public async Task<IActionResult> Delete(int id)
		{
			Role role = rolesRepository.GetById(id);
			if (id == null || role == null)
			{
				return NotFound();
			}

			//var role = await _context.Roles.FindAsync(id);
			//if (role == null)
			//{
			//	return NotFound();
			//}
			return View(role);
		}

		// POST: Admin/Roles/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			try
			{

				var result = rolesRepository.GetById(id);
				if (result == null)
				{
					return Problem("Entity set 'WebDemoBT.Roles'  is null.");
				}
				rolesRepository.Delete(result);
				SetAlert("Delete data is succcess", "success");
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("Error", ex.Message);
			}
			return RedirectToAction(nameof(Index));
		}

		private bool RoleExists(int id)
		{
			return (_context.Roles?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
