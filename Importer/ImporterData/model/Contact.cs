using ImporterData.enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImporterData.model
{
	[Table("contact")]
	public class Contact : CreatedModified
	{
		[Column("person_id")]
		public int PersonId { get; set; }

		[Column("art_of_communication")]
		public EKindOfCommunication ArtOfCommunication { get; set; }

		[Column("contact_value")]
		public string ContactValue { get; set; }

		[Column("contact_type")]
		public EContactType ContactType { get; set; }

		[Column("main_contact")]
		public bool MainContact { get; set; } = false; // Set Default

		public Person Person { get; set; }
	}
}
