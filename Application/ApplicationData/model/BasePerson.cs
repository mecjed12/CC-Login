using ApplicationData.attribute;
using System;

namespace ApplicationData.model
{
	public class BasePerson : CreatedModify
	{
		public int Id { get; set; }

		[ApplicationProperty(DisplayName = "Vorname")]
		public string Name1 { get; set; }
		
		[ApplicationProperty(DisplayName = "Zuname")]
		public string Name2 { get; set; }

		[ApplicationProperty(DisplayName = "Geburtsdatum")]
		public DateTime? Date { get; set; }

	}
}
