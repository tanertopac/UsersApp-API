using System;
namespace UsersApp.Infrastructure
{
	public interface IRepository<T>
	{
		public ValueTask<T?> GetById(int id);
	}
}

