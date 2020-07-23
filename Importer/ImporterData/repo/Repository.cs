using System.Collections.Generic;
using System.Linq;

namespace ImporterData.repo
{
	public abstract class Repository<T> where T : class
	{

		protected readonly DcvEntities Entities;

		public Repository(DcvEntities entities)
		{
			Entities = entities;
		}

		public Repository<T> GetRepository()
		{
			return this;
		}

		public virtual void Add(T t)
		{
			Entities.Add(t);
			Entities.SaveChanges();
		}

		public virtual List<T> GetAll()
		{
			return Entities.Set<T>().ToList();
		}

		public virtual T Get(T t)
		{
			return Entities.Set<T>().FirstOrDefault(x => x == t);
		}
	}
}
