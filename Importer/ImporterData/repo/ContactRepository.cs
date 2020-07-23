using ImporterData.model;
using System.Linq;

namespace ImporterData.repo
{
	public class ContactRepository : Repository<Contact>
	{
		public ContactRepository(DcvEntities entities) : base(entities)
		{
		}

		public override Contact GetOne(Contact contact)
		{
			return Entities.Contacts.FirstOrDefault(x => x.ContactValue == contact.ContactValue);
		}
	}
}
