using ApplicationData.attribute;
using ApplicationData.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ApplicationData.model
{
	public class Contact : CreatedModify, IApplicationSubclass
	{
		public int Id { get; set; }

		[Relation(Relation = typeof(Person))]
		[Column("person_id")]
		public int PersonId { get; set; }

		[ApplicationProperty]
		[Column("art_of_communication")]
		public EKindOfCommunication ArtOfCommunication { get; set; }

		[ApplicationProperty]
		[Column("contact_value")]
		public string ContactValue { get; set; }

		[Column("contact_type")]
		public EContactType ContactType { get; set; }

		[Column("main_contact")]
		public bool MainContact { get; set; }

		public Person Person { get; set; }

		public List<PropertyInfo> GetProperties()
		{
			return GetType().GetProperties().Where(x => x.IsDefined(typeof(ApplicationPropertyAttribute), false)).ToList();
		}
	}
}
