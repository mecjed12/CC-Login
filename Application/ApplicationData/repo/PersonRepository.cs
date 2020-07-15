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

		public override Person Exists(Person person)
		{
			return Entities.People.FirstOrDefault(x => x.Name1 == person.Name1 && x.Name2 == person.Name2 && x.Date == person.Date);
		}
	}
}
