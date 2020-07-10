using System;

namespace ApplicationLogic
{

	//TODO Delete
	[Obsolete]
	public class PersonConfig
	{
		public int? Name1 { get; set; }
		public int Name2 { get; set; }
		public int? Title { get; set; }
		public int? SVNumber { get; set; }
		public int? Date { get; set; }
		public int? Gender { get; set; }
		public int? Active { get; set; }
		public int? DeletedInactive { get; set; }
		public int? NewsletterFlag { get; set; }

		public int? Email { get; set; }
		public int? PhoneNumber { get; set; }

		public int? Street { get; set; }
		public int? Place { get; set; }
		public int? ZipCode { get; set; }
		public int? Country { get; set; }

		//TODO add more if needed
	}
}
