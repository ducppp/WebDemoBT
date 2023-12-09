using DatabaseFirstDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo.Repository
{
	public interface INewsCategoryRepository
	{
		IEnumerable<NewsCategory> GetAll();
		void Insert(NewsCategory newsCategory);
		void Update(NewsCategory newsCategory);
		NewsCategory GetById(int id);
		void Delete(NewsCategory newsCategory);
	}
}