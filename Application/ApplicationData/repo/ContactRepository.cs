using ApplicationData.model;
using System.Linq;

namespace ApplicationData.repo
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
