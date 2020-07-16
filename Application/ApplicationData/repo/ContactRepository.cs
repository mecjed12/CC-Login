using ApplicationData.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationData.repo
{
	public class ContactRepository : Repository<Contact>
	{
		public ContactRepository(DcvEntities entities) : base(entities)
		{
		}

		//TODO create check
		public override Contact GetOne(Contact contact)
		{
			return Entities.Contacts.FirstOrDefault(x => x.ContactValue == contact.ContactValue);
		}
	}
}
