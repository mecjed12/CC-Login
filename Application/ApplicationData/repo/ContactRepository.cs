using ApplicationData.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationData.repo
{
	public class ContactRepository : Repository<Contact>
	{
		public ContactRepository(DcvEntities entities) : base(entities)
		{
		}

		//TODO create check
		public override Contact Exists(Contact t)
		{
			return base.Exists(t);
		}
	}
}
