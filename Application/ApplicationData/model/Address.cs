using ApplicationData;
using ApplicationData.enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace ApplicationData.model
{
	public class Address : CreatedModify, IApplicationSubclass
	{
		public int Id { get; set; }

		[ApplicationProperty("Strasse")]
		public string Street { get; set; }

		[ApplicationProperty("Ort")]
		public string Place { get; set; }

		[ApplicationProperty("Postleitzahl")]
		[Column("zip")]
		public int? ZipCode { get; set; }

		[ApplicationProperty("Land")]
		public string Country { get; set; }

		[Column("contact_type")]
		public EContactType? ContactType { get; set; }

		[Column("billing_address")]
		public bool? BillingAdress { get; set; }

		public List<RelPersonAddress> PAddress { get; set; }

		public List<PropertyInfo> GetProperties()
		{
			return GetType().GetProperties().Where(x => x.IsDefined(typeof(ApplicationProperty), false)).ToList();
		}
	}
}
