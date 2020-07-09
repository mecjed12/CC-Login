using Microsoft.EntityFrameworkCore;
using ApplicationData.model;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationData.repo
{
	public class PersonRepository : Repository<Person>
	{
		public PersonRepository(DcvEntities entities) : base(entities)
		{
		}

		public override List<Person> GetAll()
		{
			return Entities.People.Include(x => x.PAddress).ThenInclude(x => x.Address).Include(x => x.Contacts).ToList();
		}
	}
}
