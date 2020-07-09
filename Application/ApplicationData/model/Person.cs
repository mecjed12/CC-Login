using ApplicationData;
using ApplicationData.enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace ApplicationData.model
{

	[Table("person")]
	public class Person : BasePerson, IApplicationClass
	{
		[ApplicationProperty]
		public string Title { get; set; }

		[ApplicationProperty]
		[Column("sv_nr")]
		public double? SVNumber { get; set; }

		[ApplicationProperty]
		public string Gender { get; set; }

		public string Busy { get; set; }

		[Column("busy_by")]
		public string BusyAt { get; set; }

		//Base64
		public string Picture { get; set; }

		public EFunction? Function { get; set; }

		[Column("aktiv")]
		public bool Active { get; set; }

		[Column("deleted_inaktiv")]
		public bool DeletedInactive { get; set; }

		[Column("newsletter_flag")]
		public bool NewsletterFlag { get; set; }


		public List<RelPersonAddress> PAddress { get; set; }

		public List<Contact> Contacts { get; set; }


		public List<PropertyInfo> GetProperties()
		{
			//TODO find out how to make it only add CreatedAt ones
			var PersonProps = GetType().GetProperties().Where(p => p.IsDefined(typeof(ApplicationProperty), true)).ToList();
			PersonProps.AddRange(new Address().GetProperties());
			PersonProps.AddRange(new Contact().GetProperties());
			return PersonProps;
		}
	}
}
