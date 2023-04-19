using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MyMVCNET.UI.Models.DAL.CrudRepository
{
	public class Crud<T, TContext> : ICrud<T> where T : class where TContext : DbContext, new()
	{
		TContext db = null;
		DbSet<T> dbSet = null;

		public Crud()
		{
			db = new TContext();
			dbSet = db.Set<T>();
		}
		public Crud(TContext db)
		{
			this.db = db;
			dbSet = db.Set<T>();
		}

		public int Delete(T entity)
		{
			#region HardDeleteAktif
			db.Entry(entity).State = EntityState.Deleted;
			dbSet.Remove(entity);
			return db.SaveChanges();
			#endregion

			#region SoftDelete
			//dbSet.GetType().GetProperty("isDeleted").SetValue(entity, 0);
			//return Update(entity); 
			#endregion

		}

		public T Get(object ID)
		{
			return dbSet.Find(ID);
		}

		public List<T> GetAll()
		{
			return dbSet.ToList();
		}

		public List<T> GetByFunc(Expression<Func<T, bool>> cond)
		{
			return dbSet.Where(cond).ToList();
		}
		public T Get(Expression<Func<T, bool>> cond)
		{
			return dbSet.Where(cond).SingleOrDefault();
		}

		public int Insert(T entity)
		{
			T eklenmisData = dbSet.Add(entity);
			return db.SaveChanges();
		}

		public int Update(T entity)
		{
			db.Entry(entity).State = EntityState.Modified;
			dbSet.Attach(entity);
			return db.SaveChanges();
		}
	}
}