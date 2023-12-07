﻿using DatabaseFirstDemo.Dao;
using DatabaseFirstDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo.Repository
{
	public class RolesRepository : IRolesRepository
	{
		public IEnumerable<Role> GetAll() => RolesDao.Instance.GetAll();
		public void Insert(Role role) => RolesDao.Instance.Insert(role);
		//public void Update(Role role);
		//public Role GetById(int id);
		//public void Delete(Role role);
	}
}
