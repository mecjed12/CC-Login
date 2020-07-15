using ApplicationData.attribute;
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
		[ApplicationProperty(DisplayName = "Titel")]
		public string Title { get; set; }

		[ApplicationProperty(DisplayName = "Sozialversicherungsnummer")]
		[Column("sv_nr")]
		public long? SVNumber { get; set; }

		[ApplicationProperty(DisplayName = "Geschlecht")]
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

		[Relation]
		public List<RelPersonAddress> PAddress { get; set; }

		[Relation]
		public List<Contact> Contacts { get; set; }

		public List<PropertyInfo> GetProperties()
		{
			var PersonProps = GetType().GetProperties().Where(p => p.IsDefined(typeof(ApplicationPropertyAttribute), true)).ToList();
			var SubProps = GetSubclasses();
			SubProps.ForEach(subClass =>
			{
				PersonProps.AddRange(subClass.GetProperties());
			});
			return PersonProps;
		}

		public List<IApplicationSubclass> GetSubclasses()
		{
			return new List<IApplicationSubclass>
			{
				new Address(),
				new Contact()
			};
		}

		public List<PropertyInfo> GetSubclassProperties()
		{
			//return GetType().GetProperties().Where(p => p.IsDefined(typeof(SubclassPropertyAttribute), false)).ToList();
			return new List<PropertyInfo> { };
		} 
	}
}
