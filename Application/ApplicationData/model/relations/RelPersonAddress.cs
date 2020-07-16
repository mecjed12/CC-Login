using ApplicationData.attribute;
using ApplicationData.enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace ApplicationData.model
{
	[Relation]
	[Table("addressperson")]
	public class RelPersonAddress
	{
		public int Id { get; set; }

		[Relation(Relation = typeof(Address))]
		public int AddressId { get; set; }

		[Relation(Relation = typeof(Person))]
		public int PersonId { get; set; }

		[Column("contact_type")]
		public EContactType? ContactType { get; set; }

		[Column("billing_address")]
		public bool BillingAdress { get; set; }

		[Relation]
		public Address Address { get; set; }

		[Relation]
		public Person Person { get; set; }

		public List<PropertyInfo> GetProperties()
		{
			return Address.GetProperties();
		}
	}
}
