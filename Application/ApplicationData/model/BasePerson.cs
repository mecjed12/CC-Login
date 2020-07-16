using ApplicationData.attribute;
using System;

namespace ApplicationData.model
{
	public class BasePerson : CreatedModify
	{
		public int Id { get; set; }

		[ApplicationProperty(DisplayName = "Vorname", Required = true)]
		public string Name1 { get; set; }
		
		[ApplicationProperty(DisplayName = "Zuname", Required = true)]
		public string Name2 { get; set; }

		[ApplicationProperty(DisplayName = "Geburtsdatum", Required = true)]
		public DateTime? Date { get; set; }

	}
}
