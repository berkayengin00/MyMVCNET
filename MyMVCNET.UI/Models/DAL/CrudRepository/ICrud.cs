using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyMVCNET.UI.Models.DAL.CrudRepository
{
	public interface ICrud<T> where T : class
	{
		List<T> GetAll();
		T Get(object ID);
		List<T> GetByFunc(Expression<Func<T, bool>> cond);
		int Insert(T entity);
		int Update(T entity);
		int Delete(T entity);
	}
}