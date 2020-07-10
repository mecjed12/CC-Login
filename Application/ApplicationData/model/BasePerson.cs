using System;

namespace ApplicationData.model
{
	public class BasePerson : CreatedModify
	{
		public int Id { get; set; }

		[ApplicationProperty("Vorname")]
		public string Name1 { get; set; }

		[ApplicationProperty("Zuname")]
		public string Name2 { get; set; }

		[ApplicationProperty("Geburtsdatum")]
		public DateTime? Date { get; set; }

	}
}
