using DatabaseFirstDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo.Dao
{
	public class NewsCategoryDao
	{
		private static NewsCategoryDao instance;
		private static readonly object instanceLock = new object();
		public static NewsCategoryDao Instance
		{
			get
			{
				lock (instanceLock)
				{
					if (instance == null)
					{
						instance = new NewsCategoryDao();
					}
					return instance;
				}
			}
		}

		public IEnumerable<NewsCategory> GetAll()
		{
			List<NewsCategory> newsCategory;
			try
			{
				using ProductMagementDemoContext stock = new ProductMagementDemoContext();
				newsCategory = stock.NewsCategories.ToList();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return newsCategory;
		}

		public NewsCategory GetById(int? id)
		{
			NewsCategory newsCategory;
			try
			{
				using ProductMagementDemoContext stock = new ProductMagementDemoContext();
				newsCategory = stock.NewsCategories.SingleOrDefault(r => r.Id == id);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return newsCategory;
		}

		public void Insert(NewsCategory newsCategory)
		{
			try
			{
				using ProductMagementDemoContext stock = new ProductMagementDemoContext();
				stock.Add(newsCategory);
				stock.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void Update(NewsCategory newsCategory)
		{
			try
			{
				using ProductMagementDemoContext stock = new ProductMagementDemoContext();
				stock.Entry<NewsCategory>(newsCategory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				stock.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void Delete(NewsCategory newsCategory)
		{
			try
			{
				using ProductMagementDemoContext stock = new ProductMagementDemoContext();
				var rl = stock.NewsCategories.SingleOrDefault(c => c.Id == newsCategory.Id);
				stock.Remove(rl);
				stock.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

	}
}