using ImporterData.model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ImporterData.repo
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

		public override Person GetOne(Person person)
		{
			if (person.SVNumber != null)
			{
				return Entities.People.Include(x => x.PAddress).ThenInclude(x => x.Address).Include(x => x.Contacts).FirstOrDefault(x => x.SVNumber == person.SVNumber);
			}

			return Entities.People.Include(x => x.PAddress).ThenInclude(x => x.Address).Include(x => x.Contacts).FirstOrDefault(x => x.Name1 == person.Name1 && x.Name2 == person.Name2 && x.Date == person.Date);
		}
	}
}
