using ApplicationData.attribute;
using ApplicationData.enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace ApplicationData.model
{
	[Display(Name = "Personen")]
	[Table("person")]//Needed otherwise the name of the DBset is used to find the table
	public class Person : BasePerson, IApplicationClass
	{
		[ApplicationProperty(DisplayName = "Titel", Index = 3)]
		public string Title { get; set; }

		[ApplicationProperty(DisplayName = "Sozialversicherungsnummer", Index = 5)]
		[Column("sv_nr")]
		public long? SVNumber { get; set; }

		[ApplicationProperty(DisplayName = "Geschlecht", Index = 4)]
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

		public List<Contact> Contacts { get; set; }

		[Column("user_id")]
		public int? UserId { get; set; }

		#region Things application needs
		[NotMapped]
		[ApplicationProperty(DisplayName = "E-Mail", Index = 6)]
		public string Email
		{
			get => _email;
			set
			{
				if (Contacts == null) Contacts = new List<Contact>();
				if (Contacts.FirstOrDefault(x => x.ContactValue == value) == null) Contacts.Add(new Contact() { ArtOfCommunication = EKindOfCommunication.Email, ContactValue = value, Person = this });
				_email = value;
			}
		}
		[NotMapped]
		private string _email;

		[NotMapped]
		[ApplicationProperty(DisplayName = "Telefonnummer", Index = 7)]
		public string Phone
		{
			get => _phone;
			set
			{
				if (Contacts == null) Contacts = new List<Contact>();
				if (Contacts.FirstOrDefault(x => x.ContactValue == value) == null) Contacts.Add(new Contact() { ArtOfCommunication = EKindOfCommunication.Telefon, ContactValue = value, Person = this });
				_phone = value;
			}
		}
		[NotMapped]
		private string _phone;

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
			};
		}
		#endregion
	}
}
